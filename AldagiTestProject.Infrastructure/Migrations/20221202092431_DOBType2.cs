using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class DOBType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Countries_CitizenshipIdId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "CitizenshipIdId",
                table: "Persons",
                newName: "CitizenshipId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_CitizenshipIdId",
                table: "Persons",
                newName: "IX_Persons_CitizenshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Countries_CitizenshipId",
                table: "Persons",
                column: "CitizenshipId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Countries_CitizenshipId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "CitizenshipId",
                table: "Persons",
                newName: "CitizenshipIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_CitizenshipId",
                table: "Persons",
                newName: "IX_Persons_CitizenshipIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Countries_CitizenshipIdId",
                table: "Persons",
                column: "CitizenshipIdId",
                principalTable: "Countries",
                principalColumn: "Id");
        }
    }
}
