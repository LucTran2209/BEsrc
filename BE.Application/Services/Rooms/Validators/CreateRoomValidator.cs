using BE.Application.Abstractions;
using BE.Application.Services.Rooms.RoomServiceInputDto;
using BE.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
