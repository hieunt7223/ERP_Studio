using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using xdcb.Common.DanhMuc.ChuDauTus;

namespace xdcb.Common
{
    public class CreateUpdateChuDauTuPageModel : CreateUpdateChuDauTuDto
    {
        [TextArea(Rows = 2)]
        [DisplayOrder(10005)]
        public override string GhiChu { get; set; }
    }
}
