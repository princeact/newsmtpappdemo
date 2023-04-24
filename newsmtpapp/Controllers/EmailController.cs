using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using Org.BouncyCastle.Asn1.Ocsp;

namespace EmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("roderick.casper@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("roderick.casper@ethereal.email"));
            email.Subject = "test smtp";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);

            smtp.Authenticate("roderick.casper@ethereal.email", "CQUwVrcpEdu5Uc4Jza");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();
        }
    }
}