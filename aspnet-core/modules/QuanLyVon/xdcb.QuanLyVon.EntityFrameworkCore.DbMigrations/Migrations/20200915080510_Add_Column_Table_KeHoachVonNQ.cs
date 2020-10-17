using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class Add_Column_Table_KeHoachVonNQ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeHoachVonNQChiTiets",
                schema: "von",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<Guid>(nullable: false),
                    KeHoachVonNQId = table.Column<Guid>(nullable: false),
                    NghiQuyetId = table.Column<Guid>(nullable: false),
                    CongTrinhId = table.Column<Guid>(nullable: false),
                    LuyKeVonNamTruoc = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachVonDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachVonDauNamDuocDuyet = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhTang = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhGiam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachVonDieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachVonDieuChinhDuocDuyet = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    GhiChuSoDauNam = table.Column<string>(nullable: true),
                    GhiChuUyBanDauNam = table.Column<string>(nullable: true),
                    GhiChuSoDieuChinh = table.Column<string>(nullable: true),
                    GhiChuUyBanDieuChinh = table.Column<string>(nullable: true),
                    StringKeHoachVonDauNam = table.Column<string>(nullable: true),
                    StringKeHoachVonDauNamDuocDuyet = table.Column<string>(nullable: true),
                    StringDieuChinhTang = table.Column<string>(nullable: true),
                    StringDieuChinhGiam = table.Column<string>(nullable: true),
                    StringKeHoachVonDieuChinh = table.Column<string>(nullable: true),
                    StringKeHoachVonDieuChinhDuocDuyet = table.Column<string>(nullable: true),
                    IsSelectDieuChinh = table.Column<bool>(nullable: false, defaultValue: false),
                    IsDeleteDieuChinh = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeHoachVonNQChiTiets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeHoachVonNQs",
                schema: "von",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<Guid>(nullable: false),
                    Nam = table.Column<int>(nullable: false),
                    KeHoachVonDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachVonDauNamDuocDuyet = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachVonDieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachVonDieuChinhDuocDuyet = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    TrangThaiDauNam = table.Column<string>(maxLength: 255, nullable: false, defaultValue: ""),
                    TrangThaiDieuChinh = table.Column<string>(maxLength: 255, nullable: false, defaultValue: ""),
                    NgayBanHanhDauNam = table.Column<DateTime>(nullable: true),
                    NgayBanHanhDieuChinh = table.Column<DateTime>(nullable: true),
                    SoQuyetDinhDauNam = table.Column<string>(maxLength: 255, nullable: true),
                    SoQuyetDinhDieuChinh = table.Column<string>(maxLength: 255, nullable: true),
                    DinhKemFileDauNam = table.Column<string>(maxLength: 500, nullable: true),
                    DinhKemFileDieuChinh = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeHoachVonNQs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeHoachVonNQChiTiets",
                schema: "von");

            migrationBuilder.DropTable(
                name: "KeHoachVonNQs",
                schema: "von");
        }
    }
}
