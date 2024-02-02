using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HangryHub.OrderService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialSqlite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PriceEuro_Euro = table.Column<double>(type: "REAL", nullable: false),
                    OrderAccepted_IsAccepted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrderAccepted_Date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OrderDeclined_IsDeclined = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrderDeclined_Date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OrderReady_IsReady = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrderReady_Date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OrderState = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
