using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Janjao.Template.Api.Middleware;

public sealed class BadRequestExceptionHandler(ILogger<BadRequestExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not BadHttpRequestException badRequestException)
        {
            return false;
        }

        logger.LogError(badRequestException, "Exception occurred: {Message}", badRequestException.Message);

        var problemDetails = new ProblemDetails
        {
            Title = "Erro interno no servidor",
            Status = StatusCodes.Status500InternalServerError,
            Detail = "Ocorreu um erro interno no servidor",
            Instance = context.TraceIdentifier
        };

        context.Response.StatusCode = problemDetails.Status.Value;

        await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}