using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class AddcolumnLuyKeVonTongCongtoKeHoachVonNQChiTiets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LuyKeVonTongCong",
                schema: "von",
                table: "KeHoachVonNQChiTiets",
                type: "decimal(22,6)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LuyKeVonTongCong",
                schema: "von",
                table: "KeHoachVonNQChiTiets");
        }
    }
}
