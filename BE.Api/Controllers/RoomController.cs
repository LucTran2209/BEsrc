using BE.Application.Abstractions.ServiceInterfaces;
using BE.Application.Services.Rooms.RoomServiceInputDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE.Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class RoomController : ControllerBase
	{
		private readonly ILogger<RoomController> logger;
		private readonly IRoomService roomService;

		public RoomController(ILogger<RoomController> logger, IRoomService roomService)
		{
			this.logger = logger;
			this.roomService = roomService;
		}

		[HttpPost]
		public async Task<IActionResult> InsertAsync([FromBody] CreateRoomInputDto inputDto)
		{
			var output = await roomService.CreateAsync(inputDto);
			return Created(output.StatusCode, output);
		}

		[HttpGet]
		public async Task<IActionResult> GetListAsync([FromQuery] GetListRoomInputDto inputDto)
		{
			var output = await roomService.GetListRoomAsync(inputDto);
			return Ok(output);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync([FromBody] UpdateRoomInputDto inputDto)
		{
			var output = await roomService.UpdateRoomAsync(inputDto);

			if (output.StatusCode == "NotFound")
			{
				return NotFound(output);
			}

			return Ok(output);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var output = await roomService.DeleteRoomAsync(id);

			if (output.StatusCode == "NotFound")
			{
				return NotFound(output);
			}

			return Ok(output);
		}
	}
}
