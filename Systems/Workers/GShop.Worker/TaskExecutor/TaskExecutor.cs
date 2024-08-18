namespace GShop.Worker;

using GShop.Services.RabbitMq;
using System.Threading.Tasks;
using GShop.Services.Actions;
using GShop.Services.Logger;

public class TaskExecutor : ITaskExecutor
{
    private readonly IAppLogger logger;
    private readonly IRabbitMq rabbitMq;

    public TaskExecutor(
        IAppLogger logger,
        IRabbitMq rabbitMq
    )
    {
        this.logger = logger;
        this.rabbitMq = rabbitMq;
    }

    public void Start()
    {
        rabbitMq.Subscribe<PublicateGadgetModel>(QueueNames.PUBLICATE_GADGET, async data =>
        {
            logger.Information($"Starting publication of the gadget::: {data.Id}");

            await Task.Delay(5000);

            logger.Information($"The gadget was publicated::: {data.Id} | {data.Title} | {data.Description} | {data.CreatorName} | {data.CreatorEmail}");
        });
    }
}