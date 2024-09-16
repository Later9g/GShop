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
            EmailConfirmed = true,
            PhoneNumber = model.PhoneNumber,
            PhoneNumberConfirmed = true           

        };

        var result = await userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            throw new ProcessException($"Creating user account is wrong. {string.Join(", ", result.Errors.Select(s => s.Description))}");

        // Returning the created user
        return UserAccountModelMapper.UserToUserAccountModel(user);
    }

    public async Task Update(Guid id, UpdateUserAccountModel model)
    {
        var user = await userManager.FindByIdAsync(id.ToString());

        if (user == null)
            throw new ProcessException("User not fouhd");

        if (!string.IsNullOrEmpty(model.UserName) && model.UserName != user.UserName)
        {
            user.UserName = model.UserName;
        }

        if (!string.IsNullOrEmpty(model.Email) && model.Email != user.Email)
        {
            var emailChangeToken = await userManager.GenerateChangeEmailTokenAsync(user, model.Email);
            var resultEmail = await userManager.ChangeEmailAsync(user, model.Email, emailChangeToken);
            if (!resultEmail.Succeeded)
            {
                throw new ProcessException($"Error updating email: {string.Join(", ", resultEmail.Errors.Select(e => e.Description))}");
            }
        }

        if (!string.IsNullOrEmpty(model.PhoneNumber) && model.PhoneNumber != user.PhoneNumber)
        {
            var phoneChangeToken = await userManager.GenerateChangePhoneNumberTokenAsync(user, model.PhoneNumber);
            var resultPhone = await userManager.ChangePhoneNumberAsync(user, model.PhoneNumber, phoneChangeToken);
            if (!resultPhone.Succeeded)
            {
                throw new ProcessException($"Error updating phone number: {string.Join(", ", resultPhone.Errors.Select(e => e.Description))}");
            }
        }

        if (!string.IsNullOrEmpty(model.Password))
        {
            var resultPassword = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.Password);
            if (!resultPassword.Succeeded)
            {
                throw new ProcessException($"Error updating password: {string.Join(", ", resultPassword.Errors.Select(e => e.Description))}");
            }
        }

        var updateResult = await userManager.UpdateAsync(user);

        if (!updateResult.Succeeded)
        {
            throw new ProcessException($"Error updating user account: {string.Join(", ", updateResult.Errors.Select(e => e.Description))}");
        }
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

    public async Task SendEmailConfirmation(string baseUrl)
    {
        var user = await GetCurrentUser();

        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

        var confirmationLink = $"{baseUrl}/Account/ConfirmEmail?userId={user.Id}&token={Uri.EscapeDataString(token)}";

        var email = new EmailModel()
        {
            To = user.Email,
            Subject = "Email confirmation",
            Body = $"Click the following link to confirm your email: {confirmationLink}"
        };

        await action.SendEmail(email) ;

        return;
    }
}
