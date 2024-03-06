namespace Janjao.Template.Api.Endpoints;

public interface IEndpointBase
{
    static abstract void Map(IEndpointRouteBuilder app);
}