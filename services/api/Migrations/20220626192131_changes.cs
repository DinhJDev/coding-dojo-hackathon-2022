using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Lng",
                table: "Supplies",
                type: "double",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<double>(
                name: "Lat",
                table: "Supplies",
                type: "double",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<double>(
                name: "Lng",
                table: "LostFounds",
                type: "double",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<double>(
                name: "Lat",
                table: "LostFounds",
                type: "double",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Lng",
                table: "Supplies",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<bool>(
                name: "Lat",
                table: "Supplies",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<bool>(
                name: "Lng",
                table: "LostFounds",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<bool>(
                name: "Lat",
                table: "LostFounds",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}
