namespace GShop.Context.Entities;

public class OrderStatus : BaseEntity
{
    public string Title { get; set; } = default!;
    public virtual ICollection<Order> Orders { get; set; } = default!;
}

// user_id count(reviews) avg(rating) images description