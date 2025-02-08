using EmailSender.Dto;
using EmailSender.Services;

namespace EmailSender.Endpoints;

public static class Mail
{
    public static void MailEndpoints(this WebApplication app)
    {
        app.MapPost("/sendMail", (EmailContent emailContent, IEmailSender emailSender) => {
                emailSender.SendMail(emailContent);
            })
            .WithOpenApi();
    }
}