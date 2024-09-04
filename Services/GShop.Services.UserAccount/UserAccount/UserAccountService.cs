namespace GShop.Services.UserAccount;

using GShop.Common.Exceptions;
using GShop.Common.Validator;
using GShop.Context.Entities;
using GShop.Services.Actions;
using GShop.Services.UserAccount.UserAccount.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class UserAccountService : IUserAccountService
{
    private readonly UserManager<User> userManager;
    private readonly IModelValidator<RegisterUserAccountModel> registerUserAccountModelValidator;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly IAction action;

    public UserAccountService(
        UserManager<User> userManager, 
        IModelValidator<RegisterUserAccountModel> registerUserAccountModelValidator,
        IHttpContextAccessor httpContextAccessor,
        IAction action
    )
    {
        this.userManager = userManager;
        this.registerUserAccountModelValidator = registerUserAccountModelValidator;
        this.httpContextAccessor = httpContextAccessor;
        this.action = action;
    }

    public async Task<User> GetCurrentUser()
    {

        var userClaim = httpContextAccessor.HttpContext?.User;

        var Name = userClaim.FindFirst(ClaimTypes.NameIdentifier).Value;

        var user = await userManager.FindByNameAsync(Name);

        return user;
    }

    public async Task<bool> HasAdmin()
    {
         var admin = await userManager.Users.FirstOrDefaultAsync(x => x.UserName == "admin");
        if ( admin == null ) 
        {
            return false;
        }
        return true;
    }

    public async Task<UserAccountModel> Create(RegisterUserAccountModel model)
    {
        registerUserAccountModelValidator.Check(model);

        // Find user by email
        var user = await userManager.FindByEmailAsync(model.Email);
        if (user != null)
            throw new ProcessException($"User account with email {model.Email} already exist.");

        // Create user account
        user = new User()
        {
            UserName = model.UserName,
            Email = model.Email,
            EmailConfirmed = true, // Так как это учебный проект, то сразу считаем, что почта подтверждена. В реальном проекте, скорее всего, надо будет ее подтвердить через ссылку в письме
            PhoneNumber = model.PhoneNumber,
            PhoneNumberConfirmed = false           
            
            // ... Также здесь есть еще интересные свойства. Посмотрите в документации.
        };

        var result = await userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            throw new ProcessException($"Creating user account is wrong. {string.Join(", ", result.Errors.Select(s => s.Description))}");

        // Returning the created user
        return UserAccountModelMapper.UserToUserAccountModel(user);
    }

    public async Task Update(Guid id, string currentPassword, UpdateUserAccountModel model)
    {
        var user = await userManager.FindByIdAsync(id.ToString());

        if (user == null)
            throw new ProcessException("User not fouhd");

        user.UserName = model.UserName == null? user.UserName : model.UserName;

        var emailToken = await userManager.GenerateChangeEmailTokenAsync(user, model.Email);
        if (model.Email != null)
            await userManager.ChangeEmailAsync(user, model.Email, emailToken);

        var phoneNumberToken = await userManager.GenerateChangePhoneNumberTokenAsync(user, model.PhoneNumber);

        if (model.PhoneNumber != null)
            await userManager.ChangePhoneNumberAsync(user, model.PhoneNumber, phoneNumberToken);

        if (model.Password != null)
            await userManager.ChangePasswordAsync(user, currentPassword, model.Password);
    }

    public async Task<UserAccountModel> GetUser(Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());

        if (user == null) return null;

        var userModel = UserAccountModelMapper.UserToUserAccountModel(user);

        return userModel;
    }

    public async Task Delete()
    {

        var user = await GetCurrentUser();

        await userManager.DeleteAsync(user);
    }

    public async Task ConfirmEmail()
    {
        var user = await GetCurrentUser();

        var token = userManager.GenerateEmailConfirmationTokenAsync(user);

        await action.SendEmail(new EmailModel()
        {
            To = user.Email,
            Subject = "Email confirmation",
            Body = $"Click the following link to confirm your email {token}"
        }) ;

        return;
    }
}
