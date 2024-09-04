using GShop.Services.Settings;

namespace GShop.EmailSender.EmailService;

public interface IMailService
{
    public void SendEmail(EmailDTO request, EmailSettings settings);
    public void Start(EmailSettings settings);
}
