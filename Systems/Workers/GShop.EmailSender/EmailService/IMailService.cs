namespace GShop.EmailSender.EmailService;

public interface IMailService
{
    public void SendEmail(EmailDTO request);
    public void Start();
}
