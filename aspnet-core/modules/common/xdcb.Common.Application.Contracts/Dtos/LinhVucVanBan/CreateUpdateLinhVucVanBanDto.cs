using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace xdcb.Common.DanhMuc.LinhVucVanBanDtos
{
    public class CreateUpdateLinhVucVanBanDto
    {
        [StringLength(100)]
        [DisplayName(ViewTextConsts.LinhVucVanBan.MaLinhVucVanBan)]
        [Display(Prompt = ViewTextConsts.PlaceholderLinhVucVanBan.MaLinhVucVanBan)]
        public string MaLinhVuc { get; set; }

        [Required(ErrorMessage = Messages.MSG_Requied)]
        [StringLength(256)]
        [DisplayName(ViewTextConsts.LinhVucVanBan.TenLinhVucVanBan)]
        [Display(Prompt = ViewTextConsts.PlaceholderLinhVucVanBan.TenLinhVucVanBan)]
        public string TenLinhVuc { get; set; }

        [StringLength(500)]
        [DisplayName(ViewTextConsts.LinhVucVanBan.MoTa)]
        [Display(Prompt = ViewTextConsts.PlaceholderLinhVucVanBan.MoTa)]
        public virtual string MoTa { get; set; }
    }
}
