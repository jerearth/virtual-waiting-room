﻿using Microsoft.AspNetCore.Identity.UI.Services;

namespace Internal.Account;

public sealed class IdentityNoOpEmailSender : IEmailSender<User>
{
    private readonly IEmailSender emailSender;

    public IdentityNoOpEmailSender(IEmailSender emailSender)
    {
        this.emailSender = emailSender;

    }

    public Task SendConfirmationLinkAsync(User user, string email, string confirmationLink) =>
        emailSender.SendEmailAsync(
            email,
            "Confirm your email",
            $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>."
        );

    public Task SendPasswordResetLinkAsync(User user, string email, string resetLink) =>
        emailSender.SendEmailAsync(
            email,
            "Reset your password",
            $"Please reset your password by <a href='{resetLink}'>clicking here</a>."
        );

    public Task SendPasswordResetCodeAsync(User user, string email, string resetCode) =>
        emailSender.SendEmailAsync(
            email,
            "Reset your password",
            $"Please reset your password using the following code: {resetCode}"
        );
}
