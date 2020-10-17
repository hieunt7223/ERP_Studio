using System;
using Volo.Abp.Domain.Entities;

namespace xdcb.HoSoCongTrinh.Entities
{
    public class vHoSoCongTrinhChiTiet : Entity<Guid>
    {
        public Guid CongTrinhId { get; set; }

        public Guid LoaiHoSoId { get; set; }

        public int TrangThai { get; set; }

        public DateTime HanXuLy { get; set; }

        public int SoLanDieuChinh { get; set; }

        #region Hồ sơ công trình chi tiết

        public Guid HoSoCongTrinhChiTietId { get; set; }

        public int SoLanDieuChinhChiTiet { get; set; }

        public string SuCanThietDauTu { get; set; }

        public string QuyMoDauTu { get; set; }

        public string NguonVonDauTu { get; set; }

        public int TrangThaiChiTiet { get; set; }

        public DateTime HanXuLyChiTiet { get; set; }

        #endregion Hồ sơ công trình chi tiết
    }
}