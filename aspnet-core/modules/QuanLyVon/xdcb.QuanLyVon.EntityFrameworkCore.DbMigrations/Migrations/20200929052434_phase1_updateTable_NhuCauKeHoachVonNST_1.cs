using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class phase1_updateTable_NhuCauKeHoachVonNST_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "NhuCauKeHoachVon",
                schema: "von",
                table: "KeHoachVonNSTChiTiets",
                type: "decimal(22,6)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NhuCauKeHoachVon",
                schema: "von",
                table: "KeHoachVonNSTChiTiets");
        }
    }
}
