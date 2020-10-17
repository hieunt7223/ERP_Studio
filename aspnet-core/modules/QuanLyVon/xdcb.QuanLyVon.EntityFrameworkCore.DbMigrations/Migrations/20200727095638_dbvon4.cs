using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class dbvon4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nam",
                schema: "von",
                table: "NhuCauVons");

            migrationBuilder.AddColumn<int>(
                name: "DenNam",
                schema: "von",
                table: "NhuCauVons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TuNam",
                schema: "von",
                table: "NhuCauVons",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DenNam",
                schema: "von",
                table: "NhuCauVons");

            migrationBuilder.DropColumn(
                name: "TuNam",
                schema: "von",
                table: "NhuCauVons");

            migrationBuilder.AddColumn<int>(
                name: "Nam",
                schema: "von",
                table: "NhuCauVons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
