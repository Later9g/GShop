namespace GShop.Context.Entities;

public class OrderGadget : BaseEntity
{
    public int GadgetId { get; set; }
    public virtual Gadget Gadget { get; set; } = default!;

    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = default!;

    public int Quantity { get; set; } = default!;
    public double Price { get; set; } = default!;
    public int Total { get; set; } = default!;
}
