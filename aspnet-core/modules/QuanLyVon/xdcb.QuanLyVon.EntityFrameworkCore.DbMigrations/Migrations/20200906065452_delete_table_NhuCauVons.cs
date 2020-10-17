using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class delete_table_NhuCauVons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhuCauVons",
                schema: "von");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhuCauVons",
                schema: "von",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CongTrinhId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DenNam = table.Column<int>(type: "int", nullable: false),
                    DieuChinhGiamNSTWDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhGiamNTSDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhGiamODADauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhTangNSTWDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhTangNTSDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DieuChinhTangODADauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    DonViBaoCaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChuChuyenVienDauNam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChuChuyenVienDieuChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChuDauNam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChuDieuChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaiDoanNam = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LuyKeKhoiLuongNamTruocNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    LuyKeKhoiLuongNamTruocNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    LuyKeKhoiLuongNamTruocODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    LuyKeVonNamTruocNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    LuyKeVonNamTruocNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    LuyKeVonNamTruocODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    MucDauTuNST = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    MucDauTuNSTW = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    MucDauTuODA = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NgayBanHanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NhuCauKeHoachVonNSTWDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauKeHoachVonNSTWDieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauKeHoachVonNTSDauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauKeHoachVonNTSDieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauKeHoachVonODADauNam = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    NhuCauKeHoachVonODADieuChinh = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    SoQuyetDinh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TongMucDauTu = table.Column<decimal>(type: "decimal(22,6)", nullable: false, defaultValue: 0m),
                    TuNam = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhuCauVons", x => x.Id);
                });
        }
    }
}
