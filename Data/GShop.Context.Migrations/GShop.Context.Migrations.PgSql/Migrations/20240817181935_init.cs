using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GShop.Context.Migrations.PgSql.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gadget_details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Star = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Sales = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    Stock = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gadget_details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "order_statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    Username = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gadgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gadgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gadgets_gadget_details_Id",
                        column: x => x.Id,
                        principalTable: "gadget_details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gadgets_users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Total = table.Column<double>(type: "double precision", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_order_statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "order_statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "followers",
                columns: table => new
                {
                    FollowersId = table.Column<int>(type: "integer", nullable: false),
                    LikedGadgetsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_followers", x => new { x.FollowersId, x.LikedGadgetsId });
                    table.ForeignKey(
                        name: "FK_followers_gadgets_LikedGadgetsId",
                        column: x => x.LikedGadgetsId,
                        principalTable: "gadgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_followers_users_FollowersId",
                        column: x => x.FollowersId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gadget_categories",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "integer", nullable: false),
                    GadgetsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gadget_categories", x => new { x.CategoriesId, x.GadgetsId });
                    table.ForeignKey(
                        name: "FK_gadget_categories_categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gadget_categories_gadgets_GadgetsId",
                        column: x => x.GadgetsId,
                        principalTable: "gadgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gadget_images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GadgetId = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gadget_images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gadget_images_gadgets_GadgetId",
                        column: x => x.GadgetId,
                        principalTable: "gadgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    GadgetId = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IsLiked = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reviews_gadgets_GadgetId",
                        column: x => x.GadgetId,
                        principalTable: "gadgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reviews_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderGadgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GadgetId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Total = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderGadgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderGadgets_gadgets_GadgetId",
                        column: x => x.GadgetId,
                        principalTable: "gadgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderGadgets_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderGadgets_GadgetId",
                table: "OrderGadgets",
                column: "GadgetId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderGadgets_OrderId",
                table: "OrderGadgets",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderGadgets_Uid",
                table: "OrderGadgets",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_categories_Uid",
                table: "categories",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_followers_LikedGadgetsId",
                table: "followers",
                column: "LikedGadgetsId");

            migrationBuilder.CreateIndex(
                name: "IX_gadget_categories_GadgetsId",
                table: "gadget_categories",
                column: "GadgetsId");

            migrationBuilder.CreateIndex(
                name: "IX_gadget_images_GadgetId",
                table: "gadget_images",
                column: "GadgetId");

            migrationBuilder.CreateIndex(
                name: "IX_gadgets_CreatorId",
                table: "gadgets",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_gadgets_Title",
                table: "gadgets",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_gadgets_Uid",
                table: "gadgets",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_statuses_Uid",
                table: "order_statuses",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_StatusId",
                table: "orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_Uid",
                table: "orders",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_UserId",
                table: "orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_GadgetId",
                table: "reviews",
                column: "GadgetId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_Uid",
                table: "reviews",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reviews_UserId_GadgetId",
                table: "reviews",
                columns: new[] { "UserId", "GadgetId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_Uid",
                table: "users",
                column: "Uid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderGadgets");

            migrationBuilder.DropTable(
                name: "followers");

            migrationBuilder.DropTable(
                name: "gadget_categories");

            migrationBuilder.DropTable(
                name: "gadget_images");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "gadgets");

            migrationBuilder.DropTable(
                name: "order_statuses");

            migrationBuilder.DropTable(
                name: "gadget_details");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
