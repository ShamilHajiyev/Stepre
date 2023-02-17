using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stepre.Migrations
{
    public partial class updateSocialMediaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialMedia",
                table: "SocialMedia");

            migrationBuilder.RenameTable(
                name: "SocialMedia",
                newName: "SocialMedias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialMedias",
                table: "SocialMedias",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialMedias",
                table: "SocialMedias");

            migrationBuilder.RenameTable(
                name: "SocialMedias",
                newName: "SocialMedia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialMedia",
                table: "SocialMedia",
                column: "Id");
        }
    }
}
