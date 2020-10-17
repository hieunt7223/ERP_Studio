using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Text;

namespace xdcb.Common.Web.Pages
{
    [Authorize]

    public class CommonBasePageModel : PageModel
    {
    }
}
