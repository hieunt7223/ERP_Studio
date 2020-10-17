using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class altertable_thuvienvanban_donvibanhanh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonViBanHanh",
                schema: "common",
                table: "ThuVienVanBans");

            migrationBuilder.AddColumn<Guid>(
                name: "DonViBanHanhId",
                schema: "common",
                table: "ThuVienVanBans",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonViBanHanhId",
                schema: "common",
                table: "ThuVienVanBans");

            migrationBuilder.AddColumn<string>(
                name: "DonViBanHanh",
                schema: "common",
                table: "ThuVienVanBans",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
