using GShop.Services.UserAccount.UserAccount.Models;

namespace GShop.Services.UserAccount;

public interface IUserAccountService
{
    Task<bool> HasAdmin();

    /// <summary>
    /// Create user account
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<UserAccountModel> Create(RegisterUserAccountModel model);
    Task<UserAccountModel> GetById(Guid id);
    Task Update(Guid id, string currentPassword, UpdateUserAccountModel model);

    Task Delete(Guid id);



    // .. Также здесь можно разместить методы для изменения данных учетной записи, восстановления и смены пароля, подтверждения электронной почты, установки телефона и его подтверждения и т.д.
    // .. Но это уже на самостоятельно.
    // .. Удачи! Я в вас верю!  :)
}
