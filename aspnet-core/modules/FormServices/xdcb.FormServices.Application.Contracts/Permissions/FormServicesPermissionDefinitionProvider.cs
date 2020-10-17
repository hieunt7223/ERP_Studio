using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using xdcb.FormServices.Localization;

namespace xdcb.FormServices.Permissions
{
    public class FormServicesPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(FormServicesPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(FormServicesPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<FormServicesResource>(name);
        }
    }
}