using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.HoSoCongTrinh.Migrations
{
    public partial class altertable_hscongtrinh_chitiet_add_ischudautu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsChuDauTu",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChuDauTu",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");
        }
    }
}
