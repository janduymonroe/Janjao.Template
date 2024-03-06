using FluentValidation;
using Janjao.Template.Api;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
//Add Layers
builder.Services.AddApiLayer();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

//Use Layers
app.UseApiLayer();

app.UseHttpsRedirection();
app.Run();