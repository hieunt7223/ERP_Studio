using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.HoSoCongTrinh.Migrations
{
    public partial class altertable_hosochitiet_hosochitietcongviec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoSoCongTrinhChiTietGoiThaus_HoSoCongTrinhChiTietLoaiGoiThaus_HoSoCongTrinhChiTietLoaiGoiThauId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus");

            migrationBuilder.DropTable(
                name: "HoSoCongTrinhChiTietGoiThauFiles",
                schema: "hsct");

            migrationBuilder.DropTable(
                name: "HoSoCongTrinhChiTietLoaiGoiThaus",
                schema: "hsct");

            migrationBuilder.DropIndex(
                name: "IX_HoSoCongTrinhChiTietGoiThaus_HoSoCongTrinhChiTietLoaiGoiThauId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus");

            migrationBuilder.DropColumn(
                name: "DonViThucHien",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus");

            migrationBuilder.DropColumn(
                name: "GiaDuToan",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus");

            migrationBuilder.DropColumn(
                name: "HeSoGiam",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus");

            migrationBuilder.DropColumn(
                name: "HinhThucHopDongId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus");

            migrationBuilder.DropColumn(
                name: "HoSoCongTrinhChiTietLoaiGoiThauId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus");

            migrationBuilder.DropColumn(
                name: "NguonVonId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus");

            migrationBuilder.DropColumn(
                name: "PhuongThucDauThauId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus");

            migrationBuilder.DropColumn(
                name: "TenGoiThau",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus");

            migrationBuilder.AddColumn<string>(
                name: "DanhGiaCoQuanThamDinh",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KetQuaThamDinhCanCuPhapLys",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TongMucDauTu",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TongMucDuToanDuocDuyet",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "YKienThamDinhCanCuPhapLy",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YKienThamDinhGiaTriCongViec",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YKienThamDinhNoiDungKeHoach",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThoiGianThucHien",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThoiGianBatDau",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GiaGoiThau",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<Guid>(
                name: "GoiThauId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhuongThucLuaChonNhaThauId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HoSoCongTrinhChiTietCongViecs",
                schema: "hsct",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    HoSoCongTrinhChiTietId = table.Column<Guid>(nullable: false),
                    CongViecGoiThauId = table.Column<Guid>(nullable: true),
                    DonViThucHienId = table.Column<Guid>(nullable: true),
                    DonViThucHien = table.Column<string>(nullable: true),
                    GiaTriThucHien = table.Column<decimal>(nullable: false),
                    IsTuanThuPhuHop = table.Column<bool>(nullable: false),
                    LoaiCongViec = table.Column<int>(nullable: false),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoCongTrinhChiTietCongViecs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoCongTrinhChiTietCongViecs_HoSoCongTrinhChiTiets_HoSoCongTrinhChiTietId",
                        column: x => x.HoSoCongTrinhChiTietId,
                        principalSchema: "hsct",
                        principalTable: "HoSoCongTrinhChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoSoCongTrinhChiTietCongViecs_HoSoCongTrinhChiTietId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietCongViecs",
                column: "HoSoCongTrinhChiTietId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoSoCongTrinhChiTietCongViecs",
                schema: "hsct");

            migrationBuilder.DropColumn(
                name: "DanhGiaCoQuanThamDinh",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "KetQuaThamDinhCanCuPhapLys",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "TongMucDauTu",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "TongMucDuToanDuocDuyet",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "YKienThamDinhCanCuPhapLy",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "YKienThamDinhGiaTriCongViec",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "YKienThamDinhNoiDungKeHoach",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "GoiThauId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus");

            migrationBuilder.DropColumn(
                name: "PhuongThucLuaChonNhaThauId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGianThucHien",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGianBatDau",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GiaGoiThau",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DonViThucHien",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GiaDuToan",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "HeSoGiam",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "HinhThucHopDongId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "HoSoCongTrinhChiTietLoaiGoiThauId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NguonVonId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhuongThucDauThauId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenGoiThau",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "HoSoCongTrinhChiTietGoiThauFiles",
                schema: "hsct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoSoCongTrinhChiTietGoiThauId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "HoSoCongTrinhChiTietLoaiGoiThaus",
                schema: "hsct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    TenLoaiGoiThau = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoCongTrinhChiTietLoaiGoiThaus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoSoCongTrinhChiTietGoiThaus_HoSoCongTrinhChiTietLoaiGoiThauId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                column: "HoSoCongTrinhChiTietLoaiGoiThauId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoCongTrinhChiTietGoiThauFiles_HoSoCongTrinhChiTietGoiThauId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThauFiles",
                column: "HoSoCongTrinhChiTietGoiThauId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoSoCongTrinhChiTietGoiThaus_HoSoCongTrinhChiTietLoaiGoiThaus_HoSoCongTrinhChiTietLoaiGoiThauId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                column: "HoSoCongTrinhChiTietLoaiGoiThauId",
                principalSchema: "hsct",
                principalTable: "HoSoCongTrinhChiTietLoaiGoiThaus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
