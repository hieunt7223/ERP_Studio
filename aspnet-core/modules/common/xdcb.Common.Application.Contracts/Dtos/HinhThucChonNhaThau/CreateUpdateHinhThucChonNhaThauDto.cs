using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace xdcb.Common.DanhMuc.HinhThucChonNhaThauDtos
{
    public class CreateUpdateHinhThucChonNhaThauDto
    {
        [Required(ErrorMessage = Messages.MSG_Requied)]
        [StringLength(255)]
        [DisplayName(ViewTextConsts.HinhThucChonNhaThau.TenHinhThucChonNhaThau)]
        [Display(Prompt = ViewTextConsts.PlaceholderHinhThucChonNhaThau.TenHinhThucChonNhaThau)]
        public string TenHinhThucChonNhaThau { get; set; }
    }
}
