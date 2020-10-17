using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class dbvon8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhuCauKeHoachVonChiTiets",
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
                    NhuCauKeHoachVonID = table.Column<Guid>(nullable: false),
                    CongTrinhID = table.Column<Guid>(nullable: false),
                    LuyKeKhoiLuongNamTruocNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    LuyKeVonNamTruocNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauVonDauNamNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhGiamNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhTangNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauVonDieuChinhNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    GhiChuDauNamNST = table.Column<string>(nullable: true),
                    GhiChuDieuChinhNST = table.Column<string>(nullable: true),
                    GhiChuChuyenVienDauNamNST = table.Column<string>(nullable: true),
                    GhiChuChuyenVienDieuChinhNST = table.Column<string>(nullable: true),
                    IsSelectNST = table.Column<bool>(nullable: false, defaultValue: false),
                    LuyKeKhoiLuongNamTruocNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    LuyKeVonNamTruocNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauVonDauNamNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhGiamNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhTangNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauVonDieuChinhNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    GhiChuDauNamNSTW = table.Column<string>(nullable: true),
                    GhiChuDieuChinhNSTW = table.Column<string>(nullable: true),
                    GhiChuChuyenVienDauNamNSTW = table.Column<string>(nullable: true),
                    GhiChuChuyenVienDieuChinhNSTW = table.Column<string>(nullable: true),
                    IsSelectNSTW = table.Column<bool>(nullable: false, defaultValue: false),
                    LuyKeKhoiLuongNamTruocODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    LuyKeVonNamTruocODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauVonDauNamODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhGiamODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhTangODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauVonDieuChinhODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    GhiChuDauNamODA = table.Column<string>(nullable: true),
                    GhiChuDieuChinhODA = table.Column<string>(nullable: true),
                    GhiChuChuyenVienDauNamODA = table.Column<string>(nullable: true),
                    GhiChuChuyenVienDieuChinhODA = table.Column<string>(nullable: true),
                    IsSelectODA = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSelect = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhuCauKeHoachVonChiTiets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhuCauKeHoachVons",
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
                    TuNam = table.Column<int>(nullable: false),
                    DenNam = table.Column<int>(nullable: false),
                    GiaiDoanNam = table.Column<string>(nullable: false),
                    ChuDauTuID = table.Column<Guid>(nullable: false),
                    TenKeHoach = table.Column<string>(maxLength: 255, nullable: true, defaultValue: ""),
                    TrangThaiDauNam = table.Column<string>(maxLength: 255, nullable: true, defaultValue: ""),
                    TrangThaiDieuChinh = table.Column<string>(maxLength: 255, nullable: true, defaultValue: ""),
                    TongNhuCauVonDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    TongNhuCauVonDieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhuCauKeHoachVons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhuCauKeHoachVonChiTiets",
                schema: "von");

            migrationBuilder.DropTable(
                name: "NhuCauKeHoachVons",
                schema: "von");
        }
    }
}
