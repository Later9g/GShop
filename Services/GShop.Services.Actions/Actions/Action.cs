namespace GShop.Services.Actions;

using GShop.Services.RabbitMq;
using System.Threading.Tasks;

public class Action : IAction
{
    private readonly IRabbitMq rabbitMq;

    public Action(IRabbitMq rabbitMq)
    {
        this.rabbitMq = rabbitMq;
    }

    public async Task PublicateGadget(PublicateGadgetModel model)
    {
        await rabbitMq.PushAsync(QueueNames.PUBLICATE_GADGET, model);
    }

    public async Task SendEmail(EmailModel model)
    {
        await rabbitMq.PushAsync(QueueNames.SEND_EMAIL, model);
    }
}
