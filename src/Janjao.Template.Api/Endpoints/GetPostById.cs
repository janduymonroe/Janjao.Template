using Janjao.Template.Api.Extensions;
using Janjao.Template.Application.UseCases.PostUseCases.GetPostById;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Janjao.Template.Api.Endpoints;
public class GetPostById : IEndpointBase
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapGet("/{id}", Handle)
        .WithRequestValidation<GetPostByIdRequest>()
        .WithSummary("Gets a post by id")
        .WithDescription("Gets a post by id");

    public static async Task<Results<Ok<GetPostByIdResponse>, NotFound>> Handle([AsParameters] GetPostByIdRequest request, CancellationToken cancellationToken)
    {
        var GetPostById = new GetPostByIdResponse
        {
            Id = 1,
            Title = "Hello World",
            Text = "Hello World",
            Author = new GetPostByIdResponseAuthor
            {
                Id = 1,
                Name = "Janjao"
            }
        };

        return GetPostById is null
            ? TypedResults.NotFound()
            : TypedResults.Ok(GetPostById);
    }
}