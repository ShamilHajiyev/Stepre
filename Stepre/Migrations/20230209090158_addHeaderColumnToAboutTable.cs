using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stepre.Migrations
{
    public partial class addHeaderColumnToAboutTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Header",
                table: "Abouts");
        }
    }
}
