namespace GShop.Context.Entities;

public class Like : BaseEntity
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public int GadgetId { get; set; }

    public virtual Gadget Gadget { get; set; }
}
