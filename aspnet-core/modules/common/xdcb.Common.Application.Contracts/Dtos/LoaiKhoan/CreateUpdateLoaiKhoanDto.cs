using System;
using System.ComponentModel.DataAnnotations;
using static xdcb.Common.DanhMuc.ViewTextConsts;

namespace xdcb.Common.DanhMuc.LoaiKhoanDtos
{
    public class CreateUpdateLoaiKhoanDto
    {
        [System.ComponentModel.DisplayName(LoaiKhoan.LoaiLoaiKhoan)]
        public LoaiKhoanType LoaiLoaiKhoan { get; set; }

        [System.ComponentModel.DisplayName(LoaiKhoan.MaLoaiKhoan)]
        public string MaSo { get; set; }

        [Required(ErrorMessage = Messages.MSG_Requied)]
        [System.ComponentModel.DisplayName(LoaiKhoan.TenLoaiKhoan)]
        [StringLength(255)]
        public string TenLoaiKhoan { get; set; }

        [System.ComponentModel.DisplayName(LoaiKhoan.LoaiKhoanCha)]
        public Guid? LoaiKhoanChaID { get; set; }

        [System.ComponentModel.DisplayName(LoaiKhoan.GhiChu)]
        [StringLength(500)]
        public virtual string GhiChu { get; set; }
    }
}