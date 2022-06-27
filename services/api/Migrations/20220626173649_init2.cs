using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lon",
                table: "Supplies",
                newName: "Lng");

            migrationBuilder.RenameColumn(
                name: "Lon",
                table: "LostFounds",
                newName: "Lng");

            migrationBuilder.RenameColumn(
                name: "Lon",
                table: "HotZones",
                newName: "Lng");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lng",
                table: "Supplies",
                newName: "Lon");

            migrationBuilder.RenameColumn(
                name: "Lng",
                table: "LostFounds",
                newName: "Lon");

            migrationBuilder.RenameColumn(
                name: "Lng",
                table: "HotZones",
                newName: "Lon");
        }
    }
}
