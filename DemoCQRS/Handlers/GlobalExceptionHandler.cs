using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DemoCQRS.Handlers;

public class GlobalExceptionHandler(
    IProblemDetailsService problemDetailsService)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        var execDetails = exception switch
        {
            InvalidDataException =>
            (Detail: exception.Message, StatusCode: StatusCodes.Status400BadRequest),
            _ =>
            (Detail: exception.Message, StatusCode: StatusCodes.Status500InternalServerError)
        };

        httpContext.Response.StatusCode = execDetails.StatusCode;
        return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = new ProblemDetails
            {
                Status = execDetails.StatusCode,
                Title = "An error occurred",
                Type = exception.GetType().Name,
                Detail = exception.Message
            }
        });
    }
}
