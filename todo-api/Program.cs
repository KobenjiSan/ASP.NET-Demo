
using src.Services;

// Creates the web application builder, the starting point of every ASP.NET Core app.
// This sets up configuration, logging, and a built-in Dependency Injection (DI) container.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TaskService>();   // Registers service with DI container

builder.Services.AddControllers();              // Adds support for controllers (enables [ApiController] and [Route])         

var app = builder.Build();                      // Builds the web app pipeline; compiles all the settings and services

app.MapControllers();                           // Maps controller endpoints (required for controller-based APIs)

app.MapGet("/", () => "Hello World!");

app.Run();