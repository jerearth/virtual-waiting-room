using Database;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// Add authorization
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<
    AuthenticationStateProvider,
    IdentityRevalidatingAuthenticationStateProvider
>();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
    })
    .AddIdentityCookies();

builder.Services
    .AddIdentityCore<User>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequiredLength = 6;
        options.Password.RequireDigit = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/landing";
});

builder.Services.AddTransient<IEmailSender>(x => new SendGridEmailSender("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"));
builder.Services.AddSingleton<IEmailSender<User>, IdentityNoOpEmailSender>();

// Setup Database connection
#if DEBUG
builder.Services.AddDbContextFactory<AppDbContext>(
    opts => opts.UseInMemoryDatabase(Constants.APPLICATION_NAME)
);
#else
var connectionString = builder.Configuration.GetConnectionString(Constants.APPLICATION_NAME);
var serverVersion = ServerVersion.AutoDetect(connectionString);
builder.Services.AddDbContextFactory<AppDbContext>(
    opts => opts.UseMySql(connectionString, serverVersion)
);
#endif

var app = builder.Build();

// Migrate Database
using (var scope = app.Services.CreateScope())
{
    var dbContextFactory = scope.ServiceProvider.GetRequiredService<
        IDbContextFactory<AppDbContext>
    >();
    using var dbContext = dbContextFactory.CreateDbContext();

    if (dbContext.Database.IsRelational())
        dbContext.Database.Migrate();

    AppDataSeeder.SeedTestData(scope.ServiceProvider).GetAwaiter().GetResult();
}

app.UseForwardedHeaders(
    new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    }
);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
