using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class dbvon7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DieuChinhGiamNSTWDieuChinh",
                schema: "von",
                table: "NhuCauVons");

            migrationBuilder.DropColumn(
                name: "DieuChinhGiamNTSDieuChinh",
                schema: "von",
                table: "NhuCauVons");

            migrationBuilder.DropColumn(
                name: "DieuChinhGiamODADieuChinh",
                schema: "von",
                table: "NhuCauVons");

            migrationBuilder.DropColumn(
                name: "DieuChinhTangNSTWDieuChinh",
                schema: "von",
                table: "NhuCauVons");

            migrationBuilder.DropColumn(
                name: "DieuChinhTangNTSDieuChinh",
                schema: "von",
                table: "NhuCauVons");

            migrationBuilder.DropColumn(
                name: "DieuChinhTangODADieuChinh",
                schema: "von",
                table: "NhuCauVons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DieuChinhGiamNSTWDieuChinh",
                schema: "von",
                table: "NhuCauVons",
                type: "decimal(22,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DieuChinhGiamNTSDieuChinh",
                schema: "von",
                table: "NhuCauVons",
                type: "decimal(22,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DieuChinhGiamODADieuChinh",
                schema: "von",
                table: "NhuCauVons",
                type: "decimal(22,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DieuChinhTangNSTWDieuChinh",
                schema: "von",
                table: "NhuCauVons",
                type: "decimal(22,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DieuChinhTangNTSDieuChinh",
                schema: "von",
                table: "NhuCauVons",
                type: "decimal(22,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DieuChinhTangODADieuChinh",
                schema: "von",
                table: "NhuCauVons",
                type: "decimal(22,6)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
