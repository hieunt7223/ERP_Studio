using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.HoSoCongTrinh.Migrations
{
    public partial class alter_table_hosocongtrinh_thanhphanhoso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBatBuoc",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBatBuoc",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos");
        }
    }
}
