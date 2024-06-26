﻿// <auto-generated />
using System;
using GShop.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GShop.Context.Migrations.PgSql.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20240626090459_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CategoryGadget", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("integer");

                    b.Property<int>("GadgetsId")
                        .HasColumnType("integer");

                    b.HasKey("CategoriesId", "GadgetsId");

                    b.HasIndex("GadgetsId");

                    b.ToTable("gadget_categories", (string)null);
                });

            modelBuilder.Entity("GShop.Context.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("GShop.Context.Entities.Gadget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("gadgets", (string)null);
                });

            modelBuilder.Entity("GShop.Context.Entities.GadgetDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<double>("Sales")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.0);

                    b.Property<int>("Star")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("Stock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("gadget_details", (string)null);
                });

            modelBuilder.Entity("GShop.Context.Entities.GadgetImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GadgetId")
                        .HasColumnType("integer");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.HasIndex("GadgetId");

                    b.ToTable("gadget_images", (string)null);
                });

            modelBuilder.Entity("GShop.Context.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<double>("Total")
                        .HasColumnType("double precision");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("GShop.Context.Entities.OrderGadget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GadgetId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("Total")
                        .HasColumnType("integer");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GadgetId");

                    b.HasIndex("OrderId");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("OrderGadgets");
                });

            modelBuilder.Entity("GShop.Context.Entities.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("order_statuses", (string)null);
                });

            modelBuilder.Entity("GShop.Context.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("GadgetId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsLiked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GadgetId");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.HasIndex("UserId", "GadgetId")
                        .IsUnique();

                    b.ToTable("reviews", (string)null);
                });

            modelBuilder.Entity("GShop.Context.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("GadgetUser", b =>
                {
                    b.Property<int>("FollowersId")
                        .HasColumnType("integer");

                    b.Property<int>("LikedGadgetsId")
                        .HasColumnType("integer");

                    b.HasKey("FollowersId", "LikedGadgetsId");

                    b.HasIndex("LikedGadgetsId");

                    b.ToTable("GadgetUser");
                });

            modelBuilder.Entity("CategoryGadget", b =>
                {
                    b.HasOne("GShop.Context.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GShop.Context.Entities.Gadget", null)
                        .WithMany()
                        .HasForeignKey("GadgetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GShop.Context.Entities.Gadget", b =>
                {
                    b.HasOne("GShop.Context.Entities.GadgetDetails", "Details")
                        .WithOne("Gadget")
                        .HasForeignKey("GShop.Context.Entities.Gadget", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GShop.Context.Entities.User", "User")
                        .WithMany("CreatedGadgets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Details");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GShop.Context.Entities.GadgetImage", b =>
                {
                    b.HasOne("GShop.Context.Entities.Gadget", "Gadget")
                        .WithMany("Images")
                        .HasForeignKey("GadgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gadget");
                });

            modelBuilder.Entity("GShop.Context.Entities.Order", b =>
                {
                    b.HasOne("GShop.Context.Entities.OrderStatus", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GShop.Context.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GShop.Context.Entities.OrderGadget", b =>
                {
                    b.HasOne("GShop.Context.Entities.Gadget", "Gadget")
                        .WithMany("OrderGadgets")
                        .HasForeignKey("GadgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GShop.Context.Entities.Order", "Order")
                        .WithMany("OrderGadgets")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gadget");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("GShop.Context.Entities.Review", b =>
                {
                    b.HasOne("GShop.Context.Entities.Gadget", "Gadget")
                        .WithMany("Reviews")
                        .HasForeignKey("GadgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GShop.Context.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gadget");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GadgetUser", b =>
                {
                    b.HasOne("GShop.Context.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("FollowersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GShop.Context.Entities.Gadget", null)
                        .WithMany()
                        .HasForeignKey("LikedGadgetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GShop.Context.Entities.Gadget", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("OrderGadgets");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("GShop.Context.Entities.GadgetDetails", b =>
                {
                    b.Navigation("Gadget")
                        .IsRequired();
                });

            modelBuilder.Entity("GShop.Context.Entities.Order", b =>
                {
                    b.Navigation("OrderGadgets");
                });

            modelBuilder.Entity("GShop.Context.Entities.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("GShop.Context.Entities.User", b =>
                {
                    b.Navigation("CreatedGadgets");

                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
