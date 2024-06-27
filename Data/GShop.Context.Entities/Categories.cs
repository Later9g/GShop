namespace GShop.Context.Entities;

public class Category : BaseEntity
{
    public string Title { get; set; }
    public virtual ICollection<Gadget>? Gadgets { get; set; }
}
