using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineRivalMarket.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class currenyfist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyDolor",
                table: "IntelligenceRecord");

            migrationBuilder.DropColumn(
                name: "CurrencyEuro",
                table: "IntelligenceRecord");

            migrationBuilder.DropColumn(
                name: "CurrencyTl",
                table: "IntelligenceRecord");

            migrationBuilder.DropColumn(
                name: "RakipDolor",
                table: "IntelligenceRecord");

            migrationBuilder.RenameColumn(
                name: "RakipTl",
                table: "IntelligenceRecord",
                newName: "RakipCurrency");

            migrationBuilder.RenameColumn(
                name: "RakipEuro",
                table: "IntelligenceRecord",
                newName: "MCurrency");

            migrationBuilder.AddColumn<string>(
                name: "ForeignCurrencyId",
                table: "IntelligenceRecord",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ForeignCurrency",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignCurrency", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IntelligenceRecord_ForeignCurrencyId",
                table: "IntelligenceRecord",
                column: "ForeignCurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_IntelligenceRecord_ForeignCurrency_ForeignCurrencyId",
                table: "IntelligenceRecord",
                column: "ForeignCurrencyId",
                principalTable: "ForeignCurrency",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntelligenceRecord_ForeignCurrency_ForeignCurrencyId",
                table: "IntelligenceRecord");

            migrationBuilder.DropTable(
                name: "ForeignCurrency");

            migrationBuilder.DropIndex(
                name: "IX_IntelligenceRecord_ForeignCurrencyId",
                table: "IntelligenceRecord");

            migrationBuilder.DropColumn(
                name: "ForeignCurrencyId",
                table: "IntelligenceRecord");

            migrationBuilder.RenameColumn(
                name: "RakipCurrency",
                table: "IntelligenceRecord",
                newName: "RakipTl");

            migrationBuilder.RenameColumn(
                name: "MCurrency",
                table: "IntelligenceRecord",
                newName: "RakipEuro");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyDolor",
                table: "IntelligenceRecord",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyEuro",
                table: "IntelligenceRecord",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyTl",
                table: "IntelligenceRecord",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RakipDolor",
                table: "IntelligenceRecord",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
