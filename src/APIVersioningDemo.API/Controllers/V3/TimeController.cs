using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APIVersioningDemo.API.Controllers.V3
{
	[ApiController]
	[ApiVersion(3)]
	[Route("api/v{version:apiVersion}/[controller]")]
	//[Route("api/[controller]")]
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
			string dateTime = DateTimeOffset.Now.ToString() + "MMT";
			await Task.CompletedTask;
			return Ok(dateTime);
		}
	}
}
