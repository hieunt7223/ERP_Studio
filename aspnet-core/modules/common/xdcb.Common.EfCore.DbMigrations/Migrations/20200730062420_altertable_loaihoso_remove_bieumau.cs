using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class altertable_loaihoso_remove_bieumau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BieuMau1",
                schema: "common",
                table: "LoaiHoSos");

            migrationBuilder.DropColumn(
                name: "BieuMau2",
                schema: "common",
                table: "LoaiHoSos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BieuMau1",
                schema: "common",
                table: "LoaiHoSos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BieuMau2",
                schema: "common",
                table: "LoaiHoSos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
