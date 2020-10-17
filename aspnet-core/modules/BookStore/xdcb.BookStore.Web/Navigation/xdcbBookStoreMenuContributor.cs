using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace xdcb.BookStore
{
    public class xdcbBookStoreMenuContributor : IMenuContributor
    {
        public virtual async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name != StandardMenus.Main)
            {
                return;
            }

            var hasPermission = await context.IsGrantedAsync(BookStorePermissions.BookStore.Default);

            if (hasPermission)
            {
                context.Menu
                    .AddItem(new ApplicationMenuItem("BookStore", "Menu:BookStore")
                        .AddItem(new ApplicationMenuItem("BookStore.Books", "DevExtreme Grid", url: "/devextreme"))
                        .AddItem(new ApplicationMenuItem("BookStore.Books", "BookStore", url: "/books"))
                    );
            }
        }
    }
}
