namespace GShop.Api;

using GShop.Api.Settings;
using GShop.Services.Gadgets;
using GShop.Context.Seeder;
using GShop.Services.Logger;
using GShop.Services.Settings;
using GShop.Services.RabbitMq;
using GShop.Services.Actions;
using GShop.Services.UserAccount;

public static class Bootstrapper
{
    public static IServiceCollection RegisterServices (this IServiceCollection service, IConfiguration configuration = null)
    {
        service
            .AddMainSettings()
            .AddLogSettings()
            .AddSwaggerSettings()
            .AddIdentitySettings()
            .AddAppLogger()
            .AddDbSeeder()
            .AddApiSpecialSettings()
            .AddGadgetService()
            .AddGadgetViewMapper()
            .AddRabbitMq()
            .AddActions()
            .AddUserAccountService()
            ;
            

        return service;
    }
}
