using GShop.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace GShop.Context;

public static class GadgetContextConfiguration
{
    public static void ConfigureGadgets(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gadget>().ToTable("gadgets");
        modelBuilder.Entity<Gadget>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<Gadget>().Property(x => x.Name).HasMaxLength(20);
        modelBuilder.Entity<Gadget>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Gadget>().HasOne(x => x.User).WithMany(x => x.CreatedGadgets);
        modelBuilder.Entity<Gadget>().HasMany(x => x.Followers).WithMany(x => x.LikedGadgets);
    }
}
