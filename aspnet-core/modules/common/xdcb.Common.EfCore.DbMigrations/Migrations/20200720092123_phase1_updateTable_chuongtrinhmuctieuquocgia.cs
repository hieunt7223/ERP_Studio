using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class phase1_updateTable_chuongtrinhmuctieuquocgia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TenChuongTrinhMucTieuQuocGia",
                schema: "common",
                table: "ChuongTrinhMucTieuQuocGias",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaChuongTrinhMucTieuQuocGia",
                schema: "common",
                table: "ChuongTrinhMucTieuQuocGias",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TenChuongTrinhMucTieuQuocGia",
                schema: "common",
                table: "ChuongTrinhMucTieuQuocGias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "MaChuongTrinhMucTieuQuocGia",
                schema: "common",
                table: "ChuongTrinhMucTieuQuocGias",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
