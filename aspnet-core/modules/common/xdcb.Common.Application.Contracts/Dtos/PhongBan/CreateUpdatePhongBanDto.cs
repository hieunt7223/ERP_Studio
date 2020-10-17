using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static xdcb.Common.DanhMuc.ViewTextConsts;

namespace xdcb.Common.DanhMuc.PhongBanDtos
{
    public class CreateUpdatePhongBanDto
    {
        [Required(ErrorMessage = Messages.MSG_Requied)]
        [DisplayName(Phongban.ChuDauTu)]
        public Guid ChuDauTuId { get; set; }

        [StringLength(10)]
        [DisplayName(Phongban.MaPhongBan)]
        public string MaPhongBan { get; set; }

        [Required(ErrorMessage = Messages.MSG_Requied)]
        [StringLength(100)]
        [DisplayName(Phongban.TenPhongBan)]
        public string TenPhongBan { get; set; }

        [StringLength(255)]
        [DisplayName(Phongban.ChucNangNhiemVu)]
        public string ChucNangNhiemVu { get; set; }

        [StringLength(24)]
        [DisplayName(Phongban.SoDienThoai)]
        public string SoDienThoai { get; set; }
    }
}