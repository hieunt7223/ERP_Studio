using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using xdcb.Common.DanhMuc.LinhVucVanBanDtos;

namespace xdcb.Common
{
    public class CreateUpdateLinhVucVanBanPageModel : CreateUpdateLinhVucVanBanDto
    {
        [TextArea(Rows = 2)]
        [DisplayOrder(10005)]
        public override string MoTa { get; set; }
    }
}
