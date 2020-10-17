using System;
using System.Collections.Generic;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class ListHoSoCongTrinhChiTietViewModel
    {
        /// <summary>
        /// Id Hồ sơ công trình 
        /// </summary>
        public Guid HoSoCongTrinhId { get; set; }

        /// <summary>
        /// Id Công trình
        /// </summary>
        public Guid CongTrinhId { get; set; }

        /// <summary>
        /// Id Loại hồ sơ
        /// </summary>
        public Guid LoaiHoSoId { get; set; }

        /// <summary>
        /// Tên loại hồ sơ
        /// </summary>
        public string TenLoaiHoSo { get; set; }

        public DateTime HanXuLy { get; set; }

        public int SoLanDieuChinh { get; set; }

        public int TrangThai { get; set; }

        public bool Expand { get; set; } = false;

        public TrangThaiXuLyViewModel TrangThaiXuLy { get; set; }

        public List<HoSoCongTrinhChiTietViewModel> HoSoCongTrinhChiTiets { get; set; } = new List<HoSoCongTrinhChiTietViewModel>();
    }
}