using BE.Application.Abstractions;
using BE.Application.Services.Rooms.RoomServiceInputDto;
using BE.Persistence;
using FluentValidation;

namespace BE.Application.Services.Rooms.Validators
{
	public class CreateRoomValidator : ValidatorBase<CreateRoomInputDto>
	{
		public CreateRoomValidator(ApplicationDbContext context) : base(context)
		{
			RuleFor(r => r.RoomName)
				.NotEmpty().WithMessage("RoomName is required");
		}
	}
}
