using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class remote_bat_buot_nhap_ma_cong_trinh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CongTrinhs_MaCongTrinh",
                schema: "common",
                table: "CongTrinhs");

            migrationBuilder.AlterColumn<string>(
                name: "MaCongTrinh",
                schema: "common",
                table: "CongTrinhs",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MaCongTrinh",
                schema: "common",
                table: "CongTrinhs",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CongTrinhs_MaCongTrinh",
                schema: "common",
                table: "CongTrinhs",
                column: "MaCongTrinh",
                unique: true);
        }
    }
}
