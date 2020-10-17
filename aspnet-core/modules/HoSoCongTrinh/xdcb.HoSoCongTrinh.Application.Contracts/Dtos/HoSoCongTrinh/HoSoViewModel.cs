using System;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoViewModel
    {
        /// <summary>
        /// Số thứ tự trên view
        /// </summary>
        public string Stt { get; set; }

        /// <summary>
        /// Id loại hồ sơ
        /// </summary>
        public Guid? LoaiHoSoId { get; set; }

        /// <summary>
        /// Id Hồ sơ công trình
        /// </summary>
        public Guid? HoSoCongTrinhId { get; set; }

        /// <summary>
        /// Là Loại hồ sơ điều chỉnh = true
        /// </summary>
        public bool IsDieuChinh { get; set; } = false;

        /// <summary>
        /// Tên loại hồ sơ
        /// </summary>
        public string TenLoaiHoSo { get; set; }

        public TrangThaiXuLyViewModel TrangThaiXuLy { get; set; }

        /// <summary>
        /// Hạn xử lý
        /// </summary>
        public string HanXuLy { get; set; }

        /// <summary>
        /// Ngày xử lý
        /// </summary>
        public double NgayXuLy { get; set; }

        /// <summary>
        /// Số lần điều chỉnh đối với loại hồ sơ điều chỉnh
        /// </summary>
        public int? SoLanDieuChinh { get; set; }

        public ActionViewModel Action { get; set; }
    }
}