using Microsoft.EntityFrameworkCore.Migrations;

namespace Myo.Migrations
{
    public partial class AddingDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkpoints_Myos_MyoIdMyo",
                table: "Checkpoints");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkpoints_Myos_MyoIdMyo",
                table: "Checkpoints",
                column: "MyoIdMyo",
                principalTable: "Myos",
                principalColumn: "IdMyo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkpoints_Myos_MyoIdMyo",
                table: "Checkpoints");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkpoints_Myos_MyoIdMyo",
                table: "Checkpoints",
                column: "MyoIdMyo",
                principalTable: "Myos",
                principalColumn: "IdMyo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
