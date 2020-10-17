using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class add_Column_Table_NhuCauKeHoachVonChiTiet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleteDieuChinh",
                schema: "von",
                table: "NhuCauKeHoachVonChiTiets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelectDieuChinh",
                schema: "von",
                table: "NhuCauKeHoachVonChiTiets",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleteDieuChinh",
                schema: "von",
                table: "NhuCauKeHoachVonChiTiets");

            migrationBuilder.DropColumn(
                name: "IsSelectDieuChinh",
                schema: "von",
                table: "NhuCauKeHoachVonChiTiets");
        }
    }
}
