using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineRivalMarket.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class classClean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Explanation",
                table: "IntelligenceRecord");

            migrationBuilder.DropColumn(
                name: "FieldFeedback",
                table: "IntelligenceRecord");

            migrationBuilder.DropColumn(
                name: "IntelligenceType",
                table: "IntelligenceRecord");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "IntelligenceRecord");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "IntelligenceRecord");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Explanation",
                table: "IntelligenceRecord",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldFeedback",
                table: "IntelligenceRecord",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IntelligenceType",
                table: "IntelligenceRecord",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "IntelligenceRecord",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Region",
                table: "IntelligenceRecord",
                type: "int",
                nullable: true);
        }
    }
}
