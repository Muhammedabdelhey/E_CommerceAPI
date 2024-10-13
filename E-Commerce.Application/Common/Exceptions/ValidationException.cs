using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(string message) : base(message)
    {
        Errors = new Dictionary<string, string[]>();
    }
    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public ValidationException(IEnumerable<IdentityError> identityErrors)
    : this()
    {
        Errors = identityErrors
            .GroupBy(e => e.Code, e => e.Description)
            .ToDictionary(errorGroup => errorGroup.Key, errorGroup => errorGroup.ToArray());
    }
    public IDictionary<string, string[]> Errors { get; }
}