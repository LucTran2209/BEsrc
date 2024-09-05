using BE.Application.Abstractions;
using BE.Application.Abstractions.ServiceInterfaces;
using BE.Application.Common.Results;
using BE.Application.Extensions;
using BE.Application.Services.Rooms.RoomServiceInputDto;
using BE.Domain.Abstractions.UnitOfWork;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace BE.Application.Services.Rooms
{
	public class RoomService : BaseService, IRoomService
	{
		//Validator
		private readonly IValidator<CreateRoomInputDto> createRoomValidator;
		private readonly IValidator<UpdateRoomInputDto> updateRoomValidator;

		public RoomService(IUnitOfWork unitOfWork,
						   IValidator<CreateRoomInputDto> createRoomValidator,
						   IValidator<UpdateRoomInputDto> updateRoomValidator)
			: base(unitOfWork)
		{
			this.createRoomValidator = createRoomValidator;
			this.updateRoomValidator = updateRoomValidator;
		}

		public async Task<ResultService> CreateAsync(CreateRoomInputDto inputDto)
		{
			await createRoomValidator.ValidateAndThrowAsync(inputDto);
			var room = inputDto.ToEntity();

			unitOfWork.RoomRepository.Insert(room);
			await unitOfWork.SaveChangesAsync();

			return new ResultService
			{
				StatusCode = HttpStatusCode.Created.ToString(),
				Message = "Success"
			};

		}

		public async Task<ResultService> GetListRoomAsync(GetListRoomInputDto inputDto)
		{
			var rooms = unitOfWork.RoomRepository.GetAll();
			var query = rooms.Filter(inputDto.Search, r => r.RoomName.Contains(inputDto.Search));

			var res = await query.OrderBy(inputDto.OrderBy, inputDto.OrderByDesc)
									.ThenBy(inputDto.ThenBy, inputDto.ThenByDesc)
									.ToPageList(inputDto)
									.ToPageResult(await query.CountAsync(), inputDto, r => RoomExtention.ToDto(r));

			return new ResultService
			{
				StatusCode = HttpStatusCode.OK.ToString(),
				Message = "Success",
				Datas = res
			};
		}

		public async Task<ResultService> UpdateRoomAsync(UpdateRoomInputDto inputDto)
		{
			await updateRoomValidator.ValidateAndThrowAsync(inputDto);

			var room = await unitOfWork.RoomRepository.FindByIdAsync(inputDto.Id);

			if (room == null)
			{
				return new ResultService
				{
					StatusCode = HttpStatusCode.NotFound.ToString(),
					Message = "Room not found"
				};
			}
			room.BuildingId = inputDto.BuildingId;
			room.RoomName = inputDto.RoomName;
			room.RoomType = inputDto.RoomType;
			room.Capacity = inputDto.Capacity;
			room.Floor = inputDto.Floor;
			room.IsAvailable = inputDto.IsAvailable;
			room.Area = inputDto.Area;
			room.Equipment = inputDto.Equipment;
			room.Image = inputDto.Image;
			room.Notes = inputDto.Notes;

			unitOfWork.RoomRepository.Update(room);
			await unitOfWork.SaveChangesAsync();

			return new ResultService
			{
				StatusCode = HttpStatusCode.OK.ToString(),
				Message = "Room updated successfully"
			};

		}

		public async Task<ResultService> DeleteRoomAsync(int id)
		{
			var room = await unitOfWork.RoomRepository.FindByIdAsync(id);

			if (room == null)
			{
				return new ResultService
				{
					StatusCode = HttpStatusCode.NotFound.ToString(),
					Message = "Room not found"
				};
			}

			unitOfWork.RoomRepository.Delete(room);
			await unitOfWork.SaveChangesAsync();

			return new ResultService
			{
				StatusCode = HttpStatusCode.OK.ToString(),
				Message = "Room deleted successfully"
			};
		}
	}
}
