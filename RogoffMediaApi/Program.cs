global using Microsoft.EntityFrameworkCore;
using EntityFrameworkLibrary;
using HealthChecks.UI.Client;
using RogoffMediaApi.StartupConfig;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

builder.AddStandardServices();
builder.AddAuthServices();
builder.AddHealthCheckServices();
builder.AddCustomServices();
builder.AddApiVersioningServices();
builder.AddDatabaseServices();

var app = builder.Build();

app.UseWatchDogExceptionLogger();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts =>
    {
        opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecksUI();

app.Run();
