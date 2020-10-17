using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using xdcb.Common.DanhMuc.LoaiVanBanDtos;

namespace xdcb.Common
{
    public class CreateUpdateLoaiVanBanPageModel : CreateUpdateLoaiVanBanDto
    {
        [TextArea(Rows = 2)]
        [DisplayOrder(10005)]
        public override string MoTa { get; set; }
    }
}
