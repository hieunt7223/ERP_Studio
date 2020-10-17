using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using xdcb.HoSoCongTrinh.Constants;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhChiTietGoiThauDto : FullAuditedEntityDto<Guid>
    {
        public Guid HoSoCongTrinhChiTietId { get; set; }

        /// <summary>
        /// Id danh mục loại gói thầu
        /// </summary>
        [DisplayName(ViewTextConsts.GoiThau.TenGoiThau)]
        public Guid LoaiGoiThauId { get; set; }

        /// <summary>
        /// Tên loại gói thầu
        /// </summary>
        [DisplayName(ViewTextConsts.GoiThau.TenGoiThau)]
        public string TenLoaiGoiThau { get; set; }

        /// <summary>
        /// Id Gói thầu cha
        /// </summary>
        [Required(ErrorMessage = HoSoConstants.Messages.MSG_Requied)]
        public Guid GoiThauParentId { get; set; } = Guid.Empty;

        /// <summary>
        /// Id danh mục gói thầu
        /// </summary>
        [DisplayName(ViewTextConsts.GoiThau.TenGoiThau)]
        [Required(ErrorMessage = HoSoConstants.Messages.MSG_Requied)]
        public Guid GoiThauId { get; set; }

        /// <summary>
        /// Tên gói thầu
        /// </summary>
        public string TenGoiThau { get; set; }

        /// <summary>
        /// Giá gói thầu
        /// </summary>
        [DisplayName(ViewTextConsts.GoiThau.GiaGoiThau)]
        public decimal? GiaGoiThau { get; set; }

        /// <summary>
        /// Id danh mục hinh thức lựa chọn nhà thầu
        /// </summary>
        [DisplayName(ViewTextConsts.GoiThau.HinhThucLuaChonNhaThau)]
        public Guid? HinhThucLuaChonNhaThauId { get; set; }

        /// <summary>
        /// Tên hinh thức lựa chọn nhà thầu
        /// </summary>
        [DisplayName(ViewTextConsts.GoiThau.HinhThucLuaChonNhaThau)]
        public string TenHinhThucLuaChonNhaThau { get; set; }

        /// <summary>
        /// Id danh mục phương thức lựa chọn nhà thầu
        /// </summary>
        [DisplayName(ViewTextConsts.GoiThau.PhuongThucLuaChonNhaThau)]
        public Guid? PhuongThucLuaChonNhaThauId { get; set; }

        /// <summary>
        /// Tên phương thức lựa chọn nhà thầu
        /// </summary>
        [DisplayName(ViewTextConsts.GoiThau.PhuongThucLuaChonNhaThau)]
        public string TenPhuongThucLuaChonNhaThau { get; set; }

        /// <summary>
        /// Thời gian bắt đầu, quý 1,2,3,4
        /// </summary>
        [DisplayName(ViewTextConsts.GoiThau.ThoiGianBatDau)]
        public string ThoiGianBatDau { get; set; }

        /// <summary>
        /// Id danh mục hình thức hợp đồng
        /// </summary>
        [DisplayName(ViewTextConsts.GoiThau.LoaiHopDong)]
        public Guid? LoaiHopDongId { get; set; }

        /// <summary>
        /// Tên hình thức hợp đồng
        /// </summary>
        [DisplayName(ViewTextConsts.GoiThau.LoaiHopDong)]
        public string TenLoaiHopDong { get; set; }

        /// <summary>
        /// Thời gian thực hiện tính theo ngày. vd 75 ngàys
        /// </summary>
        [DisplayName(ViewTextConsts.GoiThau.ThoiGianThucHien)]
        public string ThoiGianThucHien { get; set; }
    }
}