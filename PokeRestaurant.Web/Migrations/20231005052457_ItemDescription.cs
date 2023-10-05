using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeRestaurant.Web.Migrations
{
    /// <inheritdoc />
    public partial class ItemDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "PokeRestaurant",
                table: "MenuItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "PokeRestaurant",
                table: "MenuItems");
        }
    }
}
