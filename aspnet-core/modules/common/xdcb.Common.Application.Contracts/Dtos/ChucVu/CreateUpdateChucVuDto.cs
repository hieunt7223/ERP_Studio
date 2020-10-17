using System.ComponentModel.DataAnnotations;
using static xdcb.Common.DanhMuc.ViewTextConsts;

namespace xdcb.Common.DanhMuc.ChucVuDtos
{
    public class CreateUpdateChucVuDto
    {
        [StringLength(16)]
        [System.ComponentModel.DisplayName(ChucVu.MaChucVu)]
        [Display(Prompt = PlaceholderChucVu.MaChucVu)]
        public string MaChucVu { get; set; }

        [Required(ErrorMessage = Messages.MSG_Requied)]
        [StringLength(255)]
        [System.ComponentModel.DisplayName(ChucVu.TenChucVu)]
        [Display(Prompt = PlaceholderChucVu.TenChucVu)]
        public string TenChucVu { get; set; }
    }
}