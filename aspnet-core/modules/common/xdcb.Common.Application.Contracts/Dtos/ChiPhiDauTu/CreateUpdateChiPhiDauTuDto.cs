using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace xdcb.Common.DanhMuc.ChiPhiDauTuDtos
{
    public class CreateUpdateChiPhiDauTuDto
    {
        [Required(ErrorMessage = Messages.MSG_Requied)]
        [StringLength(255)]
        [DisplayName(ViewTextConsts.ChiPhiDauTu.TenChiPhi)]
        [Display(Prompt = ViewTextConsts.PlaceholderChiPhiDauTu.TenChiPhi)]
        public string TenChiPhi { get; set; }

        [Required(ErrorMessage = Messages.MSG_Requied)]
        [DisplayName(ViewTextConsts.ChiPhiDauTu.LoaiChiPhi)]
        [Display(Prompt = ViewTextConsts.PlaceholderChiPhiDauTu.LoaiChiPhi)]
        public string LoaiChiPhi { get; set; }
    }
}