using Microsoft.EntityFrameworkCore.Migrations;

namespace BurgerBar.Migrations
{
    public partial class CreationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreationType",
                table: "Product",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Appetizers" },
                    { 2L, "Soup" },
                    { 3L, "Main courses" },
                    { 4L, "Salads" },
                    { 5L, "Desserts" },
                    { 6L, "Beverages" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.AlterColumn<int>(
                name: "CreationType",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
