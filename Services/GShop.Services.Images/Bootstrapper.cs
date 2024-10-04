using Microsoft.Extensions.DependencyInjection;

namespace GShop.Services.Images;

public static class Bootstrapper
{
    public static IServiceCollection AddImageService(this IServiceCollection services)
    {
        return services
            .AddScoped<IImageService, ImageService>();
    }
}
