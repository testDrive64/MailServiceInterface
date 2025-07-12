using Microsoft.AspNetCore.Mvc;
using SendMail;
using SendMail.Models;

namespace MailServiceInterface.Controllers;

[ApiController]
[Route("[controller]")]
public class MailServiceController : ControllerBase
{
    private readonly ILogger<MailServiceController> _logger;

    public MailServiceController(ILogger<MailServiceController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostMail")]
    public IActionResult Post(Mail newMail) 
    {
<<<<<<< HEAD
        MailService service = new MailService(newMail.Receivers, newMail.Subject, newMail.Body, newMail.Attachments);
=======
        MailService service = new MailService(newMail.To, newMail.Subject, newMail.Body);
>>>>>>> 41e62cf97c105b020e43661a26cb70d7630aeb28
        if(service.SendEmail())
            return Ok(newMail);
        else
        return BadRequest();
    }
}
