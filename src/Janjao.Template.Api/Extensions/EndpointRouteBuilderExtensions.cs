using Janjao.Template.Api.Endpoints;

namespace Janjao.Template.Api.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpointBase
    {
        TEndpoint.Map(app);
        return app;
    }
}