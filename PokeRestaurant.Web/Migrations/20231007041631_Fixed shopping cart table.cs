using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeRestaurant.Web.Migrations
{
    /// <inheritdoc />
    public partial class Fixedshoppingcarttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Orders_OrderID",
                schema: "PokeRestaurant",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_OrderID",
                schema: "PokeRestaurant",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "OrderID",
                schema: "PokeRestaurant",
                table: "ShoppingCarts");

            migrationBuilder.AddColumn<int>(
                name: "CartID",
                schema: "PokeRestaurant",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartID",
                schema: "PokeRestaurant",
                table: "Orders",
                column: "CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShoppingCarts_CartID",
                schema: "PokeRestaurant",
                table: "Orders",
                column: "CartID",
                principalSchema: "PokeRestaurant",
                principalTable: "ShoppingCarts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShoppingCarts_CartID",
                schema: "PokeRestaurant",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CartID",
                schema: "PokeRestaurant",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CartID",
                schema: "PokeRestaurant",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                schema: "PokeRestaurant",
                table: "ShoppingCarts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_OrderID",
                schema: "PokeRestaurant",
                table: "ShoppingCarts",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Orders_OrderID",
                schema: "PokeRestaurant",
                table: "ShoppingCarts",
                column: "OrderID",
                principalSchema: "PokeRestaurant",
                principalTable: "Orders",
                principalColumn: "ID");
        }
    }
}
