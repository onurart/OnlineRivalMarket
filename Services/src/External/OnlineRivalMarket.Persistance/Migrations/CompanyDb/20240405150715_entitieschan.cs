using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineRivalMarket.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class entitieschan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaing_Brand_BrandId",
                table: "Campaing");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaing_Category_CategoryId",
                table: "Campaing");

            migrationBuilder.DropForeignKey(
                name: "FK_IntelligenceRecord_Brand_BrandId",
                table: "IntelligenceRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_IntelligenceRecord_Category_CategoryId",
                table: "IntelligenceRecord");

            migrationBuilder.DropIndex(
                name: "IX_IntelligenceRecord_BrandId",
                table: "IntelligenceRecord");

            migrationBuilder.DropIndex(
                name: "IX_IntelligenceRecord_CategoryId",
                table: "IntelligenceRecord");

            migrationBuilder.DropIndex(
                name: "IX_Campaing_BrandId",
                table: "Campaing");

            migrationBuilder.DropIndex(
                name: "IX_Campaing_CategoryId",
                table: "Campaing");

            migrationBuilder.DropColumn(
                name: "VehicleGroup",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "VehicleType",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "IntelligenceRecord");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "IntelligenceRecord");

            migrationBuilder.DropColumn(
                name: "VehicleGroup",
                table: "IntelligenceRecord");

            migrationBuilder.DropColumn(
                name: "VehicleType",
                table: "IntelligenceRecord");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Campaing");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Campaing");

            migrationBuilder.AddColumn<string>(
                name: "VehicleGroupId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleTypeId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VehicleGroup",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_VehicleGroupId",
                table: "Product",
                column: "VehicleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_VehicleTypeId",
                table: "Product",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_VehicleGroup_VehicleGroupId",
                table: "Product",
                column: "VehicleGroupId",
                principalTable: "VehicleGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_VehicleType_VehicleTypeId",
                table: "Product",
                column: "VehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_VehicleGroup_VehicleGroupId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_VehicleType_VehicleTypeId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "VehicleGroup");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropIndex(
                name: "IX_Product_VehicleGroupId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_VehicleTypeId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "VehicleGroupId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "VehicleGroup",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleType",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrandId",
                table: "IntelligenceRecord",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "IntelligenceRecord",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleGroup",
                table: "IntelligenceRecord",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleType",
                table: "IntelligenceRecord",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrandId",
                table: "Campaing",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Campaing",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IntelligenceRecord_BrandId",
                table: "IntelligenceRecord",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_IntelligenceRecord_CategoryId",
                table: "IntelligenceRecord",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaing_BrandId",
                table: "Campaing",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaing_CategoryId",
                table: "Campaing",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaing_Brand_BrandId",
                table: "Campaing",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaing_Category_CategoryId",
                table: "Campaing",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IntelligenceRecord_Brand_BrandId",
                table: "IntelligenceRecord",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IntelligenceRecord_Category_CategoryId",
                table: "IntelligenceRecord",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
