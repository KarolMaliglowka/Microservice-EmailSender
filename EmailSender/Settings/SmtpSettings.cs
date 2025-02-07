namespace EmailSender.Settings;

public class SmtpSettings
{
    public const string Smtp = "Smtp";
    public string? SmtpHost { get; set; } = string.Empty;
    public int SmtpPort { get; set; }
    public bool UseSsl { get; set; }
    public string? EmailAddress { get; set; } = string.Empty;
    public string? Password { get; set; } = string.Empty;
}