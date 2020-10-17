using System;
using System.ComponentModel.DataAnnotations;
using static xdcb.Common.DanhMuc.ViewTextConsts;

namespace xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGiaDtos
{
    public class CreateUpdateChuongTrinhMucTieuQuocGiaDto
    {
        [System.ComponentModel.DisplayName(ChuongTrinhMucTieuQuocGia.MaChuongTrinhMucTieuQuocGia)]
        [StringLength(16)]
        public string MaChuongTrinhMucTieuQuocGia { get; set; }
        [System.ComponentModel.DisplayName(ChuongTrinhMucTieuQuocGia.TenChuongTrinhMucTieuQuocGia)]
        [StringLength(255)]
        [Required(ErrorMessage = Messages.MSG_Requied)]
        public string TenChuongTrinhMucTieuQuocGia { get; set; }
        [System.ComponentModel.DisplayName(ChuongTrinhMucTieuQuocGia.MaChuongTrinhMucTieuQuocGiaCha)]
        public Guid? ParentId { get; set; }
    }
}