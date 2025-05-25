public class MailSettings 
{
    public string? SmtpAddress { get; set; }
    public string? SmtpPassword { get; set;}
    public int SmtpPort { get; set;}
    public bool SSLEnabled { get; set; }
    public string? EmailFrom { get; set; }
}