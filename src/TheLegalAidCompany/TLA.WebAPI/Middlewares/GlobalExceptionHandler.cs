using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TLA.WebAPI.Exceptions;

namespace TLA.WebAPI.Middlewares;

internal sealed class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger
) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Unhandled exception occurred");

        string? traceId = System.Diagnostics.Activity.Current?.TraceId.ToString(); 
        
        if (exception is FunctionalException)
        {
            var problemDetailsFunctionalException = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = exception.GetType().Name,
                Title = "A functional error occurred",
                Detail = exception.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                Extensions = { ["traceId"] = traceId ?? string.Empty }
            };

            httpContext.Response.StatusCode = problemDetailsFunctionalException.Status.Value;

            await httpContext.Response.WriteAsJsonAsync(problemDetailsFunctionalException, cancellationToken).ConfigureAwait(false);

            return true;
        }
        if (exception is TechnicalException)
        {
            var problemDetailsTechnicalException = new ProblemDetails
            {
                Status = StatusCodes.Status503ServiceUnavailable,
                Type = exception.GetType().Name,
                Title = "A technical error occurred",
                Detail = exception.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                Extensions = { ["traceId"] = traceId ?? string.Empty }
            };

            httpContext.Response.StatusCode = problemDetailsTechnicalException.Status.Value;

            await httpContext.Response.WriteAsJsonAsync(problemDetailsTechnicalException, cancellationToken).ConfigureAwait(false);

            return true;
        }

        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status510NotExtended,
            Type = "Exception",
            Title = "An unexpected error occurred",
            Detail = "Something went wrong",
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken).ConfigureAwait(false);

        return true;
    }
}
