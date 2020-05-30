using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Myo.Migrations
{
    public partial class AddingMyoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Myos",
                columns: table => new
                {
                    IdMyo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerIdUser = table.Column<int>(type: "integer", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Goal = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Myos", x => x.IdMyo);
                    table.ForeignKey(
                        name: "FK_Myos_Users_OwnerIdUser",
                        column: x => x.OwnerIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Checkpoints",
                columns: table => new
                {
                    IdCheckpoint = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TestDescription = table.Column<string>(type: "text", nullable: true),
                    MyoIdMyo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkpoints", x => x.IdCheckpoint);
                    table.ForeignKey(
                        name: "FK_Checkpoints_Myos_MyoIdMyo",
                        column: x => x.MyoIdMyo,
                        principalTable: "Myos",
                        principalColumn: "IdMyo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkpoints_MyoIdMyo",
                table: "Checkpoints",
                column: "MyoIdMyo");

            migrationBuilder.CreateIndex(
                name: "IX_Myos_OwnerIdUser",
                table: "Myos",
                column: "OwnerIdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkpoints");

            migrationBuilder.DropTable(
                name: "Myos");
        }
    }
}
