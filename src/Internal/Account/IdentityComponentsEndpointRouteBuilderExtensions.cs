﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Text.Json;

namespace Microsoft.AspNetCore.Routing;

public static class IdentityComponentsEndpointRouteBuilderExtensions
{
    // These endpoints are required by the Identity Razor components defined in the /Components/Account/Pages directory of this project.
    public static IEndpointConventionBuilder MapAdditionalIdentityEndpoints(
        this IEndpointRouteBuilder endpoints
    )
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var accountGroup = endpoints.MapGroup("/account");

        accountGroup.MapPost(
            "/logout",
            async (
                ClaimsPrincipal user,
                SignInManager<User> signInManager,
                [FromForm] string returnUrl
            ) =>
            {
                await signInManager.SignOutAsync();
                return TypedResults.LocalRedirect($"~/{returnUrl}");
            }
        );

        var manageGroup = endpoints.MapGroup("/settings").RequireAuthorization();

        var loggerFactory = endpoints.ServiceProvider.GetRequiredService<ILoggerFactory>();
        var downloadLogger = loggerFactory.CreateLogger("DownloadPersonalData");

        manageGroup.MapPost(
            "/download-personal-data",
            async (
                HttpContext context,
                [FromServices] UserManager<User> userManager,
                [FromServices] AuthenticationStateProvider authenticationStateProvider
            ) =>
            {
                var user = await userManager.GetUserAsync(context.User);
                if (user is null)
                {
                    return Results.NotFound(
                        $"Unable to load user with ID '{userManager.GetUserId(context.User)}'."
                    );
                }

                var userId = await userManager.GetUserIdAsync(user);
                downloadLogger.LogInformation(
                    "User with ID '{UserId}' asked for their personal data.",
                    userId
                );

                // Only include personal data for download
                var personalData = new Dictionary<string, string>();
                var personalDataProps = typeof(User)
                    .GetProperties()
                    .Where(prop => Attribute.IsDefined(prop, typeof(PersonalDataAttribute)));
                foreach (var p in personalDataProps)
                {
                    personalData.Add(p.Name, p.GetValue(user)?.ToString() ?? "null");
                }

                var fileBytes = JsonSerializer.SerializeToUtf8Bytes(personalData);

                context.Response.Headers.TryAdd(
                    "Content-Disposition",
                    "attachment; filename=PersonalData.json"
                );
                return TypedResults.File(
                    fileBytes,
                    contentType: "application/json",
                    fileDownloadName: "PersonalData.json"
                );
            }
        );

        return accountGroup;
    }
}
