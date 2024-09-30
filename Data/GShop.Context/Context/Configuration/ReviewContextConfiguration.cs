using GShop.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace GShop.Context
{
    public static class ReviewContextConfiguration
    {
        public static void ConfigureReviews(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().ToTable("reviews");
            modelBuilder.Entity<Review>().HasOne(x=>x.User).WithMany(x => x.Reviews);
            modelBuilder.Entity<Review>().HasOne(x=>x.Gadget).WithMany(x => x.Reviews);
            modelBuilder.Entity<Review>().Property(x => x.Comment).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Review>().Property(x => x.Rating).IsRequired();
            modelBuilder.Entity<Review>()
                .HasIndex(r => new { r.UserId, r.GadgetId })
                .IsUnique();
            modelBuilder.Entity<Review>().HasOne(x => x.Gadget).WithMany(x => x.Reviews).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Review>().HasOne(x => x.User).WithMany(x => x.Reviews).HasPrincipalKey(x=>x.Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
