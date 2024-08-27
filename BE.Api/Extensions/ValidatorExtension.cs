using FluentValidation.Results;
using FluentValidation;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BE.Api.Extensions;

public static class ValidatorExtension
{
    public static string ValidationResult(this ValidationException validation)
    {
        var failures = validation.Errors
            .Select(error => new ValidationFailure(error.PropertyName, error.ErrorMessage))
            .ToList();

        JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
        };

        return JsonSerializer.Serialize(new ValidationResult(failures), options);
    }
}
