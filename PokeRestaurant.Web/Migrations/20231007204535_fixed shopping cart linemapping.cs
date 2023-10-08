using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeRestaurant.Web.Migrations
{
    /// <inheritdoc />
    public partial class fixedshoppingcartlinemapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShoppingCarts_CartID",
                schema: "PokeRestaurant",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartLine_ShoppingCarts_ShoppingCartID",
                schema: "PokeRestaurant",
                table: "ShoppingCartLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartLine",
                schema: "PokeRestaurant",
                table: "ShoppingCartLine");

            migrationBuilder.RenameTable(
                name: "ShoppingCartLine",
                schema: "PokeRestaurant",
                newName: "ShoppingCartLines",
                newSchema: "PokeRestaurant");

            migrationBuilder.RenameColumn(
                name: "CartID",
                schema: "PokeRestaurant",
                table: "Orders",
                newName: "ShoppingCartID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CartID",
                schema: "PokeRestaurant",
                table: "Orders",
                newName: "IX_Orders_ShoppingCartID");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartLine_ShoppingCartID",
                schema: "PokeRestaurant",
                table: "ShoppingCartLines",
                newName: "IX_ShoppingCartLines_ShoppingCartID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartLines",
                schema: "PokeRestaurant",
                table: "ShoppingCartLines",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShoppingCarts_ShoppingCartID",
                schema: "PokeRestaurant",
                table: "Orders",
                column: "ShoppingCartID",
                principalSchema: "PokeRestaurant",
                principalTable: "ShoppingCarts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartLines_ShoppingCarts_ShoppingCartID",
                schema: "PokeRestaurant",
                table: "ShoppingCartLines",
                column: "ShoppingCartID",
                principalSchema: "PokeRestaurant",
                principalTable: "ShoppingCarts",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShoppingCarts_ShoppingCartID",
                schema: "PokeRestaurant",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartLines_ShoppingCarts_ShoppingCartID",
                schema: "PokeRestaurant",
                table: "ShoppingCartLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartLines",
                schema: "PokeRestaurant",
                table: "ShoppingCartLines");

            migrationBuilder.RenameTable(
                name: "ShoppingCartLines",
                schema: "PokeRestaurant",
                newName: "ShoppingCartLine",
                newSchema: "PokeRestaurant");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartID",
                schema: "PokeRestaurant",
                table: "Orders",
                newName: "CartID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ShoppingCartID",
                schema: "PokeRestaurant",
                table: "Orders",
                newName: "IX_Orders_CartID");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartLines_ShoppingCartID",
                schema: "PokeRestaurant",
                table: "ShoppingCartLine",
                newName: "IX_ShoppingCartLine_ShoppingCartID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartLine",
                schema: "PokeRestaurant",
                table: "ShoppingCartLine",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShoppingCarts_CartID",
                schema: "PokeRestaurant",
                table: "Orders",
                column: "CartID",
                principalSchema: "PokeRestaurant",
                principalTable: "ShoppingCarts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartLine_ShoppingCarts_ShoppingCartID",
                schema: "PokeRestaurant",
                table: "ShoppingCartLine",
                column: "ShoppingCartID",
                principalSchema: "PokeRestaurant",
                principalTable: "ShoppingCarts",
                principalColumn: "ID");
        }
    }
}
