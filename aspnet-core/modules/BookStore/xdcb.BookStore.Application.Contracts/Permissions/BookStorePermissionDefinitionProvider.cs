using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace xdcb.BookStore
{
    public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var permissionGroup = context.AddGroup(BookStorePermissions.GroupName);
            
            var bookStore = permissionGroup.AddPermission(BookStorePermissions.BookStore.Default, L("Permission:BookStore"));
            bookStore.AddChild(BookStorePermissions.BookStore.Management, L("Read"));
            bookStore.AddChild(BookStorePermissions.BookStore.Update, L("Edit"));
            bookStore.AddChild(BookStorePermissions.BookStore.Delete, L("Delete"));
            bookStore.AddChild(BookStorePermissions.BookStore.Create, L("Create"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BookStoreResource>(name);
        }
    }
}
