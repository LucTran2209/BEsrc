using BE.Application.Common.Results;
using BE.Application.Services.Rooms.RoomServiceInputDto;

namespace BE.Application.Abstractions.ServiceInterfaces
{
	public interface IRoomService
	{
		Task<ResultService> CreateAsync(CreateRoomInputDto inputDto);

		Task<ResultService> GetListRoomAsync(GetListRoomInputDto inputDto);

		Task<ResultService> UpdateRoomAsync(UpdateRoomInputDto inputDto);

		Task<ResultService> DeleteRoomAsync(int id); 

	}
}
