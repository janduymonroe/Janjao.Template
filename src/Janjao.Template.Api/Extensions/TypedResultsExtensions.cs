﻿using Microsoft.AspNetCore.Http.HttpResults;

namespace Janjao.Template.Api.Extensions;

public record ValidationError(string Message);

public static class TypedResultsExtensions
{
    public static BadRequest<ValidationError> ValidationError(this IResultExtensions results, string message)
    {
        return TypedResults.BadRequest(new ValidationError(message));
    }

    public static NotFound<ValidationError> NotFound(this IResultExtensions results, string message)
    {
        return TypedResults.NotFound(new ValidationError(message));
    }
}