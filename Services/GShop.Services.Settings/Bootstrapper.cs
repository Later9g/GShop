﻿namespace GShop.Services.Settings;

using GShop.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddMainSettings(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Settings.Load<MainSettings>("Main", configuration);
        services.AddSingleton(settings);

        return services;
    }

    public static IServiceCollection AddSwaggerSettings(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Settings.Load<SwaggerSettings>("Swagger", configuration);
        services.AddSingleton(settings);

        return services;
    }

    public static IServiceCollection AddLogSettings(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Settings.Load<LogSettings>("Log", configuration);
        services.AddSingleton(settings);

        return services;
    }

    public static IServiceCollection AddIdentitySettings(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Settings.Load<IdentitySettings>("Identity", configuration);
        services.AddSingleton(settings);

        return services;
    }

    public static IServiceCollection AddEmailSettings(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Settings.Load<EmailSettings>("Email", configuration);
        services.AddSingleton(settings);

        return services;
    }

}