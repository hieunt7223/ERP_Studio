using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using xdcb.HoSoCongTrinh.Constants;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CongViecChuaDuDieuKienLapKeHoachDto
    {
        public Guid Id { get; set; }

        public Guid HoSoCongTrinhChiTietId { get; set; }

        /// <summary>
        /// Id danh mục công việc gói thầu
        /// </summary>
        [DisplayName(ViewTextConsts.CongViec.NoiDung)]
        [Required(ErrorMessage = HoSoConstants.Messages.MSG_Requied)]
        public Guid CongViecGoiThauId { get; set; }

        /// <summary>
        /// Tên nội dung kiểm tra
        /// </summary>
        [DisplayName(ViewTextConsts.CongViec.NoiDung)]
        public string TenNoiDungKiemTra { get; set; }

        /// <summary>
        /// Tuần thủ, phù hợp
        /// </summary>
        [DisplayName(ViewTextConsts.CongViec.GiaTri)]
        [Required(ErrorMessage = HoSoConstants.Messages.MSG_Requied)]
        public decimal GiaTri { get; set; }
    }
}