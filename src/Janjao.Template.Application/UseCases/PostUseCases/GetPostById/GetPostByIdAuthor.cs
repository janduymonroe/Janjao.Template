namespace Janjao.Template.Application.UseCases.PostUseCases.GetPostById;

public record GetPostByIdResponseAuthor
{
    public required int Id { get; init; } 
    public required string Name { get; init; }
}