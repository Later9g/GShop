using GShop.Context.Entities;

namespace GShop.Services.Gadgets;

public class GadgetModel
{
    public Guid Id { get; set; }

    public Guid CreatorId { get; set; }
    public string CreatorName { get; set; }

    public string Title { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public double Rating { get; set; }

    public IEnumerable<string> Categories { get; set; }
}

static public class GadgetMapper
{
    static public GadgetModel GadgetToGadgetModel(Gadget gadget)
    {
        
        var result = new GadgetModel()
        {
            Id = gadget.Uid,
            Title = gadget.Title,
            CreatorName = gadget.Creator.Username,
            CreatorId = gadget.Creator.Uid,
            Price = gadget.Details.Price,
            Stock = gadget.Details.Stock,
            Rating = gadget.Reviews.Any() ? gadget.Reviews.Average(r => r.Rating) : 0.0,
            Categories = gadget.Categories.Select(s => s.Title)

        };

        return result;
    }
}
