namespace GShop.EmailSender.EmailService;

using GShop.Services.Actions;
using GShop.Services.Logger;
using GShop.Services.RabbitMq;
using GShop.Services.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Net.Mail;

public class MailService : IMailService
{
    private readonly AppLogger logger;
    private readonly IRabbitMq rabbitMq;
    private readonly EmailSettings settings;

    public MailService(
        AppLogger logger,
        IRabbitMq rabbitMq,
        EmailSettings settings) 
    {
        this.logger = logger;
        this.rabbitMq = rabbitMq;
        this.settings = settings;
    }

    public void SendEmail(EmailDTO request)
    {
        var email = new MimeMessage();

        email.From.Add(MailboxAddress.Parse(settings.EmailUserName));
        email.To.Add(MailboxAddress.Parse(request.To));
        email.Subject = request.Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

        using var smtp = new MailKit.Net.Smtp.SmtpClient();
        smtp.ConnectAsync(settings.EmailHost, settings.Port,SecureSocketOptions.StartTls);
        smtp.AuthenticateAsync(settings.EmailUserName, settings.EmailPassword);
        smtp.SendAsync(email);
        smtp.DisconnectAsync(true);
    }


    public void Start()
    {
        rabbitMq.Subscribe<EmailModel>(QueueNames.SEND_EMAIL, async data =>
        {
            logger.Information($"Sendinbg email to:::{ data.To}");
            var email = EmailModelMapper.EmailModelToEmailDTO(data);
            SendEmail(email);
            logger.Information($"Email was send::: {data.To} | {settings.EmailUserName} | {data.Subject}");
        });
    }

}
