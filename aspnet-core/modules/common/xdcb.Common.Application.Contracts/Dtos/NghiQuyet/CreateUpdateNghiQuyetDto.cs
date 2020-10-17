using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static xdcb.Common.DanhMuc.ViewTextConsts;

namespace xdcb.Common.DanhMuc.NghiQuyetDtos
{
    public class CreateUpdateNghiQuyetDto
    {
        [Required(ErrorMessage = Messages.MSG_Requied)]
        [StringLength(255)]
        [System.ComponentModel.DisplayName(NghiQuyet.SoVanBan)]
        [Display(Prompt = PlaceholderNghiQuyet.SoVanBan)]
        public string SoVanBan { get; set; }
        [DataType(DataType.Date)]
        [System.ComponentModel.DisplayName(NghiQuyet.NgayBanHanh)]
        [Required(ErrorMessage = Messages.MSG_Requied)]
        public DateTime NgayBanHanh { get; set; }
        [StringLength(196)]
        [System.ComponentModel.DisplayName(NghiQuyet.TrichYeu)]
        [Display(Prompt = PlaceholderNghiQuyet.TrichYeu)]
        [Required(ErrorMessage = Messages.MSG_Requied)]
        public string TrichYeu { get; set; }

        [System.ComponentModel.DisplayName(NghiQuyet.TheoDoi)]
        public bool IsTheoDoi { get; set; }

    }
}