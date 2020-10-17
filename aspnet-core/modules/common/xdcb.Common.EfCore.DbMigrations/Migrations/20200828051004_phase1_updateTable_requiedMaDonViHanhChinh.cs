using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class phase1_updateTable_requiedMaDonViHanhChinh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DonViHanhChinhs_MaDonViHanhChinh",
                schema: "common",
                table: "DonViHanhChinhs");

            migrationBuilder.AlterColumn<string>(
                name: "MaDonViHanhChinh",
                schema: "common",
                table: "DonViHanhChinhs",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonViHanhChinhs_MaDonViHanhChinh",
                schema: "common",
                table: "DonViHanhChinhs",
                column: "MaDonViHanhChinh",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DonViHanhChinhs_MaDonViHanhChinh",
                schema: "common",
                table: "DonViHanhChinhs");

            migrationBuilder.AlterColumn<string>(
                name: "MaDonViHanhChinh",
                schema: "common",
                table: "DonViHanhChinhs",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.CreateIndex(
                name: "IX_DonViHanhChinhs_MaDonViHanhChinh",
                schema: "common",
                table: "DonViHanhChinhs",
                column: "MaDonViHanhChinh",
                unique: true,
                filter: "[MaDonViHanhChinh] IS NOT NULL");
        }
    }
}
