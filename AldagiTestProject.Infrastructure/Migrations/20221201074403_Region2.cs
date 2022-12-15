using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Region2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "Countries");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_RegionId",
                table: "Countries",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Regions_RegionId",
                table: "Countries",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Regions_RegionId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_RegionId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Countries");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
