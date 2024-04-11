using Janjao.Template.Api;
using Janjao.Template.Application;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

//Add Layers
builder.Services.AddApiLayer();
builder.Services.AddApplicationLayer();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

//Use Layers
app.UseApiLayer();

app.UseHttpsRedirection();
app.Run();