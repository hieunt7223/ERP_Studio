using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class phase1_updateTable_nguonvon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "common",
                table: "NguonVons",
                nullable: false,
                defaultValue: -1,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "common",
                table: "NguonVons",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: -1);
        }
    }
}
