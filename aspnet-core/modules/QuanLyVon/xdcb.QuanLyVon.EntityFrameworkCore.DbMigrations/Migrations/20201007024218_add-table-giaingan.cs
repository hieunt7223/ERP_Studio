using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class addtablegiaingan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GiaiNganChiTiets",
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
                    GiaiNganId = table.Column<Guid>(nullable: false),
                    LoaiKhoanId = table.Column<Guid>(nullable: false),
                    LoaiCongTrinhId = table.Column<Guid>(nullable: false),
                    CongTrinhId = table.Column<Guid>(nullable: false),
                    KeHoachVonNSTChiTietId = table.Column<Guid>(nullable: false),
                    KeHoachVonNSTWChiTietId = table.Column<Guid>(nullable: false),
                    LuyKeVonNamNayNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    LuyKeGiaiNganNamNayNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachVonNamTruocKeoDaiNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachVonNamNayNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KhoiLuongThucHienNamNayNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    GiaiNganNamNayNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    GiaiNganNamTruocKeoDaiNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    GhiChuNST = table.Column<string>(nullable: true),
                    GhiChuChuyenVienNST = table.Column<string>(nullable: true),
                    IsSelectNST = table.Column<bool>(nullable: false, defaultValue: false),
                    LuyKeVonNamNayNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    LuyKeGiaiNganNamNayNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachVonNamTruocKeoDaiNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachVonNamNayNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KhoiLuongThucHienNamNayNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    GiaiNganNamNayNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    GiaiNganNamTruocKeoDaiNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    GhiChuNSTW = table.Column<string>(nullable: true),
                    GhiChuChuyenVienNSTW = table.Column<string>(nullable: true),
                    IsSelectNSTW = table.Column<bool>(nullable: false, defaultValue: false),
                    LuyKeVonNamNayODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    LuyKeGiaiNganNamNayODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachVonNamTruocKeoDaiODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KeHoachVonNamNayODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    KhoiLuongThucHienNamNayODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    GiaiNganNamNayODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    GiaiNganNamTruocKeoDaiODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    GhiChuODA = table.Column<string>(nullable: true),
                    GhiChuChuyenVienODA = table.Column<string>(nullable: true),
                    IsSelectODA = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSelectDieuChinh = table.Column<bool>(nullable: false, defaultValue: false),
                    IsDeleteDieuChinh = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaiNganChiTiets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiaiNgans",
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
                    QuyThang = table.Column<int>(nullable: false),
                    ChuDauTuId = table.Column<Guid>(nullable: false),
                    IsKeHoachKeoDai = table.Column<bool>(nullable: false, defaultValue: false),
                    TenKeHoach = table.Column<string>(maxLength: 255, nullable: true, defaultValue: ""),
                    TrangThai = table.Column<string>(maxLength: 255, nullable: true, defaultValue: ""),
                    TongGiaiNgan = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NgayGui = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaiNgans", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiaiNganChiTiets",
                schema: "von");

            migrationBuilder.DropTable(
                name: "GiaiNgans",
                schema: "von");
        }
    }
}
