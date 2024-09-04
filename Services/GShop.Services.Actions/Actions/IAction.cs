namespace GShop.Services.Actions;

using System.Threading.Tasks;

public interface IAction
{
    Task PublicateGadget(PublicateGadgetModel model);

    Task SendEmail(EmailModel model);
}
