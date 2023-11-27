using Database;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using System;
using Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

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

app.Run();
