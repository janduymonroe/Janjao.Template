using System.Reflection;
using Serilog;

namespace Janjao.Template.Api.Settings;

public static class LogSettings
{
    public static void AddLogSettings(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        var logger = new LoggerConfiguration()
            .MinimumLevel.Error()
            .Enrich.WithProperty("Version", Assembly.GetEntryAssembly()!.GetName().Version)
            .Enrich.WithEnvironmentName()
            .Enrich.WithMachineName()
            .Enrich.WithProcessId()
            .Enrich.WithThreadId()
            .Enrich.WithMemoryUsage()
            .Enrich.FromLogContext()
            .CreateLogger();
        
        builder.Logging.AddSerilog(logger);
    }
}