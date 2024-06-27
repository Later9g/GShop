namespace GShop.api.Controllers.Models.Gadets;

public class GadgetResponceModel
{
    public Guid Id { get; set; }

    public string Username { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public double Rating { get; set; }
}
