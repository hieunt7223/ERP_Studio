using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using static xdcb.Common.DanhMuc.ViewTextConsts;

namespace xdcb.Common.DanhMuc.LoaiCongTrinhDtos
{
    public class CreateUpdateLoaiCongTrinhDto
    {
        [System.ComponentModel.DisplayName(LoaiCongTrinh.MaLoaiCongTrinh)]
        [StringLength(10)]
        [Display(Prompt = PlaceholderLoaiCongTrinh.MaLoaiCongTrinh)]
        public string MaLoaiCongTrinh { get; set; }

        [Display(Prompt = PlaceholderLoaiCongTrinh.TenLoaiCongTrinh)]
        [Required(ErrorMessage = Messages.MSG_Requied)]
        [System.ComponentModel.DisplayName(LoaiCongTrinh.TenLoaiCongTrinh)]
        [StringLength(255)]
        public string TenLoaiCongTrinh { get; set; }

        [System.ComponentModel.DisplayName(LoaiCongTrinh.MoTa)]
        [StringLength(500)]
        [Display(Prompt = PlaceholderLoaiCongTrinh.MoTa)]
        public virtual string MoTa { get; set; }
    }
}