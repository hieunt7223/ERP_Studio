using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class phase1_updateTable_nghiQuyet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrichYeu",
                schema: "common",
                table: "NghiQuyets",
                maxLength: 196,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(196)",
                oldMaxLength: 196,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SoVanBan",
                schema: "common",
                table: "NghiQuyets",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayBanHanh",
                schema: "common",
                table: "NghiQuyets",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrichYeu",
                schema: "common",
                table: "NghiQuyets",
                type: "nvarchar(196)",
                maxLength: 196,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 196);

            migrationBuilder.AlterColumn<string>(
                name: "SoVanBan",
                schema: "common",
                table: "NghiQuyets",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayBanHanh",
                schema: "common",
                table: "NghiQuyets",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
