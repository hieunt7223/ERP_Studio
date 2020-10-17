using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace xdcb.Common.Web.Pages
{
    [Authorize]
    public class CommonBaseAbpPageModel: AbpPageModel
    {
    }
}
