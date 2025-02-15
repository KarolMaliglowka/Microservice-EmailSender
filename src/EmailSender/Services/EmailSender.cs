using EmailSender.Dto;
using EmailSender.Settings;
using MimeKit;

namespace EmailSender.Services;

public interface IEmailSender
{
    Task SendMail(EmailContent emailContent);
}
public class EmailSender(MessageSender messageSender, IConfiguration configuration, ILogger<EmailSender> logger) : IEmailSender
{
    public async Task SendMail(EmailContent mailContent)
    {
        try
        {
            var smtpSettings = new SmtpSettings();
            configuration.GetSection(SmtpSettings.Smtp).Bind(smtpSettings);
        
            var message = new MimeMessage();
            if (string.IsNullOrWhiteSpace(smtpSettings.EmailAddress))
            {
                smtpSettings.EmailAddress = Environment.GetEnvironmentVariable("EMAILADDRESS");
            }

            message.From.Add(new MailboxAddress(mailContent.Name, smtpSettings.EmailAddress));

            if (mailContent.To != null)
            {
                foreach (var to in mailContent.To)
                {
                    message.To.Add(new MailboxAddress(to, to));
                }
            }

            if (mailContent.Cc != null)
            {
                foreach (var cc in mailContent.Cc)
                {
                    message.Cc.Add(new MailboxAddress(cc, cc));
                }
            }

            if (mailContent.Bcc != null)
            {
                foreach (var bcc in mailContent.Bcc)
                {
                    message.Bcc.Add(new MailboxAddress(bcc, bcc));
                }
            }

            message.Subject = mailContent.Subject;
            var textPart = mailContent.BodyIsHtml ? "html" : "plain";
            message.Body = new TextPart(textPart)
            {
                Text = mailContent.Body
            };
            
            await messageSender.MailSender(message);
            logger.LogInformation($"Sent email: {message}.");
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while sending email.");
            throw new Exception("Error while sending email.", e);
        }
    }
}