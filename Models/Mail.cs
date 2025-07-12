namespace SendMail.Models;

/// <summary>
/// Creates the Mail item
/// </summary>
/// <remarks>
/// This is the object that build the mail object to send.
/// The response will send a subject as string, a body as string
/// to set the E-Mail subject and body.
/// The receivers property will contain a list of addresses
/// to send the E-Mail to.
/// The created property will always be the end of the E-Mail.
/// </remarks>
public class Mail
{
    /// <value>
    /// The Created property represents the date 
    /// when the email is send
    /// <remark>
    /// The <see cref="Created"/> is a <see langword="DateTime"/>
    /// that you use to define the creation Date.
    /// </remark>
    public DateTime Created { get; set; }
    /// <value>
    /// The Receivers property represents a list of string to define
    /// a list of E-Mails
    /// <remark>
    /// The <see cref="Receivers"/> is a <see langword="List<string>"/>
    /// that you use to define a list of E-Mail receivers.
    /// </remark>
    public List<string> Receivers { get; set; } = new List<string>();
    public string Attachments { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
}
