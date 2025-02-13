using MailKit.Net.Smtp;
using MimeKit;
using Serilog.Data;
using ILogger = Serilog.ILogger;

namespace EmailSender.Settings;

public class MessageSender(IConfiguration configuration, ILogger<MessageSender> logger)
{
    public async Task MailSender(MimeMessage message)
    {
        var smtpSettings = new SmtpSettings();
        configuration.GetSection(SmtpSettings.Smtp).Bind(smtpSettings);

        if (string.IsNullOrWhiteSpace(smtpSettings.SmtpHost) || 
            smtpSettings.SmtpPort == 0 ||
            string.IsNullOrWhiteSpace(smtpSettings.EmailAddress) ||
            string.IsNullOrWhiteSpace(smtpSettings.Password))
        {
            smtpSettings.SmtpHost = Environment.GetEnvironmentVariable("SMTPHOST");
            smtpSettings.SmtpPort = Convert.ToInt32(Environment.GetEnvironmentVariable("SMTPPORT"));
            smtpSettings.UseSsl = Convert.ToBoolean(Environment.GetEnvironmentVariable("USESSL"));
            smtpSettings.EmailAddress = Environment.GetEnvironmentVariable("EMAILADDRESS");
            smtpSettings.Password = Environment.GetEnvironmentVariable("PASSWORD");
        }

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
            logger.LogError(e, "Error while connecting to smtp");
            throw;
        }
    }
}