using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace StaticLabs.TasksApp.Api.Exceptions;

public static class ExceptionExtensions
{
    public static ProblemDetails ToProblemDetails(this RequiredResourceDoesNotExistException exception)
    {
        return new ProblemDetails
        {
            Title = nameof(RequiredResourceDoesNotExistException),
            Status = (int)HttpStatusCode.NotFound
        };
    }
}