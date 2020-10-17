using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class initdbvon2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GhiChuSo",
                schema: "von",
                table: "KeHoachTongNguonChiTiets");

            migrationBuilder.DropColumn(
                name: "GhiChuUyBan",
                schema: "von",
                table: "KeHoachTongNguonChiTiets");

            migrationBuilder.AddColumn<string>(
                name: "GhiChuSoDauNam",
                schema: "von",
                table: "KeHoachTongNguonChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChuSoDieuChinh",
                schema: "von",
                table: "KeHoachTongNguonChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChuUyBanDauNam",
                schema: "von",
                table: "KeHoachTongNguonChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChuUyBanDieuChinh",
                schema: "von",
                table: "KeHoachTongNguonChiTiets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GhiChuSoDauNam",
                schema: "von",
                table: "KeHoachTongNguonChiTiets");

            migrationBuilder.DropColumn(
                name: "GhiChuSoDieuChinh",
                schema: "von",
                table: "KeHoachTongNguonChiTiets");

            migrationBuilder.DropColumn(
                name: "GhiChuUyBanDauNam",
                schema: "von",
                table: "KeHoachTongNguonChiTiets");

            migrationBuilder.DropColumn(
                name: "GhiChuUyBanDieuChinh",
                schema: "von",
                table: "KeHoachTongNguonChiTiets");

            migrationBuilder.AddColumn<string>(
                name: "GhiChuSo",
                schema: "von",
                table: "KeHoachTongNguonChiTiets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChuUyBan",
                schema: "von",
                table: "KeHoachTongNguonChiTiets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
