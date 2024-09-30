using GShop.Api.Controllers;

namespace GShop.Services.Gadgets;
public static class Bootstrapper
{
    public static IServiceCollection AddGadgetViewMapper(this IServiceCollection services)
    {
        return services
            .AddSingleton<IGadgetViewMapper, GadgetViewMapper>();            
    }
}