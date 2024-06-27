using System.ComponentModel.DataAnnotations;

namespace GShop.Context.Entities;

public class GadgetDetails
{
    [Key]
    public int Id { get; set; }
    public virtual  Gadget Gadget { get; set; } 

    public string? Description { get; set; }
    public double Price { get; set; }
    public int Star { get; set; }
    public double Sales { get; set; }
    public int Stock { get; set; }
}

// user_id count(reviews) avg(rating) images description