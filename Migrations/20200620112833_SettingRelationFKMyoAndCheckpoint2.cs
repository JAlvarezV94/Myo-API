using Microsoft.EntityFrameworkCore.Migrations;

namespace Myo.Migrations
{
    public partial class SettingRelationFKMyoAndCheckpoint2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMyo",
                table: "Checkpoints",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdMyo",
                table: "Checkpoints");
        }
    }
}
