namespace GShop.Context.Entities;

public class Gadget : BaseEntity
{
    public required string Title { get; set; } 
    public Guid CreatorId { get; set; }
    public virtual User Creator { get; set; } 

    public virtual GadgetDetails? Details { get; set; }

    public virtual ICollection<User>? Followers { get; set; }
    public virtual ICollection<Category>? Categories { get; set; }
    public virtual ICollection<GadgetImage>? Images { get; set; } 
    public virtual ICollection<OrderGadget>? OrderGadgets { get; set; } 
    public virtual ICollection<Review>? Reviews { get; set; }

    public virtual ICollection<Like>? Likes { get; set; }
}

// user_id count(reviews) avg(rating) images description