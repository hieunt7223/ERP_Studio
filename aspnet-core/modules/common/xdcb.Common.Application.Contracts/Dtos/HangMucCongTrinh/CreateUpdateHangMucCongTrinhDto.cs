using System.ComponentModel.DataAnnotations;
using static xdcb.Common.DanhMuc.ViewTextConsts;

namespace xdcb.Common.DanhMuc.HangMucCongTrinhDtos
{
    public class CreateUpdateHangMucCongTrinhDto
    {
        [System.ComponentModel.DisplayName(HangMucCongTrinh.MaHangMucCongTrinh)]
        [StringLength(10)]
        public string MaHangMuc { get; set; }

        [Required(ErrorMessage = Messages.MSG_Requied)]
        [StringLength(225)]
        [System.ComponentModel.DisplayName(HangMucCongTrinh.TenHangMucCongTrinh)]
        public string TenHangMuc { get; set; }

        [StringLength(500)]
        [System.ComponentModel.DisplayName(HangMucCongTrinh.MoTa)]
        public string MoTa { get; set; }
    }
}