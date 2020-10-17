using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.HoSoCongTrinh.Migrations
{
    public partial class altertable_hosochitiet_goithau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GoiThauParentId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoaiHopDongId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoaiKeHoach",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoiThauParentId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus");

            migrationBuilder.DropColumn(
                name: "LoaiHopDongId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus");

            migrationBuilder.DropColumn(
                name: "LoaiKeHoach",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus");
        }
    }
}
