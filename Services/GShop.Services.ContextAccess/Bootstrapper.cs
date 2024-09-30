namespace GShop.Services.ContextAccess;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddContextAccessService(this IServiceCollection services)
    {
        services.AddScoped<IContextAccess, ContextAccess>();  

        return services;
    }
}
