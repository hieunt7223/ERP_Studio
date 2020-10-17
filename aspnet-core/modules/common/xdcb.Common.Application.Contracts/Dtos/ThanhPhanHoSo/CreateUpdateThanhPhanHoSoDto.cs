using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace xdcb.Common.DanhMuc.ThanhPhanHoSoDtos
{
    public class CreateUpdateThanhPhanHoSoDto
    {
        [Required(ErrorMessage = Messages.MSG_Requied)]
        [StringLength(255)]
        [DisplayName(ViewTextConsts.ThanhPhanHoSo.TenThanhPhanHoSo)]
        [Display(Prompt = ViewTextConsts.PlaceholderThanhPhanHoSo.TenThanhPhanHoSo)]
        public string TenThanhPhanHoSo { get; set; }

        [DisplayName(ViewTextConsts.ThanhPhanHoSo.LoaiVanBan)]
        [Display(Prompt = ViewTextConsts.PlaceholderThanhPhanHoSo.LoaiVanBan)]
        public Guid? LoaiVanBanId { get; set; }
    }
}
