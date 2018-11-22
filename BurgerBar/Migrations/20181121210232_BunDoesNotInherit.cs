using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BurgerBar.Migrations
{
    public partial class BunDoesNotInherit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Ingredient_BunId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BottomPicture",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "TopPicture",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Ingredient");

            migrationBuilder.CreateTable(
                name: "Bun",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TopPicture = table.Column<string>(nullable: true),
                    BottomPicture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bun", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Bun_BunId",
                table: "Product",
                column: "BunId",
                principalTable: "Bun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Bun_BunId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Bun");

            migrationBuilder.AddColumn<string>(
                name: "BottomPicture",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TopPicture",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Ingredient",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Ingredient_BunId",
                table: "Product",
                column: "BunId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
