using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HangryHub.DeliveryService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order_State",
                table: "Deliveries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order_State",
                table: "Deliveries");
        }
    }
}
