namespace GShop.Context.Entities;

public class User : BaseEntity
{
    public required string Email { get; set; }
    public string? Phone { get; set; } 
    public string? Address { get; set; } 
    public int? Age { get; set; }
    public required string Username { get; set; } 

    public virtual ICollection<Gadget>? CreatedGadgets { get; set;} 
    public virtual ICollection<Gadget>? LikedGadgets { get; set;}
    public virtual ICollection<Review>? Reviews { get; set;} 
    public virtual ICollection<Order>? Orders { get; set;} 

}


//email adress phone liked_gadgets created_gadgets reviews reviewed_gadgets