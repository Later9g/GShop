using GShop.Services.RabbitMq;
using GShop.Services.Logger;
using GShop.EmailSender.EmailService;
using GShop.Services.Settings;

namespace GShop.EmailSender;
public static class Bootstrapper
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services
            .AddEmailSettings()
            .AddAppLogger()
            .AddRabbitMq()
            ;

        services.AddSingleton<IMailService, MailService>();

        return services;
    }
}