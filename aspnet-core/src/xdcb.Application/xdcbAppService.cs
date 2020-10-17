using System;
using System.Collections.Generic;
using System.Text;
using xdcb.Localization;
using Volo.Abp.Application.Services;

namespace xdcb
{
    /* Inherit your application services from this class.
     */
    public abstract class xdcbAppService : ApplicationService
    {
        protected xdcbAppService()
        {
            LocalizationResource = typeof(xdcbResource);
        }
    }
}
