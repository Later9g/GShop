﻿namespace GShop.Context.Entities;

public class Review :BaseEntity
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; } 

    public Guid GadgetId { get; set; }
    public virtual Gadget Gadget { get; set; } 

    public int Rating { get; set; }
    public string? Comment { get; set; } 
}
