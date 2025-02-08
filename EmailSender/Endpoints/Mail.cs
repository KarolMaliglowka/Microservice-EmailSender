using EmailSender.Dto;
using EmailSender.Services;

namespace EmailSender.Endpoints;

public static class MailEndpoints
{
    public static void MapMailEndpoints(this WebApplication app)
    {
        app.MapPost("/sendMail", (EmailContent emailContent, IEmailSender emailSender) => {
                emailSender.SendMail(emailContent);
            })
            .WithOpenApi();
    }
}