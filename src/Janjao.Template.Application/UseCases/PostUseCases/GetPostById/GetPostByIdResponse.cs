namespace Janjao.Template.Application.UseCases.PostUseCases.GetPostById;

public record GetPostByIdResponse
{
    public required int Id { get; init; }
    public required string Title { get; init; }
    public required string Text { get; init; }
    public required GetPostByIdResponseAuthor Author { get; init; }
}