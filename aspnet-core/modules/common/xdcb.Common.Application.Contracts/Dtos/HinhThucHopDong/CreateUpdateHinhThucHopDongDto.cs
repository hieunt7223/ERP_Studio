using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace xdcb.Common.DanhMuc.HinhThucHopDongDtos
{
    public class CreateUpdateHinhThucHopDongDto
    {
        [Required(ErrorMessage = Messages.MSG_Requied)]
        [StringLength(256)]
        [DisplayName(ViewTextConsts.HinhThucHopDong.TenHinhThucHopDong)]
        [Display(Prompt = ViewTextConsts.PlaceholderHinhThucHopDong.TenHinhThucHopDong)]
        public string TenHinhThucHopDong { get; set; }
    }
}
