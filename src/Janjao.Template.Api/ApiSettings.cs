using Janjao.Template.Api.Endpoints;
using Janjao.Template.Api.Middleware;
using Janjao.Template.Api.Settings;
using Serilog;

namespace Janjao.Template.Api;

public static class ApiSettings
{
    public static IServiceCollection AddApiLayer(this IServiceCollection services)
    {
        services.AddSerilog();
        services.AddProblemDetails();
        services.AddExceptionHandler<ExceptionGlobalHandler>();
        services.AddSwaggerSettings();

        return services;
    }
    
    public static WebApplication UseApiLayer(this WebApplication app)
    {
        app.UseSwaggerSettings();
        app.UseExceptionHandler();
        app.UseSwaggerSettings();
        app.MapEndpoints();

        return app;
    }
}