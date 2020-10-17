using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;
using xdcb.HoSoCongTrinh.Permissions;

namespace xdcb.HoSoCongTrinh.Web.Menus
{
    public class HoSoCongTrinhMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenu(context);
            }
        }

        private async Task ConfigureMainMenu(MenuConfigurationContext context)
        {
            //Add main menu items.
            var hoSoCongTrinh = await context.IsGrantedAsync(HoSoCongTrinhPermissions.Default);
            if (hoSoCongTrinh)
            {
                context.Menu.AddItem(
                  new ApplicationMenuItem("xdcb.HoSoCongTrinh", "Hồ sơ công trình", url: "/HoSoCongTrinh/List", icon: "fa fa-files-o", order: 2));
               
            }
            var giaiNgan = await context.IsGrantedAsync(GiaiNganPermissions.Default);
            if (giaiNgan)
            {
                context.Menu.AddItem(
                 new ApplicationMenuItem("xdcb.GiaiNgan", "Giải ngân", url: "/GiaiNgan/List", icon: "fa fa-files-o", order: 5));
            }

            // Báo cáo nhu cầu vốn
            context.Menu.AddItem(new ApplicationMenuItem("BaoCaoNhuCauVon", "Báo cáo nhu cầu vốn", icon: "fa fa-files-o", order: 4));

            var baoCaoNCV = await context.IsGrantedAsync(BaoCaoNCVPermissions.Default);
            if (baoCaoNCV)
            {
                context.Menu.FindMenuItem("BaoCaoNhuCauVon").AddItem(
                 new ApplicationMenuItem("xdcb.BaoCaoNCVHangNam", "Nhu cầu vốn hằng năm", url: "/BaoCaoNCVHangNam/List"));
                context.Menu.FindMenuItem("BaoCaoNhuCauVon").AddItem(
                     new ApplicationMenuItem("xdcb.BaoCaoNCVHangNam", "Nhu cầu vốn trung hạn", url: "/BaoCaoNCVTrungHan/List"));
            }
            
        }
    }
}