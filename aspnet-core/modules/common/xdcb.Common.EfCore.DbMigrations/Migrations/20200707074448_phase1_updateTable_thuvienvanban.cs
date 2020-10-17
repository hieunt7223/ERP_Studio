using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class phase1_updateTable_thuvienvanban : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KyHieuVanBan",
                schema: "common",
                table: "ThuVienVanBans");

            migrationBuilder.DropColumn(
                name: "NgayHetHieuLuc",
                schema: "common",
                table: "ThuVienVanBans");

            migrationBuilder.DropColumn(
                name: "NgayHieuLuc",
                schema: "common",
                table: "ThuVienVanBans");

            migrationBuilder.DropColumn(
                name: "NguoiKy",
                schema: "common",
                table: "ThuVienVanBans");

            migrationBuilder.DropColumn(
                name: "SoVanBan",
                schema: "common",
                table: "ThuVienVanBans");

            migrationBuilder.AddColumn<string>(
                name: "SoKyHieu",
                schema: "common",
                table: "ThuVienVanBans",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoKyHieu",
                schema: "common",
                table: "ThuVienVanBans");

            migrationBuilder.AddColumn<string>(
                name: "KyHieuVanBan",
                schema: "common",
                table: "ThuVienVanBans",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayHetHieuLuc",
                schema: "common",
                table: "ThuVienVanBans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayHieuLuc",
                schema: "common",
                table: "ThuVienVanBans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiKy",
                schema: "common",
                table: "ThuVienVanBans",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoVanBan",
                schema: "common",
                table: "ThuVienVanBans",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
