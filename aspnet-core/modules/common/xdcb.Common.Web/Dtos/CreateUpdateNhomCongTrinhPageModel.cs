using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using xdcb.Common.DanhMuc.NhomCongTrinhDtos;

namespace xdcb.Common
{
    public class CreateUpdateNhomCongTrinhPageModel : CreateUpdateNhomCongTrinhDto
    {
        [TextArea(Rows = 2)]
        [DisplayOrder(10005)]
        public override string MoTa { get; set; }
    }
}
