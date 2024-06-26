using GShop.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace GShop.Context
{
    public static class GadgetImageContextConfiguration
    {
        public static void ConfiugreGadgetImages(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GadgetImage>().ToTable("gadget_images");
            modelBuilder.Entity<GadgetImage>().HasOne(x => x.Gadget).WithMany(x => x.Images).HasPrincipalKey(x=>x.Id);
        }
    }
}
