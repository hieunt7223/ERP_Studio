using System;
using System.Windows.Forms;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Component;
using xdcb.FormServices.Shared;
using System.IO;
using DevExpress.Utils;
using DevExpress.XtraTreeList.Columns;

namespace xdcb.FormStudio.DesignTreeList
{
    public partial class frmDesignTreeList : GGScreen
    {
        #region
        public string pathDesign;
        public string strCreate;
        #endregion
        public frmDesignTreeList()
        {
            InitializeComponent();
            pathDesign = string.Empty;
            lbl_text.Text = string.Empty;
            strCreate = string.Empty;
        }

        #region Action
        private void btn_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(strCreate))
            {
                GGFunctions.ShowMessage("Vui lòng chọn tạo mới hoặc chỉnh sửa file trước!");

                return;
            }
            if (string.IsNullOrWhiteSpace(pathDesign))
            {
                guiCreateTreeList guiCreate = new guiCreateTreeList();
                if (guiCreate.ShowDialog() == DialogResult.OK)
                {
                    string path = ConfigManager.PathTreeListXML() + guiCreate.moduleName + @"\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    path += guiCreate.FileName + ".xml";
                    if (File.Exists(path))
                    {
                        GGFunctions.ShowMessage("Tên giao diện đã trùng. Vui lòng kiểm tra lại!");
                        return;
                    }
                    SaveColumnTreeList(path);
                    pathDesign = path;
                    lbl_text.Text = guiCreate.FileName + ".xml";
                    GGFunctions.ShowMessage("Lưu xml TreeList Thành công!");
                }
            }
            else
            {
                if (File.Exists(pathDesign))
                {
                    File.Delete(pathDesign);
                }
                SaveColumnTreeList(pathDesign);
                GGFunctions.ShowMessage("Lưu xml TreeList Thành công!");
            }
        }

        private void btn_Saveas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(strCreate))
            {
                GGFunctions.ShowMessage("Vui lòng chọn tạo mới hoặc chỉnh sửa file trước!");
                return;
            }
            guiCreateTreeList guiCreate = new guiCreateTreeList();
            if (guiCreate.ShowDialog() == DialogResult.OK)
            {
                string path = ConfigManager.PathTreeListXML() + guiCreate.moduleName + @"\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += guiCreate.FileName + ".xml";
                if (File.Exists(path))
                {
                    GGFunctions.ShowMessage("Tên giao diện đã trùng. Vui lòng kiểm tra lại!");
                    return;
                }
                SaveColumnTreeList(path);
                pathDesign = path;
                lbl_text.Text = guiCreate.FileName + ".xml";
                GGFunctions.ShowMessage("Lưu xml TreeList Thành công!");
            }
        }

        private void btn_runDesign_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(strCreate))
            {
                GGFunctions.ShowMessage("Vui lòng chọn tạo mới hoặc chỉnh sửa file trước!");
                return;
            }
            RunDesign();
        }
        private void btn_EditTreeList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = ConfigManager.PathTreeListXML();
            dialog.ValidateNames = false;
            dialog.CheckFileExists = false;
            dialog.CheckPathExists = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.SafeFileName;
                if (!filename.StartsWith(CreateDesignTree.NewTreeList.GetDescription()))
                {
                    GGFunctions.ShowMessage("Không phải là file TreeList để chỉnh sửa. Vui lòng kiểm tra lại!");
                    return;
                }
                pathDesign = dialog.FileName;
                lbl_text.Text = filename;
                strCreate = CreateDesignTree.NewTreeList.ToString();
                SetTreeListControl();
                tre_DesignTreeList.RestoreLayoutFromXml(pathDesign, OptionsLayoutBase.FullLayout);
            }
        }

        private void btn_NewTreeList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pathDesign = string.Empty;
            lbl_text.Text = string.Empty;
            strCreate = CreateDesignTree.NewTreeList.ToString();
            SetTreeListControl();
            RunDesign();
        }
        #endregion

        #region Config
        public void RunDesign()
        {
            try
            {
                var treeDesigner = new TreeDesigner();
                treeDesigner.InitEditingObject(tre_DesignTreeList);
                treeDesigner.ShowDialog();
            }
            catch (Exception ex)
            {
                //
            }
        }
        public void SetTreeListControl()
        {
            tre_DesignTreeList.Columns.Clear();
        }

        public void SaveColumnTreeList(string path)
        {
            tre_DesignTreeList.OptionsLayout.StoreAllOptions = false;
            tre_DesignTreeList.OptionsLayout.StoreAppearance = true;
            tre_DesignTreeList.OptionsBehavior.PopulateServiceColumns = true;
            if (tre_DesignTreeList.Columns.Count > 0)
            {
                int i = 1;
                foreach (TreeListColumn column in tre_DesignTreeList.Columns)
                {
                    column.Name = "TreeListColumn" + i.ToString();
                    i++;
                }
            }
            tre_DesignTreeList.SaveLayoutToXml(path, OptionsLayoutBase.FullLayout);
        }
        #endregion
    }
}