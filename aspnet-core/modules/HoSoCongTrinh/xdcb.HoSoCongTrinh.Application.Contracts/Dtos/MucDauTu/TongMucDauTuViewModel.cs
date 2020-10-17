using System;
using System.ComponentModel;
using xdcb.HoSoCongTrinh.Constants;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class TongMucDauTuViewModel
    {
        [DisplayName(ViewTextConsts.TongMucDauTuViewModel.Stt)]
        public int Stt { get; set; }

        /// <summary>
        /// Id Tong muc dau tu
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id Hồ sơ công trình chi tiết
        /// </summary>
        public Guid? HoSoCongTrinhChiTietId{ get; set; }

        [DisplayName(ViewTextConsts.TongMucDauTuViewModel.TenChiPhi)]
        public string TenChiPhi { get; set; }

        [DisplayName(ViewTextConsts.TongMucDauTuViewModel.TenChiPhi)]
        public Guid? ChiPhiId { get; set; }

        [DisplayName(ViewTextConsts.TongMucDauTuViewModel.DonViTrinh)]
        public decimal? DonViTrinh { get; set; }

        /// <summary>
        /// format 20.000
        /// </summary>
        public string DonViTrinhFormat { get; set; }

        [DisplayName(ViewTextConsts.TongMucDauTuViewModel.ThamDinhDeNghi)]
        public decimal? ThamDinhDeNghi { get; set; }

        /// <summary>
        /// format 20.000
        /// </summary>
        public string ThamDinhDeNghiFormat { get; set; }

        /// <summary>
        /// Chi phí bắt buộc, không được xóa
        /// </summary>
        public bool IsBatBuoc { get; set; }
    }
}