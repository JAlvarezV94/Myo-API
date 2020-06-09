using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Myo.Migrations
{
    public partial class AddingEndDateToMyoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Myos_Users_OwnerIdUser",
                table: "Myos");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerIdUser",
                table: "Myos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Myos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Myos_Users_OwnerIdUser",
                table: "Myos",
                column: "OwnerIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Myos_Users_OwnerIdUser",
                table: "Myos");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Myos");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerIdUser",
                table: "Myos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Myos_Users_OwnerIdUser",
                table: "Myos",
                column: "OwnerIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
