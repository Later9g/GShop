using FluentValidation;
using GShop.Context;
using GShop.Settings;
using Microsoft.EntityFrameworkCore;

namespace GShop.Services.Gadgets;

public class CreateGadgetModel
{
    public Guid CreatorId { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }


}

public class CreateGadgetModelValidator : AbstractValidator<CreateGadgetModel>
{
    public CreateGadgetModelValidator(IDbContextFactory<MainDbContext> contextFactory)
    {

        RuleFor(x => x.Title).GadgetTitle();

        RuleFor(x => x.CreatorId)
            .NotEmpty().WithMessage("User is required")
            .Must((id) =>
            {
                using var context = contextFactory.CreateDbContext();
                var found = context.Users.Any(a => a.Uid == id);
                return found;
            }).WithMessage("User not found");

        RuleFor(x => x.Description).GadgetDescription();

        RuleFor(x => x.Price).GadgetPrice();
    }
}