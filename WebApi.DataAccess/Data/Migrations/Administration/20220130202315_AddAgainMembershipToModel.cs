using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.DataAccess.Data.Migrations.Administration
{
    public partial class AddAgainMembershipToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganisationMembers_Organisations_OrganisationsId",
                table: "OrganisationMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganisationMembers_Users_UsersId",
                table: "OrganisationMembers");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "OrganisationMembers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "OrganisationsId",
                table: "OrganisationMembers",
                newName: "OrganisationId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganisationMembers_UsersId",
                table: "OrganisationMembers",
                newName: "IX_OrganisationMembers_UserId");

            migrationBuilder.InsertData(
                table: "OrganisationMembers",
                columns: new[] { "OrganisationId", "UserId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-de00000000de"), new Guid("00000000-0000-0000-0000-ad00000000ad") });

            migrationBuilder.InsertData(
                table: "OrganisationMembers",
                columns: new[] { "OrganisationId", "UserId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-b000000000b0"), new Guid("00000000-0000-0000-0000-ad00000000ad") });

            migrationBuilder.InsertData(
                table: "OrganisationMembers",
                columns: new[] { "OrganisationId", "UserId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-500000000050"), new Guid("00000000-0000-0000-0000-ad00000000ad") });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganisationMembers_Organisations_OrganisationId",
                table: "OrganisationMembers",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganisationMembers_Users_UserId",
                table: "OrganisationMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganisationMembers_Organisations_OrganisationId",
                table: "OrganisationMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganisationMembers_Users_UserId",
                table: "OrganisationMembers");

            migrationBuilder.DeleteData(
                table: "OrganisationMembers",
                keyColumns: new[] { "OrganisationId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-500000000050"), new Guid("00000000-0000-0000-0000-ad00000000ad") });

            migrationBuilder.DeleteData(
                table: "OrganisationMembers",
                keyColumns: new[] { "OrganisationId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-b000000000b0"), new Guid("00000000-0000-0000-0000-ad00000000ad") });

            migrationBuilder.DeleteData(
                table: "OrganisationMembers",
                keyColumns: new[] { "OrganisationId", "UserId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-de00000000de"), new Guid("00000000-0000-0000-0000-ad00000000ad") });

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "OrganisationMembers",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "OrganisationId",
                table: "OrganisationMembers",
                newName: "OrganisationsId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganisationMembers_UserId",
                table: "OrganisationMembers",
                newName: "IX_OrganisationMembers_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganisationMembers_Organisations_OrganisationsId",
                table: "OrganisationMembers",
                column: "OrganisationsId",
                principalTable: "Organisations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganisationMembers_Users_UsersId",
                table: "OrganisationMembers",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
