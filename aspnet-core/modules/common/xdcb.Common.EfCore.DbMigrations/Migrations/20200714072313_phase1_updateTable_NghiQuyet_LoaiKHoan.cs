using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class phase1_updateTable_NghiQuyet_LoaiKHoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "ThuVienVanBans",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "ThanhPhanHoSos",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "PhuongThucDauThaus",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "PhongBans",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "NhomCongTrinhs",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "NguonVons",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SoVanBan",
                schema: "common",
                table: "NghiQuyets",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayBanHanh",
                schema: "common",
                table: "NghiQuyets",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "NghiQuyets",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "LoaiVanBans",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "LoaiCongTrinhs",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaSo",
                schema: "common",
                table: "Loai_Khoans",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "Loai_Khoans",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "LinhVucVanBans",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "KhoanChis",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "HinhThucHopDongs",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "HinhThucChonNhaThaus",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "HangMucCongTrinhs",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "FileCuaThuVienVanBans",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "DoUuTiens",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "DonViHanhChinhs",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "ChuongTrinhMucTieuQuocGias",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "ChuDauTus",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "ChucVus",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "ChiPhiDauTus",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CongTrinhs",
                schema: "common",
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
                    ChuDauTuId = table.Column<Guid>(nullable: true),
                    MaCongTrinh = table.Column<string>(maxLength: 10, nullable: false),
                    TenCongTrinh = table.Column<string>(maxLength: 500, nullable: false),
                    NhomCongTrinhId = table.Column<Guid>(nullable: true),
                    MaSoDuAn = table.Column<string>(nullable: true),
                    LoaiKhoanId = table.Column<Guid>(nullable: true),
                    CTMTQuocGiaId = table.Column<Guid>(nullable: true),
                    LoaiCongTrinhId = table.Column<Guid>(nullable: true),
                    DienTich = table.Column<double>(nullable: true),
                    ThoiGianThucHienTuNgay = table.Column<DateTime>(nullable: true),
                    ThoiGianThucHienDenNgay = table.Column<DateTime>(nullable: true),
                    SoQuyetDinhDauTu = table.Column<string>(maxLength: 50, nullable: true),
                    NgayQuyetDinhDauTu = table.Column<DateTime>(nullable: true),
                    TongMucDauTu = table.Column<decimal>(nullable: true),
                    ChuongTrinhMucTieuQuocGiaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongTrinhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CongTrinhs_ChuDauTus_ChuDauTuId",
                        column: x => x.ChuDauTuId,
                        principalSchema: "common",
                        principalTable: "ChuDauTus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CongTrinhs_ChuongTrinhMucTieuQuocGias_ChuongTrinhMucTieuQuocGiaId",
                        column: x => x.ChuongTrinhMucTieuQuocGiaId,
                        principalSchema: "common",
                        principalTable: "ChuongTrinhMucTieuQuocGias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CongTrinhs_LoaiCongTrinhs_LoaiCongTrinhId",
                        column: x => x.LoaiCongTrinhId,
                        principalSchema: "common",
                        principalTable: "LoaiCongTrinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CongTrinhs_Loai_Khoans_LoaiKhoanId",
                        column: x => x.LoaiKhoanId,
                        principalSchema: "common",
                        principalTable: "Loai_Khoans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CongTrinhs_NhomCongTrinhs_NhomCongTrinhId",
                        column: x => x.NhomCongTrinhId,
                        principalSchema: "common",
                        principalTable: "NhomCongTrinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoaiHoSos",
                schema: "common",
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
                    TenLoaiHoSo = table.Column<string>(maxLength: 500, nullable: false),
                    LaDieuChinh = table.Column<bool>(nullable: false),
                    ApDung = table.Column<bool>(nullable: false),
                    BieuMau = table.Column<string>(nullable: true),
                    ThoiGianXuLyQuyDinh = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiHoSos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiaDiemXayDungs",
                schema: "common",
                columns: table => new
                {
                    CongTrinhId = table.Column<Guid>(nullable: false),
                    DonViHanhChinhId = table.Column<Guid>(nullable: false),
                    GhiChu = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaDiemXayDungs", x => new { x.CongTrinhId, x.DonViHanhChinhId });
                    table.ForeignKey(
                        name: "FK_DiaDiemXayDungs_CongTrinhs_CongTrinhId",
                        column: x => x.CongTrinhId,
                        principalSchema: "common",
                        principalTable: "CongTrinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiaDiemXayDungs_DonViHanhChinhs_DonViHanhChinhId",
                        column: x => x.DonViHanhChinhId,
                        principalSchema: "common",
                        principalTable: "DonViHanhChinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoaiHoSoChiPhiDauTus",
                schema: "common",
                columns: table => new
                {
                    LoaiHoSoId = table.Column<Guid>(nullable: false),
                    ChiPhiDauTuId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiHoSoChiPhiDauTus", x => new { x.LoaiHoSoId, x.ChiPhiDauTuId });
                    table.ForeignKey(
                        name: "FK_LoaiHoSoChiPhiDauTus_ChiPhiDauTus_ChiPhiDauTuId",
                        column: x => x.ChiPhiDauTuId,
                        principalSchema: "common",
                        principalTable: "ChiPhiDauTus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoaiHoSoChiPhiDauTus_LoaiHoSos_LoaiHoSoId",
                        column: x => x.LoaiHoSoId,
                        principalSchema: "common",
                        principalTable: "LoaiHoSos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoaiHoSoCoSoPhapLys",
                schema: "common",
                columns: table => new
                {
                    LoaiHoSoId = table.Column<Guid>(nullable: false),
                    ThuVienVanBanId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiHoSoCoSoPhapLys", x => new { x.LoaiHoSoId, x.ThuVienVanBanId });
                    table.ForeignKey(
                        name: "FK_LoaiHoSoCoSoPhapLys_LoaiHoSos_LoaiHoSoId",
                        column: x => x.LoaiHoSoId,
                        principalSchema: "common",
                        principalTable: "LoaiHoSos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoaiHoSoCoSoPhapLys_ThuVienVanBans_ThuVienVanBanId",
                        column: x => x.ThuVienVanBanId,
                        principalSchema: "common",
                        principalTable: "ThuVienVanBans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoaiHoSoThanhPhanHoSos",
                schema: "common",
                columns: table => new
                {
                    LoaiHoSoId = table.Column<Guid>(nullable: false),
                    ThanhPhanHoSoId = table.Column<Guid>(nullable: false),
                    BatBuoc = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiHoSoThanhPhanHoSos", x => new { x.LoaiHoSoId, x.ThanhPhanHoSoId });
                    table.ForeignKey(
                        name: "FK_LoaiHoSoThanhPhanHoSos_LoaiHoSos_LoaiHoSoId",
                        column: x => x.LoaiHoSoId,
                        principalSchema: "common",
                        principalTable: "LoaiHoSos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoaiHoSoThanhPhanHoSos_ThanhPhanHoSos_ThanhPhanHoSoId",
                        column: x => x.ThanhPhanHoSoId,
                        principalSchema: "common",
                        principalTable: "ThanhPhanHoSos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CongTrinhs_ChuDauTuId",
                schema: "common",
                table: "CongTrinhs",
                column: "ChuDauTuId");

            migrationBuilder.CreateIndex(
                name: "IX_CongTrinhs_ChuongTrinhMucTieuQuocGiaId",
                schema: "common",
                table: "CongTrinhs",
                column: "ChuongTrinhMucTieuQuocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_CongTrinhs_LoaiCongTrinhId",
                schema: "common",
                table: "CongTrinhs",
                column: "LoaiCongTrinhId");

            migrationBuilder.CreateIndex(
                name: "IX_CongTrinhs_LoaiKhoanId",
                schema: "common",
                table: "CongTrinhs",
                column: "LoaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_CongTrinhs_NhomCongTrinhId",
                schema: "common",
                table: "CongTrinhs",
                column: "NhomCongTrinhId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiemXayDungs_DonViHanhChinhId",
                schema: "common",
                table: "DiaDiemXayDungs",
                column: "DonViHanhChinhId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHoSoChiPhiDauTus_ChiPhiDauTuId",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                column: "ChiPhiDauTuId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHoSoCoSoPhapLys_ThuVienVanBanId",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                column: "ThuVienVanBanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHoSoThanhPhanHoSos_ThanhPhanHoSoId",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                column: "ThanhPhanHoSoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaDiemXayDungs",
                schema: "common");

            migrationBuilder.DropTable(
                name: "LoaiHoSoChiPhiDauTus",
                schema: "common");

            migrationBuilder.DropTable(
                name: "LoaiHoSoCoSoPhapLys",
                schema: "common");

            migrationBuilder.DropTable(
                name: "LoaiHoSoThanhPhanHoSos",
                schema: "common");

            migrationBuilder.DropTable(
                name: "CongTrinhs",
                schema: "common");

            migrationBuilder.DropTable(
                name: "LoaiHoSos",
                schema: "common");

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "ThuVienVanBans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "ThanhPhanHoSos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "PhuongThucDauThaus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "PhongBans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "NhomCongTrinhs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "NguonVons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SoVanBan",
                schema: "common",
                table: "NghiQuyets",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayBanHanh",
                schema: "common",
                table: "NghiQuyets",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "NghiQuyets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "LoaiVanBans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "LoaiCongTrinhs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaSo",
                schema: "common",
                table: "Loai_Khoans",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "Loai_Khoans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "LinhVucVanBans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "KhoanChis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "HinhThucHopDongs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "HinhThucChonNhaThaus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "HangMucCongTrinhs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "FileCuaThuVienVanBans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "DoUuTiens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "DonViHanhChinhs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "ChuongTrinhMucTieuQuocGias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "ChuDauTus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "ChucVus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "ChiPhiDauTus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);
        }
    }
}
