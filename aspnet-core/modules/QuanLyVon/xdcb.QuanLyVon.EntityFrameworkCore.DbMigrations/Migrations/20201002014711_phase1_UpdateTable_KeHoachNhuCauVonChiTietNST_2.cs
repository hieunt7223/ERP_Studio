using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class phase1_UpdateTable_KeHoachNhuCauVonChiTietNST_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NhuCauKeHoachVon",
                schema: "von",
                table: "KeHoachVonNSTChiTiets",
                newName: "NhuCauKeHoachVonDieuChinh");

            migrationBuilder.AddColumn<Guid>(
                name: "LoaiKhoanId",
                schema: "von",
                table: "KeHoachVonNSTChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NhuCauKeHoachVonChiTietDauNamId",
                schema: "von",
                table: "KeHoachVonNSTChiTiets",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NhuCauKeHoachVonChiTietDieuChinhId",
                schema: "von",
                table: "KeHoachVonNSTChiTiets",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "NhuCauKeHoachVonDauNam",
                schema: "von",
                table: "KeHoachVonNSTChiTiets",
                type: "decimal(22,6)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoaiKhoanId",
                schema: "von",
                table: "KeHoachVonNSTChiTiets");

            migrationBuilder.DropColumn(
                name: "NhuCauKeHoachVonChiTietDauNamId",
                schema: "von",
                table: "KeHoachVonNSTChiTiets");

            migrationBuilder.DropColumn(
                name: "NhuCauKeHoachVonChiTietDieuChinhId",
                schema: "von",
                table: "KeHoachVonNSTChiTiets");

            migrationBuilder.DropColumn(
                name: "NhuCauKeHoachVonDauNam",
                schema: "von",
                table: "KeHoachVonNSTChiTiets");

            migrationBuilder.RenameColumn(
                name: "NhuCauKeHoachVonDieuChinh",
                schema: "von",
                table: "KeHoachVonNSTChiTiets",
                newName: "NhuCauKeHoachVon");
        }
    }
}
