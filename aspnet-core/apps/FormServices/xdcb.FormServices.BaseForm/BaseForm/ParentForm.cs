using System.Windows.Forms;
using xdcb.FormServices.Shared;
using xdcb.FormServices.Component;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;

namespace xdcb.FormServices.BaseForm
{
    public partial class ParentForm : GGScreen
    {
        #region
        public string btnAction;

        public string pathJsonUI;

        public BaseModule Module { get; set; }

        public Panel pnMainControl;

        public GGSearchGridControl gridSearch;

        public Bar Toolbar;

        public DockPanel DockPanelLeft;

        #endregion
        public ParentForm()
        {
            InitializeComponent();
            BaseFormModule();
            pnMainControl = panelview;
            gridSearch = grd_Search;
            Toolbar = BarMenu;
            DockPanelLeft = pnlLeftPanel;
            GridView dgvSearchResults = (GridView)gridSearch.MainView;
        }
        public virtual void BaseFormModule()
        {
            InitializeForm();
        }

        public virtual void InitializeForm()
        {
            InitObject();
            InitJsonUI();
            InitFormSearch();

            InitializeJsonForControl();

            InvalidateToolBar();
        }

        public virtual void InitObject()
        {
        }
        public virtual void InitJsonUI()
        {
        }

        public virtual void InitializeJsonForControl()
        {
            string url = ConfigManager.PathDesignUI() + pathJsonUI;
        }

        public virtual Control InitializeControl(Control ctrl)
        {
            if (ctrl is IGGControl)
            {
                IGGControl control = (IGGControl)ctrl;
                control.InitializeControl();
            }
            return ctrl;
        }


        //Truyền dữ liệu vào cột
        public virtual void InitFormSearch()
        {
            //string dataMember = GetProperty.GetPropertyStringValue(ctrl, Customs.cstDataMember);
            //grd_Search.Controls.
        }

        public virtual void GetDataSearch()
        {

        }

        #region InvalidateToolBar
        public void InvalidateToolBar()
        {
            if (!string.IsNullOrWhiteSpace(btnAction))
            {
                if (btnAction == ButtonAction.btnNew.ToString())
                {
                    pnlLeftPanel.Enabled = false;
                    stm_New.Enabled = false;
                    stm_Cancel.Enabled = true;
                    stm_Delete.Enabled = true;
                    stm_Save.Enabled = true;
                    stm_Edit.Enabled = false;
                }
                else if (btnAction == ButtonAction.btnCancel.ToString())
                {
                    pnlLeftPanel.Enabled = true;
                    stm_New.Enabled = true;
                    stm_Cancel.Enabled = false;
                    stm_Delete.Enabled = false;
                    stm_Save.Enabled = false;
                    stm_Edit.Enabled = true;
                }
                else if (btnAction == ButtonAction.btnDelete.ToString())
                {
                    pnlLeftPanel.Enabled = true;
                    stm_New.Enabled = true;
                    stm_Cancel.Enabled = false;
                    stm_Delete.Enabled = false;
                    stm_Save.Enabled = false;
                    stm_Edit.Enabled = false;
                    //pnMainControls.Controls.Clear();
                }
                else if (btnAction == ButtonAction.btnSave.ToString())
                {
                    pnlLeftPanel.Enabled = true;
                    stm_New.Enabled = true;
                    stm_Cancel.Enabled = false;
                    stm_Delete.Enabled = false;
                    stm_Save.Enabled = false;
                    stm_Edit.Enabled = true;
                }
                else if (btnAction == ButtonAction.btnEdit.ToString())
                {
                    pnlLeftPanel.Enabled = false;
                    stm_New.Enabled = false;
                    stm_Cancel.Enabled = true;
                    stm_Delete.Enabled = true;
                    stm_Save.Enabled = true;
                    stm_Edit.Enabled = false;
                }

                else if (btnAction == ButtonAction.btnView.ToString())
                {
                    pnlLeftPanel.Enabled = true;
                    stm_New.Enabled = true;
                    stm_Cancel.Enabled = false;
                    stm_Delete.Enabled = false;
                    stm_Save.Enabled = false;
                    stm_Edit.Enabled = true;
                }
            }
            else
            {
                pnlLeftPanel.Enabled = true;
                stm_New.Enabled = true;
                stm_Cancel.Enabled = false;
                stm_Delete.Enabled = false;
                stm_Save.Enabled = false;
                stm_Edit.Enabled = false;
            }
        }
        #endregion

        #region Tạo mới
        private void stm_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Module.ActionNew();
            btnAction = ButtonAction.btnNew.ToString();
            InvalidateToolBar();
            Cursor.Current = Cursors.Default;

        }
        #endregion

        #region Sửa
        private void stm_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Module.ActionEdit();
            btnAction = ButtonAction.btnEdit.ToString();
            InvalidateToolBar();
        }

        #endregion

        #region Hủy
        private void stm_Cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Module.ActionCancel();
            btnAction = ButtonAction.btnCancel.ToString();
            InvalidateToolBar();
        }
        #endregion

        #region Xóa
        private void stm_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Module.ActionDelete();
            btnAction = ButtonAction.btnDelete.ToString();
            InvalidateToolBar();
        }
        #endregion

        #region Lưu
        private void stm_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = Module.ActionSave();
            btnAction = ButtonAction.btnSave.ToString();
            InvalidateToolBar();
        }
        #endregion Lưu

        public void InitForm()
        {
            this.Text = FunctionModule.CurrentModule;

            //InitBarSubMenus();
            //InitDisplayToolbar();

            ////Init close module button 
            //DevExpress.XtraBars.BarButtonItem barbtnCloseModule = new DevExpress.XtraBars.BarButtonItem();
            //barbtnCloseModule.Name = "fld_barbtnCloseModule";
            //barbtnCloseModule.Caption = "Close Module";
            //barbtnCloseModule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BarButtonCloseModule_ItemClick);
            //barbtnCloseModule.Id = ToolbarManager.GetNewItemId();
            //ToolbarManager.Items.Add(barbtnCloseModule);
            //barSubItemMenuFile.AddItem(barbtnCloseModule);
            //barSubItemMenuFile.ItemLinks[barSubItemMenuFile.ItemLinks.Count - 1].BeginGroup = true;

            ////Add close application button
            //DevExpress.XtraBars.BarButtonItem barbtnCloseApp = new DevExpress.XtraBars.BarButtonItem();
            //barbtnCloseApp.Name = "fld_barbtnCloseApp";
            //barbtnCloseApp.Caption = "Exit POS";
            //barbtnCloseApp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BarButtonCloseApp_ItemClick);
            //barbtnCloseApp.Id = ToolbarManager.GetNewItemId();
            //ToolbarManager.Items.Add(barbtnCloseApp);
            //barSubItemMenuFile.AddItem(barbtnCloseApp);
        }
        public void InitDisplayToolbar()
        {

        }

        private void frmBaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);
            FunctionModule.RemoveOpenedModule(Module);
            SplashScreenManager.CloseForm();
        }
    }
}