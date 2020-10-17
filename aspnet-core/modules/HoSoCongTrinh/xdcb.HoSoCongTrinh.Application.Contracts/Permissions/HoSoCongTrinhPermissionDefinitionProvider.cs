using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using xdcb.HoSoCongTrinh.Localization;

namespace xdcb.HoSoCongTrinh.Permissions
{
    public class HoSoCongTrinhPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(HoSoCongTrinhPermissions.GroupName);

            var hoSoCongTrinh = myGroup.AddPermission(HoSoCongTrinhPermissions.Default, L("HoSoCongTrinh"));
            hoSoCongTrinh.AddChild(HoSoCongTrinhPermissions.Read, L("Read"));
            hoSoCongTrinh.AddChild(HoSoCongTrinhPermissions.Update, L("Edit"));
            hoSoCongTrinh.AddChild(HoSoCongTrinhPermissions.Delete, L("Delete"));
            hoSoCongTrinh.AddChild(HoSoCongTrinhPermissions.Create, L("Create"));

            var baoCaoGroup = context.AddGroup(BaoCaoNCVPermissions.GroupName);
            var baoCaoNCV = baoCaoGroup.AddPermission(BaoCaoNCVPermissions.Default, L("BaoCaoNCV"));
            baoCaoNCV.AddChild(BaoCaoNCVPermissions.Read, L("Read"));
            baoCaoNCV.AddChild(BaoCaoNCVPermissions.Update, L("Edit"));
            baoCaoNCV.AddChild(BaoCaoNCVPermissions.Delete, L("Delete"));
            baoCaoNCV.AddChild(BaoCaoNCVPermissions.Create, L("Create"));

            var giaiNganGroup = context.AddGroup(GiaiNganPermissions.GroupName);
            var giaiNgan = giaiNganGroup.AddPermission(GiaiNganPermissions.Default, L("GiaiNgan"));
            giaiNgan.AddChild(GiaiNganPermissions.Read, L("Read"));
            giaiNgan.AddChild(GiaiNganPermissions.Update, L("Edit"));
            giaiNgan.AddChild(GiaiNganPermissions.Delete, L("Delete"));
            giaiNgan.AddChild(GiaiNganPermissions.Create, L("Create"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HoSoCongTrinhResource>(name);
        }
    }
}