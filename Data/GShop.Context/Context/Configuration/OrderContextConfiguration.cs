using GShop.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace GShop.Context
{
    public static class OrderContextConfiguration
    {
        public static void ConfigureOrders(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().HasOne(x => x.User).WithMany(x => x.Orders);
            modelBuilder.Entity<Order>().Property(x=>x.Note).HasMaxLength(100);
        }
    }
}
