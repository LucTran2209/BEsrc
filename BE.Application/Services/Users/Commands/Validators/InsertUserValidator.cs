using BE.Application.Services.Users.Commands.Requests;
using BE.Persistence;
using FluentValidation;

namespace BE.Application.Services.Users.Commands.Validators
{
    public class InsertUserValidator : ValidatorBase<InsertUserCommand>
    {
        public InsertUserValidator(ApplicationDbContext context) : base(context)
        {
            RuleFor(u => u.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber is requierd")
                .MaximumLength(10).WithMessage("Max length 10");
        }


    }
}
