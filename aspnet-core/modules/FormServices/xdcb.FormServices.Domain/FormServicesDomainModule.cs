using Volo.Abp.Modularity;

namespace xdcb.FormServices
{
    [DependsOn(
        typeof(FormServicesDomainSharedModule)
        )]
    public class FormServicesDomainModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
           
        }
    }
}