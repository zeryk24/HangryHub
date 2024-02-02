using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HangryHub.DeliveryService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Restaurant_Id_Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Restaurant_Contact_VirtualPhone = table.Column<string>(type: "TEXT", nullable: false),
                    Restaurant_Contact_RealPhone = table.Column<string>(type: "TEXT", nullable: false),
                    Restaurant_Location_Address = table.Column<string>(type: "TEXT", nullable: false),
                    Restaurant_Location_Description = table.Column<string>(type: "TEXT", nullable: false),
                    Order_Id_Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Customer_Id_Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Customer_Contact_VirtualPhone = table.Column<string>(type: "TEXT", nullable: false),
                    Customer_Contact_RealPhone = table.Column<string>(type: "TEXT", nullable: false),
                    Customer_DeliveryLocation_Address = table.Column<string>(type: "TEXT", nullable: false),
                    Customer_DeliveryLocation_Note = table.Column<string>(type: "TEXT", nullable: false),
                    Customer_DeliveryLocation_Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Freelencer_Id_Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    Freelencer_TransportType = table.Column<int>(type: "INTEGER", nullable: true),
                    Freelencer_Contact_VirtualPhone = table.Column<string>(type: "TEXT", nullable: true),
                    Freelencer_Contact_RealPhone = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliveries");
        }
    }
}
