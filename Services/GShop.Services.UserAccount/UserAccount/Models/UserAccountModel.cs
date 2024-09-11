namespace GShop.Services.UserAccount;

using GShop.Context.Entities;

public class UserAccountModel
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
static public class UserAccountModelMapper
{
    static public User UserAccountModelToUser(UserAccountModel model)
    {
        var result = new User()
        {
            UserName = model.UserName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
        };

        return result;
    }

    static public UserAccountModel UserToUserAccountModel(User user)
    {
        var result = new UserAccountModel()
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
        };

        return result;
    }

}
