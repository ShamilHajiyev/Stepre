using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stepre.Migrations
{
    public partial class addQuoteColumnToAboutTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Abouts",
                newName: "TopContent");

            migrationBuilder.AddColumn<string>(
                name: "BottomContent",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Quote",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BottomContent",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Quote",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "TopContent",
                table: "Abouts",
                newName: "Content");
        }
    }
}
