using Janjao.Template.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

//Add Layers
builder.Services.AddApiLayer();

var app = builder.Build();

app.UseHttpsRedirection();
app.Run();