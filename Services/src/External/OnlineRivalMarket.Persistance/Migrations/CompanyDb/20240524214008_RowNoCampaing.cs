﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineRivalMarket.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class RowNoCampaing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RowNo",
                table: "Campaing",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowNo",
                table: "Campaing");
        }
    }
}
