using FluentValidation;

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
        //RuleFor(x => x.Title).GadgetTitle();

        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required")
            .MinimumLength(1).WithMessage("Minimum lenght is 1")
            .MaximumLength(100).WithMessage("Maximum lenght is 100");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Maximum length is 1000");

        RuleFor(x => x.Price).NotEmpty().WithMessage("Price cannot be empty")
            .GreaterThan(0).WithMessage("Price cannot be less then 0");

        RuleFor(x => x.Stock).GreaterThanOrEqualTo(0).WithMessage("Stock cannot be less then 0");
    }
}