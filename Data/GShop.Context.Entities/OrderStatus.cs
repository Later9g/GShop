namespace GShop.Context.Entities;

public class OrderStatus : BaseEntity
{
    public string Title { get; set; } 
    public virtual ICollection<Order> Orders { get; set; } 
}