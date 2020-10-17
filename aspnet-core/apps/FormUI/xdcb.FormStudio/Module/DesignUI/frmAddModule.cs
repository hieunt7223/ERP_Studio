using System;
using DevExpress.XtraEditors;
using xdcb.FormServices.BaseForm;

namespace xdcb.FormStudio
{
    public partial class frmAddModule : XtraForm
    {
        #region parameter
        //public Modules objModules { get; set; }
        //ContextDb _Context = new ContextDb();
        #endregion

        public frmAddModule()
        {
            InitializeComponent();
            SetProperty.InitializeControls(grb_info.Controls);
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(cbb_STSystemID.EditValue.ToString()))
            //{
            //    Functions.ShowMessage("Vui lòng chọn phân hệ");
            //    return;
            //}
            //else if (string.IsNullOrWhiteSpace(txt_STModuleName.EditValue.ToString()))
            //{
            //    Functions.ShowMessage("Vui lòng nhập tên giao diện");
            //    return;
            //}
            //else if (string.IsNullOrWhiteSpace(txt_STModuleNo.EditValue.ToString()))
            //{
            //    Functions.ShowMessage("Vui lòng nhập mã giao diện");
            //    return;
            //}
            //else if (_Context.Modules.ToList().Where(x => x.ModuleNo == txt_STModuleNo.EditValue.ToString().Trim()).ToList().Count() > 0)
            //{
            //    Functions.ShowMessage("Mã giao diện đã trùng, Vui lòng kiểm tra lại");
            //    return;
            //}
            //objModules = new Modules();
            //objModules.Status = Status.Alive.ToString();
            //objModules.FK_SystemID = cbb_STSystemID.EditValue == null ? 0 : Convert.ToInt32(cbb_STSystemID.EditValue.ToString());
            //objModules.ModuleParentID = cbb_STModuleID.EditValue == null ? 0 : Convert.ToInt32(cbb_STModuleID.EditValue.ToString());
            //objModules.ModuleNo = txt_STModuleNo.EditValue.ToString();
            //objModules.ModuleName = txt_STModuleName.EditValue.ToString();
            //string link = string.Empty;

            //Systems objSTSystems = _Context.Systems.ToList().Where(x => x.SystemID == objModules.FK_SystemID).ToList().FirstOrDefault();
            //if (objSTSystems.SystemID > 0)
            //{
            //    link = objSTSystems.SystemNo + @"\";
            //}

            //if (objModules.ModuleParentID != 0)
            //{
            //    Modules objInfo = _Context.Modules.ToList().Where(x => x.ModuleID == objModules.ModuleParentID).ToList().FirstOrDefault();
            //    if (objInfo.ModuleID > 0)
            //        link += objInfo.ModuleNo + @"\";
            //}
            //else
            //{
            //    link += objModules.ModuleNo + @"\";
            //}
            //objModules.ModuleLink = link;
            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}