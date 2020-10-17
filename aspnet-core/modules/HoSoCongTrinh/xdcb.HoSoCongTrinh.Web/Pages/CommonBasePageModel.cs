using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xdcb.HoSoCongTrinh
{
    [Authorize]

    public class CommonBasePageModel : PageModel
    {
    }
}
