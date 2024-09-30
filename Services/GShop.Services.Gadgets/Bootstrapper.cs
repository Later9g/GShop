using Microsoft.Extensions.DependencyInjection;

namespace GShop.Services.Gadgets;
public static class Bootstrapper
{
    public static IServiceCollection AddGadgetService(this IServiceCollection services)
    {
        return services
            .AddScoped<IGadgetService, GadgetService>();            
    }
}