using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class InitCommon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "common");

            migrationBuilder.CreateTable(
                name: "ChiPhiDauTus",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    TenChiPhi = table.Column<string>(maxLength: 255, nullable: false),
                    LoaiChiPhi = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiPhiDauTus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChucVus",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    MaChucVu = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    TenChucVu = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChuDauTus",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    MaSoChuong = table.Column<string>(maxLength: 10, nullable: true),
                    Ten = table.Column<string>(maxLength: 255, nullable: false),
                    DiaChi = table.Column<string>(maxLength: 255, nullable: true),
                    SoDienThoai = table.Column<string>(maxLength: 15, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(maxLength: 255, nullable: true),
                    NguoiDaiDien = table.Column<string>(maxLength: 150, nullable: true),
                    SDTNguoiDaiDien = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuDauTus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChuongTrinhMucTieuQuocGias",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    MaChuongTrinhMucTieuQuocGia = table.Column<string>(maxLength: 255, nullable: false),
                    TenChuongTrinhMucTieuQuocGia = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuongTrinhMucTieuQuocGias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonViHanhChinhs",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    MaDonViHanhChinh = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    TenDonViHanhChinh = table.Column<string>(maxLength: 255, nullable: false),
                    CapDonViHanhChinh = table.Column<int>(nullable: false),
                    ThuocCapDonViHanhChinh = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViHanhChinhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoUuTiens",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    MaDoUuTien = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    TenDoUuTien = table.Column<string>(maxLength: 255, nullable: false),
                    MoTa = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoUuTiens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HangMucCongTrinhs",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    MaHangMuc = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    TenHangMuc = table.Column<string>(maxLength: 255, nullable: false),
                    MoTa = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangMucCongTrinhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HinhThucChonNhaThaus",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    TenHinhThucChonNhaThau = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhThucChonNhaThaus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HinhThucHopDongs",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    TenHinhThucHopDong = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhThucHopDongs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhoanChis",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    MaKhoanChi = table.Column<string>(maxLength: 10, nullable: true),
                    TenKhoanChi = table.Column<string>(maxLength: 255, nullable: false),
                    GhiChu = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoanChis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinhVucVanBans",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    MaLinhVuc = table.Column<string>(maxLength: 10, nullable: true),
                    TenLinhVuc = table.Column<string>(maxLength: 256, nullable: false),
                    MoTa = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhVucVanBans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loai_Khoans",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    LoaiLoaiKhoan = table.Column<int>(nullable: false),
                    MaSo = table.Column<int>(nullable: false),
                    TenLoaiKhoan = table.Column<string>(maxLength: 255, nullable: false),
                    GhiChu = table.Column<string>(maxLength: 255, nullable: true),
                    LoaiKhoanChaID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loai_Khoans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiCongTrinhs",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    MaLoaiCongTrinh = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    TenLoaiCongTrinh = table.Column<string>(maxLength: 255, nullable: false),
                    MoTa = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiCongTrinhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiVanBans",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    MaLoaiVanBan = table.Column<string>(maxLength: 10, nullable: true),
                    TenLoaiVanBan = table.Column<string>(maxLength: 255, nullable: false),
                    MoTa = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiVanBans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NghiQuyets",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    SoVanBan = table.Column<string>(maxLength: 10, nullable: true),
                    NgayBanHanh = table.Column<DateTime>(nullable: false),
                    TrichYeu = table.Column<string>(maxLength: 196, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NghiQuyets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguonVons",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    MaNguonVon = table.Column<string>(maxLength: 10, nullable: true),
                    TenNguonVon = table.Column<string>(maxLength: 255, nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    ThuTuHienThi = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguonVons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhomCongTrinhs",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    MaNhomCongTrinh = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    TenNhomCongTrinh = table.Column<string>(maxLength: 255, nullable: false),
                    MoTa = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhomCongTrinhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhuongThucDauThaus",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    TenPhuongThucDauThau = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuongThucDauThaus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhongBans",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    ChuDauTuId = table.Column<Guid>(nullable: false),
                    MaPhongBan = table.Column<string>(maxLength: 10, nullable: false),
                    TenPhongBan = table.Column<string>(maxLength: 100, nullable: false),
                    ChucNangNhiemVu = table.Column<string>(maxLength: 255, nullable: true),
                    SoDienThoai = table.Column<string>(maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhongBans_ChuDauTus_ChuDauTuId",
                        column: x => x.ChuDauTuId,
                        principalSchema: "common",
                        principalTable: "ChuDauTus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThanhPhanHoSos",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    TenThanhPhanHoSo = table.Column<string>(maxLength: 256, nullable: false),
                    LoaiVanBanId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhPhanHoSos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThanhPhanHoSos_LoaiVanBans_LoaiVanBanId",
                        column: x => x.LoaiVanBanId,
                        principalSchema: "common",
                        principalTable: "LoaiVanBans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThuVienVanBans",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    SoVanBan = table.Column<string>(maxLength: 50, nullable: false),
                    KyHieuVanBan = table.Column<string>(maxLength: 50, nullable: false),
                    LinhVucVanBanId = table.Column<Guid>(nullable: true),
                    LoaiVanBanId = table.Column<Guid>(nullable: false),
                    TrichYeu = table.Column<string>(maxLength: 500, nullable: true),
                    CapBanHanh = table.Column<int>(nullable: false),
                    DonViBanHanh = table.Column<string>(maxLength: 50, nullable: false),
                    NguoiKy = table.Column<string>(maxLength: 50, nullable: true),
                    NgayBanHanh = table.Column<DateTime>(nullable: false),
                    NgayHieuLuc = table.Column<DateTime>(nullable: true),
                    NgayHetHieuLuc = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuVienVanBans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThuVienVanBans_LinhVucVanBans_LinhVucVanBanId",
                        column: x => x.LinhVucVanBanId,
                        principalSchema: "common",
                        principalTable: "LinhVucVanBans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThuVienVanBans_LoaiVanBans_LoaiVanBanId",
                        column: x => x.LoaiVanBanId,
                        principalSchema: "common",
                        principalTable: "LoaiVanBans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileCuaThuVienVanBans",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    ThuVienVanBanId = table.Column<Guid>(nullable: false),
                    FileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileCuaThuVienVanBans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileCuaThuVienVanBans_ThuVienVanBans_ThuVienVanBanId",
                        column: x => x.ThuVienVanBanId,
                        principalSchema: "common",
                        principalTable: "ThuVienVanBans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileCuaThuVienVanBans_ThuVienVanBanId",
                schema: "common",
                table: "FileCuaThuVienVanBans",
                column: "ThuVienVanBanId");

            migrationBuilder.CreateIndex(
                name: "IX_PhongBans_ChuDauTuId",
                schema: "common",
                table: "PhongBans",
                column: "ChuDauTuId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhPhanHoSos_LoaiVanBanId",
                schema: "common",
                table: "ThanhPhanHoSos",
                column: "LoaiVanBanId");

            migrationBuilder.CreateIndex(
                name: "IX_ThuVienVanBans_LinhVucVanBanId",
                schema: "common",
                table: "ThuVienVanBans",
                column: "LinhVucVanBanId");

            migrationBuilder.CreateIndex(
                name: "IX_ThuVienVanBans_LoaiVanBanId",
                schema: "common",
                table: "ThuVienVanBans",
                column: "LoaiVanBanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiPhiDauTus",
                schema: "common");

            migrationBuilder.DropTable(
                name: "ChucVus",
                schema: "common");

            migrationBuilder.DropTable(
                name: "ChuongTrinhMucTieuQuocGias",
                schema: "common");

            migrationBuilder.DropTable(
                name: "DonViHanhChinhs",
                schema: "common");

            migrationBuilder.DropTable(
                name: "DoUuTiens",
                schema: "common");

            migrationBuilder.DropTable(
                name: "FileCuaThuVienVanBans",
                schema: "common");

            migrationBuilder.DropTable(
                name: "HangMucCongTrinhs",
                schema: "common");

            migrationBuilder.DropTable(
                name: "HinhThucChonNhaThaus",
                schema: "common");

            migrationBuilder.DropTable(
                name: "HinhThucHopDongs",
                schema: "common");

            migrationBuilder.DropTable(
                name: "KhoanChis",
                schema: "common");

            migrationBuilder.DropTable(
                name: "Loai_Khoans",
                schema: "common");

            migrationBuilder.DropTable(
                name: "LoaiCongTrinhs",
                schema: "common");

            migrationBuilder.DropTable(
                name: "NghiQuyets",
                schema: "common");

            migrationBuilder.DropTable(
                name: "NguonVons",
                schema: "common");

            migrationBuilder.DropTable(
                name: "NhomCongTrinhs",
                schema: "common");

            migrationBuilder.DropTable(
                name: "PhongBans",
                schema: "common");

            migrationBuilder.DropTable(
                name: "PhuongThucDauThaus",
                schema: "common");

            migrationBuilder.DropTable(
                name: "ThanhPhanHoSos",
                schema: "common");

            migrationBuilder.DropTable(
                name: "ThuVienVanBans",
                schema: "common");

            migrationBuilder.DropTable(
                name: "ChuDauTus",
                schema: "common");

            migrationBuilder.DropTable(
                name: "LinhVucVanBans",
                schema: "common");

            migrationBuilder.DropTable(
                name: "LoaiVanBans",
                schema: "common");
        }
    }
}
