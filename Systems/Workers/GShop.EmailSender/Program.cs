using GShop.Services.Settings;
using GShop.Settings;
using GShop.Services.Logger;
using GShop.EmailSender.Configuration;
using GShop.EmailSender;
using GShop.EmailSender.EmailService;

var emailSettings = Settings.Load<EmailSettings>("Email");
var logSettings = Settings.Load<LogSettings>("Log");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddAppLogger(logSettings);

// Configure services
var services = builder.Services;


services.RegisterAppServices();

services.AddHttpContextAccessor();

services.AddAppHealthChecks();


var app = builder.Build();

var logger = app.Services.GetRequiredService<IAppLogger>();


app.UseAppHealthChecks();


logger.Information("Email service has started");

// Start task executor

logger.Information("Try to connect to RabbitMq");

app.Services.GetRequiredService<IMailService>().Start(emailSettings);

logger.Information("RabbitMq connected");


// Run app

logger.Information("Email service is running");

app.Run();

logger.Information("Email service has stopped");
