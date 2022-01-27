using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.DataAccess.Data.Migrations.Administration
{
    public partial class FixAdminSeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Organisations",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-de00000000de"),
                column: "Name",
                value: "dev organisation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Organisations",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-de00000000de"),
                column: "Name",
                value: "00000000-0000-0000-0000-DE00000000DE");
        }
    }
}
