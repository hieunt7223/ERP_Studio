using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace xdcb.Common.DanhMuc.LoaiVanBanDtos
{
    public class CreateUpdateLoaiVanBanDto
    {
        [StringLength(16)]
        [DisplayName(ViewTextConsts.LoaiVanBan.MaLoaiVanBan)]
        [Display(Prompt = ViewTextConsts.PlaceholderLoaiVanBan.MaLoaiVanBan)]
        public string MaLoaiVanBan { get; set; }

        [Required(ErrorMessage = Messages.MSG_Requied)]
        [StringLength(255)]
        [DisplayName(ViewTextConsts.LoaiVanBan.TenLoaiVanBan)]
        [Display(Prompt = ViewTextConsts.PlaceholderLoaiVanBan.TenLoaiVanBan)]
        public string TenLoaiVanBan { get; set; }

        [StringLength(500)]
        [DisplayName(ViewTextConsts.LoaiVanBan.MoTa)]
        [Display(Prompt = ViewTextConsts.PlaceholderLoaiVanBan.MoTa)]
        public virtual string MoTa { get; set; }
    }
}