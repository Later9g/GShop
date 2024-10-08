﻿namespace GShop.Services.Likes;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddLikeService(this IServiceCollection services)
    {
        services.AddScoped<ILikeService, LikeService>();  

        return services;
    }
}
