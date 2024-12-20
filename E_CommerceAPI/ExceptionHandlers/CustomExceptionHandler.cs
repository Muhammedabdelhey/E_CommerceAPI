﻿using E_Commerce.Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace E_Commerce.Application.ExceptionHandlers
{
    public class CustomExceptionHandler : IExceptionHandler
    {
        private readonly Dictionary<Type, Func<HttpContext, Exception, Task>> _exceptionHandlers;

        public CustomExceptionHandler()
        {
            // Register known exception types and handlers.
            _exceptionHandlers = new()
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException },
            };
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var exceptionType = exception.GetType();

            if (_exceptionHandlers.ContainsKey(exceptionType))
            {
                await _exceptionHandlers[exceptionType].Invoke(httpContext, exception);
                return true;
            }
            await HandleUnHandledException(httpContext, exception);
            return true;
        }

        private async Task HandleValidationException(HttpContext httpContext, Exception ex)
        {
            var exception = (ValidationException)ex;

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            await httpContext.Response.WriteAsJsonAsync(new ValidationProblemDetails(exception.Errors)
            {
                Title = exception.Message,
                Status = StatusCodes.Status400BadRequest,
            });
        }

        private async Task HandleNotFoundException(HttpContext httpContext, Exception ex)
        {
            var exception = (NotFoundException)ex;

            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Title = "The specified resource was not found.",
                Detail = exception.Message
            });
        }
        private async Task HandleUnHandledException(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails()
            {
                Status = StatusCodes.Status400BadRequest,
                Title = $"an {ex.GetType()} has occurred",
                Detail = ex.StackTrace,
            });
        }
    }
}
