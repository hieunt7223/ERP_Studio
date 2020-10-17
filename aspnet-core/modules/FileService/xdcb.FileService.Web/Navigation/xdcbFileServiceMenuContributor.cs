using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace xdcb.FileService
{
    public class xdcbFileServiceMenuContributor : IMenuContributor
    {
        public virtual async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            //if (context.Menu.Name != StandardMenus.Main)
            //{
            //    return;
            //}

            //var menuItem = new ApplicationMenuItem("BooksStore", "Menu:FileService", "Menu:Books", icon: "fa fa-users");
            //menuItem.AddItem(new ApplicationMenuItem("BooksStore.Books", "Menu:Books", url: "/books"));

            //context.Menu.AddItem(
            //   new ApplicationMenuItem("BooksStore", "Menu:FileService")
            //       .AddItem(new ApplicationMenuItem("BooksStore.Books", "Menu:Books", url: "/Books"))
           //);
        }
    }
}
