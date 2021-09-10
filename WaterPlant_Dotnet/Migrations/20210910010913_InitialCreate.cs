using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WaterPlant_Dotnet.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequiredDueAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    WateringAgainDueAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    RequireWaitDueAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    Reminder6h = table.Column<string>(type: "TEXT", nullable: true),
                    Reminder30s = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plant");
        }
    }
}
