using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class Add_Column_Table_KeHoachTongNguonChiTiet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleteDieuChinh",
                schema: "von",
                table: "KeHoachTongNguonChiTiets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelectDieuChinh",
                schema: "von",
                table: "KeHoachTongNguonChiTiets",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleteDieuChinh",
                schema: "von",
                table: "KeHoachTongNguonChiTiets");

            migrationBuilder.DropColumn(
                name: "IsSelectDieuChinh",
                schema: "von",
                table: "KeHoachTongNguonChiTiets");
        }
    }
}
