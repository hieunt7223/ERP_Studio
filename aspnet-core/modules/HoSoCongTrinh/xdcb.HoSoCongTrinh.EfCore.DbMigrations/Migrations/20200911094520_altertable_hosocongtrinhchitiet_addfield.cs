using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.HoSoCongTrinh.Migrations
{
    public partial class altertable_hosocongtrinhchitiet_addfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CapQuyetDinhChuTruongDauTu",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CapQuyetDinhDauTuDuAn",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DonViChuTriThamDinhId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DonViPhoiHopThamDinhs",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HinhThucThamDinh",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MucTieuDauTu",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NganhLinhVucSuDungId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoiDungDauTu",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoiDungTrinhVaKienNghi",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SuCanThietDauTuDuAn",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SuPhuHopMucTieuChienLuoc",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SuPhuHopMucTieuPhanLoai",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SuTuanThuQuyDinh",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YKienCuaDonViThamDinh",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YKienThamDinhDonViPhoiHop",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HoSoCongTrinhChiTietNguonVons",
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
                    NguonVonId = table.Column<Guid>(nullable: false),
                    GiaTriDeNghi = table.Column<decimal>(nullable: false),
                    GiaTriThamDinh = table.Column<decimal>(nullable: false),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoCongTrinhChiTietNguonVons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoCongTrinhChiTietNguonVons_HoSoCongTrinhChiTiets_HoSoCongTrinhChiTietId",
                        column: x => x.HoSoCongTrinhChiTietId,
                        principalSchema: "hsct",
                        principalTable: "HoSoCongTrinhChiTiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoSoCongTrinhChiTietNguonVons_HoSoCongTrinhChiTietId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietNguonVons",
                column: "HoSoCongTrinhChiTietId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoSoCongTrinhChiTietNguonVons",
                schema: "hsct");

            migrationBuilder.DropColumn(
                name: "CapQuyetDinhChuTruongDauTu",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "CapQuyetDinhDauTuDuAn",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "DonViChuTriThamDinhId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "DonViPhoiHopThamDinhs",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "HinhThucThamDinh",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "MucTieuDauTu",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "NganhLinhVucSuDungId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "NoiDungDauTu",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "NoiDungTrinhVaKienNghi",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "SuCanThietDauTuDuAn",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "SuPhuHopMucTieuChienLuoc",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "SuPhuHopMucTieuPhanLoai",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "SuTuanThuQuyDinh",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "YKienCuaDonViThamDinh",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "YKienThamDinhDonViPhoiHop",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");
        }
    }
}
