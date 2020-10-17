using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static xdcb.Common.DanhMuc.ViewTextConsts;

namespace xdcb.Common.DanhMuc.NganhLinhVucSuDungDtos
{
    public class CreateUpdateNganhLinhVucSuDungDto
    {
        [DisplayName(NganhLinhVucSuDungConst.Ten)]
        [StringLength(500)]
        [Display(Prompt = NganhLinhVucSuDungConst.Ten)]
        public string TenNganhLinhVucSuDung { get; set; }
    }
}