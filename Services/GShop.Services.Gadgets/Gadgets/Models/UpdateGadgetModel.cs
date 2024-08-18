using FluentValidation;
using GShop.Settings;

namespace GShop.Services.Gadgets;

public class UpdateGadgetModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }

    public IEnumerable<string> categoryTitles { get; set; }
}

public class UpdateGadgetModelValidator : AbstractValidator<UpdateGadgetModel>
{
    public UpdateGadgetModelValidator()
    {
        RuleFor(x => x.Title).GadgetTitle();

        RuleFor(x => x.Description).GadgetDescription();

        RuleFor(x => x.Price).GadgetPrice();

        RuleFor(x => x.Stock).GreaterThanOrEqualTo(0).WithMessage("Stock cannot be less then 0");
    }
}