﻿using System.Reflection;

namespace Janjao.Template.Api.Settings;

public static class SwaggerSettings
{
    public static IServiceCollection AddSwaggerSettings(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new() { Title = "Template", Version = "v1" });
            opt.TagActionsBy(d =>
            {
                return new List<string>() { d.ActionDescriptor.DisplayName! };
            });
        });
        return services;
    }

    public static WebApplication UseSwaggerSettings(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
}