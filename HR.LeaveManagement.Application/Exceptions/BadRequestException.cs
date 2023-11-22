using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {

    }

    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        ValidationError = new();

        foreach (var errors in validationResult.Errors)
        {
            ValidationError.Add(errors.ErrorMessage);
        }
    }

    public List<string> ValidationError { get; set; }
}