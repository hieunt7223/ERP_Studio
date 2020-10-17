using System;

namespace xdcb.Common.DanhMuc.CongTrinhDtos
{
    public class DiaDiemThucHienDto
    {
        /// <summary>
        /// Id Hồ sơ công trình địa điểm thực hiện
        /// </summary>
        [System.ComponentModel.DisplayName(ViewTextConsts.DiaDiemThucHienViewModel.ThanhPho)]
        public Guid Id { get; set; }

        /// <summary>
        /// Id đơn vị hành chính cấp thành phố, huyện, thị xã
        /// </summary>
        public Guid DonViHanhChinhChaId { get; set; }

        /// <summary>
        /// Id Đơn vị hành chính
        /// </summary>
        [System.ComponentModel.DisplayName(ViewTextConsts.DiaDiemThucHienViewModel.Phuong)]
        public Guid? DonViHanhChinhId { get; set; }

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