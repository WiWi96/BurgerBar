using Microsoft.EntityFrameworkCore.Migrations;

namespace BurgerBar.Migrations
{
    public partial class Price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IngredientType",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "IngredientType",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "IngredientType",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "IngredientType",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "IngredientType",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Ingredient");

            migrationBuilder.InsertData(
                table: "IngredientType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Meat" },
                    { 2L, "Cheese" },
                    { 3L, "Sauce" },
                    { 4L, "Vegetable" },
                    { 5L, "Spice" }
                });
        }
    }
}
