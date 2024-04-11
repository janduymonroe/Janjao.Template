using FluentValidation;
using FluentValidation.AspNetCore;
using Janjao.Template.Application.UseCases.PostUseCases.CreatePost;
using Microsoft.Extensions.DependencyInjection;

namespace Janjao.Template.Application;

public static class ApplicationSettings
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation()
            .AddValidatorsFromAssembly(typeof(CreatePostValidator).Assembly);
        
        return services;
    }
    

}