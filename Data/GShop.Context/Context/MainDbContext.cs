namespace GShop.Context;

using GShop.Context.Context;
using GShop.Context.Entities;
using Microsoft.EntityFrameworkCore;

public class MainDbContext : DbContext
{
    public DbSet<User> Users { get; set; }  
    public DbSet<Gadget> Gadgets { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderGadget> OrderGadgets { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<GadgetImage> Images { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<GadgetDetails> GadgetDetails { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }


    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureCategories();
        modelBuilder.ConfigureGadgets();
        modelBuilder.ConfigureGadgetDetails();
        modelBuilder.ConfiugreGadgetImages();
        modelBuilder.ConfigureOrders();
        modelBuilder.ConfigureOrders();
        modelBuilder.ConfigureOrderStatuses();
        modelBuilder.ConfigureReviews();
        modelBuilder.ConfigureUsers();
    }
}
