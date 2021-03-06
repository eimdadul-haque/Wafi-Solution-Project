using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wafi_Solution_Project.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "holidayD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_holidayD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "countriesD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HolidayModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countriesD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_countriesD_holidayD_HolidayModelId",
                        column: x => x.HolidayModelId,
                        principalTable: "holidayD",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_countriesD_HolidayModelId",
                table: "countriesD",
                column: "HolidayModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "countriesD");

            migrationBuilder.DropTable(
                name: "holidayD");
        }
    }
}
