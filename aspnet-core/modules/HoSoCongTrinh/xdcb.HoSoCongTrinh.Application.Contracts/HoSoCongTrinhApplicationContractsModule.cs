using Volo.Abp.Modularity;

namespace xdcb.HoSoCongTrinh
{
    [DependsOn(
        typeof(HoSoCongTrinhDomainSharedModule)
    )]
    public class HoSoCongTrinhApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            HoSoCongTrinhDtoExtensions.Configure();
        }
    }
}