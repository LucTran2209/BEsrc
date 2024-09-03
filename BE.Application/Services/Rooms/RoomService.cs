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
		private readonly IValidator<CreateRoomInputDto> createRoomValidator;
		public RoomService(IUnitOfWork unitOfWork, IValidator<CreateRoomInputDto> createRoomValidator) : base(unitOfWork)
		{
			this.createRoomValidator = createRoomValidator;
		}

		public async Task<ResultService> CreateAsync(CreateRoomInputDto inputDto)
		{
			await createRoomValidator.ValidateAndThrowAsync(inputDto);
			var room = inputDto.ToEntity();
			room.Id = new Guid();

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
	}
}
