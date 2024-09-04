using GShop.Services.Actions;

namespace GShop.EmailSender.EmailService;

public class EmailDTO
{
    public string To { get; set; }
    public string Subject { get; set; }
     public string Body { get; set; }
}

public static class EmailModelMapper
{ 

    public static EmailDTO EmailModelToEmailDTO(EmailModel model)
    {
        var emailDTO = new EmailDTO();
            
        emailDTO.To = model.To;
        emailDTO.Subject = model.Subject;
        emailDTO.Body = model.Body;

        return emailDTO;
    }

}
