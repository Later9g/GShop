namespace GShop.Services.Settings;

public class EmailSettings
{
    public string EmailHost { get; private set; }
    public string EmailUserName { get; private set;}

    public string EmailPassword { get; private set;}
    public int Port { get; private set;}
}
