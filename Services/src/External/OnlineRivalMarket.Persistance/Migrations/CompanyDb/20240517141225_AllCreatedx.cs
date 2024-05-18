using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineRivalMarket.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class AllCreatedx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldInformation_AppUser_AppUserId",
                table: "FieldInformation");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "FieldInformation",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FieldInformation_AppUserId",
                table: "FieldInformation",
                newName: "IX_FieldInformation_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldInformation_AppUser_UserId",
                table: "FieldInformation",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldInformation_AppUser_UserId",
                table: "FieldInformation");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "FieldInformation",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_FieldInformation_UserId",
                table: "FieldInformation",
                newName: "IX_FieldInformation_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldInformation_AppUser_AppUserId",
                table: "FieldInformation",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id");
        }
    }
}
