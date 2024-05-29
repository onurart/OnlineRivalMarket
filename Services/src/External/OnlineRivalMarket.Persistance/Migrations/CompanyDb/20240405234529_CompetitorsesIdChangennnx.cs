using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineRivalMarket.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class CompetitorsesIdChangennnx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaing_Competitors_CompetitorsesId",
                table: "Campaing");

            migrationBuilder.DropColumn(
                name: "CompetitorsId",
                table: "Campaing");

            migrationBuilder.RenameColumn(
                name: "CompetitorsesId",
                table: "Campaing",
                newName: "CompetitorId");

            migrationBuilder.RenameIndex(
                name: "IX_Campaing_CompetitorsesId",
                table: "Campaing",
                newName: "IX_Campaing_CompetitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaing_Competitors_CompetitorId",
                table: "Campaing",
                column: "CompetitorId",
                principalTable: "Competitors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaing_Competitors_CompetitorId",
                table: "Campaing");

            migrationBuilder.RenameColumn(
                name: "CompetitorId",
                table: "Campaing",
                newName: "CompetitorsesId");

            migrationBuilder.RenameIndex(
                name: "IX_Campaing_CompetitorId",
                table: "Campaing",
                newName: "IX_Campaing_CompetitorsesId");

            migrationBuilder.AddColumn<string>(
                name: "CompetitorsId",
                table: "Campaing",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaing_Competitors_CompetitorsesId",
                table: "Campaing",
                column: "CompetitorsesId",
                principalTable: "Competitors",
                principalColumn: "Id");
        }
    }
}
