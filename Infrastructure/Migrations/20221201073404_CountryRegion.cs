using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class CountryRegion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CitizenshipId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CitizenshipId",
                table: "Persons",
                column: "CitizenshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Country_CitizenshipId",
                table: "Persons",
                column: "CitizenshipId",
                principalTable: "Country",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Country_CitizenshipId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CitizenshipId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CitizenshipId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Persons");
        }
    }
}
