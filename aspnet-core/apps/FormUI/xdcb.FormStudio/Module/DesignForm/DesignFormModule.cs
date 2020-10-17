using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;

namespace xdcb.FormStudio.DesignForm
{
    public class DesignFormModule : BaseModule
    {
        public DesignFormModule()
        {
            Name = ModuleName.DesignForm.ToString();
            frmDesignForm frm = new frmDesignForm();
            UIMainForm = frm;
            InitializeModule();
        }
    }
}
