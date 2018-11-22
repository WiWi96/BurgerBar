using Microsoft.EntityFrameworkCore.Migrations;

namespace BurgerBar.Migrations
{
    public partial class Number2Code : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Product",
                newName: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Product",
                newName: "Number");
        }
    }
}
