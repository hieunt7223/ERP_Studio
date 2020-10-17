using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using xdcb.QuanLyVon.Localization;

namespace xdcb.QuanLyVon.Permissions
{
    public class QuanLyVonPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(QuanLyVonPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(QuanLyVonPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<QuanLyVonResource>(name);
        }
    }
}