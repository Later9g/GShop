﻿namespace GShop.Context;

using Microsoft.EntityFrameworkCore;
using GShop.Context.Entities;

public static class CategoriesContextConfiguration
{
    public static void ConfigureCategories(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().ToTable("categories");
        modelBuilder.Entity<Category>().Property(x => x.Title).IsRequired();
        modelBuilder.Entity<Category>().Property(x => x.Title).HasMaxLength(100);
        modelBuilder.Entity<Category>().HasMany(x => x.Gadgets).WithMany(x => x.Categories).UsingEntity(t => t.ToTable("gadget_categories"));
    }
}