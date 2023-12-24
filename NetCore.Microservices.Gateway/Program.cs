using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", false, true)
    .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

builder.Services.AddOcelot();

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(policyBuilder =>
{
    policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});

await app.UseOcelot();

app.Run();