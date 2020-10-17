using System;
using xdcb.HoSoCongTrinh.Constants;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class DiaDiemThucHienViewModel
    {
        /// <summary>
        /// Id Hồ sơ công trình địa điểm thực hiện
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id đơn vị hành chính thành phố, huyện, thị xã
        /// </summary>
        [System.ComponentModel.DisplayName(ViewTextConsts.DiaDiemThucHienViewModel.ThanhPho)]
        public Guid? DonViHanhChinhChaId { get; set; }

        /// <summary>
        /// Id Đơn vị hành chính phường xã thị trấn
        /// </summary>
        [System.ComponentModel.DisplayName(ViewTextConsts.DiaDiemThucHienViewModel.Phuong)]
        public Guid? DonViHanhChinhId { get; set; }

        /// <summary>
        /// Id Hồ sơ công trình chi tiết
        /// </summary>
        public Guid? HoSoCongTrinhChiTietId { get; set; }

        [System.ComponentModel.DisplayName(ViewTextConsts.DiaDiemThucHienViewModel.Stt)]
        public int Stt { get; set; }

        /// <summary>
        /// Thành phố/Huyện/Thị xã
        /// </summary>
        [System.ComponentModel.DisplayName(ViewTextConsts.DiaDiemThucHienViewModel.ThanhPho)]
        public string ThanhPho { get; set; }

        /// <summary>
        /// Phường/xã/thị trấn
        /// </summary>
        [System.ComponentModel.DisplayName(ViewTextConsts.DiaDiemThucHienViewModel.Phuong)]
        public string Phuong { get; set; }

        [System.ComponentModel.DisplayName(ViewTextConsts.DiaDiemThucHienViewModel.GhiChu)]
        public string GhiChu { get; set; }
    }
}