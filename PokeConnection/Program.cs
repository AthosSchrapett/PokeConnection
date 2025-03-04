using PokeConnection.API.Extensions;
using PokeConnection.API.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(map => map.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services
    .AddDbConfigurations(builder.Configuration)
    .AddHttpClientConfigurations()
    .AddServicesConfiguration();

builder.Host
    .AddSerilog()
    .UseSerilog();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<HandleException>();

app.Run();

public partial class Program
{
}
