using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HangryHub.DeliveryService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDelivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Restaurant_Id1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Restaurant_Contact_VirtualPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Restaurant_Contact_RealPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Restaurant_Location_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Restaurant_Location_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Id1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Customer_Id_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Customer_Contact_VirtualPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Contact_RealPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_DeliveryLocation_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_DeliveryLocation_Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_DeliveryLocation_Type = table.Column<int>(type: "int", nullable: false),
                    Freelencer_Id_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Freelencer_TransportType = table.Column<int>(type: "int", nullable: false),
                    Freelencer_Contact_VirtualPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Freelencer_Contact_RealPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_OrderId_Order_Id1",
                        column: x => x.Order_Id1,
                        principalTable: "OrderId",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliveries_RestaurantId_Restaurant_Id1",
                        column: x => x.Restaurant_Id1,
                        principalTable: "RestaurantId",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_Order_Id1",
                table: "Deliveries",
                column: "Order_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_Restaurant_Id1",
                table: "Deliveries",
                column: "Restaurant_Id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "OrderId");

            migrationBuilder.DropTable(
                name: "RestaurantId");
        }
    }
}
