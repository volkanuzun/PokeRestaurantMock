using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeRestaurant.Web.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCart_Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems",
                schema: "PokeRestaurant");

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                schema: "PokeRestaurant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    DateAddedUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Orders_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "PokeRestaurant",
                        principalTable: "Orders",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartLine",
                schema: "PokeRestaurant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShoppingCartID = table.Column<int>(type: "int", nullable: true),
                    DateAddedUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartLine", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoppingCartLine_ShoppingCarts_ShoppingCartID",
                        column: x => x.ShoppingCartID,
                        principalSchema: "PokeRestaurant",
                        principalTable: "ShoppingCarts",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartLine_ShoppingCartID",
                schema: "PokeRestaurant",
                table: "ShoppingCartLine",
                column: "ShoppingCartID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_OrderID",
                schema: "PokeRestaurant",
                table: "ShoppingCarts",
                column: "OrderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartLine",
                schema: "PokeRestaurant");

            migrationBuilder.DropTable(
                name: "ShoppingCarts",
                schema: "PokeRestaurant");

            migrationBuilder.CreateTable(
                name: "OrderItems",
                schema: "PokeRestaurant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAddedUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "PokeRestaurant",
                        principalTable: "Orders",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderID",
                schema: "PokeRestaurant",
                table: "OrderItems",
                column: "OrderID");
        }
    }
}
