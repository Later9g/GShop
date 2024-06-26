using GShop.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace GShop.Context;

public static class GadgetDetailsConfigurations
{
    public static void ConfigureGadgetDetails(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GadgetDetails>().ToTable("gadget_details");
        modelBuilder.Entity<GadgetDetails>().HasOne(x => x.Gadget).WithOne(x => x.Details).HasPrincipalKey<GadgetDetails>(x=>x.Id);
        modelBuilder.Entity<GadgetDetails>().Property(x=>x.Description).HasMaxLength(300);
        modelBuilder.Entity<GadgetDetails>().Property(x => x.Price).IsRequired();
        modelBuilder.Entity<GadgetDetails>().Property(x=>x.Stock).HasDefaultValue(0);
        modelBuilder.Entity<GadgetDetails>().Property(x=>x.Sales).HasDefaultValue(0);
        modelBuilder.Entity<GadgetDetails>().Property(x=>x.Star).HasDefaultValue(0);
    }
}
