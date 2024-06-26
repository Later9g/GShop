namespace GShop.Context.Entities;

public class User : BaseEntity
{
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string Address { get; set; } = default!;
    public int Age { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public virtual ICollection<Gadget> CreatedGadgets { get; set;} = default!;
    public virtual ICollection<Gadget> LikedGadgets { get; set;} = default!;
    public virtual ICollection<Review> Reviews { get; set;} = default!;
    public virtual ICollection<Order> Orders { get; set;} = default!;

}


//email adress phone liked_gadgets created_gadgets reviews reviewed_gadgets