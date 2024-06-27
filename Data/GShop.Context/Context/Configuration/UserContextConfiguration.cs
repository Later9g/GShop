using Microsoft.EntityFrameworkCore;
using GShop.Context.Entities;

namespace GShop.Context.Context
{
    public static class UserContextConfiguration
    {
        public static void ConfigureUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");

            modelBuilder.Entity<User>().Property(x => x.Username).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Username).HasMaxLength(10);

            modelBuilder.Entity<User>().Property(x => x.Username).HasMaxLength(10);

            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();
        }
    }
}
