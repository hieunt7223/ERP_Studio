using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.HoSoCongTrinh.Migrations
{
    public partial class InitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "hsct");

            migrationBuilder.CreateTable(
                name: "HoSoCongTrinhChiTietLoaiGoiThaus",
                schema: "hsct",
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
                    OrderIndex = table.Column<int>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    TenLoaiGoiThau = table.Column<string>(maxLength: 500, nullable: false),
                    MoTa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoCongTrinhChiTietLoaiGoiThaus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoSoCongTrinhs",
                schema: "hsct",
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
                    OrderIndex = table.Column<int>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    CongTrinhId = table.Column<Guid>(nullable: false),
                    LoaiHoSoId = table.Column<Guid>(nullable: false),
                    ChuDauTuId = table.Column<Guid>(nullable: false),
                    TrangThai = table.Column<int>(maxLength: 255, nullable: false),
                    HanXuLy = table.Column<DateTime>(nullable: false),
                    SoLanDieuChinh = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoCongTrinhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoSoCongTrinhChiTiets",
                schema: "hsct",
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
                    OrderIndex = table.Column<int>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    HoSoCongTrinhId = table.Column<Guid>(nullable: false),
                    SoLanDieuChinh = table.Column<int>(nullable: false, defaultValue: 0),
                    SuCanThietDauTu = table.Column<string>(nullable: true),
                    QuyMoDauTu = table.Column<string>(nullable: true),
                    NguonVonDauTu = table.Column<string>(nullable: true),
                    TrangThai = table.Column<int>(maxLength: 255, nullable: false),
                    HanXuLy = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoCongTrinhChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoCongTrinhChiTiets_HoSoCongTrinhs_HoSoCongTrinhId",
                        column: x => x.HoSoCongTrinhId,
                        principalSchema: "hsct",
                        principalTable: "HoSoCongTrinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoSoCongTrinhChiTietCoSoPhapLys",
                schema: "hsct",
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
                    OrderIndex = table.Column<int>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    HoSoCongTrinhChiTietId = table.Column<Guid>(nullable: false),
                    ThuVienVanBanId = table.Column<Guid>(nullable: true),
                    NoiDungJson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoCongTrinhChiTietCoSoPhapLys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoCongTrinhChiTietCoSoPhapLys_HoSoCongTrinhChiTiets_HoSoCongTrinhChiTietId",
                        column: x => x.HoSoCongTrinhChiTietId,
                        principalSchema: "hsct",
                        principalTable: "HoSoCongTrinhChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoSoCongTrinhChiTietDiaDiems",
                schema: "hsct",
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
                    OrderIndex = table.Column<int>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    HoSoCongTrinhChiTietId = table.Column<Guid>(nullable: false),
                    DonViHanhChinhId = table.Column<Guid>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoCongTrinhChiTietDiaDiems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoCongTrinhChiTietDiaDiems_HoSoCongTrinhChiTiets_HoSoCongTrinhChiTietId",
                        column: x => x.HoSoCongTrinhChiTietId,
                        principalSchema: "hsct",
                        principalTable: "HoSoCongTrinhChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoSoCongTrinhChiTietGoiThaus",
                schema: "hsct",
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
                    OrderIndex = table.Column<int>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    HoSoCongTrinhChiTietId = table.Column<Guid>(nullable: false),
                    HoSoCongTrinhChiTietLoaiGoiThauId = table.Column<Guid>(nullable: false),
                    TenGoiThau = table.Column<string>(maxLength: 500, nullable: false),
                    DonViThucHien = table.Column<string>(maxLength: 500, nullable: true),
                    GiaDuToan = table.Column<decimal>(nullable: false),
                    NguonVonId = table.Column<Guid>(nullable: true),
                    HinhThucLuaChonNhaThauId = table.Column<Guid>(nullable: true),
                    PhuongThucDauThauId = table.Column<Guid>(nullable: true),
                    ThoiGianBatDau = table.Column<DateTime>(nullable: true),
                    HinhThucHopDongId = table.Column<Guid>(nullable: true),
                    ThoiGianThucHien = table.Column<DateTime>(nullable: true),
                    GiaGoiThau = table.Column<decimal>(nullable: false),
                    HeSoGiam = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoCongTrinhChiTietGoiThaus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoCongTrinhChiTietGoiThaus_HoSoCongTrinhChiTiets_HoSoCongTrinhChiTietId",
                        column: x => x.HoSoCongTrinhChiTietId,
                        principalSchema: "hsct",
                        principalTable: "HoSoCongTrinhChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoSoCongTrinhChiTietGoiThaus_HoSoCongTrinhChiTietLoaiGoiThaus_HoSoCongTrinhChiTietLoaiGoiThauId",
                        column: x => x.HoSoCongTrinhChiTietLoaiGoiThauId,
                        principalSchema: "hsct",
                        principalTable: "HoSoCongTrinhChiTietLoaiGoiThaus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoSoCongTrinhChiTietKetQuaThamDinhs",
                schema: "hsct",
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
                    OrderIndex = table.Column<int>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    HoSoCongTrinhChiTietId = table.Column<Guid>(nullable: false),
                    FileId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoCongTrinhChiTietKetQuaThamDinhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoCongTrinhChiTietKetQuaThamDinhs_HoSoCongTrinhChiTiets_HoSoCongTrinhChiTietId",
                        column: x => x.HoSoCongTrinhChiTietId,
                        principalSchema: "hsct",
                        principalTable: "HoSoCongTrinhChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoSoCongTrinhChiTietMucDauTus",
                schema: "hsct",
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
                    OrderIndex = table.Column<int>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    HoSoCongTrinhChiTietId = table.Column<Guid>(nullable: false),
                    ChiPhiDauTuId = table.Column<Guid>(nullable: false),
                    SoTien = table.Column<decimal>(nullable: false),
                    SoTienThamDinh = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoCongTrinhChiTietMucDauTus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoCongTrinhChiTietMucDauTus_HoSoCongTrinhChiTiets_HoSoCongTrinhChiTietId",
                        column: x => x.HoSoCongTrinhChiTietId,
                        principalSchema: "hsct",
                        principalTable: "HoSoCongTrinhChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoSoCongTrinhChiTietNoiDungYeuCaus",
                schema: "hsct",
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
                    OrderIndex = table.Column<int>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    HoSoCongTrinhChiTietId = table.Column<Guid>(nullable: false),
                    NoiDung = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoCongTrinhChiTietNoiDungYeuCaus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoCongTrinhChiTietNoiDungYeuCaus_HoSoCongTrinhChiTiets_HoSoCongTrinhChiTietId",
                        column: x => x.HoSoCongTrinhChiTietId,
                        principalSchema: "hsct",
                        principalTable: "HoSoCongTrinhChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoSoCongTrinhChiTietThanhPhanHoSos",
                schema: "hsct",
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
                    OrderIndex = table.Column<int>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    HoSoCongTrinhChiTietId = table.Column<Guid>(nullable: false),
                    ThanhPhanHoSoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoCongTrinhChiTietThanhPhanHoSos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoCongTrinhChiTietThanhPhanHoSos_HoSoCongTrinhChiTiets_HoSoCongTrinhChiTietId",
                        column: x => x.HoSoCongTrinhChiTietId,
                        principalSchema: "hsct",
                        principalTable: "HoSoCongTrinhChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoSoCongTrinhChiTietGoiThauFiles",
                schema: "hsct",
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
                    OrderIndex = table.Column<int>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    HoSoCongTrinhChiTietGoiThauId = table.Column<Guid>(nullable: false),
                    FileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoCongTrinhChiTietGoiThauFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoCongTrinhChiTietGoiThauFiles_HoSoCongTrinhChiTietGoiThaus_HoSoCongTrinhChiTietGoiThauId",
                        column: x => x.HoSoCongTrinhChiTietGoiThauId,
                        principalSchema: "hsct",
                        principalTable: "HoSoCongTrinhChiTietGoiThaus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoSoCongTrinhChiTietThanhPhanHoSoFiles",
                schema: "hsct",
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
                    OrderIndex = table.Column<int>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    HoSoCongTrinhChiTietThanhPhanHoSoId = table.Column<Guid>(nullable: false),
                    FileId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoCongTrinhChiTietThanhPhanHoSoFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoCongTrinhChiTietThanhPhanHoSoFiles_HoSoCongTrinhChiTietThanhPhanHoSos_HoSoCongTrinhChiTietThanhPhanHoSoId",
                        column: x => x.HoSoCongTrinhChiTietThanhPhanHoSoId,
                        principalSchema: "hsct",
                        principalTable: "HoSoCongTrinhChiTietThanhPhanHoSos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoSoCongTrinhChiTietCoSoPhapLys_HoSoCongTrinhChiTietId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietCoSoPhapLys",
                column: "HoSoCongTrinhChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoCongTrinhChiTietDiaDiems_HoSoCongTrinhChiTietId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietDiaDiems",
                column: "HoSoCongTrinhChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoCongTrinhChiTietGoiThauFiles_HoSoCongTrinhChiTietGoiThauId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThauFiles",
                column: "HoSoCongTrinhChiTietGoiThauId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoCongTrinhChiTietGoiThaus_HoSoCongTrinhChiTietId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                column: "HoSoCongTrinhChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoCongTrinhChiTietGoiThaus_HoSoCongTrinhChiTietLoaiGoiThauId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                column: "HoSoCongTrinhChiTietLoaiGoiThauId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoCongTrinhChiTietKetQuaThamDinhs_HoSoCongTrinhChiTietId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietKetQuaThamDinhs",
                column: "HoSoCongTrinhChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoCongTrinhChiTietMucDauTus_HoSoCongTrinhChiTietId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietMucDauTus",
                column: "HoSoCongTrinhChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoCongTrinhChiTietNoiDungYeuCaus_HoSoCongTrinhChiTietId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietNoiDungYeuCaus",
                column: "HoSoCongTrinhChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoCongTrinhChiTiets_HoSoCongTrinhId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                column: "HoSoCongTrinhId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoCongTrinhChiTietThanhPhanHoSoFiles_HoSoCongTrinhChiTietThanhPhanHoSoId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSoFiles",
                column: "HoSoCongTrinhChiTietThanhPhanHoSoId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoCongTrinhChiTietThanhPhanHoSos_HoSoCongTrinhChiTietId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos",
                column: "HoSoCongTrinhChiTietId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoSoCongTrinhChiTietCoSoPhapLys",
                schema: "hsct");

            migrationBuilder.DropTable(
                name: "HoSoCongTrinhChiTietDiaDiems",
                schema: "hsct");

            migrationBuilder.DropTable(
                name: "HoSoCongTrinhChiTietGoiThauFiles",
                schema: "hsct");

            migrationBuilder.DropTable(
                name: "HoSoCongTrinhChiTietKetQuaThamDinhs",
                schema: "hsct");

            migrationBuilder.DropTable(
                name: "HoSoCongTrinhChiTietMucDauTus",
                schema: "hsct");

            migrationBuilder.DropTable(
                name: "HoSoCongTrinhChiTietNoiDungYeuCaus",
                schema: "hsct");

            migrationBuilder.DropTable(
                name: "HoSoCongTrinhChiTietThanhPhanHoSoFiles",
                schema: "hsct");

            migrationBuilder.DropTable(
                name: "HoSoCongTrinhChiTietGoiThaus",
                schema: "hsct");

            migrationBuilder.DropTable(
                name: "HoSoCongTrinhChiTietThanhPhanHoSos",
                schema: "hsct");

            migrationBuilder.DropTable(
                name: "HoSoCongTrinhChiTietLoaiGoiThaus",
                schema: "hsct");

            migrationBuilder.DropTable(
                name: "HoSoCongTrinhChiTiets",
                schema: "hsct");

            migrationBuilder.DropTable(
                name: "HoSoCongTrinhs",
                schema: "hsct");
        }
    }
}
