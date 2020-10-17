using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;

namespace xdcb.FormStudio.DesignGridView
{
    public partial class guiCreateGridView : XtraForm
    {
        public string FileName;
        public string moduleName;
        public guiCreateGridView(string strCreate)
        {
            InitializeComponent();
            GetValueControl();
            if (strCreate == CreateDesignGrid.NewGridView.ToString())
            {
                txt_Group.Text = CreateDesignGrid.NewGridView.GetDescription();
            }
            else if (strCreate == CreateDesignGrid.NewBanded.ToString())
            {
                txt_Group.Text = CreateDesignGrid.NewBanded.GetDescription();
            }
        }

        public void GetValueControl()
        {
            cbb_Module.ColumnsCaption = new string[1] { ComboBaseControl.Value.GetDescription().ToString() };
            cbb_Module.FieldsName = new string[1] { ComboBaseControl.Value.ToString() };
            cbb_Module.ValueMember = ComboBaseControl.Key.ToString();
            cbb_Module.DisplayMember = ComboBaseControl.Value.ToString();
            cbb_Module.DataSource = typeof(ModuleName).ToList();
            cbb_Module.cboBase.CustomDisplayText += cbb_Module_CustomDisplayText;
            cbb_Module.ShowData();
        }

        private void cbb_Module_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.DisplayText != null)
            {
                ModuleName status;
                Enum.TryParse(e.Value.ToString(), out status);
                e.DisplayText = typeof(ModuleName).GetValueByKey(status);
            }
            else
            {
                e.DisplayText = null;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_dongy_Click(object sender, EventArgs e)
        {
            if (txt_FileName.EditValue == null)
            {
                GGFunctions.ShowMessage("Vui lòng nhập tên file!");
                return;
            }
            if (cbb_Module.EditValue == null)
            {
                GGFunctions.ShowMessage("Vui lòng chọn tên module!");
                return;
            }
            moduleName = cbb_Module.EditValue.ToString();
            FileName = txt_Group.Text + txt_FileName.EditValue.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}