using BE.Application.Services.Rooms.RoomServiceInputDto;
using BE.Application.Services.Rooms.RoomServiceOutputDto;
using BE.Domain.Entities.Rooms;

namespace BE.Application.Services.Rooms
{
	public static class RoomExtention
	{
		public static Room ToEntity(this CreateRoomInputDto command)
		{
			var room = new Room();
			room.RoomName = command.RoomName;
			room.RoomType = command.RoomType;
			room.Capacity = command.Capacity;
			room.Floor = command.Floor;
			room.Area = command.Area;
			room.IsAvailable = command.IsAvailable;
			room.Equipment = command.Equipment;
			room.Image = command.Image;
			room.Notes = command.Notes;
			return room;
		}

		public static GetListRoomOutputDto ToDto(this Room room)
		{
			return new GetListRoomOutputDto
			{
				Id = room.Id,
				RoomName = room.RoomName,
				RoomType = room.RoomType,
				Capacity = room.Capacity,
				Floor = room.Floor,
				Area = room.Area,
				IsAvailable = room.IsAvailable,
				Equipment = room.Equipment,
				Image = room.Image,
				Notes = room.Notes,
			};
		}
	}
}
