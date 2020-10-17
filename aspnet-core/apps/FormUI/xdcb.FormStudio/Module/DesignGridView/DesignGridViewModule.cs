using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;

namespace xdcb.FormStudio.DesignGridView
{
    public class DesignGridViewModule : BaseModule
    {
        public DesignGridViewModule()
        {
            Name = ModuleName.DesignGridView.ToString();
            frmDesignGridView frm = new frmDesignGridView();
            UIMainForm = frm;
            InitializeModule();
        }
    }
}
