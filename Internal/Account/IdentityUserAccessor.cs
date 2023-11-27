namespace Internal.Account;

public sealed class IdentityUserAccessor(
    UserManager<User> userManager,
    IdentityRedirectManager redirectManager
)
{
    public async Task<User> GetRequiredUserAsync(HttpContext context)
    {
        var user = await userManager.GetUserAsync(context.User);

        if (user is null)
        {
            redirectManager.RedirectToWithStatus(
                "account/invalid-user",
                $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.",
                context
            );
        }

        return user;
    }
}
