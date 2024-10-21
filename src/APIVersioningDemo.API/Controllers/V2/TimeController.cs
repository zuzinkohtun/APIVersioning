using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APIVersioningDemo.API.Controllers.V2
{
	[ApiController]
	[ApiVersion(2)]
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
		public async Task<IActionResult> Get(int i)
		{
			string dateTime = DateTimeOffset.Now.ToString() + i;
			await Task.CompletedTask;
			return Ok(dateTime);
		}
	}
}
