using BE.Application.Abstractions;
using BE.Application.Services.Building.BuildingServiceInputDto;
using BE.Persistence;
using FluentValidation;

namespace BE.Application.Services.Building.Validators
{
    public class UpdateBuildingValidator : ValidatorBase<UpdateBuildingInputDto>
    {
        public UpdateBuildingValidator(ApplicationDbContext context) : base(context)
        {
            RuleFor(u => u.ContactNumber)
                .NotEmpty().WithMessage("PhoneNumber is requierd")
                .MaximumLength(10).WithMessage("Max length 10");
        }
    }
}
