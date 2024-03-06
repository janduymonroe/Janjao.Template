using Janjao.Template.Api.Extensions;
using Janjao.Template.Api.Filter;

namespace Janjao.Template.Api.Endpoints;

public static class Endpoints
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("")
            .WithOpenApi()
            .AddEndpointFilter<RequestLoggingFilter>();

        endpoints.MapGroup("/post")
            .WithTags("Post")
            .MapEndpoint<GetPostById>();
    }
}