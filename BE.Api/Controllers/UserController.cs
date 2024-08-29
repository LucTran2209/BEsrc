using BE.Application.Services.Users.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UserController(IMediator mediator)
		{
			_mediator = mediator;
		}


		//Insert User to Database
		[HttpPost]
		public async Task<IActionResult> InsertUser([FromBody] InsertUserCommand command)
		{
			//if (!ModelState.IsValid)
			//{
			//	return BadRequest(ModelState);
			//}

			var result = await _mediator.Send(command);

			return Ok();
		}
	}
}
