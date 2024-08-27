using FluentValidation.Results;
using BE.Infrastructure;
using System.Security.Claims;
using FluentValidation;
using BE.Persistence;

namespace BE.Application;

public class ValidatorBase<T> : AbstractValidator<T> where T : class
{
    protected readonly ApplicationDbContext Context;
    //protected readonly ClaimsPrincipal User;

    public ValidatorBase(ApplicationDbContext context)
    {
        this.Context = context;
       // this.User = principal;
    }

    protected override void RaiseValidationException(ValidationContext<T> context, ValidationResult result)
    {
        throw new ValidationException(result.Errors);
    }
}

