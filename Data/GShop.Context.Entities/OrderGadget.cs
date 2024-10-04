namespace GShop.Context.Entities;

public class OrderGadget : BaseEntity
{
    public int GadgetId { get; set; }
    public virtual Gadget Gadget { get; set; } 

    public int OrderId { get; set; }
    public virtual Order Order { get; set; } 

    public int Quantity { get; set; } = default!;
    public double Price { get; set; } = default!;
    public double Total { get; set; } = default!;
}
