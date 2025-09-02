using Microsoft.AspNetCore.Mvc;
using RentAPlaceAPI.Services;

namespace RentAPlaceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestEmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public TestEmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet("send")]
        public async Task<IActionResult> SendTestEmail(string to = "amanpoddar775@gmail.com")
        {
            try
            {
                await _emailService.SendEmailAsync(
                    to,
                    "✅ RentAPlace Email Test",
                    "<h3>Hello!</h3><p>This is a test email from <b>RentAPlace</b>.</p>"
                );

                return Ok(new { message = $"Test email sent successfully to {to}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to send test email", error = ex.Message });
            }
        }
    }
}
