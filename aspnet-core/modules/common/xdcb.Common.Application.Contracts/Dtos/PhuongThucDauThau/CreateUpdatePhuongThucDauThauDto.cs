using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace xdcb.Common.DanhMuc.PhuongThucDauThauDtos
{
    public class CreateUpdatePhuongThucDauThauDto
    {
        [Required(ErrorMessage = Messages.MSG_Requied)]
        [StringLength(255)]
        [DisplayName(ViewTextConsts.PhuongThucDauThau.TenPhuongThucDauThau)]
        [Display(Prompt = ViewTextConsts.PlaceholderPhuongThucDauThau.TenPhuongThucDauThau)]
        public string TenPhuongThucDauThau { get; set; }
    }
}