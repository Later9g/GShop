using Microsoft.EntityFrameworkCore;
using GShop.Context.Entities;
using Microsoft.AspNetCore.Identity;

namespace GShop.Context.Context
{
    public static class UserContextConfiguration
    {
        public static void ConfigureUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<IdentityRole<Guid>>().ToTable("user_roles");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("user_role_owners");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("user_role_claims");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");

            modelBuilder.Entity<User>().Property(x => x.UserName).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.UserName).HasMaxLength(15);

            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();
        }
    }
}
