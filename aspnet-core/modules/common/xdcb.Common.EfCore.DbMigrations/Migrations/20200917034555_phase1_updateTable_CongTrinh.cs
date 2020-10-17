using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class phase1_updateTable_CongTrinh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "NST",
                schema: "common",
                table: "CongTrinhs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NSTW",
                schema: "common",
                table: "CongTrinhs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ODA",
                schema: "common",
                table: "CongTrinhs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NST",
                schema: "common",
                table: "CongTrinhs");

            migrationBuilder.DropColumn(
                name: "NSTW",
                schema: "common",
                table: "CongTrinhs");

            migrationBuilder.DropColumn(
                name: "ODA",
                schema: "common",
                table: "CongTrinhs");
        }
    }
}
