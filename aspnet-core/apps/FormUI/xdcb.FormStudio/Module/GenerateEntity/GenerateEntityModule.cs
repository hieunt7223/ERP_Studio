using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;

namespace xdcb.FormStudio.GenerateEntity
{
    public class GenerateEntityModule : BaseModule
    {
        public GenerateEntityModule()
        {
            Name = ModuleName.GenerateEntity.ToString();
            frmGenerateEntity frm = new frmGenerateEntity();
            UIMainForm = frm;

            InitializeModule();
        }
    }
}
