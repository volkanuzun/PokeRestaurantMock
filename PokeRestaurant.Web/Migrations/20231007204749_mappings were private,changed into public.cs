using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeRestaurant.Web.Migrations
{
    /// <inheritdoc />
    public partial class mappingswereprivatechangedintopublic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BaseToppings",
                schema: "PokeRestaurant",
                table: "ShoppingCartLines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProteinToppings",
                schema: "PokeRestaurant",
                table: "ShoppingCartLines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseToppings",
                schema: "PokeRestaurant",
                table: "ShoppingCartLines");

            migrationBuilder.DropColumn(
                name: "ProteinToppings",
                schema: "PokeRestaurant",
                table: "ShoppingCartLines");
        }
    }
}
