using Janjao.Template.Api.Middleware;
using Janjao.Template.Api.Settings;
using Serilog;

namespace Janjao.Template.Api;

public static class ApiSettings
{
    public static IServiceCollection AddApiLayer(this IServiceCollection services)
    {
        services.AddSwaggerSettings();
        services.AddSerilog();
        services.AddExceptionHandler<ExceptionGlobalHandler>();
        services.AddProblemDetails();
        return services;
    }
    
    public static WebApplication UseApiLayer(this WebApplication app)
    {
        app.UseSwaggerSettings();
        app.UseExceptionHandler();
        return app;
    }
}