namespace GShop.Context.Entities;

public class Gadget : BaseEntity
{
    public string Name { get; set; } = default!; 
    public int UserId { get; set; }
    public virtual User User { get; set; } = default!;

    public virtual GadgetDetails Details { get; set; } = default!;

    public virtual ICollection<User> Followers { get; set; } = default!;
    public virtual ICollection<Category> Categories { get; set; } = default!;
    public virtual ICollection<GadgetImage> Images { get; set; } = default!;
    public virtual ICollection<OrderGadget> OrderGadgets { get; set; } = default!;
    public virtual ICollection<Review> Reviews { get; set; } = default!;
}

// user_id count(reviews) avg(rating) images description