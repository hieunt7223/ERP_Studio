using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;

namespace xdcb.FormStudio.DesignModule
{
    public class DesignModuleModule : BaseModule
    {
        public DesignModuleModule()
        {
            Name = ModuleName.DesignModule.ToString();
            frmDesignModule frm = new frmDesignModule();
            UIMainForm = frm;
            InitializeModule();
        }
    }
}