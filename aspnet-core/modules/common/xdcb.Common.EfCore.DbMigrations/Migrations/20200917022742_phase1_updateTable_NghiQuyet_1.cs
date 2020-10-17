using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class phase1_updateTable_NghiQuyet_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTheoDoi",
                schema: "common",
                table: "NghiQuyets",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NghiQuyetId",
                schema: "common",
                table: "CongTrinhs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CongTrinhs_NghiQuyetId",
                schema: "common",
                table: "CongTrinhs",
                column: "NghiQuyetId");

            migrationBuilder.AddForeignKey(
                name: "FK_CongTrinhs_NghiQuyets_NghiQuyetId",
                schema: "common",
                table: "CongTrinhs",
                column: "NghiQuyetId",
                principalSchema: "common",
                principalTable: "NghiQuyets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CongTrinhs_NghiQuyets_NghiQuyetId",
                schema: "common",
                table: "CongTrinhs");

            migrationBuilder.DropIndex(
                name: "IX_CongTrinhs_NghiQuyetId",
                schema: "common",
                table: "CongTrinhs");

            migrationBuilder.DropColumn(
                name: "IsTheoDoi",
                schema: "common",
                table: "NghiQuyets");

            migrationBuilder.DropColumn(
                name: "NghiQuyetId",
                schema: "common",
                table: "CongTrinhs");
        }
    }
}
