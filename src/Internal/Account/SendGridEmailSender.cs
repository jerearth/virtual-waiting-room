using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

public class SendGridEmailSender : IEmailSender
{
    private readonly string apiKey;

    public SendGridEmailSender(string apiKey)
    {
        this.apiKey = apiKey;
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("waitbuddy2@gmail.com", "WaitBuddy");
        var to = new EmailAddress(email);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
        return client.SendEmailAsync(msg);
    }
}
