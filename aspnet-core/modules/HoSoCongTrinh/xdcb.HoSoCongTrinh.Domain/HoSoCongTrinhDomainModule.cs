using Volo.Abp.Modularity;

namespace xdcb.HoSoCongTrinh
{
    [DependsOn(
        typeof(HoSoCongTrinhDomainSharedModule)
        )]
    public class HoSoCongTrinhDomainModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
           
        }
    }
}