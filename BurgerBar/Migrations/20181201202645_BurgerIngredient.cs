using Microsoft.EntityFrameworkCore.Migrations;

namespace BurgerBar.Migrations
{
    public partial class BurgerIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BurgerIngredient_Product_BurgerId",
                table: "BurgerIngredient");

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
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BurgerIngredient_Product_BurgerId",
                table: "BurgerIngredient");

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
        }
    }
}
