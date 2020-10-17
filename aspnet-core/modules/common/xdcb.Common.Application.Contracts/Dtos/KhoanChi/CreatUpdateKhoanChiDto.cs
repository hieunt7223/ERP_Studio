using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace xdcb.Common.DanhMuc.KhoanChiDtos
{
    public class CreateUpdateKhoanChiDto
    {
        [StringLength(10)]
        [DisplayName(ViewTextConsts.KhoanChi.MaKhoanChi)]
        [Display(Prompt = ViewTextConsts.PlaceholderKhoanChi.MaKhoanChi)]
        public string MaKhoanChi { get; set; }

        [Required(ErrorMessage = Messages.MSG_Requied)]
        [StringLength(255)]
        [DisplayName(ViewTextConsts.KhoanChi.TenKhoanChi)]
        [Display(Prompt = ViewTextConsts.PlaceholderKhoanChi.TenKhoanChi)]
        public string TenKhoanChi { get; set; }

        [StringLength(500)]
        [DisplayName(ViewTextConsts.KhoanChi.GhiChu)]
        [Display(Prompt = ViewTextConsts.PlaceholderKhoanChi.GhiChu)]
        public virtual string GhiChu { get; set; }
    }
}
