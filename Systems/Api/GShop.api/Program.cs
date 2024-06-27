using GShop.Api;
using GShop.Api.Configuration;
using GShop.Context;
using GShop.Context.Seeder;
using GShop.Services.Logger;
using GShop.Services.Settings;
using GShop.Settings;

var builder = WebApplication.CreateBuilder(args);

var mainSetting = Settings.Load<MainSettings>("Main");
var logSetting = Settings.Load<LogSettings>("Log");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");

builder.AddAppLogger(mainSetting, logSetting);

var services = builder.Services;

services.AddHttpContextAccessor();
services.AddAppDbContext();
services.RegisterServices();
services.AddAppAutoMappers();
services.AddAppValidator();
services.AddAppCors();
services.AddAppControllerAndViews();
services.AddAppHealthChecks();
services.AddAppVersioning();
services.AddAppSwagger(mainSetting,swaggerSettings);

services.RegisterServices(builder.Configuration);
var app = builder.Build();

app.UseAppSwagger();
app.UseAppCors();
app.UseAppControllerAndViews();
app.UseAppHealthChecks();

DbInitializer.Execute(app.Services);
DbSeeder.Execute(app.Services);

app.Run();
