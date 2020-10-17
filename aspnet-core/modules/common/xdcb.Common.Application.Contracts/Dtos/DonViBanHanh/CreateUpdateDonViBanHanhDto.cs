using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace xdcb.Common.DanhMuc.DonViBanHanhDtos
{
    public class CreateUpdateDonViBanHanhDto
    {
        [Display(Prompt = ViewTextConsts.PlaceholderDonViBanHanh.TenDonViBanHanh)]
        [Required(ErrorMessage = Messages.MSG_Requied)]
        [StringLength(50)]
        [DisplayName(ViewTextConsts.DonViBanHanh.TenDonViBanHanh)]
        public string Ten { get; set; }
    }
}