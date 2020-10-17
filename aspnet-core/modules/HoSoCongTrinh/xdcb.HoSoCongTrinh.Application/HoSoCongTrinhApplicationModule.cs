using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace xdcb.HoSoCongTrinh
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
         typeof(HoSoCongTrinhDomainModule),
         typeof(HoSoCongTrinhApplicationContractsModule)
         )]
    public class HoSoCongTrinhApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<HoSoCongTrinhApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<HoSoCongTrinhApplicationAutoMapperProfile>();
            });
        }
    }
}