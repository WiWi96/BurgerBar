using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BurgerBar.Migrations
{
    public partial class AddFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "BottomPicture",
                table: "Bun");

            migrationBuilder.DropColumn(
                name: "TopPicture",
                table: "Bun");

            migrationBuilder.AddColumn<long>(
                name: "PictureId",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BottomPictureId",
                table: "Bun",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TopPictureId",
                table: "Bun",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_PictureId",
                table: "Ingredient",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Bun_BottomPictureId",
                table: "Bun",
                column: "BottomPictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Bun_TopPictureId",
                table: "Bun",
                column: "TopPictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bun_File_BottomPictureId",
                table: "Bun",
                column: "BottomPictureId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bun_File_TopPictureId",
                table: "Bun",
                column: "TopPictureId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_File_PictureId",
                table: "Ingredient",
                column: "PictureId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bun_File_BottomPictureId",
                table: "Bun");

            migrationBuilder.DropForeignKey(
                name: "FK_Bun_File_TopPictureId",
                table: "Bun");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_File_PictureId",
                table: "Ingredient");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_PictureId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Bun_BottomPictureId",
                table: "Bun");

            migrationBuilder.DropIndex(
                name: "IX_Bun_TopPictureId",
                table: "Bun");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "BottomPictureId",
                table: "Bun");

            migrationBuilder.DropColumn(
                name: "TopPictureId",
                table: "Bun");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BottomPicture",
                table: "Bun",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TopPicture",
                table: "Bun",
                nullable: true);
        }
    }
}
