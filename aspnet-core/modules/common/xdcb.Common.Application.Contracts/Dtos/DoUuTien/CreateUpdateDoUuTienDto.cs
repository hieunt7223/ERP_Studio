using System.ComponentModel.DataAnnotations;
using static xdcb.Common.DanhMuc.ViewTextConsts;

namespace xdcb.Common.DanhMuc.DoUuTienDtos
{
    public class CreateUpdateDoUuTienDto
    {
        [Required(ErrorMessage = Messages.MSG_Requied)]
        [System.ComponentModel.DisplayName(DoUuTien.TenDoUuTien)]
        [StringLength(255)]
        [Display(Prompt = PlaceholderDoUuTien.TenDoUuTien)]

        public string TenDoUuTien { get; set; }
        [System.ComponentModel.DisplayName(DoUuTien.MaDoUuTien)]
        [Display(Prompt = PlaceholderDoUuTien.MaDoUuTien)]
        public virtual int MaDoUuTien { get; set; }

     
        [System.ComponentModel.DisplayName(DoUuTien.ThuTuHienThi)]
        [Display(Prompt = PlaceholderDoUuTien.ThuTuHienThi)]

        public int? ThuTuHienThi { get; set; }

        [System.ComponentModel.DisplayName(DoUuTien.MoTa)]
        [StringLength(500)]
        [Display(Prompt = PlaceholderDoUuTien.MoTa)]
        public virtual string MoTa { get; set; }
    }
}