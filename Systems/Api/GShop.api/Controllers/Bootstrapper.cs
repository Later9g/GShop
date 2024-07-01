using GShop.api.Controllers;

namespace GShop.Services.Gadgets;
public static class Bootstrapper
{
    public static IServiceCollection AddViewService(this IServiceCollection services)
    {
        return services
            .AddSingleton<IGadgetViewService, GadgetViewService>();            
    }
}