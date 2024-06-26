namespace GShop.Context.Entities;

public class Review :BaseEntity
{
    public int UserId { get; set; }
    public virtual User User { get; set; } = default!;

    public int GadgetId { get; set; }
    public virtual Gadget Gadget { get; set; } = default!;

    public int Rating { get; set; }
    public string Comment { get; set; } = default!;
    public bool IsLiked { get; set; }
}


// user_id gadget_id liked comment rating