using GShop.Context.Entities;

namespace GShop.Services.UserAccount.UserAccount.Models;

public class UpdateUserAccountModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
