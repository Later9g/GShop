namespace GShop.Services.UserAccount;

using FluentValidation;
using GShop.Context.Entities;
using System.Text.RegularExpressions;

public class RegisterUserAccountModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}

public class RegisterUserAccountModelValidator : AbstractValidator<RegisterUserAccountModel>
{
    public RegisterUserAccountModelValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("User name is required.");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Email is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MaximumLength(50).WithMessage("Password is long.");

        RuleFor(x => x.PhoneNumber)
       .Length(11).WithMessage("Phone number must be 11 digits long")
       .Matches(new Regex(@"^8\d{10}$")).WithMessage("Phone number is not valid");
    }
}

static public class RegisterUserAccountMapper
{
    static public UserAccountModel UserToRegisterUserAccountModel(User user)
    {
        var result = new UserAccountModel()
        {
            UserName = user.UserName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
        };

        return result;
    }
}