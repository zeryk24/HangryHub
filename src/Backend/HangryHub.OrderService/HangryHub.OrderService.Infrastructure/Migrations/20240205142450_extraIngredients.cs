using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HangryHub.OrderService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class extraIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExtraIngredient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name_Name = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity_Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderItemId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraIngredient_OrderItem_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraIngredient_OrderItemId",
                table: "ExtraIngredient",
                column: "OrderItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraIngredient");
        }
    }
}
