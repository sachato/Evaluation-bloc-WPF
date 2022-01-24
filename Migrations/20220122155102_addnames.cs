using Microsoft.EntityFrameworkCore.Migrations;

namespace Evaluation_bloc.Migrations
{
    public partial class addnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceNom",
                table: "Salaries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteNom",
                table: "Salaries",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceNom",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "SiteNom",
                table: "Salaries");
        }
    }
}
