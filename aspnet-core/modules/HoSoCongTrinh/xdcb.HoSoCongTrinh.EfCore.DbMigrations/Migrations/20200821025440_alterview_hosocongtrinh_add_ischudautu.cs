using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.HoSoCongTrinh.Migrations
{
    public partial class alterview_hosocongtrinh_add_ischudautu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var script = @"
                  ALTER VIEW [hsct].[vHoSoCongTrinhs]
                  AS
                  SELECT common.CongTrinhs.Id, common.CongTrinhs.TenCongTrinh, common.CongTrinhs.MaCongTrinh, common.CongTrinhs.ChuDauTuId, common.CongTrinhs.LoaiKhoanId, common.CongTrinhs.CTMTQuocGiaId,
                  common.CongTrinhs.LoaiCongTrinhId, common.CongTrinhs.NhomCongTrinhId, common.CongTrinhs.ThoiGianThucHienTuNgay, common.CongTrinhs.ThoiGianThucHienDenNgay, common.CongTrinhs.DienTich,
                  hsct.HoSoCongTrinhs.Id AS HoSoCongTrinhId, hsct.HoSoCongTrinhs.LoaiHoSoId, hsct.HoSoCongTrinhs.TrangThai, hsct.HoSoCongTrinhs.HanXuLy, hsct.HoSoCongTrinhs.SoLanDieuChinh, common.CongTrinhs.LastModificationTime,
                  hsct.HoSoCongTrinhs.IsChuDauTu
                  FROM     common.CongTrinhs LEFT OUTER JOIN
                  hsct.HoSoCongTrinhs ON common.CongTrinhs.Id = hsct.HoSoCongTrinhs.CongTrinhId AND hsct.HoSoCongTrinhs.IsDeleted = 0
                  WHERE  (common.CongTrinhs.IsDeleted = 0)
                  GO
            ";
            migrationBuilder.Sql(script);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
