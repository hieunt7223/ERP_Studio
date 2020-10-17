using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.HoSoCongTrinh.Migrations
{
    public partial class altertable_hosocongtrinhchitiet_nguonvon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MucDauTuBoSung",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MucDauTuPheDuyet",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "NoiDungQuyMoDauTuDeXuatDieuChinh",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoiDungQuyMoDauTuPheDuyet",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GiaTriNguonVon",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietNguonVons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MucDauTuBoSung",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "MucDauTuPheDuyet",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "NoiDungQuyMoDauTuDeXuatDieuChinh",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "NoiDungQuyMoDauTuPheDuyet",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "GiaTriNguonVon",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietNguonVons");
        }
    }
}
