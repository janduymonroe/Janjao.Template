using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Janjao.Template.Api.Middleware;

public sealed class ExceptionGlobalHandler(ILogger<ExceptionGlobalHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        var problemDetails = new ProblemDetails
        {
            Title = "Erro interno no servidor",
            Status = StatusCodes.Status500InternalServerError,
            Detail = "Ocorreu um erro interno no servidor",
            Instance = context.TraceIdentifier
        };

        context.Response.StatusCode = problemDetails.Status.Value;
        context.Response.ContentType = "application/problem+json";

        await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}