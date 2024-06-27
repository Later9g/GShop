namespace GShop.Services.Gadgets;

public class CreateGadgetModel
{
    public Guid CreatorId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
}
