namespace GShop.Api;

using GShop.Api.Settings;
using GShop.Context.Seeder;
using GShop.Services.Logger;
using GShop.Services.Settings;

public static class Bootstrapper
{
    public static IServiceCollection RegisterServices (this IServiceCollection service, IConfiguration configuration = null)
    {
        service
            .AddMainSettings()
            .AddLogSettings()
            .AddSwaggerSettings()
            .AddAppLogger()
            .AddDbSeeder()
            .AddApiSpecialSettings()
            ;

        return service;
    }
}
