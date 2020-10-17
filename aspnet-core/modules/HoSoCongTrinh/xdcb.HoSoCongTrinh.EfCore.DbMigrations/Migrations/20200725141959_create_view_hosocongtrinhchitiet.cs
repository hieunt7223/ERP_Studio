using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.HoSoCongTrinh.Migrations
{
    public partial class create_view_hosocongtrinhchitiet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var script = @"
                  CREATE VIEW [hsct].[vHoSoCongTrinhChiTiets]
                  AS
                  SELECT hsct.HoSoCongTrinhs.Id,
                         hsct.HoSoCongTrinhs.CongTrinhId,
                         hsct.HoSoCongTrinhs.LoaiHoSoId,
                         hsct.HoSoCongTrinhs.TrangThai,
                         hsct.HoSoCongTrinhs.HanXuLy,
                         hsct.HoSoCongTrinhs.SoLanDieuChinh,
                         hsct.HoSoCongTrinhChiTiets.Id AS HoSoCongTrinhChiTietId,
                         hsct.HoSoCongTrinhChiTiets.SoLanDieuChinh AS SoLanDieuChinhChiTiet,
                         hsct.HoSoCongTrinhChiTiets.SuCanThietDauTu,
                         hsct.HoSoCongTrinhChiTiets.QuyMoDauTu,
                         hsct.HoSoCongTrinhChiTiets.NguonVonDauTu,
                         hsct.HoSoCongTrinhChiTiets.TrangThai AS TrangThaiChiTiet,
                         hsct.HoSoCongTrinhChiTiets.HanXuLy AS HanXuLyChiTiet
                  FROM hsct.HoSoCongTrinhs
                  LEFT OUTER JOIN hsct.HoSoCongTrinhChiTiets ON hsct.HoSoCongTrinhs.Id = hsct.HoSoCongTrinhChiTiets.HoSoCongTrinhId
                  AND hsct.HoSoCongTrinhChiTiets.IsDeleted = 0
                  WHERE (hsct.HoSoCongTrinhs.IsDeleted = 0)
                  GO     
            ";
            migrationBuilder.Sql(script);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [hsct].[vHoSoCongTrinhChiTiets]");
        }
    }
}
