using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class altertable_danhmuc_goithau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoiThaus_LoaiGoiThaus_LoaiGoiThauId",
                schema: "common",
                table: "GoiThaus");

            migrationBuilder.DropIndex(
                name: "IX_GoiThaus_LoaiGoiThauId",
                schema: "common",
                table: "GoiThaus");

            migrationBuilder.AddColumn<Guid>(
                name: "GoiThauParentId",
                schema: "common",
                table: "GoiThaus",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoiThauParentId",
                schema: "common",
                table: "GoiThaus");

            migrationBuilder.CreateIndex(
                name: "IX_GoiThaus_LoaiGoiThauId",
                schema: "common",
                table: "GoiThaus",
                column: "LoaiGoiThauId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoiThaus_LoaiGoiThaus_LoaiGoiThauId",
                schema: "common",
                table: "GoiThaus",
                column: "LoaiGoiThauId",
                principalSchema: "common",
                principalTable: "LoaiGoiThaus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
