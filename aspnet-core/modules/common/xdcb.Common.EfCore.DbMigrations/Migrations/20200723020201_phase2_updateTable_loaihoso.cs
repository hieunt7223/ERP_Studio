using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class phase2_updateTable_loaihoso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BieuMau1",
                schema: "common",
                table: "LoaiHoSos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BieuMau2",
                schema: "common",
                table: "LoaiHoSos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
