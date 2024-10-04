using FluentValidation;
using GShop.Context;
using GShop.Services.Gadgets;
using Microsoft.EntityFrameworkCore;

namespace GShop.Api.Controllers;

public class CreateGadgetRequestModel
{
    public Guid CreatorId { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
}


public class CreateGadgetRequestModelValidator : AbstractValidator<CreateGadgetRequestModel>
{
    public CreateGadgetRequestModelValidator(IDbContextFactory<MainDbContext> contextFactory)
    {

        //RuleFor(x => x.Title).GadgetTitle();

        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required")
            .MinimumLength(1).WithMessage("Minimum lenght is 1")
            .MaximumLength(100).WithMessage("Maximum lenght is 100");

        RuleFor(x => x.CreatorId)
            .NotEmpty().WithMessage("User is required")
            .Must((id) =>
            {
                using var context = contextFactory.CreateDbContext();
                var found = context.Users.Any(a => a.Id == id);
                return found;
            }).WithMessage("User not found");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Maximum length is 1000");

        RuleFor(x => x.Price).NotEmpty().WithMessage("Price cannot be empty")
            .GreaterThan(0).WithMessage("Price cannot be lower than 0");
    }
}