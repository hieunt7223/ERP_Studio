using System;
using xdcb.HoSoCongTrinh.Constants;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhSearchInput
    {
        /// <summary>
        /// search theo tên
        /// </summary>
        [System.ComponentModel.DisplayName(ViewTextConsts.HoSoCongTrinhSearchInput.TenCongTrinh)]
        public string TenCongTrinh { get; set; }

        /// <summary>
        /// năm thực hiện công trình
        /// </summary>
        [System.ComponentModel.DisplayName(ViewTextConsts.HoSoCongTrinhSearchInput.NamThucHienCongTrinh)]
        public string NamThucHienCongTrinh { get; set; }

        /// <summary>
        /// Trạng thái hồ sơ
        /// default = 0 filter all trạng thái
        /// </summary>
        [System.ComponentModel.DisplayName(ViewTextConsts.HoSoCongTrinhSearchInput.TrangThaiHoSo)]
        public int TrangThaiHoSo { get; set; }

        /// <summary>
        /// Id Loại hồ sơ
        /// </summary>
        [System.ComponentModel.DisplayName(ViewTextConsts.HoSoCongTrinhSearchInput.LoaiHoSoId)]
        public Guid? LoaiHoSoId { get; set; }

        /// <summary>
        /// Id chủ đầu tư, chỉ hiển thị đối với chuyên viên
        /// </summary>
        [System.ComponentModel.DisplayName(ViewTextConsts.HoSoCongTrinhSearchInput.ChuDauTuId)]
        public Guid? ChuDauTuId { get; set; }

        /// <summary>
        /// Vị trí get
        /// </summary>
        public int Skip { get; set; } = 0;

        /// <summary>
        /// Số record get
        /// </summary>
        public int Take { get; set; } = 10;
    }
}