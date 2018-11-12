using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BurgerBar.Migrations
{
    public partial class IngredientType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Ingredient");

            migrationBuilder.AddColumn<long>(
                name: "TypeId",
                table: "Ingredient",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "IngredientType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientType", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_TypeId",
                table: "Ingredient",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_IngredientType_TypeId",
                table: "Ingredient",
                column: "TypeId",
                principalTable: "IngredientType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_IngredientType_TypeId",
                table: "Ingredient");

            migrationBuilder.DropTable(
                name: "IngredientType");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_TypeId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Ingredient",
                nullable: false,
                defaultValue: 0);
        }
    }
}
