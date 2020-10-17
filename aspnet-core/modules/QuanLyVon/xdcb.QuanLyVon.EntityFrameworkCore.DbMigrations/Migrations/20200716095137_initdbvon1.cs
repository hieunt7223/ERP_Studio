using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class initdbvon1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "von");

            migrationBuilder.CreateTable(
                name: "KeHoachTongNguonChiTiets",
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
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    KeHoachTongNguonId = table.Column<Guid>(nullable: false),
                    NguonVonId = table.Column<Guid>(nullable: false),
                    NguonVonChaId = table.Column<Guid>(nullable: false),
                    TenNguonVon = table.Column<string>(maxLength: 255, nullable: true),
                    KeHoachDauNamTruoc = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachBoSungNamTruoc = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachDauNamDuocDuyet = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhTang = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhGiam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachBoSung = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachBoSungDuocDuyet = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    GhiChuSo = table.Column<string>(nullable: true),
                    GhiChuUyBan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeHoachTongNguonChiTiets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeHoachTongNguons",
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
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    Nam = table.Column<int>(nullable: false),
                    NgayQuyetDinhDauNam = table.Column<DateTime>(nullable: true),
                    NgayQuyetDinhDieuChinh = table.Column<DateTime>(nullable: true),
                    SoQuyetDinhDauNam = table.Column<string>(maxLength: 255, nullable: true),
                    SoQuyetDinhDieuChinh = table.Column<string>(maxLength: 255, nullable: true),
                    KeHoachDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachDauNamDuocDuyet = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachSauBoSung = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachSauBoSungDuocDuyet = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    TrangThaiDauNam = table.Column<string>(maxLength: 255, nullable: false, defaultValue: ""),
                    TrangThaiDieuChinh = table.Column<string>(maxLength: 255, nullable: false, defaultValue: ""),
                    DinhKemFileDauNam = table.Column<string>(maxLength: 500, nullable: true),
                    DinhKemFileDieuChinh = table.Column<string>(maxLength: 500, nullable: true),
                    GhiChuDauNam = table.Column<string>(nullable: true),
                    GhiChuDieuChinh = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeHoachTongNguons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeHoachTongNguonChiTiets",
                schema: "von");

            migrationBuilder.DropTable(
                name: "KeHoachTongNguons",
                schema: "von");
        }
    }
}
