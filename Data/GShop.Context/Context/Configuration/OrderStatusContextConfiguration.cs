using GShop.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace GShop.Context
{
    public static class OrderStatusContextConfiguration
    {
        public static void ConfigureOrderStatuses(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<OrderStatus>().ToTable("order_statuses");
            modelBuilder.Entity<OrderStatus>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<OrderStatus>().Property(x => x.Title).HasMaxLength(100);
            modelBuilder.Entity<OrderStatus>().HasMany(x => x.Orders).WithOne(x => x.Status).HasPrincipalKey(x=>x.Id).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
