using GShop.Services.Settings;
using GShop.Settings;
using GShop.Services.Logger;
using GShop.EmailSender.Configuration;
using GShop.EmailSender;
using Microsoft.AspNetCore.Identity.UI.Services;
using GShop.EmailSender.EmailService;

var emailSettings = Settings.Load<EmailSettings>("Email");
var logSettings = Settings.Load<LogSettings>("Log");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddAppLogger(logSettings);

// Configure services
var services = builder.Services;


services.AddHttpContextAccessor();

services.AddAppHealthChecks();

services.RegisterAppServices();


var app = builder.Build();

var logger = app.Services.GetRequiredService<IAppLogger>();


app.UseAppHealthChecks();


logger.Information("Worker has started");

// Start task executor

logger.Information("Try to connect to RabbitMq");

app.Services.GetRequiredService<IMailService>().Start();

logger.Information("RabbitMq connected");


// Run app

logger.Information("Worker started");

app.Run();

logger.Information("Worker has stopped");
