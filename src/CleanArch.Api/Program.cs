using CleanArch.Api.ExceptionHandling;
using CleanArch.Application;
using CleanArch.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddInfrastructure(configuration);
services.AddApplication();
services.AddExceptionHandler<ValidationExceptionHandler>();
services.AddExceptionHandler<GlobalExceptionHandler>();
services.AddProblemDetails();
services.AddControllers();
services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
