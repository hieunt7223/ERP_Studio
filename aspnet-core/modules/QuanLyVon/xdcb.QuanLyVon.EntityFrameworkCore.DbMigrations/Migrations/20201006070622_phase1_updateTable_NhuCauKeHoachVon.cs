using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class phase1_updateTable_NhuCauKeHoachVon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGianGuiBaoCaoDauNam",
                schema: "von",
                table: "NhuCauKeHoachVons",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGianGuiBaoCaoDieuChinh",
                schema: "von",
                table: "NhuCauKeHoachVons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThoiGianGuiBaoCaoDauNam",
                schema: "von",
                table: "NhuCauKeHoachVons");

            migrationBuilder.DropColumn(
                name: "ThoiGianGuiBaoCaoDieuChinh",
                schema: "von",
                table: "NhuCauKeHoachVons");
        }
    }
}
