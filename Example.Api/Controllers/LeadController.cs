using Example.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Example.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class LeadController : ControllerBase
	{
		private readonly ILogger<LeadController> _logger;
		private readonly IMediator _mediator;

		public LeadController(ILogger<LeadController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<string> Get()
		{
			string newId = await _mediator.Send(new CreateNewLeadCommand { Name = "Jimmy Johnson" });
			return newId;
		}
	}
}
