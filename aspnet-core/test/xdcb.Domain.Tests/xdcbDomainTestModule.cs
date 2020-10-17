using xdcb.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace xdcb
{
    [DependsOn(
        typeof(xdcbEntityFrameworkCoreTestModule)
        )]
    public class xdcbDomainTestModule : AbpModule
    {

    }
}