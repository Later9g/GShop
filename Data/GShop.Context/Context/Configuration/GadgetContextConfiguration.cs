using GShop.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace GShop.Context;

public static class GadgetContextConfiguration
{
    public static void ConfigureGadgets(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gadget>().ToTable("gadgets");
        modelBuilder.Entity<Gadget>().Property(x => x.Title).IsRequired();
        modelBuilder.Entity<Gadget>().Property(x => x.Title).HasMaxLength(20);
        modelBuilder.Entity<Gadget>().HasIndex(x => x.Title).IsUnique();
        modelBuilder.Entity<Gadget>().HasOne(x => x.Creator).WithMany(x => x.CreatedGadgets);
        modelBuilder.Entity<Gadget>().HasMany(x => x.Followers).WithMany(x => x.LikedGadgets).UsingEntity(x => x.ToTable("followers"));
    }
}
