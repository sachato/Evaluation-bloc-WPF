using Microsoft.EntityFrameworkCore.Migrations;

namespace Evaluation_bloc.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Services_ServiceId",
                table: "Salaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Sites_SiteId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_ServiceId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_SiteId",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Salaries");

            migrationBuilder.AddColumn<int>(
                name: "Service",
                table: "Salaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Site",
                table: "Salaries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Service",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "Site",
                table: "Salaries");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Salaries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiteId",
                table: "Salaries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_ServiceId",
                table: "Salaries",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_SiteId",
                table: "Salaries",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Services_ServiceId",
                table: "Salaries",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Sites_SiteId",
                table: "Salaries",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
