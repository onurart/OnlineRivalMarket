using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineRivalMarket.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class entityCampaingDuzenleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaing_Competitors_CompetitorsId",
                table: "Campaing");

            migrationBuilder.DropIndex(
                name: "IX_Campaing_CompetitorsId",
                table: "Campaing");

            migrationBuilder.AlterColumn<string>(
                name: "CompetitorsId",
                table: "Campaing",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompetitorsesId",
                table: "Campaing",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campaing_CompetitorsesId",
                table: "Campaing",
                column: "CompetitorsesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaing_Competitors_CompetitorsesId",
                table: "Campaing",
                column: "CompetitorsesId",
                principalTable: "Competitors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaing_Competitors_CompetitorsesId",
                table: "Campaing");

            migrationBuilder.DropIndex(
                name: "IX_Campaing_CompetitorsesId",
                table: "Campaing");

            migrationBuilder.DropColumn(
                name: "CompetitorsesId",
                table: "Campaing");

            migrationBuilder.AlterColumn<string>(
                name: "CompetitorsId",
                table: "Campaing",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campaing_CompetitorsId",
                table: "Campaing",
                column: "CompetitorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaing_Competitors_CompetitorsId",
                table: "Campaing",
                column: "CompetitorsId",
                principalTable: "Competitors",
                principalColumn: "Id");
        }
    }
}
