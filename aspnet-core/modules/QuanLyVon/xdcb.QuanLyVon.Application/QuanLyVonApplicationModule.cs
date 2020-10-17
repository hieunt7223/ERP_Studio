using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace xdcb.QuanLyVon
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(QuanLyVonDomainModule),
        typeof(QuanLyVonApplicationContractsModule)
        )]
    public class QuanLyVonApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<QuanLyVonApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<QuanLyVonApplicationAutoMapperProfile>();// (validate: true);
            });
        }
    }
}