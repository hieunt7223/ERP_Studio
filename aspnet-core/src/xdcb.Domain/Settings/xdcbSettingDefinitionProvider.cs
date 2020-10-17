using Volo.Abp.Settings;

namespace xdcb.Settings
{
    public class xdcbSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(xdcbSettings.MySetting1));
        }
    }
}
