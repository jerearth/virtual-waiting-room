using Entities;
using Entities.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace Database;

public class AppDataSeeder
{
    public static async Task SeedTestData(IServiceProvider serviceProvider)
    {
        var dbContextFactory = serviceProvider.GetRequiredService<
            IDbContextFactory<AppDbContext>
        >()!;

        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

        using var db = dbContextFactory.CreateDbContext();

        if (await userManager.FindByEmailAsync(Constants.TestData.EMAIL) is not null)
            return;

        User user = new User
        {
            Email = Constants.TestData.EMAIL,
            UserName = Constants.TestData.EMAIL,
            EmailConfirmed = true
        };

        await userManager.CreateAsync(user, Constants.TestData.PASSWORD);
    }
}
