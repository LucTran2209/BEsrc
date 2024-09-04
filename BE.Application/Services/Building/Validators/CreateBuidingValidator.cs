using BE.Application.Abstractions;
using BE.Application.Services.Building.BuildingServiceInputDto;
using BE.Persistence;
using FluentValidation;

namespace BE.Application.Services.Building.Validators
{
    public class CreateBuidingValidator : ValidatorBase<CreateBuildingInputDto>
    {
        public CreateBuidingValidator(ApplicationDbContext context) : base(context)
        {
            RuleFor(u => u.ContactNumber)
                .NotEmpty().WithMessage("Contact Number is requierd");
        }
    }
}
