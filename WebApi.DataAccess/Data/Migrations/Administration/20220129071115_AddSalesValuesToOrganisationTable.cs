using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.DataAccess.Data.Migrations.Administration
{
    public partial class AddSalesValuesToOrganisationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Organisations",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-500000000050"), "sales organisation" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organisations",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-500000000050"));
        }
    }
}
