using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class phase1_addTable_NghiQuyetCongTrinh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NghiQuyetCongTrinhs",
                schema: "common",
                columns: table => new
                {
                    CongTrinhId = table.Column<Guid>(nullable: false),
                    NghiQuyetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NghiQuyetCongTrinhs", x => new { x.CongTrinhId, x.NghiQuyetId });
                    table.ForeignKey(
                        name: "FK_NghiQuyetCongTrinhs_CongTrinhs_CongTrinhId",
                        column: x => x.CongTrinhId,
                        principalSchema: "common",
                        principalTable: "CongTrinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NghiQuyetCongTrinhs_NghiQuyets_NghiQuyetId",
                        column: x => x.NghiQuyetId,
                        principalSchema: "common",
                        principalTable: "NghiQuyets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NghiQuyetCongTrinhs_NghiQuyetId",
                schema: "common",
                table: "NghiQuyetCongTrinhs",
                column: "NghiQuyetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NghiQuyetCongTrinhs",
                schema: "common");
        }
    }
}
