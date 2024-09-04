namespace GShop.EmailSender.EmailService;

using GShop.Services.Actions;
using GShop.Services.Logger;
using GShop.Services.RabbitMq;
using GShop.Services.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
public class MailService : IMailService
{
    private readonly IAppLogger logger;
    private readonly IRabbitMq rabbitMq;

    public MailService(
        IAppLogger logger,
        IRabbitMq rabbitMq)
    {
        this.logger = logger;
        this.rabbitMq = rabbitMq;
    }

    public async void  SendEmail(EmailDTO request,EmailSettings settings)
    {
        var email = new MimeMessage();

        email.From.Add(MailboxAddress.Parse(settings.EmailUserName));
        email.To.Add(MailboxAddress.Parse(request.To));
        email.Subject = request.Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(settings.EmailHost, settings.Port,SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(settings.EmailUserName, settings.EmailPassword);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }


    public void Start(EmailSettings settings)
    {
        rabbitMq.Subscribe<EmailModel>(QueueNames.SEND_EMAIL, async data =>
        {
            logger.Information($"Sendinbg email to:::{ data.To}");
            var email = EmailModelMapper.EmailModelToEmailDTO(data);
            SendEmail(email, settings);
            logger.Information($"Email was send::: {data.To} | {settings.EmailUserName} | {data.Subject}");
        });
    }

}
