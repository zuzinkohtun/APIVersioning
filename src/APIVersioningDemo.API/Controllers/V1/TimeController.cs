using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APIVersioningDemo.API.Controllers.V1
{
    [ApiController]
    [ApiVersion(1, Deprecated =true)]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public class TimeController : ControllerBase
    {
        private readonly ILogger<TimeController> _logger;

        public TimeController(ILogger<TimeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("GetCurrentDateTime")]
        public async Task<IActionResult> Get()
        {
            string dateTime = DateTime.Now.ToString();
            await Task.CompletedTask;
            return Ok(dateTime);
        }
    }
}
