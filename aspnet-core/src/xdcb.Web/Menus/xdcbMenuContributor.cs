using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using xdcb.Localization;
using xdcb.MultiTenancy;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace xdcb.Web.Menus
{
    public class xdcbMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            
            if (!MultiTenancyConsts.IsEnabled)
            {
                var administration = context.Menu.GetAdministration();
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<xdcbResource>>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem("xdcb.Home", l["Menu:Home"], "/"));
            context.Menu.AddItem(
             new ApplicationMenuItem("TongQuan", "Tổng quan", url: "/#", icon: "fa fa-signal",order:1));
            context.Menu.AddItem(
               new ApplicationMenuItem("ThongKe", "Báo cáo thống kê", url: "/#", icon: "fa fa-bar-chart", order: 5));

        }
    }
}
