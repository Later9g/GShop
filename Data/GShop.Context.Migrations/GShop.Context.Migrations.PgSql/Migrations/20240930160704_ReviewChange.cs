using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GShop.Context.Migrations.PgSql.Migrations
{
    /// <inheritdoc />
    public partial class ReviewChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_gadgets_GadgetId",
                table: "reviews");

            migrationBuilder.AlterColumn<Guid>(
                name: "GadgetId",
                table: "reviews",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_gadgets_Uid",
                table: "gadgets",
                column: "Uid");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_gadgets_GadgetId",
                table: "reviews",
                column: "GadgetId",
                principalTable: "gadgets",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_gadgets_GadgetId",
                table: "reviews");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_gadgets_Uid",
                table: "gadgets");

            migrationBuilder.AlterColumn<int>(
                name: "GadgetId",
                table: "reviews",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_gadgets_GadgetId",
                table: "reviews",
                column: "GadgetId",
                principalTable: "gadgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
