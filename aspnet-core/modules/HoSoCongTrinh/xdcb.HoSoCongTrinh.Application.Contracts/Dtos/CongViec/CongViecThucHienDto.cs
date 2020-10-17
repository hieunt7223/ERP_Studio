using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using xdcb.HoSoCongTrinh.Constants;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CongViecThucHienDto
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
        /// Tên đơn vị thực hiện
        /// </summary>
        [DisplayName(ViewTextConsts.CongViec.DonViThucHien)]
        [Required(ErrorMessage = HoSoConstants.Messages.MSG_Requied)]
        public string DonViThucHien { get; set; }

        /// <summary>
        /// Giá trị thực hiện
        /// </summary>
        [DisplayName(ViewTextConsts.CongViec.GiaTriThucHien)]
        [Required(ErrorMessage = HoSoConstants.Messages.MSG_Requied)]
        public decimal GiaTriThucHien { get; set; }
    }
}