using GShop.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace GShop.Context.Context
{
    public static class OrderGadgetContextConfiguration
    {
        public static void ConfigureOrderGadget(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<OrderGadget>().ToTable("order_gadgets");
            modelBuilder.Entity<OrderGadget>().HasOne(x => x.Gadget).WithMany(x => x.OrderGadgets);
            modelBuilder.Entity<OrderGadget>().HasOne(x=>x.Order).WithMany(x=>x.OrderGadgets);
            modelBuilder.Entity<OrderGadget>().Property(x=>x.Quantity).IsRequired();
        }
    }
}
