using System;
using System.Windows.Forms;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Component;
using xdcb.FormServices.Shared;
using System.IO;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;

namespace xdcb.FormStudio.DesignGridView
{
    public partial class frmDesignGridView : GGScreen
    {
        #region
        public string pathDesign;
        public string strCreate;
        #endregion
        public frmDesignGridView()
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
                guiCreateGridView guiCreate = new guiCreateGridView(strCreate);
                if (guiCreate.ShowDialog() == DialogResult.OK)
                {
                    string path = ConfigManager.PathGridViewXML() + guiCreate.moduleName + @"\";
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
                    SaveXMLGridView(path);
                    pathDesign = path;
                    lbl_text.Text = guiCreate.FileName + ".xml";
                    GGFunctions.ShowMessage("Lưu giao diện gridView Thành công!");
                }
            }
            else
            {
                if (File.Exists(pathDesign))
                {
                    File.Delete(pathDesign);
                }
                SaveXMLGridView(pathDesign);
                GGFunctions.ShowMessage("Lưu giao diện gridView Thành công!");
            }
        }

        private void btn_Saveas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(strCreate))
            {
                GGFunctions.ShowMessage("Vui lòng chọn tạo mới hoặc chỉnh sửa file trước!");
                return;
            }
            guiCreateGridView guiCreate = new guiCreateGridView(strCreate);
            if (guiCreate.ShowDialog() == DialogResult.OK)
            {
                string path = ConfigManager.PathGridViewXML() + guiCreate.moduleName + @"\";
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
                SaveXMLGridView(path);
                pathDesign = path;
                lbl_text.Text = guiCreate.FileName + ".xml";
                GGFunctions.ShowMessage("Lưu giao diện gridView Thành công!");
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

        private void btn_NewGridView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pathDesign = string.Empty;
            lbl_text.Text = string.Empty;
            strCreate = CreateDesignGrid.NewGridView.ToString();
            SetGridControl();
            RunDesign();
        }

        private void btn_NewBanded_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pathDesign = string.Empty;
            lbl_text.Text = string.Empty;
            strCreate = CreateDesignGrid.NewBanded.ToString();
            SetGridControl();
            RunDesign();
        }

        private void btn_EditGridView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = ConfigManager.PathGridViewXML();
            dialog.ValidateNames = false;
            dialog.CheckFileExists = false;
            dialog.CheckPathExists = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.SafeFileName;
                if (!filename.StartsWith(CreateDesignGrid.NewGridView.GetDescription()))
                {
                    GGFunctions.ShowMessage("Không phải là file GridView để chỉnh sửa. Vui lòng kiểm tra lại!");
                    return;
                }
                pathDesign = dialog.FileName;
                lbl_text.Text = filename;
                strCreate = CreateDesignGrid.NewGridView.ToString();
                SetGridControl();
                grd_DesignGrid.MainView.RestoreLayoutFromXml(pathDesign, OptionsLayoutBase.FullLayout);
            }
        }

        private void btn_EditBanded_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = ConfigManager.PathGridViewXML();
            dialog.ValidateNames = false;
            dialog.CheckFileExists = false;
            dialog.CheckPathExists = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.SafeFileName;
                if (!filename.StartsWith(CreateDesignGrid.NewBanded.GetDescription()))
                {
                    GGFunctions.ShowMessage("Không phải là file BandedGrid để chỉnh sửa. Vui lòng kiểm tra lại!");
                    return;
                }
                pathDesign = dialog.FileName;
                lbl_text.Text = filename;
                strCreate = CreateDesignGrid.NewBanded.ToString();
                SetGridControl();
                grd_DesignGrid.MainView.RestoreLayoutFromXml(pathDesign, OptionsLayoutBase.FullLayout);
            }
        }
        #endregion

        #region Config
        public void RunDesign()
        {
            var gridDesigner = new GridDesigner();
            gridDesigner.InitGrid(grd_DesignGrid);
            gridDesigner.ShowDialog();
        }
        public void SetGridControl()
        {
            if (strCreate == CreateDesignGrid.NewGridView.ToString())
            {
                gridView1.Columns.Clear();
                grd_DesignGrid.MainView = gridView1;
            }
            else if (strCreate == CreateDesignGrid.NewBanded.ToString())
            {
                bandedGridView1.Columns.Clear();
                bandedGridView1.Bands.Clear();
                grd_DesignGrid.MainView = bandedGridView1;
            }
        }
        #endregion

        public void SaveXMLGridView(string path)
        {
            if (strCreate == CreateDesignGrid.NewGridView.ToString())
            {
                GridView gridView = (GridView)grd_DesignGrid.MainView;
                if (gridView.Columns.Count > 0)
                {
                    int i = 1;
                    foreach (GridColumn column in gridView.Columns)
                    {
                        column.Name = "GridColumn" + i.ToString();
                        i++;
                    }
                }
                gridView.SaveLayoutToXml(path, OptionsLayoutBase.FullLayout);
            }
            else if (strCreate == CreateDesignGrid.NewBanded.ToString())
            {
                BandedGridView bandedGridView = (BandedGridView)grd_DesignGrid.MainView;
                if (bandedGridView.Columns.Count > 0)
                {
                    int i = 1;
                    foreach (BandedGridColumn column in bandedGridView.Columns)
                    {
                        column.Name = "BandedGridColumn" + i.ToString();
                        i++;
                    }
                }
                bandedGridView.SaveLayoutToXml(path, OptionsLayoutBase.FullLayout);
            }

        }
    }
}