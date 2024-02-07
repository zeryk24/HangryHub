using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HangryHub.MainService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToSelectedAdditionalIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "SelectedAdditionalIngredients",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "SelectedAdditionalIngredients");
        }
    }
}
