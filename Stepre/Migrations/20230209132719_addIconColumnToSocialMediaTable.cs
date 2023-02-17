using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stepre.Migrations
{
    public partial class addIconColumnToSocialMediaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "SocialMedias");
        }
    }
}
