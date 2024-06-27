namespace GShop.Services.Gadgets;

public class GadgetModel
{
    public Guid Id { get; set; }

    public Guid CreatorId { get; set; }
    public string CreatorName { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public double Rating { get; set; }

    public IEnumerable<string> Categories { get; set; }
}
