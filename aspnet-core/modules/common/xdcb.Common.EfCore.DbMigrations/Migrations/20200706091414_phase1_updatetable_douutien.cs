using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class phase1_updatetable_douutien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MaDoUuTien",
                schema: "common",
                table: "DoUuTiens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThuTuHienThi",
                schema: "common",
                table: "DoUuTiens",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThuTuHienThi",
                schema: "common",
                table: "DoUuTiens");

            migrationBuilder.AlterColumn<string>(
                name: "MaDoUuTien",
                schema: "common",
                table: "DoUuTiens",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
