using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class dbvon6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NhuCauKeHoachVonTrungHanNSTWDauNam",
                schema: "von",
                table: "NhuCauVons");

            migrationBuilder.DropColumn(
                name: "NhuCauKeHoachVonTrungHanNSTWDieuChinh",
                schema: "von",
                table: "NhuCauVons");

            migrationBuilder.DropColumn(
                name: "NhuCauKeHoachVonTrungHanNTSDauNam",
                schema: "von",
                table: "NhuCauVons");

            migrationBuilder.DropColumn(
                name: "NhuCauKeHoachVonTrungHanNTSDieuChinh",
                schema: "von",
                table: "NhuCauVons");

            migrationBuilder.DropColumn(
                name: "NhuCauKeHoachVonTrungHanODADauNam",
                schema: "von",
                table: "NhuCauVons");

            migrationBuilder.DropColumn(
                name: "NhuCauKeHoachVonTrungHanODADieuChinh",
                schema: "von",
                table: "NhuCauVons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "NhuCauKeHoachVonTrungHanNSTWDauNam",
                schema: "von",
                table: "NhuCauVons",
                type: "decimal(22,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NhuCauKeHoachVonTrungHanNSTWDieuChinh",
                schema: "von",
                table: "NhuCauVons",
                type: "decimal(22,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NhuCauKeHoachVonTrungHanNTSDauNam",
                schema: "von",
                table: "NhuCauVons",
                type: "decimal(22,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NhuCauKeHoachVonTrungHanNTSDieuChinh",
                schema: "von",
                table: "NhuCauVons",
                type: "decimal(22,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NhuCauKeHoachVonTrungHanODADauNam",
                schema: "von",
                table: "NhuCauVons",
                type: "decimal(22,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NhuCauKeHoachVonTrungHanODADieuChinh",
                schema: "von",
                table: "NhuCauVons",
                type: "decimal(22,6)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
