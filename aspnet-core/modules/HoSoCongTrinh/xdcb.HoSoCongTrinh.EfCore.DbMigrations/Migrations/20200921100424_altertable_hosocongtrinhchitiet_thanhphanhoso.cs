using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.HoSoCongTrinh.Migrations
{
    public partial class altertable_hosocongtrinhchitiet_thanhphanhoso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DonViBanHanhId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayBanHanh",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoKyHieu",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrichYeu",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonViBanHanhId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos");

            migrationBuilder.DropColumn(
                name: "NgayBanHanh",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos");

            migrationBuilder.DropColumn(
                name: "SoKyHieu",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos");

            migrationBuilder.DropColumn(
                name: "TrichYeu",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos");
        }
    }
}
