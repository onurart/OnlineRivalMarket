using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineRivalMarket.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class CompetitorsesIdChangen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntelligenceRecord_Competitors_CompetitorsesId",
                table: "IntelligenceRecord");

            migrationBuilder.RenameColumn(
                name: "CompetitorsesId",
                table: "IntelligenceRecord",
                newName: "CompetitorId");

            migrationBuilder.RenameIndex(
                name: "IX_IntelligenceRecord_CompetitorsesId",
                table: "IntelligenceRecord",
                newName: "IX_IntelligenceRecord_CompetitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_IntelligenceRecord_Competitors_CompetitorId",
                table: "IntelligenceRecord",
                column: "CompetitorId",
                principalTable: "Competitors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntelligenceRecord_Competitors_CompetitorId",
                table: "IntelligenceRecord");

            migrationBuilder.RenameColumn(
                name: "CompetitorId",
                table: "IntelligenceRecord",
                newName: "CompetitorsesId");

            migrationBuilder.RenameIndex(
                name: "IX_IntelligenceRecord_CompetitorId",
                table: "IntelligenceRecord",
                newName: "IX_IntelligenceRecord_CompetitorsesId");

            migrationBuilder.AddForeignKey(
                name: "FK_IntelligenceRecord_Competitors_CompetitorsesId",
                table: "IntelligenceRecord",
                column: "CompetitorsesId",
                principalTable: "Competitors",
                principalColumn: "Id");
        }
    }
}
