using GShop.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace GShop.Context
{
    public static class ReviewContextConfiguration
    {
        public static void ConfigureReviews(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().ToTable("reviews");
            modelBuilder.Entity<Review>().Property(x => x.Comment).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Review>().Property(x => x.Rating).IsRequired();
            modelBuilder.Entity<Review>()
                .HasIndex(r => new { r.UserId, r.GadgetId })
                .IsUnique();
            modelBuilder.Entity<Review>()
                 .HasOne(r => r.Gadget)
                 .WithMany(g => g.Reviews)
                 .HasForeignKey(r => r.GadgetId)
                 .HasPrincipalKey(g => g.Uid)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
