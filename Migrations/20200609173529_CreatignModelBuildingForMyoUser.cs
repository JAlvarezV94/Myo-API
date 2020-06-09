using Microsoft.EntityFrameworkCore.Migrations;

namespace Myo.Migrations
{
    public partial class CreatignModelBuildingForMyoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Myos_Users_UserIdUser",
                table: "Myos");

            migrationBuilder.DropIndex(
                name: "IX_Myos_UserIdUser",
                table: "Myos");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Myos");

            migrationBuilder.DropColumn(
                name: "UserIdUser",
                table: "Myos");

            migrationBuilder.AddColumn<int>(
                name: "OwnerIdUser",
                table: "Myos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Myos_OwnerIdUser",
                table: "Myos",
                column: "OwnerIdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Myos_Users_OwnerIdUser",
                table: "Myos",
                column: "OwnerIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Myos_Users_OwnerIdUser",
                table: "Myos");

            migrationBuilder.DropIndex(
                name: "IX_Myos_OwnerIdUser",
                table: "Myos");

            migrationBuilder.DropColumn(
                name: "OwnerIdUser",
                table: "Myos");

            migrationBuilder.AddColumn<int>(
                name: "Owner",
                table: "Myos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserIdUser",
                table: "Myos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Myos_UserIdUser",
                table: "Myos",
                column: "UserIdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Myos_Users_UserIdUser",
                table: "Myos",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
