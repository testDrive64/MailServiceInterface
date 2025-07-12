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
        MailService service = new MailService(newMail.Receivers, newMail.Subject, newMail.Body, newMail.Attachments);
        if(service.SendEmail())
            return Ok(newMail);
        else
        return BadRequest();
    }
}
