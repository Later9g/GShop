using GShop.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace GShop.Context.Context.Configuration;

public static class LikeConfiguration
{
    public static void ConfiugreLikes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Like>().ToTable("likes");
        modelBuilder.Entity<Like>().HasOne(x => x.Gadget).WithMany(x => x.Likes);
        modelBuilder.Entity<Like>().HasOne(x => x.User).WithMany(x => x.Likes);
        modelBuilder.Entity<Like>().HasIndex(x => new { x.UserId, x.GadgetId }).IsUnique();
    }
}
