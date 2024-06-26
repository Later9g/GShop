namespace GShop.Context.Entities;

public class Order : BaseEntity
{
    public int UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public virtual OrderStatus Status { get; set; } = default!;
    public string Note { get; set; } = default!; 
    public double Total { get; set; }
    public virtual ICollection<OrderGadget> OrderGadgets { get; set; } = default!;
}

//userid gadgetid quantity adress total_price 