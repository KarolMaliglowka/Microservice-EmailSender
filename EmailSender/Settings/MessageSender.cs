using MailKit.Net.Smtp;
using MimeKit;

namespace EmailSender.Settings;

public class MessageSender(IConfiguration configuration)
{
    public async Task MailSender(MimeMessage message)
    {
        var smtpSettings = new SmtpSettings();
        configuration.GetSection(SmtpSettings.Smtp).Bind(smtpSettings);

        try
        {
            using var client = new SmtpClient();
            await client.ConnectAsync(smtpSettings.SmtpHost, smtpSettings.SmtpPort, smtpSettings.UseSsl);
            await client.AuthenticateAsync(smtpSettings.EmailAddress, smtpSettings.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}