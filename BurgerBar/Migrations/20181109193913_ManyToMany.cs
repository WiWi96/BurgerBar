using Microsoft.EntityFrameworkCore.Migrations;

namespace BurgerBar.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BurgerIngredient_Product_BurgerId",
                table: "BurgerIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProduct_Order_OrderId",
                table: "OrderedProduct");

            migrationBuilder.AlterColumn<long>(
                name: "OrderId",
                table: "OrderedProduct",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "BurgerId",
                table: "BurgerIngredient",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_BurgerIngredient_Product_BurgerId",
                table: "BurgerIngredient",
                column: "BurgerId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProduct_Order_OrderId",
                table: "OrderedProduct",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BurgerIngredient_Product_BurgerId",
                table: "BurgerIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProduct_Order_OrderId",
                table: "OrderedProduct");

            migrationBuilder.AlterColumn<long>(
                name: "OrderId",
                table: "OrderedProduct",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BurgerId",
                table: "BurgerIngredient",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BurgerIngredient_Product_BurgerId",
                table: "BurgerIngredient",
                column: "BurgerId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProduct_Order_OrderId",
                table: "OrderedProduct",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
