using BE.Application.Abstractions;
using BE.Application.Services.Rooms.RoomServiceInputDto;
using BE.Persistence;
using FluentValidation;

namespace BE.Application.Services.Rooms.Validators
{
	public class UpdateRoomValidator : ValidatorBase<UpdateRoomInputDto>
	{
		public UpdateRoomValidator(ApplicationDbContext context) : base(context)
		{
			RuleFor(r => r.Id)
				.NotEmpty().WithMessage("Room ID is required"); 

			RuleFor(r => r.RoomName)
				.NotEmpty().WithMessage("RoomName is required"); 

			RuleFor(r => r.RoomType)
				.NotEmpty().WithMessage("RoomType is required");

			RuleFor(r => r.Capacity)
				.GreaterThan(0).WithMessage("Capacity must be greater than 0"); 

			RuleFor(r => r.Floor)
				.GreaterThanOrEqualTo(0).WithMessage("Floor must be 0 or greater"); 

			RuleFor(r => r.Area)
				.GreaterThan(0).WithMessage("Area must be greater than 0"); 

			RuleFor(r => r.Equipment)
				.NotEmpty().WithMessage("Equipment is required"); 

			RuleFor(r => r.IsAvailable)
				.NotNull().WithMessage("Availability status is required");
		}
	}
}
