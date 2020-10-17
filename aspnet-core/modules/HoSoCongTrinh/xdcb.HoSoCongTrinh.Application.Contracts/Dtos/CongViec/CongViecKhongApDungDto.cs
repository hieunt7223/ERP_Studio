using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using xdcb.HoSoCongTrinh.Constants;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CongViecKhongApDungDto
    {
        public Guid Id { get; set; }

        public Guid HoSoCongTrinhChiTietId { get; set; }

        /// <summary>
        /// Id danh mục công việc gói thầu
        /// </summary>
        [DisplayName(ViewTextConsts.CongViec.NoiDungCongViec)]
        [Required(ErrorMessage = HoSoConstants.Messages.MSG_Requied)]
        public Guid CongViecGoiThauId { get; set; }

        /// <summary>
        /// Tên nội dung công việc
        /// </summary>
        [DisplayName(ViewTextConsts.CongViec.NoiDungCongViec)]
        public string TenNoiDungCongViec { get; set; }

        /// <summary>
        /// Id danh mục chủ đầu tư
        /// </summary>
        [DisplayName(ViewTextConsts.CongViec.DonViThucHien)]
        [Required(ErrorMessage = HoSoConstants.Messages.MSG_Requied)]
        public Guid DonViThucHienId { get; set; }

        /// <summary>
        /// Tên chủ đầu tư
        /// </summary>
        [DisplayName(ViewTextConsts.CongViec.DonViThucHien)]
        public string TenDonViThucHien { get; set; }

        /// <summary>
        /// Giá trị thực hiện
        /// </summary>
        [DisplayName(ViewTextConsts.CongViec.GiaTriThucHien)]
        [Required(ErrorMessage = HoSoConstants.Messages.MSG_Requied)]
        public decimal GiaTriThucHien { get; set; }
    }
}