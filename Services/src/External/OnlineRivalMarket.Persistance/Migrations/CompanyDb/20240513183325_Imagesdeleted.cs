using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineRivalMarket.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class Imagesdeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "IntelligenceRecord");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "IntelligenceRecord",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
