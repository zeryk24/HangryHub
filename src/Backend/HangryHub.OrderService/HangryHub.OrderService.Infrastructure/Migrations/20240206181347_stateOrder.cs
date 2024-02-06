using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HangryHub.OrderService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class stateOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderAccepted_Date",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderAccepted_IsAccepted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderDeclined_Date",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderDeclined_IsDeclined",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderReady_Date",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderReady_IsReady",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderAccepted_Date",
                table: "Orders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OrderAccepted_IsAccepted",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDeclined_Date",
                table: "Orders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OrderDeclined_IsDeclined",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderReady_Date",
                table: "Orders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OrderReady_IsReady",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
