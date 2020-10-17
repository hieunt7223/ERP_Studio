using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class phase1_updateTable_uniqueDonVivsCongTrinh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DonViHanhChinhs_MaDonViHanhChinh",
                schema: "common",
                table: "DonViHanhChinhs",
                column: "MaDonViHanhChinh",
                unique: true,
                filter: "[MaDonViHanhChinh] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CongTrinhs_MaCongTrinh",
                schema: "common",
                table: "CongTrinhs",
                column: "MaCongTrinh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CongTrinhs_TenCongTrinh",
                schema: "common",
                table: "CongTrinhs",
                column: "TenCongTrinh",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DonViHanhChinhs_MaDonViHanhChinh",
                schema: "common",
                table: "DonViHanhChinhs");

            migrationBuilder.DropIndex(
                name: "IX_CongTrinhs_MaCongTrinh",
                schema: "common",
                table: "CongTrinhs");

            migrationBuilder.DropIndex(
                name: "IX_CongTrinhs_TenCongTrinh",
                schema: "common",
                table: "CongTrinhs");
        }
    }
}
