using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class phase1_updateTable_Loaihoso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApDung",
                schema: "common",
                table: "LoaiHoSos");

            migrationBuilder.DropColumn(
                name: "LaDieuChinh",
                schema: "common",
                table: "LoaiHoSos");

            migrationBuilder.DropColumn(
                name: "ThoiGianXuLyQuyDinh",
                schema: "common",
                table: "LoaiHoSos");

            migrationBuilder.AddColumn<bool>(
                name: "IsDieuChinh",
                schema: "common",
                table: "LoaiHoSos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrangThai",
                schema: "common",
                table: "LoaiHoSos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGianXuLyQuyDinhNhomA",
                schema: "common",
                table: "LoaiHoSos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGianXuLyQuyDinhNhomB",
                schema: "common",
                table: "LoaiHoSos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGianXuLyQuyDinhNhomC",
                schema: "common",
                table: "LoaiHoSos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDieuChinh",
                schema: "common",
                table: "LoaiHoSos");

            migrationBuilder.DropColumn(
                name: "IsTrangThai",
                schema: "common",
                table: "LoaiHoSos");

            migrationBuilder.DropColumn(
                name: "ThoiGianXuLyQuyDinhNhomA",
                schema: "common",
                table: "LoaiHoSos");

            migrationBuilder.DropColumn(
                name: "ThoiGianXuLyQuyDinhNhomB",
                schema: "common",
                table: "LoaiHoSos");

            migrationBuilder.DropColumn(
                name: "ThoiGianXuLyQuyDinhNhomC",
                schema: "common",
                table: "LoaiHoSos");

            migrationBuilder.AddColumn<bool>(
                name: "ApDung",
                schema: "common",
                table: "LoaiHoSos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LaDieuChinh",
                schema: "common",
                table: "LoaiHoSos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGianXuLyQuyDinh",
                schema: "common",
                table: "LoaiHoSos",
                type: "datetime2",
                nullable: true);
        }
    }
}
