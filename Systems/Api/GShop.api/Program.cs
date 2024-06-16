using GShop.Api;
using GShop.Api.Configuration;
using GShop.Services.Logger;
using GShop.Services.Settings;
using GShop.Settings;

var builder = WebApplication.CreateBuilder(args);

var mainSetting = Settings.Load<MainSettings>("Main");
var logSetting = Settings.Load<LogSettings>("Log");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");

builder.AddAppLogger(mainSetting, logSetting);

var services = builder.Services;

services.RegisterServices();
services.AddAppAutoMappers();
services.AddAppValidator();
services.AddAppCors();
services.AddAppControllerAndViews();
services.AddAppHealthChecks();
services.AddAppVersioning();
services.AddAppSwagger(mainSetting,swaggerSettings);

var app = builder.Build();

app.UseAppSwagger();
app.UseAppCors();
app.UseAppControllerAndViews();
app.UseAppHealthChecks();

app.Run();
