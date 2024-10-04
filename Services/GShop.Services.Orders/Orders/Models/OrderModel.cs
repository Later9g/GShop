namespace GShop.Services.Orders;

public class OrderModel
{
    public int OrderId { get; set; }
    public Guid UserId { get; set; }
    public string Status { get; set; }
    public string? Note { get; set; }
    public double Total { get; set; }
    public List<OrderGadgetModel> Gadgets { get; set; }
}
