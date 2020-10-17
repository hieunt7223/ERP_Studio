using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;

namespace xdcb.FormStudio.ImportData
{
    public class ImportDataModule : BaseModule
    {
        public ImportDataModule()
        {
            Name = ModuleName.GenerateEntity.ToString();
            frmImportData frm = new frmImportData();
            UIMainForm = frm;

            InitializeModule();
        }
    }
}
