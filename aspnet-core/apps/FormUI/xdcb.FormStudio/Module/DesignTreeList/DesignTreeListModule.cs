using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;

namespace xdcb.FormStudio.DesignTreeList
{
    public class DesignTreeListModule : BaseModule
    {
        public DesignTreeListModule()
        {
            Name = ModuleName.DesignTreeList.ToString();
            frmDesignTreeList frm = new frmDesignTreeList();
            UIMainForm = frm;
            InitializeModule();
        }
    }
}
