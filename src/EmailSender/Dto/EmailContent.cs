namespace EmailSender.Dto;
public class EmailContent
{
    public string? Name { get; set; }
    public List<string>? To { get; set; }
    public List<string>? Cc { get; set; }
    public List<string>? Bcc { get; set; }
    public string? Subject { get; set; }
    public bool BodyIsHtml { get; set; }
    public string? Body { get; set; }
}