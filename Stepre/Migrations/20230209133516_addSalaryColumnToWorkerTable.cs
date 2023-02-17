using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stepre.Migrations
{
    public partial class addSalaryColumnToWorkerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Workers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Workers");
        }
    }
}
