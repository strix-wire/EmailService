using Microsoft.AspNetCore.Mvc;

namespace EmailService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmailController : Controller
    {
        private readonly ILogger<EmailController> _logger;

        [HttpPost]
        public string Post()
        {
            return "Test";
        }

        [HttpGet("Test")]
        public string GetTest()
        {
            return "Serivce running";
        }
    }
}
