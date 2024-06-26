namespace GShop.Context.Entities;

public class Category : BaseEntity
{
    public string Title { get; set; } = default!;
    public virtual ICollection<Gadget> Gadgets { get; set; } = default!;
}
