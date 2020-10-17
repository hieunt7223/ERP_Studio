using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class dbvon3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhuCauVons",
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
                    CongTrinhId = table.Column<Guid>(nullable: false),
                    Nam = table.Column<int>(nullable: false),
                    GiaiDoanNam = table.Column<string>(maxLength: 255, nullable: true),
                    SoQuyetDinh = table.Column<string>(maxLength: 255, nullable: true),
                    DonViBaoCaoId = table.Column<Guid>(nullable: false),
                    NgayBanHanh = table.Column<DateTime>(nullable: false),
                    TongMucDauTu = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    MucDauTuNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    MucDauTuNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    MucDauTuODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    LuyKeKhoiLuongNamTruocNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    LuyKeKhoiLuongNamTruocNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    LuyKeKhoiLuongNamTruocODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    LuyKeVonNamTruocNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    LuyKeVonNamTruocNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    LuyKeVonNamTruocODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauKeHoachVonNTSDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauKeHoachVonNSTWDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauKeHoachVonODADauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauKeHoachVonTrungHanNTSDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauKeHoachVonTrungHanNSTWDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauKeHoachVonTrungHanODADauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhGiamNTSDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhGiamNSTWDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhGiamODADauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhTangNTSDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhTangNSTWDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhTangODADauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauKeHoachVonNTSDieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauKeHoachVonNSTWDieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauKeHoachVonODADieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhGiamNTSDieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhGiamNSTWDieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhGiamODADieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhTangNTSDieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhTangNSTWDieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhTangODADieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauKeHoachVonTrungHanNTSDieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauKeHoachVonTrungHanNSTWDieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauKeHoachVonTrungHanODADieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    GhiChuDauNam = table.Column<string>(nullable: true),
                    GhiChuChuyenVienDauNam = table.Column<string>(nullable: true),
                    GhiChuDieuChinh = table.Column<string>(nullable: true),
                    GhiChuChuyenVienDieuChinh = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhuCauVons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhuCauVons",
                schema: "von");
        }
    }
}
