using FluentValidation;

namespace Janjao.Template.Application.UseCases.PostUseCases.GetPostById;

public class GetPostByIdRequestValidator : AbstractValidator<GetPostByIdRequest>
{
    public GetPostByIdRequestValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}