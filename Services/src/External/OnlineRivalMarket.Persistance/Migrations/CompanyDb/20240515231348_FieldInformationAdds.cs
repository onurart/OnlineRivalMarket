using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineRivalMarket.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class FieldInformationAdds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "FieldInformation");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "FieldInformation");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "FieldInformation");

            migrationBuilder.AddColumn<string>(
                name: "CompetitorId",
                table: "FieldInformation",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FieldInformation_CompetitorId",
                table: "FieldInformation",
                column: "CompetitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldInformation_Competitors_CompetitorId",
                table: "FieldInformation",
                column: "CompetitorId",
                principalTable: "Competitors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldInformation_Competitors_CompetitorId",
                table: "FieldInformation");

            migrationBuilder.DropIndex(
                name: "IX_FieldInformation_CompetitorId",
                table: "FieldInformation");

            migrationBuilder.DropColumn(
                name: "CompetitorId",
                table: "FieldInformation");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "FieldInformation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "FieldInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "FieldInformation",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
