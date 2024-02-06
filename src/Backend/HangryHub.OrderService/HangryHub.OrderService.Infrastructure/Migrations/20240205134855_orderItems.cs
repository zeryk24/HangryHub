using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HangryHub.OrderService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class orderItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RestaurantItemId_ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name_Name = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity_Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price_Price = table.Column<double>(type: "REAL", nullable: false),
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");
        }
    }
}
