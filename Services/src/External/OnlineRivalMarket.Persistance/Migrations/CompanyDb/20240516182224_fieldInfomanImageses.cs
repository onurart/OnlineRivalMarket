using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineRivalMarket.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class fieldInfomanImageses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FieldInformationImagesFile",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FieldInformationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FieldInformationFileUrls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldInformationImagesFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldInformationImagesFile_FieldInformation_FieldInformationId",
                        column: x => x.FieldInformationId,
                        principalTable: "FieldInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldInformationImagesFile_FieldInformationId",
                table: "FieldInformationImagesFile",
                column: "FieldInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldInformationImagesFile");
        }
    }
}
