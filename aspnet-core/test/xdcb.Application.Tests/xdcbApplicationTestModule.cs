using Volo.Abp.Modularity;

namespace xdcb
{
    [DependsOn(
        typeof(xdcbApplicationModule),
        typeof(xdcbDomainTestModule)
        )]
    public class xdcbApplicationTestModule : AbpModule
    {

    }
}