using Volo.Abp.Modularity;

namespace xdcb.QuanLyVon
{
    [DependsOn(
        typeof(QuanLyVonDomainSharedModule)
        )]
    public class QuanLyVonDomainModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
           
        }
    }
}