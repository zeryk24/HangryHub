using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HangryHub.DeliveryService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixRestaurantAndOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_OrderId_Order_Id1",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_RestaurantId_Restaurant_Id1",
                table: "Deliveries");

            migrationBuilder.DropTable(
                name: "OrderId");

            migrationBuilder.DropTable(
                name: "RestaurantId");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_Order_Id1",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_Restaurant_Id1",
                table: "Deliveries");

            migrationBuilder.RenameColumn(
                name: "Restaurant_Id1",
                table: "Deliveries",
                newName: "Restaurant_Id_Id");

            migrationBuilder.RenameColumn(
                name: "Order_Id1",
                table: "Deliveries",
                newName: "Order_Id_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Restaurant_Id_Id",
                table: "Deliveries",
                newName: "Restaurant_Id1");

            migrationBuilder.RenameColumn(
                name: "Order_Id_Id",
                table: "Deliveries",
                newName: "Order_Id1");

            migrationBuilder.CreateTable(
                name: "OrderId",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantId",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantId", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_Order_Id1",
                table: "Deliveries",
                column: "Order_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_Restaurant_Id1",
                table: "Deliveries",
                column: "Restaurant_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_OrderId_Order_Id1",
                table: "Deliveries",
                column: "Order_Id1",
                principalTable: "OrderId",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_RestaurantId_Restaurant_Id1",
                table: "Deliveries",
                column: "Restaurant_Id1",
                principalTable: "RestaurantId",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
