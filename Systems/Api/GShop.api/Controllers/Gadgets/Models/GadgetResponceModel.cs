namespace GShop.api.Controllers;
public class GadgetResponceModel
{
    public Guid Id { get; set; }

    public Guid CreatorId { get; set; }
    public string CreatorName { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public double Rating { get; set; }
    public string Stock {  get; set; }
}
