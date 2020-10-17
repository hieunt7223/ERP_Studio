using System.ComponentModel.DataAnnotations;
using static xdcb.Common.DanhMuc.ViewTextConsts;

namespace xdcb.Common.DanhMuc.NhomCongTrinhDtos
{
    public class CreateUpdateNhomCongTrinhDto
    {
        [System.ComponentModel.DisplayName(NhomCongTrinh.MaNhomCongTrinh)]
        [StringLength(10)]
        [Display(Prompt = PlaceholderNhomCongTrinh.MaNhomCongTrinh)]
        public string MaNhomCongTrinh { get; set; }

        [Required(ErrorMessage = Messages.MSG_Requied)]
        [System.ComponentModel.DisplayName(NhomCongTrinh.TenNhomCongTrinh)]
        [StringLength(255)]
        [Display(Prompt = PlaceholderNhomCongTrinh.TenNhomCongTrinh)]
        public string TenNhomCongTrinh { get; set; }

        [System.ComponentModel.DisplayName(NhomCongTrinh.MoTa)]
        [StringLength(500)]
        [Display(Prompt = PlaceholderNhomCongTrinh.MoTa)]
        public virtual string MoTa { get; set; }
    }
}