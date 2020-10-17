using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using xdcb.Common.DanhMuc.KhoanChiDtos;

namespace xdcb.Common
{
    public class CreateUpdateKhoanChiPageModel : CreateUpdateKhoanChiDto
    {
        [TextArea(Rows = 2)]
        [DisplayOrder(10005)]
        public override string GhiChu { get; set; }
    }
}
