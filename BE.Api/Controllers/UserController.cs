using BE.Application.Services.Users.Commands.Requests;
using BE.Application.Services.Users.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BE.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] UserPageListRequest request)
        {
            var res = await mediator.Send(request);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(InsertUserCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
    }
}
