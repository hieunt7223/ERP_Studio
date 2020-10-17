using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class phase1_updateTable_donvihanhchinh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThuocCapDonViHanhChinh",
                schema: "common",
                table: "DonViHanhChinhs");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                schema: "common",
                table: "DonViHanhChinhs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "common",
                table: "DonViHanhChinhs");

            migrationBuilder.AddColumn<int>(
                name: "ThuocCapDonViHanhChinh",
                schema: "common",
                table: "DonViHanhChinhs",
                type: "int",
                nullable: true);
        }
    }
}
