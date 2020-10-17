using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class phase1_updateTable_HinhThucHopDong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HinhThucHopDongs_TenHinhThucHopDong",
                schema: "common",
                table: "HinhThucHopDongs",
                column: "TenHinhThucHopDong",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HinhThucHopDongs_TenHinhThucHopDong",
                schema: "common",
                table: "HinhThucHopDongs");
        }
    }
}
