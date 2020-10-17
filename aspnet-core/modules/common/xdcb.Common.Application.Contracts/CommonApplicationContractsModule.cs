using Volo.Abp.Modularity;

namespace xdcb.Common
{
    [DependsOn(
        typeof(CommonDomainSharedModule)
    )]
    public class CommonApplicationContractsModule : AbpModule
    {
    }
}