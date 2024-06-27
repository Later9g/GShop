namespace GShop.Context.Entities;

public class Order : BaseEntity
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public virtual OrderStatus Status { get; set; }
    public string? Note { get; set; } 
    public double Total { get; set; }
    public virtual ICollection<OrderGadget> OrderGadgets { get; set; }
}

//userid gadgetid quantity adress total_price 