using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrafficBackendAPI.UserModule.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTable_AddressModel_AddressId",
                table: "UserTable");

            migrationBuilder.DropIndex(
                name: "IX_UserTable_AddressId",
                table: "UserTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressModel",
                table: "AddressModel");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "UserTable");

            migrationBuilder.RenameTable(
                name: "AddressModel",
                newName: "AddressTable");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AddressTable",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressTable",
                table: "AddressTable",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AddressTable_UserId",
                table: "AddressTable",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressTable_UserTable_UserId",
                table: "AddressTable",
                column: "UserId",
                principalTable: "UserTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressTable_UserTable_UserId",
                table: "AddressTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressTable",
                table: "AddressTable");

            migrationBuilder.DropIndex(
                name: "IX_AddressTable_UserId",
                table: "AddressTable");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AddressTable");

            migrationBuilder.RenameTable(
                name: "AddressTable",
                newName: "AddressModel");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "UserTable",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressModel",
                table: "AddressModel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserTable_AddressId",
                table: "UserTable",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTable_AddressModel_AddressId",
                table: "UserTable",
                column: "AddressId",
                principalTable: "AddressModel",
                principalColumn: "Id");
        }
    }
}
