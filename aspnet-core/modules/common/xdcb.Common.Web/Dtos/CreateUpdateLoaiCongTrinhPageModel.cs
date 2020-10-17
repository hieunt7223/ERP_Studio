using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using xdcb.Common.DanhMuc.LoaiCongTrinhDtos;

namespace xdcb.Common
{
    public class CreateUpdateLoaiCongTrinhPageModel : CreateUpdateLoaiCongTrinhDto
    {
        [TextArea(Rows = 2)]
        [DisplayOrder(10005)]
        public override string MoTa { get; set; }
    }
}
