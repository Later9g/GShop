using GShop.Services.UserAccount;

namespace GShop.api.Controllers;

public static class UserDtoMapper
{
    public static RegisterUserAccountModel UserRegisterRequestDtoToRegisterUserAccountModel(UserRegisterRequestDTO request)
    {
        var result = new RegisterUserAccountModel()
        {
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password,
        };
        return result;
    }

    public static UserResponceDTO UserAccountModelToUserResponceDto(UserAccountModel userModel)
    {
        var result = new UserResponceDTO()
        {
            Id = userModel.Id,
            UserName = userModel.UserName,
            Email = userModel.Email,
            PhoneNumber = userModel.PhoneNumber,
        };

        return result;
    }

}
