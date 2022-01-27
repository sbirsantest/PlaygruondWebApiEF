using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.DataAccess.Data.Migrations.Administration
{
    public partial class AddNewOrganisationSeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Organisations",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-b000000000b0"), "manager organisation" });

            migrationBuilder.InsertData(
                table: "OrganisationMembers",
                columns: new[] { "OrganisationId", "UserId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-b000000000b0"), new Guid("00000000-0000-0000-0000-ad00000000ad") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrganisationMembers",
                keyColumns: new[] { "OrganisationId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-b000000000b0"), new Guid("00000000-0000-0000-0000-ad00000000ad") });

            migrationBuilder.DeleteData(
                table: "Organisations",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-b000000000b0"));
        }
    }
}
