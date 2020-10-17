using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class altertable_loaihoso_addfied : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenViewLoaiHoSo",
                schema: "common",
                table: "LoaiHoSos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenViewLoaiHoSo",
                schema: "common",
                table: "LoaiHoSos");
        }
    }
}
