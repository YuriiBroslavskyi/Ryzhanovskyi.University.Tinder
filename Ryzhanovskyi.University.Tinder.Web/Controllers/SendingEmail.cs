using Microsoft.AspNetCore.Mvc;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using System.Threading.Tasks;

namespace Ryzhanovskyi.University.Tinder.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendingEmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public SendingEmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmailAsync([FromBody] EmailModel model)
        {
            try
            {
                await _emailSender.SendEmailAsync(model.Email, model.Subject, model.Message);
                return Ok("Email sent successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while sending the email: {ex.Message}");
            }
        }
    }
}
