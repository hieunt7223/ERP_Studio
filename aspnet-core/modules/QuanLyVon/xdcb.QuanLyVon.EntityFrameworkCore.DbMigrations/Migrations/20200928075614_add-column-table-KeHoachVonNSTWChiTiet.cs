using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class addcolumntableKeHoachVonNSTWChiTiet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NhuCauKeHoachVonNamNay",
                schema: "von",
                table: "KeHoachVonNSTWChiTiets",
                newName: "NhuCauKeHoachVonDieuChinh");

            migrationBuilder.AddColumn<Guid>(
                name: "NhuCauKeHoachVonChiTietDauNamId",
                schema: "von",
                table: "KeHoachVonNSTWChiTiets",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NhuCauKeHoachVonChiTietDieuChinhId",
                schema: "von",
                table: "KeHoachVonNSTWChiTiets",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "NhuCauKeHoachVonDauNam",
                schema: "von",
                table: "KeHoachVonNSTWChiTiets",
                type: "decimal(22,6)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NhuCauKeHoachVonChiTietDauNamId",
                schema: "von",
                table: "KeHoachVonNSTWChiTiets");

            migrationBuilder.DropColumn(
                name: "NhuCauKeHoachVonChiTietDieuChinhId",
                schema: "von",
                table: "KeHoachVonNSTWChiTiets");

            migrationBuilder.DropColumn(
                name: "NhuCauKeHoachVonDauNam",
                schema: "von",
                table: "KeHoachVonNSTWChiTiets");

            migrationBuilder.RenameColumn(
                name: "NhuCauKeHoachVonDieuChinh",
                schema: "von",
                table: "KeHoachVonNSTWChiTiets",
                newName: "NhuCauKeHoachVonNamNay");
        }
    }
}
