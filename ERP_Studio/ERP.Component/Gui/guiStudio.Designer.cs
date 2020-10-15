using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraNavBar;
using DevExpress.XtraTabbedMdi;
using ERP.Component.ControlCustom;
using System.ComponentModel;
using System.Windows.Forms;

namespace ERP.Component
{
    partial class guiStudio
    {
        
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiStudio));
            this.fld_imglToolbarManager = new System.Windows.Forms.ImageList(this.components);
            this.ToolbarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.toolbarModuleAction = new DevExpress.XtraBars.Bar();
            this.fld_barcmbModule = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBoxModule = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.fld_barcmbUserGroup = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBoxUserGroup = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.fld_barbtnStart = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnClose = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barmnuTranslation = new DevExpress.XtraBars.BarSubItem();
            this.fld_barbtnExport = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnImport = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.toolbarControlFormat = new DevExpress.XtraBars.Bar();
            this.fld_barbtnFormatNone = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnAlignLeft = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnAlignRight = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnAlignBottom = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnAlignTop = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnSameWidth = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnSameHeight = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnSameSize = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnHorizontalSpacing = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnVerticalSpacing = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonAddX = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonAddY = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barspeSpacing = new DevExpress.XtraBars.BarEditItem();
            this.repositorySpinEditSpacing = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.fld_barbtnSameColor = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barlblFormatDesc = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem22 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem23 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem24 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem25 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem29 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem30 = new DevExpress.XtraBars.BarButtonItem();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.fld_barcmbTables = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBoxTables = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barButtonLabel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnTabIndex = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnCreateToolbar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem16 = new DevExpress.XtraBars.BarButtonItem();
            this.drawControl2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.moveLabel = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem5 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem18 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPermission = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.fld_barbtnExportScreen = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnImportScreen = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnDeleteAllControls = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPasteFeomClipboard = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem28 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem6 = new DevExpress.XtraBars.BarSubItem();
            this.fld_barbtnControls = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnFunctionControls = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnGridColumn = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barButtonExportControlName = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barButtonImportControlName = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbuttonCheckGridControl = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem19 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem20 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem21 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem26 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem7 = new DevExpress.XtraBars.BarSubItem();
            this.fld_barbtnCreateTables = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnRenameModuleTables = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnModuleFunctions = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnImportFunctions = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem31 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem8 = new DevExpress.XtraBars.BarSubItem();
            this.fld_barbtnReportStudio = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnAssignReport = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem9 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnCompanyConfig = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnConfigModuleDisplay = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemFieldFormatGroup = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCreateUniqueColumn = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnTableAlias = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem10 = new DevExpress.XtraBars.BarSubItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barCutBtn = new DevExpress.XtraBars.BarButtonItem();
            this.barPasteBtn = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem32 = new DevExpress.XtraBars.BarButtonItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockSectionManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockSectionPanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.navbarSectionManager = new DevExpress.XtraNavBar.NavBarControl();
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockToolboxPanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fld_navBarToolboxControl = new DevExpress.XtraNavBar.NavBarControl();
            this.fld_navBarGroupModuleFields = new DevExpress.XtraNavBar.NavBarGroup();
            this.fld_navBarGroupSearchFields = new DevExpress.XtraNavBar.NavBarGroup();
            this.fld_navbarGroupComponents = new DevExpress.XtraNavBar.NavBarGroup();
            this.fld_navBarComboBox = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarItemLabel = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarItemButton = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarItemCheckEdit = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarItemTextBox = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarPictureEdit = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarCalcEdit = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarLookupEdit = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_narBarItemDateEdit = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarItemTimeEdit = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarItemGrid = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarItemLine = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarItemGroupControl = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarItemTabControl = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarPanel = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarItemBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarGridLookupEdit = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarTreeList = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarPopupContainerControl = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarPopupContainerEdit = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarSplitter = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarGroupScreens = new DevExpress.XtraNavBar.NavBarGroup();
            this.fld_navBarItemDataMain = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarItemSearchScreen = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarItemDataSubScreen = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarItemSearchResultsScreen = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_navBarItemSeperate = new DevExpress.XtraNavBar.NavBarItem();
            this.fld_imglToolbox = new System.Windows.Forms.ImageList(this.components);
            this.dockPropertiesPanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer2 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.m_toolbarIcons = new System.Windows.Forms.ImageList(this.components);
            this.fld_barsmnuFile = new DevExpress.XtraBars.BarSubItem();
            this.fld_barmnuExit = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barsmnuView = new DevExpress.XtraBars.BarSubItem();
            this.fld_mnubarbtnToolbox = new DevExpress.XtraBars.BarButtonItem();
            this.fld_mnubarbtnPropertyExplorer = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barsmnuHelp = new DevExpress.XtraBars.BarSubItem();
            this.fld_barmnbContents = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barmnbSystemInfo = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barmnbLicenses = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barmnbAbout = new DevExpress.XtraBars.BarButtonItem();
            this.fld_mnubarbtnConfigTables = new DevExpress.XtraBars.BarButtonItem();
            this.fld_mnubarbtnImportFunctions = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnTranslation = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.fld_barlblControlText = new DevExpress.XtraBars.BarStaticItem();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.barButtonItem27 = new DevExpress.XtraBars.BarButtonItem();
            this.drawControl = new DevExpress.XtraBars.BarEditItem();
            this.repositoryDrawControl = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.fld_xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.fld_lblAppInfoBar = new System.Windows.Forms.Label();
            this.fld_pnlAppInfo = new System.Windows.Forms.Panel();
            this.lblCurrentControlName = new System.Windows.Forms.Label();
            this.hideContainerLeft = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.fld_openDialogImportGrid = new System.Windows.Forms.OpenFileDialog();
            this.txtQuickText = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorySpinEditSpacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockSectionManager)).BeginInit();
            this.dockSectionPanel.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navbarSectionManager)).BeginInit();
            this.panelContainer1.SuspendLayout();
            this.dockToolboxPanel.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_navBarToolboxControl)).BeginInit();
            this.dockPropertiesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDrawControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_xtraTabbedMdiManager)).BeginInit();
            this.fld_pnlAppInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuickText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_imglToolbarManager
            // 
            this.fld_imglToolbarManager.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.fld_imglToolbarManager.ImageSize = new System.Drawing.Size(16, 16);
            this.fld_imglToolbarManager.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ToolbarManager
            // 
            this.ToolbarManager.AllowCustomization = false;
            this.ToolbarManager.AllowQuickCustomization = false;
            this.ToolbarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.toolbarModuleAction,
            this.toolbarControlFormat,
            this.bar1,
            this.bar2});
            this.ToolbarManager.Controller = this.barAndDockingController1;
            this.ToolbarManager.DockControls.Add(this.barDockControlTop);
            this.ToolbarManager.DockControls.Add(this.barDockControlBottom);
            this.ToolbarManager.DockControls.Add(this.barDockControlLeft);
            this.ToolbarManager.DockControls.Add(this.barDockControlRight);
            this.ToolbarManager.DockManager = this.dockSectionManager;
            this.ToolbarManager.Form = this;
            this.ToolbarManager.Images = this.m_toolbarIcons;
            this.ToolbarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.fld_barsmnuFile,
            this.fld_barsmnuView,
            this.fld_barsmnuHelp,
            this.fld_barmnbContents,
            this.fld_barmnbSystemInfo,
            this.fld_barmnbLicenses,
            this.fld_barmnbAbout,
            this.fld_barmnuExit,
            this.fld_mnubarbtnPropertyExplorer,
            this.fld_mnubarbtnToolbox,
            this.fld_mnubarbtnConfigTables,
            this.fld_mnubarbtnImportFunctions,
            this.fld_barbtnStart,
            this.fld_barbtnClose,
            this.fld_barbtnAlignLeft,
            this.fld_barbtnAlignRight,
            this.fld_barbtnAlignBottom,
            this.fld_barbtnSameWidth,
            this.fld_barbtnSameHeight,
            this.fld_barbtnSameSize,
            this.fld_barbtnHorizontalSpacing,
            this.fld_barbtnVerticalSpacing,
            this.fld_barbtnFormatNone,
            this.fld_barspeSpacing,
            this.fld_barbtnCreateTables,
            this.fld_barbtnImportFunctions,
            this.fld_barcmbModule,
            this.fld_barbtnAlignTop,
            this.fld_barbtnControls,
            this.fld_barbtnFunctionControls,
            this.barButtonItem2,
            this.barButtonItem3,
            this.fld_barbtnModuleFunctions,
            this.fld_barbtnRenameModuleTables,
            this.fld_barlblFormatDesc,
            this.barButtonItem1,
            this.fld_barcmbTables,
            this.barButtonItem5,
            this.fld_barbtnCreateToolbar,
            this.fld_barbtnCompanyConfig,
            this.fld_barbtnSameColor,
            this.fld_barbtnTranslation,
            this.fld_barmnuTranslation,
            this.fld_barbtnExport,
            this.fld_barbtnImport,
            this.barButtonItem4,
            this.barButtonLabel,
            this.barButtonItem7,
            this.fld_barbtnTabIndex,
            this.barButtonItem8,
            this.barButtonItem9,
            this.barButtonAddX,
            this.barButtonAddY,
            this.barSubItem1,
            this.fld_barbtnExportScreen,
            this.fld_barbtnImportScreen,
            this.fld_barbtnDeleteAllControls,
            this.barStaticItem1,
            this.barStaticItem2,
            this.barSubItem2,
            this.barSubItem3,
            this.barSubItem4,
            this.barButtonItem6,
            this.barButtonItem11,
            this.fld_barlblControlText,
            this.barSubItem5,
            this.barButtonItem12,
            this.barButtonItem13,
            this.barButtonItem14,
            this.barButtonItemFieldFormatGroup,
            this.barButtonItem15,
            this.fld_barbtnReportStudio,
            this.fld_barbtnAssignReport,
            this.barButtonItemPasteFeomClipboard,
            this.fld_barbtnGridColumn,
            this.fld_barbuttonCheckGridControl,
            this.barButtonItemCreateUniqueColumn,
            this.fld_barButtonExportControlName,
            this.barButtonItem16,
            this.fld_barButtonImportControlName,
            this.barbtnConfigModuleDisplay,
            this.barButtonItem18,
            this.barSubItem6,
            this.barSubItem7,
            this.barSubItem8,
            this.barSubItem9,
            this.barButtonItem19,
            this.barButtonItem20,
            this.barButtonItem21,
            this.barButtonItem22,
            this.barButtonItem23,
            this.barButtonItem24,
            this.barButtonItem25,
            this.barCheckItem1,
            this.barButtonItem26,
            this.barButtonItem27,
            this.barButtonItem28,
            this.drawControl,
            this.drawControl2,
            this.moveLabel,
            this.barButtonItem29,
            this.barButtonItem30,
            this.barbtnTableAlias,
            this.fld_barcmbUserGroup,
            this.barBtnPermission,
            this.barButtonItem31,
            this.btnDelete,
            this.barSubItem10,
            this.barCutBtn,
            this.barPasteBtn,
            this.barButtonItem32});
            this.ToolbarManager.LargeImages = this.fld_imglToolbarManager;
            this.ToolbarManager.MainMenu = this.bar2;
            this.ToolbarManager.MaxItemId = 213;
            this.ToolbarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositorySpinEditSpacing,
            this.repositoryItemTextEdit1,
            this.repositoryItemComboBoxUserGroup,
            this.repositoryItemComboBoxModule,
            this.repositoryItemCheckEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemComboBoxTables,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryDrawControl,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3,
            this.repositoryItemComboBox1});
            // 
            // toolbarModuleAction
            // 
            this.toolbarModuleAction.BarName = "Custom 2";
            this.toolbarModuleAction.DockCol = 0;
            this.toolbarModuleAction.DockRow = 1;
            this.toolbarModuleAction.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.toolbarModuleAction.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.fld_barcmbModule, "", false, true, true, 125),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.fld_barcmbUserGroup, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnStart),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnClose),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barmnuTranslation, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem11)});
            this.toolbarModuleAction.Text = "Action";
            // 
            // fld_barcmbModule
            // 
            this.fld_barcmbModule.Caption = "Module:";
            this.fld_barcmbModule.Edit = this.repositoryItemComboBoxModule;
            this.fld_barcmbModule.Id = 91;
            this.fld_barcmbModule.Name = "fld_barcmbModule";
            this.fld_barcmbModule.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            // 
            // repositoryItemComboBoxModule
            // 
            this.repositoryItemComboBoxModule.AllowFocused = false;
            this.repositoryItemComboBoxModule.AutoHeight = false;
            this.repositoryItemComboBoxModule.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBoxModule.Name = "repositoryItemComboBoxModule";
            this.repositoryItemComboBoxModule.Sorted = true;
            this.repositoryItemComboBoxModule.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // fld_barcmbUserGroup
            // 
            this.fld_barcmbUserGroup.Caption = "User Group";
            this.fld_barcmbUserGroup.Edit = this.repositoryItemComboBoxUserGroup;
            this.fld_barcmbUserGroup.EditWidth = 100;
            this.fld_barcmbUserGroup.Id = 205;
            this.fld_barcmbUserGroup.Name = "fld_barcmbUserGroup";
            // 
            // repositoryItemComboBoxUserGroup
            // 
            this.repositoryItemComboBoxUserGroup.AllowFocused = false;
            this.repositoryItemComboBoxUserGroup.AutoHeight = false;
            this.repositoryItemComboBoxUserGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBoxUserGroup.Name = "repositoryItemComboBoxUserGroup";
            this.repositoryItemComboBoxUserGroup.Sorted = true;
            this.repositoryItemComboBoxUserGroup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // fld_barbtnStart
            // 
            this.fld_barbtnStart.Caption = "Start";
            this.fld_barbtnStart.Id = 74;
            this.fld_barbtnStart.Name = "fld_barbtnStart";
            // 
            // fld_barbtnClose
            // 
            this.fld_barbtnClose.Caption = "Close";
            this.fld_barbtnClose.Id = 75;
            this.fld_barbtnClose.Name = "fld_barbtnClose";
            // 
            // fld_barmnuTranslation
            // 
            this.fld_barmnuTranslation.Caption = "Translation";
            this.fld_barmnuTranslation.Id = 130;
            this.fld_barmnuTranslation.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnExport),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnImport)});
            this.fld_barmnuTranslation.Name = "fld_barmnuTranslation";
            // 
            // fld_barbtnExport
            // 
            this.fld_barbtnExport.Caption = "Export";
            this.fld_barbtnExport.Id = 131;
            this.fld_barbtnExport.Name = "fld_barbtnExport";
            // 
            // fld_barbtnImport
            // 
            this.fld_barbtnImport.Caption = "Import";
            this.fld_barbtnImport.Id = 132;
            this.fld_barbtnImport.Name = "fld_barbtnImport";
            // 
            // barButtonItem11
            // 
            this.barButtonItem11.Caption = "TabStop";
            this.barButtonItem11.Id = 161;
            this.barButtonItem11.Name = "barButtonItem11";
            // 
            // toolbarControlFormat
            // 
            this.toolbarControlFormat.BarName = "Format";
            this.toolbarControlFormat.DockCol = 0;
            this.toolbarControlFormat.DockRow = 2;
            this.toolbarControlFormat.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.toolbarControlFormat.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnFormatNone),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnAlignLeft, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnAlignRight),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnAlignBottom),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnAlignTop),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnSameWidth, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnSameHeight),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnSameSize),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnHorizontalSpacing, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnVerticalSpacing),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonAddX),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonAddY),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.fld_barspeSpacing, "", false, true, true, 51),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnSameColor),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barlblFormatDesc),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem22),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem23, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem24),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem25),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem29),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem30)});
            this.toolbarControlFormat.Text = "Control Format";
            // 
            // fld_barbtnFormatNone
            // 
            this.fld_barbtnFormatNone.Caption = "None";
            this.fld_barbtnFormatNone.Id = 85;
            this.fld_barbtnFormatNone.Name = "fld_barbtnFormatNone";
            // 
            // fld_barbtnAlignLeft
            // 
            this.fld_barbtnAlignLeft.Caption = "Align Left";
            this.fld_barbtnAlignLeft.Id = 76;
            this.fld_barbtnAlignLeft.ImageOptions.ImageIndex = 2;
            this.fld_barbtnAlignLeft.Name = "fld_barbtnAlignLeft";
            // 
            // fld_barbtnAlignRight
            // 
            this.fld_barbtnAlignRight.Caption = "Align Right";
            this.fld_barbtnAlignRight.Id = 77;
            this.fld_barbtnAlignRight.ImageOptions.ImageIndex = 3;
            this.fld_barbtnAlignRight.Name = "fld_barbtnAlignRight";
            // 
            // fld_barbtnAlignBottom
            // 
            this.fld_barbtnAlignBottom.Caption = "Align Bottom";
            this.fld_barbtnAlignBottom.Id = 78;
            this.fld_barbtnAlignBottom.ImageOptions.ImageIndex = 0;
            this.fld_barbtnAlignBottom.Name = "fld_barbtnAlignBottom";
            // 
            // fld_barbtnAlignTop
            // 
            this.fld_barbtnAlignTop.Caption = "Align Top";
            this.fld_barbtnAlignTop.Id = 96;
            this.fld_barbtnAlignTop.ImageOptions.ImageIndex = 4;
            this.fld_barbtnAlignTop.Name = "fld_barbtnAlignTop";
            // 
            // fld_barbtnSameWidth
            // 
            this.fld_barbtnSameWidth.Caption = "Same Width";
            this.fld_barbtnSameWidth.Id = 80;
            this.fld_barbtnSameWidth.ImageOptions.ImageIndex = 17;
            this.fld_barbtnSameWidth.Name = "fld_barbtnSameWidth";
            // 
            // fld_barbtnSameHeight
            // 
            this.fld_barbtnSameHeight.Caption = "Same Height";
            this.fld_barbtnSameHeight.Id = 81;
            this.fld_barbtnSameHeight.ImageOptions.ImageIndex = 15;
            this.fld_barbtnSameHeight.Name = "fld_barbtnSameHeight";
            // 
            // fld_barbtnSameSize
            // 
            this.fld_barbtnSameSize.Caption = "Same Size";
            this.fld_barbtnSameSize.Id = 82;
            this.fld_barbtnSameSize.ImageOptions.ImageIndex = 16;
            this.fld_barbtnSameSize.Name = "fld_barbtnSameSize";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Center Verti";
            this.barButtonItem2.Id = 101;
            this.barButtonItem2.ImageOptions.ImageIndex = 5;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Center Hori";
            this.barButtonItem3.Id = 102;
            this.barButtonItem3.ImageOptions.ImageIndex = 1;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // fld_barbtnHorizontalSpacing
            // 
            this.fld_barbtnHorizontalSpacing.Caption = "Hori Spacing";
            this.fld_barbtnHorizontalSpacing.Id = 83;
            this.fld_barbtnHorizontalSpacing.Name = "fld_barbtnHorizontalSpacing";
            // 
            // fld_barbtnVerticalSpacing
            // 
            this.fld_barbtnVerticalSpacing.Caption = "Verti Spacing";
            this.fld_barbtnVerticalSpacing.Id = 84;
            this.fld_barbtnVerticalSpacing.Name = "fld_barbtnVerticalSpacing";
            // 
            // barButtonAddX
            // 
            this.barButtonAddX.Caption = "Add X";
            this.barButtonAddX.Id = 142;
            this.barButtonAddX.Name = "barButtonAddX";
            // 
            // barButtonAddY
            // 
            this.barButtonAddY.Caption = "Add Y";
            this.barButtonAddY.Id = 145;
            this.barButtonAddY.Name = "barButtonAddY";
            // 
            // fld_barspeSpacing
            // 
            this.fld_barspeSpacing.Caption = "Spacing";
            this.fld_barspeSpacing.Edit = this.repositorySpinEditSpacing;
            this.fld_barspeSpacing.Id = 86;
            this.fld_barspeSpacing.Name = "fld_barspeSpacing";
            // 
            // repositorySpinEditSpacing
            // 
            this.repositorySpinEditSpacing.AutoHeight = false;
            this.repositorySpinEditSpacing.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositorySpinEditSpacing.Name = "repositorySpinEditSpacing";
            // 
            // fld_barbtnSameColor
            // 
            this.fld_barbtnSameColor.Caption = "Same Color";
            this.fld_barbtnSameColor.Id = 128;
            this.fld_barbtnSameColor.Name = "fld_barbtnSameColor";
            // 
            // fld_barlblFormatDesc
            // 
            this.fld_barlblFormatDesc.Id = 110;
            this.fld_barlblFormatDesc.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fld_barlblFormatDesc.ItemAppearance.Normal.Options.UseFont = true;
            this.fld_barlblFormatDesc.Name = "fld_barlblFormatDesc";
            // 
            // barButtonItem22
            // 
            this.barButtonItem22.Caption = "BringToFront";
            this.barButtonItem22.Id = 188;
            this.barButtonItem22.ImageOptions.ImageIndex = 11;
            this.barButtonItem22.Name = "barButtonItem22";
            // 
            // barButtonItem23
            // 
            this.barButtonItem23.Caption = "SendToBack";
            this.barButtonItem23.Id = 189;
            this.barButtonItem23.ImageOptions.ImageIndex = 12;
            this.barButtonItem23.Name = "barButtonItem23";
            // 
            // barButtonItem24
            // 
            this.barButtonItem24.Caption = "Delete";
            this.barButtonItem24.Id = 190;
            this.barButtonItem24.ImageOptions.LargeImageIndex = 4;
            this.barButtonItem24.Name = "barButtonItem24";
            // 
            // barButtonItem25
            // 
            this.barButtonItem25.Caption = "Cut";
            this.barButtonItem25.Id = 191;
            this.barButtonItem25.Name = "barButtonItem25";
            // 
            // barButtonItem29
            // 
            this.barButtonItem29.Caption = "Undo";
            this.barButtonItem29.Id = 202;
            this.barButtonItem29.Name = "barButtonItem29";
            // 
            // barButtonItem30
            // 
            this.barButtonItem30.Caption = "Redo";
            this.barButtonItem30.Id = 203;
            this.barButtonItem30.Name = "barButtonItem30";
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 4";
            this.bar1.DockCol = 1;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.fld_barcmbTables, "", true, true, true, 126),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonLabel),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem7),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnTabIndex),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnCreateToolbar),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem16),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.drawControl2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.moveLabel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Offset = 555;
            this.bar1.Text = "Custom 4";
            // 
            // fld_barcmbTables
            // 
            this.fld_barcmbTables.Caption = "Tables";
            this.fld_barcmbTables.Edit = this.repositoryItemComboBoxTables;
            this.fld_barcmbTables.Id = 115;
            this.fld_barcmbTables.Name = "fld_barcmbTables";
            this.fld_barcmbTables.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            // 
            // repositoryItemComboBoxTables
            // 
            this.repositoryItemComboBoxTables.AutoHeight = false;
            this.repositoryItemComboBoxTables.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBoxTables.Name = "repositoryItemComboBoxTables";
            this.repositoryItemComboBoxTables.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // barButtonLabel
            // 
            this.barButtonLabel.Caption = "Label";
            this.barButtonLabel.Id = 135;
            this.barButtonLabel.Name = "barButtonLabel";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Screen Text";
            this.barButtonItem7.Id = 136;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // fld_barbtnTabIndex
            // 
            this.fld_barbtnTabIndex.Caption = "Tab Index";
            this.fld_barbtnTabIndex.Id = 137;
            this.fld_barbtnTabIndex.Name = "fld_barbtnTabIndex";
            // 
            // fld_barbtnCreateToolbar
            // 
            this.fld_barbtnCreateToolbar.Caption = "Create Toolbar";
            this.fld_barbtnCreateToolbar.Id = 119;
            this.fld_barbtnCreateToolbar.Name = "fld_barbtnCreateToolbar";
            // 
            // barButtonItem16
            // 
            this.barButtonItem16.Id = 176;
            this.barButtonItem16.Name = "barButtonItem16";
            // 
            // drawControl2
            // 
            this.drawControl2.Caption = "DrawControl";
            this.drawControl2.Edit = this.repositoryItemCheckEdit2;
            this.drawControl2.EditValue = true;
            this.drawControl2.Id = 199;
            this.drawControl2.Name = "drawControl2";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // moveLabel
            // 
            this.moveLabel.Caption = "MoveLabel";
            this.moveLabel.Edit = this.repositoryItemCheckEdit3;
            this.moveLabel.EditValue = true;
            this.moveLabel.Id = 201;
            this.moveLabel.Name = "moveLabel";
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 5";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem6),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem7),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem8),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem9),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem10)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Custom 5";
            // 
            // barSubItem5
            // 
            this.barSubItem5.Caption = "Module";
            this.barSubItem5.Id = 163;
            this.barSubItem5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem12),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem13),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem18),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem8),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnPermission)});
            this.barSubItem5.Name = "barSubItem5";
            // 
            // barButtonItem12
            // 
            this.barButtonItem12.Caption = "Export";
            this.barButtonItem12.Id = 164;
            this.barButtonItem12.Name = "barButtonItem12";
            // 
            // barButtonItem13
            // 
            this.barButtonItem13.Caption = "Import";
            this.barButtonItem13.Id = 165;
            this.barButtonItem13.Name = "barButtonItem13";
            // 
            // barButtonItem18
            // 
            this.barButtonItem18.Caption = "Copy to database";
            this.barButtonItem18.Id = 180;
            this.barButtonItem18.Name = "barButtonItem18";
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "Module Configs";
            this.barButtonItem8.Id = 138;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // barBtnPermission
            // 
            this.barBtnPermission.Caption = "Permission";
            this.barBtnPermission.Id = 206;
            this.barBtnPermission.Name = "barBtnPermission";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Screens";
            this.barSubItem1.Id = 146;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnExportScreen),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnImportScreen),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnDeleteAllControls),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemPasteFeomClipboard),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem28)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // fld_barbtnExportScreen
            // 
            this.fld_barbtnExportScreen.Caption = "Export";
            this.fld_barbtnExportScreen.Id = 147;
            this.fld_barbtnExportScreen.Name = "fld_barbtnExportScreen";
            // 
            // fld_barbtnImportScreen
            // 
            this.fld_barbtnImportScreen.Caption = "Import";
            this.fld_barbtnImportScreen.Id = 148;
            this.fld_barbtnImportScreen.Name = "fld_barbtnImportScreen";
            // 
            // fld_barbtnDeleteAllControls
            // 
            this.fld_barbtnDeleteAllControls.Caption = "Delete All Controls";
            this.fld_barbtnDeleteAllControls.Id = 149;
            this.fld_barbtnDeleteAllControls.Name = "fld_barbtnDeleteAllControls";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Generate Code for Screens from XML";
            this.barButtonItem6.Id = 159;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItemPasteFeomClipboard
            // 
            this.barButtonItemPasteFeomClipboard.Caption = "Paste From Clipboard";
            this.barButtonItemPasteFeomClipboard.Id = 171;
            this.barButtonItemPasteFeomClipboard.Name = "barButtonItemPasteFeomClipboard";
            // 
            // barButtonItem28
            // 
            this.barButtonItem28.Caption = "Save Screen";
            this.barButtonItem28.Id = 195;
            this.barButtonItem28.Name = "barButtonItem28";
            // 
            // barSubItem6
            // 
            this.barSubItem6.Caption = "Control";
            this.barSubItem6.Id = 181;
            this.barSubItem6.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnControls),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnFunctionControls),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnGridColumn),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barButtonExportControlName),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barButtonImportControlName),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbuttonCheckGridControl),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem19),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem20),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem21),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem26)});
            this.barSubItem6.Name = "barSubItem6";
            // 
            // fld_barbtnControls
            // 
            this.fld_barbtnControls.Caption = "Controls";
            this.fld_barbtnControls.Id = 100;
            this.fld_barbtnControls.Name = "fld_barbtnControls";
            // 
            // fld_barbtnFunctionControls
            // 
            this.fld_barbtnFunctionControls.Caption = "Function of Controls";
            this.fld_barbtnFunctionControls.Id = 100;
            this.fld_barbtnFunctionControls.Name = "fld_barbtnFunctionControls";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Invalid Controls";
            this.barButtonItem4.Id = 134;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // fld_barbtnGridColumn
            // 
            this.fld_barbtnGridColumn.Caption = "Config Columns Control";
            this.fld_barbtnGridColumn.Id = 172;
            this.fld_barbtnGridColumn.Name = "fld_barbtnGridColumn";
            // 
            // fld_barButtonExportControlName
            // 
            this.fld_barButtonExportControlName.Caption = "Export Control Name";
            this.fld_barButtonExportControlName.Id = 175;
            this.fld_barButtonExportControlName.Name = "fld_barButtonExportControlName";
            // 
            // fld_barButtonImportControlName
            // 
            this.fld_barButtonImportControlName.Caption = "Import Control  Name";
            this.fld_barButtonImportControlName.Id = 178;
            this.fld_barButtonImportControlName.Name = "fld_barButtonImportControlName";
            // 
            // fld_barbuttonCheckGridControl
            // 
            this.fld_barbuttonCheckGridControl.Caption = "Check All GridControl";
            this.fld_barbuttonCheckGridControl.Id = 173;
            this.fld_barbuttonCheckGridControl.Name = "fld_barbuttonCheckGridControl";
            // 
            // barButtonItem19
            // 
            this.barButtonItem19.Caption = "Try Merge Controls To Group";
            this.barButtonItem19.Id = 185;
            this.barButtonItem19.Name = "barButtonItem19";
            // 
            // barButtonItem20
            // 
            this.barButtonItem20.Caption = "UpdateFieldTableName";
            this.barButtonItem20.Id = 186;
            this.barButtonItem20.Name = "barButtonItem20";
            // 
            // barButtonItem21
            // 
            this.barButtonItem21.Caption = "Merge Controls Into Group (Screen)";
            this.barButtonItem21.Id = 187;
            this.barButtonItem21.Name = "barButtonItem21";
            // 
            // barButtonItem26
            // 
            this.barButtonItem26.Caption = "Merge Controls Into Group (Module)";
            this.barButtonItem26.Id = 193;
            this.barButtonItem26.Name = "barButtonItem26";
            // 
            // barSubItem7
            // 
            this.barSubItem7.Caption = "Database";
            this.barSubItem7.Id = 182;
            this.barSubItem7.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnCreateTables),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnRenameModuleTables),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnModuleFunctions),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnImportFunctions),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem31)});
            this.barSubItem7.Name = "barSubItem7";
            // 
            // fld_barbtnCreateTables
            // 
            this.fld_barbtnCreateTables.Caption = "Create Tables";
            this.fld_barbtnCreateTables.Id = 87;
            this.fld_barbtnCreateTables.Name = "fld_barbtnCreateTables";
            // 
            // fld_barbtnRenameModuleTables
            // 
            this.fld_barbtnRenameModuleTables.Caption = "Rename Tables";
            this.fld_barbtnRenameModuleTables.Id = 105;
            this.fld_barbtnRenameModuleTables.Name = "fld_barbtnRenameModuleTables";
            // 
            // fld_barbtnModuleFunctions
            // 
            this.fld_barbtnModuleFunctions.Caption = "Module Functions";
            this.fld_barbtnModuleFunctions.Id = 103;
            this.fld_barbtnModuleFunctions.Name = "fld_barbtnModuleFunctions";
            // 
            // fld_barbtnImportFunctions
            // 
            this.fld_barbtnImportFunctions.Caption = "Import Functions";
            this.fld_barbtnImportFunctions.Id = 88;
            this.fld_barbtnImportFunctions.Name = "fld_barbtnImportFunctions";
            // 
            // barButtonItem31
            // 
            this.barButtonItem31.Caption = "Clean STFields";
            this.barButtonItem31.Id = 207;
            this.barButtonItem31.Name = "barButtonItem31";
            // 
            // barSubItem8
            // 
            this.barSubItem8.Caption = "Application";
            this.barSubItem8.Id = 183;
            this.barSubItem8.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnReportStudio),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnAssignReport)});
            this.barSubItem8.Name = "barSubItem8";
            // 
            // fld_barbtnReportStudio
            // 
            this.fld_barbtnReportStudio.Caption = "Report Studio";
            this.fld_barbtnReportStudio.Id = 169;
            this.fld_barbtnReportStudio.Name = "fld_barbtnReportStudio";
            // 
            // fld_barbtnAssignReport
            // 
            this.fld_barbtnAssignReport.Caption = "Assign Report";
            this.fld_barbtnAssignReport.Id = 170;
            this.fld_barbtnAssignReport.Name = "fld_barbtnAssignReport";
            // 
            // barSubItem9
            // 
            this.barSubItem9.Caption = "Config";
            this.barSubItem9.Id = 184;
            this.barSubItem9.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem9),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnCompanyConfig),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem15),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnConfigModuleDisplay),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemFieldFormatGroup),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemCreateUniqueColumn),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem14),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnTableAlias)});
            this.barSubItem9.Name = "barSubItem9";
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "Column Alias";
            this.barButtonItem9.Id = 139;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // fld_barbtnCompanyConfig
            // 
            this.fld_barbtnCompanyConfig.Caption = "Company Config";
            this.fld_barbtnCompanyConfig.Id = 122;
            this.fld_barbtnCompanyConfig.Name = "fld_barbtnCompanyConfig";
            // 
            // barButtonItem15
            // 
            this.barButtonItem15.Caption = "Field Format";
            this.barButtonItem15.Id = 168;
            this.barButtonItem15.Name = "barButtonItem15";
            // 
            // barbtnConfigModuleDisplay
            // 
            this.barbtnConfigModuleDisplay.Caption = "Config Display";
            this.barbtnConfigModuleDisplay.Id = 179;
            this.barbtnConfigModuleDisplay.Name = "barbtnConfigModuleDisplay";
            // 
            // barButtonItemFieldFormatGroup
            // 
            this.barButtonItemFieldFormatGroup.Caption = "Format Group";
            this.barButtonItemFieldFormatGroup.Id = 167;
            this.barButtonItemFieldFormatGroup.Name = "barButtonItemFieldFormatGroup";
            // 
            // barButtonItemCreateUniqueColumn
            // 
            this.barButtonItemCreateUniqueColumn.Caption = "Create Unique Column";
            this.barButtonItemCreateUniqueColumn.Id = 174;
            this.barButtonItemCreateUniqueColumn.Name = "barButtonItemCreateUniqueColumn";
            // 
            // barButtonItem14
            // 
            this.barButtonItem14.Caption = "Config Values";
            this.barButtonItem14.Id = 166;
            this.barButtonItem14.Name = "barButtonItem14";
            // 
            // barbtnTableAlias
            // 
            this.barbtnTableAlias.Caption = "Table Alias";
            this.barbtnTableAlias.Id = 204;
            this.barbtnTableAlias.Name = "barbtnTableAlias";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Code Generator";
            this.barButtonItem5.Id = 118;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barSubItem10
            // 
            this.barSubItem10.Caption = "Tool";
            this.barSubItem10.Id = 209;
            this.barSubItem10.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCutBtn),
            new DevExpress.XtraBars.LinkPersistInfo(this.barPasteBtn),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem32)});
            this.barSubItem10.Name = "barSubItem10";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Delete";
            this.btnDelete.Id = 208;
            this.btnDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.btnDelete.Name = "btnDelete";
            // 
            // barCutBtn
            // 
            this.barCutBtn.Caption = "Cut";
            this.barCutBtn.Id = 210;
            this.barCutBtn.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X));
            this.barCutBtn.Name = "barCutBtn";
            // 
            // barPasteBtn
            // 
            this.barPasteBtn.Caption = "Paste";
            this.barPasteBtn.Id = 211;
            this.barPasteBtn.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V));
            this.barPasteBtn.Name = "barPasteBtn";
            // 
            // barButtonItem32
            // 
            this.barButtonItem32.Caption = "Copy";
            this.barButtonItem32.Id = 212;
            this.barButtonItem32.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C));
            this.barButtonItem32.Name = "barButtonItem32";
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.ToolbarManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1284, 70);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 608);
            this.barDockControlBottom.Manager = this.ToolbarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1284, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 70);
            this.barDockControlLeft.Manager = this.ToolbarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 538);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1284, 70);
            this.barDockControlRight.Manager = this.ToolbarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 538);
            // 
            // dockSectionManager
            // 
            this.dockSectionManager.Controller = this.barAndDockingController1;
            this.dockSectionManager.Form = this;
            this.dockSectionManager.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockSectionPanel});
            this.dockSectionManager.MenuManager = this.ToolbarManager;
            this.dockSectionManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.panelContainer1});
            this.dockSectionManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar"});
            // 
            // dockSectionPanel
            // 
            this.dockSectionPanel.Controls.Add(this.dockPanel1_Container);
            this.dockSectionPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockSectionPanel.FloatVertical = true;
            this.dockSectionPanel.ID = new System.Guid("410a208d-7c05-4965-a79d-b10d980fa0df");
            this.dockSectionPanel.Location = new System.Drawing.Point(866, 22);
            this.dockSectionPanel.Name = "dockSectionPanel";
            this.dockSectionPanel.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockSectionPanel.SavedIndex = 1;
            this.dockSectionPanel.Size = new System.Drawing.Size(160, 566);
            this.dockSectionPanel.Text = "Section";
            this.dockSectionPanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.navbarSectionManager);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 20);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(154, 543);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // navbarSectionManager
            // 
            this.navbarSectionManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navbarSectionManager.LinkSelectionMode = DevExpress.XtraNavBar.LinkSelectionModeType.OneInGroup;
            this.navbarSectionManager.Location = new System.Drawing.Point(0, 0);
            this.navbarSectionManager.Name = "navbarSectionManager";
            this.navbarSectionManager.OptionsNavPane.ExpandedWidth = 154;
            this.navbarSectionManager.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navbarSectionManager.Size = new System.Drawing.Size(154, 543);
            this.navbarSectionManager.TabIndex = 18;
            this.navbarSectionManager.Text = "Section Explorer";
            this.navbarSectionManager.View = new DevExpress.XtraNavBar.ViewInfo.NavigationPaneViewInfoRegistrator();
            // 
            // panelContainer1
            // 
            this.panelContainer1.ActiveChild = this.dockPropertiesPanel;
            this.panelContainer1.Controls.Add(this.dockToolboxPanel);
            this.panelContainer1.Controls.Add(this.dockPropertiesPanel);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.panelContainer1.FloatVertical = true;
            this.panelContainer1.ID = new System.Guid("fe025c40-8bc7-439e-a400-c180a5595f2d");
            this.panelContainer1.Location = new System.Drawing.Point(1084, 70);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(200, 200);
            this.panelContainer1.Size = new System.Drawing.Size(200, 538);
            this.panelContainer1.Tabbed = true;
            this.panelContainer1.Text = "panelContainer1";
            // 
            // dockToolboxPanel
            // 
            this.dockToolboxPanel.Controls.Add(this.controlContainer1);
            this.dockToolboxPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockToolboxPanel.ID = new System.Guid("a900e3c4-7013-4ebc-9cf2-934a19d51a5e");
            this.dockToolboxPanel.Location = new System.Drawing.Point(4, 26);
            this.dockToolboxPanel.Name = "dockToolboxPanel";
            this.dockToolboxPanel.OriginalSize = new System.Drawing.Size(192, 473);
            this.dockToolboxPanel.Size = new System.Drawing.Size(193, 483);
            this.dockToolboxPanel.Text = "Toolbox";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.tableLayoutPanel1);
            this.controlContainer1.Location = new System.Drawing.Point(0, 0);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(193, 483);
            this.controlContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.fld_navBarToolboxControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 473F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(193, 483);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // fld_navBarToolboxControl
            // 
            this.fld_navBarToolboxControl.ActiveGroup = this.fld_navBarGroupModuleFields;
            this.fld_navBarToolboxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_navBarToolboxControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.fld_navBarGroupModuleFields,
            this.fld_navBarGroupSearchFields,
            this.fld_navbarGroupComponents,
            this.fld_navBarGroupScreens});
            this.fld_navBarToolboxControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.fld_navBarItemLabel,
            this.fld_navBarItemButton,
            this.fld_navBarItemGrid,
            this.fld_navBarItemDataMain,
            this.fld_navBarItemDataSubScreen,
            this.fld_navBarItemSearchScreen,
            this.fld_navBarItemSearchResultsScreen,
            this.fld_navBarItemLine,
            this.fld_navBarItemSeperate,
            this.fld_navBarItemBarItem,
            this.fld_navBarItemCheckEdit,
            this.fld_navBarItemTextBox,
            this.fld_narBarItemDateEdit,
            this.fld_navBarItemGroupControl,
            this.fld_navBarItemTimeEdit,
            this.fld_navBarPictureEdit,
            this.fld_navBarLookupEdit,
            this.fld_navBarComboBox,
            this.fld_navBarGridLookupEdit,
            this.fld_navBarTreeList,
            this.fld_navBarSplitter,
            this.fld_navBarPanel,
            this.fld_navBarCalcEdit,
            this.fld_navBarPopupContainerControl,
            this.fld_navBarPopupContainerEdit,
            this.fld_navBarItemTabControl});
            this.fld_navBarToolboxControl.LargeImages = this.fld_imglToolbox;
            this.fld_navBarToolboxControl.LinkSelectionMode = DevExpress.XtraNavBar.LinkSelectionModeType.OneInControl;
            this.fld_navBarToolboxControl.Location = new System.Drawing.Point(3, 3);
            this.fld_navBarToolboxControl.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.fld_navBarToolboxControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.fld_navBarToolboxControl.Name = "fld_navBarToolboxControl";
            this.fld_navBarToolboxControl.OptionsNavPane.ExpandedWidth = 187;
            this.fld_navBarToolboxControl.ShowHintInterval = 100;
            this.fld_navBarToolboxControl.Size = new System.Drawing.Size(187, 477);
            this.fld_navBarToolboxControl.SmallImages = this.fld_imglToolbox;
            this.fld_navBarToolboxControl.TabIndex = 3;
            this.fld_navBarToolboxControl.Text = "ToolBox";
            this.fld_navBarToolboxControl.View = new DevExpress.XtraNavBar.ViewInfo.VSToolBoxViewInfoRegistrator();
            // 
            // fld_navBarGroupModuleFields
            // 
            this.fld_navBarGroupModuleFields.Caption = "All Module Fields";
            this.fld_navBarGroupModuleFields.Expanded = true;
            this.fld_navBarGroupModuleFields.Name = "fld_navBarGroupModuleFields";
            // 
            // fld_navBarGroupSearchFields
            // 
            this.fld_navBarGroupSearchFields.Caption = "Search Fields";
            this.fld_navBarGroupSearchFields.Name = "fld_navBarGroupSearchFields";
            // 
            // fld_navbarGroupComponents
            // 
            this.fld_navbarGroupComponents.Caption = "Windows Components";
            this.fld_navbarGroupComponents.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarComboBox),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarItemLabel),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarItemButton),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarItemCheckEdit),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarItemTextBox),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarPictureEdit),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarCalcEdit),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarLookupEdit),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_narBarItemDateEdit),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarItemTimeEdit),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarItemGrid),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarItemLine),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarItemGroupControl),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarItemTabControl),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarPanel),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarItemBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarGridLookupEdit),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarTreeList),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarPopupContainerControl),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarPopupContainerEdit),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarSplitter)});
            this.fld_navbarGroupComponents.Name = "fld_navbarGroupComponents";
            // 
            // fld_navBarComboBox
            // 
            this.fld_navBarComboBox.Caption = "ComboBox";
            this.fld_navBarComboBox.ImageOptions.SmallImageIndex = 15;
            this.fld_navBarComboBox.Name = "fld_navBarComboBox";
            this.fld_navBarComboBox.Tag = "ComboBox";
            // 
            // fld_navBarItemLabel
            // 
            this.fld_navBarItemLabel.Caption = "Label";
            this.fld_navBarItemLabel.ImageOptions.SmallImageIndex = 1;
            this.fld_navBarItemLabel.Name = "fld_navBarItemLabel";
            this.fld_navBarItemLabel.Tag = "Label";
            // 
            // fld_navBarItemButton
            // 
            this.fld_navBarItemButton.Caption = "Button";
            this.fld_navBarItemButton.ImageOptions.SmallImageIndex = 9;
            this.fld_navBarItemButton.Name = "fld_navBarItemButton";
            this.fld_navBarItemButton.Tag = "Button";
            // 
            // fld_navBarItemCheckEdit
            // 
            this.fld_navBarItemCheckEdit.Caption = "CheckEdit";
            this.fld_navBarItemCheckEdit.ImageOptions.SmallImageIndex = 11;
            this.fld_navBarItemCheckEdit.Name = "fld_navBarItemCheckEdit";
            this.fld_navBarItemCheckEdit.Tag = "CheckEdit";
            // 
            // fld_navBarItemTextBox
            // 
            this.fld_navBarItemTextBox.Caption = "TextBox";
            this.fld_navBarItemTextBox.ImageOptions.SmallImageIndex = 14;
            this.fld_navBarItemTextBox.Name = "fld_navBarItemTextBox";
            this.fld_navBarItemTextBox.Tag = "TextBox";
            // 
            // fld_navBarPictureEdit
            // 
            this.fld_navBarPictureEdit.Caption = "PictureEdit";
            this.fld_navBarPictureEdit.ImageOptions.SmallImageIndex = 16;
            this.fld_navBarPictureEdit.Name = "fld_navBarPictureEdit";
            this.fld_navBarPictureEdit.Tag = "PictureEdit";
            // 
            // fld_navBarCalcEdit
            // 
            this.fld_navBarCalcEdit.Caption = "CalEdit";
            this.fld_navBarCalcEdit.Name = "fld_navBarCalcEdit";
            this.fld_navBarCalcEdit.Tag = "CalcEdit";
            // 
            // fld_navBarLookupEdit
            // 
            this.fld_navBarLookupEdit.Caption = "LookupEdit";
            this.fld_navBarLookupEdit.ImageOptions.SmallImageIndex = 12;
            this.fld_navBarLookupEdit.Name = "fld_navBarLookupEdit";
            this.fld_navBarLookupEdit.Tag = "LookupEdit";
            // 
            // fld_narBarItemDateEdit
            // 
            this.fld_narBarItemDateEdit.Caption = "DateEdit";
            this.fld_narBarItemDateEdit.ImageOptions.SmallImageIndex = 10;
            this.fld_narBarItemDateEdit.Name = "fld_narBarItemDateEdit";
            this.fld_narBarItemDateEdit.Tag = "DateEdit";
            // 
            // fld_navBarItemTimeEdit
            // 
            this.fld_navBarItemTimeEdit.Caption = "TimeEdit";
            this.fld_navBarItemTimeEdit.ImageOptions.SmallImageIndex = 17;
            this.fld_navBarItemTimeEdit.Name = "fld_navBarItemTimeEdit";
            this.fld_navBarItemTimeEdit.Tag = "TimeEdit";
            // 
            // fld_navBarItemGrid
            // 
            this.fld_navBarItemGrid.Caption = "GridControl";
            this.fld_navBarItemGrid.ImageOptions.SmallImageIndex = 2;
            this.fld_navBarItemGrid.Name = "fld_navBarItemGrid";
            this.fld_navBarItemGrid.Tag = "GridControl";
            // 
            // fld_navBarItemLine
            // 
            this.fld_navBarItemLine.Caption = "Line";
            this.fld_navBarItemLine.ImageOptions.SmallImageIndex = 7;
            this.fld_navBarItemLine.Name = "fld_navBarItemLine";
            this.fld_navBarItemLine.Tag = "Line";
            // 
            // fld_navBarItemGroupControl
            // 
            this.fld_navBarItemGroupControl.Caption = "GroupControl";
            this.fld_navBarItemGroupControl.Name = "fld_navBarItemGroupControl";
            this.fld_navBarItemGroupControl.Tag = "GroupControl";
            // 
            // fld_navBarItemTabControl
            // 
            this.fld_navBarItemTabControl.Caption = "TabControl";
            this.fld_navBarItemTabControl.Name = "fld_navBarItemTabControl";
            this.fld_navBarItemTabControl.Tag = "TabControl";
            // 
            // fld_navBarPanel
            // 
            this.fld_navBarPanel.Caption = "Panel";
            this.fld_navBarPanel.Name = "fld_navBarPanel";
            this.fld_navBarPanel.Tag = "PanelControl";
            // 
            // fld_navBarItemBarItem
            // 
            this.fld_navBarItemBarItem.Caption = "ToolbarButton";
            this.fld_navBarItemBarItem.Name = "fld_navBarItemBarItem";
            this.fld_navBarItemBarItem.Tag = "BarItem";
            // 
            // fld_navBarGridLookupEdit
            // 
            this.fld_navBarGridLookupEdit.Caption = "GridLookupEdit";
            this.fld_navBarGridLookupEdit.ImageOptions.SmallImageIndex = 2;
            this.fld_navBarGridLookupEdit.Name = "fld_navBarGridLookupEdit";
            this.fld_navBarGridLookupEdit.Tag = "GridLookupEdit";
            // 
            // fld_navBarTreeList
            // 
            this.fld_navBarTreeList.Caption = "TreeList";
            this.fld_navBarTreeList.ImageOptions.SmallImageIndex = 18;
            this.fld_navBarTreeList.Name = "fld_navBarTreeList";
            this.fld_navBarTreeList.Tag = "TreeList";
            // 
            // fld_navBarPopupContainerControl
            // 
            this.fld_navBarPopupContainerControl.Caption = "PopupContainerControl";
            this.fld_navBarPopupContainerControl.Name = "fld_navBarPopupContainerControl";
            this.fld_navBarPopupContainerControl.Tag = "PopupContainerControl";
            // 
            // fld_navBarPopupContainerEdit
            // 
            this.fld_navBarPopupContainerEdit.Caption = "PopupContainerEdit";
            this.fld_navBarPopupContainerEdit.Name = "fld_navBarPopupContainerEdit";
            this.fld_navBarPopupContainerEdit.Tag = "PopupContainerEdit";
            // 
            // fld_navBarSplitter
            // 
            this.fld_navBarSplitter.Caption = "Splitter";
            this.fld_navBarSplitter.Name = "fld_navBarSplitter";
            this.fld_navBarSplitter.Tag = "Splitter";
            // 
            // fld_navBarGroupScreens
            // 
            this.fld_navBarGroupScreens.Caption = "Module Screens";
            this.fld_navBarGroupScreens.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarItemDataMain),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarItemSearchScreen),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarItemDataSubScreen),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarItemSearchResultsScreen),
            new DevExpress.XtraNavBar.NavBarItemLink(this.fld_navBarItemSeperate)});
            this.fld_navBarGroupScreens.Name = "fld_navBarGroupScreens";
            // 
            // fld_navBarItemDataMain
            // 
            this.fld_navBarItemDataMain.Caption = "Data Main Screen";
            this.fld_navBarItemDataMain.ImageOptions.SmallImageIndex = 3;
            this.fld_navBarItemDataMain.Name = "fld_navBarItemDataMain";
            this.fld_navBarItemDataMain.Tag = "DM";
            // 
            // fld_navBarItemSearchScreen
            // 
            this.fld_navBarItemSearchScreen.Caption = "Search Screen";
            this.fld_navBarItemSearchScreen.ImageOptions.SmallImageIndex = 5;
            this.fld_navBarItemSearchScreen.Name = "fld_navBarItemSearchScreen";
            this.fld_navBarItemSearchScreen.Tag = "SM";
            // 
            // fld_navBarItemDataSubScreen
            // 
            this.fld_navBarItemDataSubScreen.Caption = "Data Sub Screen";
            this.fld_navBarItemDataSubScreen.ImageOptions.SmallImageIndex = 4;
            this.fld_navBarItemDataSubScreen.Name = "fld_navBarItemDataSubScreen";
            this.fld_navBarItemDataSubScreen.Tag = "DS";
            // 
            // fld_navBarItemSearchResultsScreen
            // 
            this.fld_navBarItemSearchResultsScreen.Caption = "Search Results Screen";
            this.fld_navBarItemSearchResultsScreen.ImageOptions.SmallImageIndex = 6;
            this.fld_navBarItemSearchResultsScreen.Name = "fld_navBarItemSearchResultsScreen";
            this.fld_navBarItemSearchResultsScreen.Tag = "SR";
            // 
            // fld_navBarItemSeperate
            // 
            this.fld_navBarItemSeperate.Caption = "--------------------------";
            this.fld_navBarItemSeperate.Name = "fld_navBarItemSeperate";
            // 
            // fld_imglToolbox
            // 
            this.fld_imglToolbox.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.fld_imglToolbox.ImageSize = new System.Drawing.Size(16, 16);
            this.fld_imglToolbox.TransparentColor = System.Drawing.SystemColors.Control;
            // 
            // dockPropertiesPanel
            // 
            this.dockPropertiesPanel.Controls.Add(this.controlContainer2);
            this.dockPropertiesPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPropertiesPanel.FloatVertical = true;
            this.dockPropertiesPanel.ID = new System.Guid("07cb178f-cb58-43aa-ac7d-e9af3fa98c5f");
            this.dockPropertiesPanel.Location = new System.Drawing.Point(4, 26);
            this.dockPropertiesPanel.Name = "dockPropertiesPanel";
            this.dockPropertiesPanel.OriginalSize = new System.Drawing.Size(192, 473);
            this.dockPropertiesPanel.Size = new System.Drawing.Size(193, 483);
            this.dockPropertiesPanel.Text = "Properties";
            // 
            // controlContainer2
            // 
            this.controlContainer2.Location = new System.Drawing.Point(0, 0);
            this.controlContainer2.Name = "controlContainer2";
            this.controlContainer2.Size = new System.Drawing.Size(193, 483);
            this.controlContainer2.TabIndex = 0;
            // 
            // m_toolbarIcons
            // 
            this.m_toolbarIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.m_toolbarIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.m_toolbarIcons.TransparentColor = System.Drawing.Color.Magenta;
            // 
            // fld_barsmnuFile
            // 
            this.fld_barsmnuFile.Caption = "&File";
            this.fld_barsmnuFile.Id = 10;
            this.fld_barsmnuFile.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barmnuExit)});
            this.fld_barsmnuFile.Name = "fld_barsmnuFile";
            // 
            // fld_barmnuExit
            // 
            this.fld_barmnuExit.Caption = "&Exit";
            this.fld_barmnuExit.Id = 63;
            this.fld_barmnuExit.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.fld_barmnuExit.Name = "fld_barmnuExit";
            // 
            // fld_barsmnuView
            // 
            this.fld_barsmnuView.Caption = "&View";
            this.fld_barsmnuView.Id = 26;
            this.fld_barsmnuView.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_mnubarbtnToolbox, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_mnubarbtnPropertyExplorer)});
            this.fld_barsmnuView.Name = "fld_barsmnuView";
            // 
            // fld_mnubarbtnToolbox
            // 
            this.fld_mnubarbtnToolbox.Caption = "Toolbox Explorer";
            this.fld_mnubarbtnToolbox.Id = 69;
            this.fld_mnubarbtnToolbox.Name = "fld_mnubarbtnToolbox";
            // 
            // fld_mnubarbtnPropertyExplorer
            // 
            this.fld_mnubarbtnPropertyExplorer.Caption = "Property Explorer";
            this.fld_mnubarbtnPropertyExplorer.Id = 68;
            this.fld_mnubarbtnPropertyExplorer.Name = "fld_mnubarbtnPropertyExplorer";
            // 
            // fld_barsmnuHelp
            // 
            this.fld_barsmnuHelp.Caption = "&Help";
            this.fld_barsmnuHelp.Id = 27;
            this.fld_barsmnuHelp.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barmnbContents),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barmnbSystemInfo),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barmnbLicenses),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barmnbAbout)});
            this.fld_barsmnuHelp.Name = "fld_barsmnuHelp";
            // 
            // fld_barmnbContents
            // 
            this.fld_barmnbContents.Caption = "&Contents";
            this.fld_barmnbContents.Id = 30;
            this.fld_barmnbContents.Name = "fld_barmnbContents";
            // 
            // fld_barmnbSystemInfo
            // 
            this.fld_barmnbSystemInfo.Caption = "&System Info...";
            this.fld_barmnbSystemInfo.Id = 31;
            this.fld_barmnbSystemInfo.Name = "fld_barmnbSystemInfo";
            // 
            // fld_barmnbLicenses
            // 
            this.fld_barmnbLicenses.Caption = "&Licences";
            this.fld_barmnbLicenses.Id = 32;
            this.fld_barmnbLicenses.Name = "fld_barmnbLicenses";
            // 
            // fld_barmnbAbout
            // 
            this.fld_barmnbAbout.Caption = "&About GMC";
            this.fld_barmnbAbout.Id = 33;
            this.fld_barmnbAbout.Name = "fld_barmnbAbout";
            // 
            // fld_mnubarbtnConfigTables
            // 
            this.fld_mnubarbtnConfigTables.Caption = "&Configure Tables and Views";
            this.fld_mnubarbtnConfigTables.Id = 71;
            this.fld_mnubarbtnConfigTables.Name = "fld_mnubarbtnConfigTables";
            // 
            // fld_mnubarbtnImportFunctions
            // 
            this.fld_mnubarbtnImportFunctions.Caption = "&Import Functions";
            this.fld_mnubarbtnImportFunctions.Id = 72;
            this.fld_mnubarbtnImportFunctions.Name = "fld_mnubarbtnImportFunctions";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 111;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // fld_barbtnTranslation
            // 
            this.fld_barbtnTranslation.Caption = "Translation";
            this.fld_barbtnTranslation.Id = 129;
            this.fld_barbtnTranslation.Name = "fld_barbtnTranslation";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Id = 158;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "barStaticItem2";
            this.barStaticItem2.Id = 151;
            this.barStaticItem2.Name = "barStaticItem2";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "barSubItem2";
            this.barSubItem2.Id = 152;
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Generate Code for Screens from XML";
            this.barSubItem3.Id = 153;
            this.barSubItem3.Name = "barSubItem3";
            // 
            // barSubItem4
            // 
            this.barSubItem4.Caption = "Export Module to XML";
            this.barSubItem4.Id = 154;
            this.barSubItem4.Name = "barSubItem4";
            // 
            // fld_barlblControlText
            // 
            this.fld_barlblControlText.Caption = "barlblControlText";
            this.fld_barlblControlText.Id = 162;
            this.fld_barlblControlText.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.fld_barlblControlText.ItemAppearance.Normal.Options.UseFont = true;
            this.fld_barlblControlText.Name = "fld_barlblControlText";
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "barCheckItem1";
            this.barCheckItem1.Id = 192;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // barButtonItem27
            // 
            this.barButtonItem27.Caption = "barButtonItem27";
            this.barButtonItem27.Id = 194;
            this.barButtonItem27.Name = "barButtonItem27";
            // 
            // drawControl
            // 
            this.drawControl.Caption = "DrawControl";
            this.drawControl.Edit = this.repositoryDrawControl;
            this.drawControl.Id = 198;
            this.drawControl.Name = "drawControl";
            // 
            // repositoryDrawControl
            // 
            this.repositoryDrawControl.AutoHeight = false;
            this.repositoryDrawControl.Name = "repositoryDrawControl";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // fld_xtraTabbedMdiManager
            // 
            this.fld_xtraTabbedMdiManager.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fld_xtraTabbedMdiManager.Appearance.Options.UseFont = true;
            this.fld_xtraTabbedMdiManager.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fld_xtraTabbedMdiManager.AppearancePage.Header.Options.UseFont = true;
            this.fld_xtraTabbedMdiManager.AppearancePage.PageClient.BackColor = System.Drawing.Color.Transparent;
            this.fld_xtraTabbedMdiManager.AppearancePage.PageClient.Options.UseBackColor = true;
            this.fld_xtraTabbedMdiManager.Controller = this.barAndDockingController1;
            this.fld_xtraTabbedMdiManager.MdiParent = this;
            // 
            // fld_lblAppInfoBar
            // 
            this.fld_lblAppInfoBar.AutoSize = true;
            this.fld_lblAppInfoBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fld_lblAppInfoBar.ForeColor = System.Drawing.SystemColors.Window;
            this.fld_lblAppInfoBar.Location = new System.Drawing.Point(3, 4);
            this.fld_lblAppInfoBar.Name = "fld_lblAppInfoBar";
            this.fld_lblAppInfoBar.Size = new System.Drawing.Size(0, 24);
            this.fld_lblAppInfoBar.TabIndex = 0;
            // 
            // fld_pnlAppInfo
            // 
            this.fld_pnlAppInfo.BackColor = System.Drawing.Color.DodgerBlue;
            this.fld_pnlAppInfo.Controls.Add(this.lblCurrentControlName);
            this.fld_pnlAppInfo.Controls.Add(this.fld_lblAppInfoBar);
            this.fld_pnlAppInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.fld_pnlAppInfo.Location = new System.Drawing.Point(0, 70);
            this.fld_pnlAppInfo.Name = "fld_pnlAppInfo";
            this.fld_pnlAppInfo.Size = new System.Drawing.Size(1084, 10);
            this.fld_pnlAppInfo.TabIndex = 11;
            // 
            // lblCurrentControlName
            // 
            this.lblCurrentControlName.AutoSize = true;
            this.lblCurrentControlName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblCurrentControlName.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentControlName.Location = new System.Drawing.Point(46, 3);
            this.lblCurrentControlName.Name = "lblCurrentControlName";
            this.lblCurrentControlName.Size = new System.Drawing.Size(0, 23);
            this.lblCurrentControlName.TabIndex = 3;
            this.lblCurrentControlName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hideContainerLeft
            // 
            this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.hideContainerLeft.Location = new System.Drawing.Point(0, 22);
            this.hideContainerLeft.Name = "hideContainerLeft";
            this.hideContainerLeft.Size = new System.Drawing.Size(19, 566);
            // 
            // txtQuickText
            // 
            this.txtQuickText.Location = new System.Drawing.Point(-377, -401);
            this.txtQuickText.Name = "txtQuickText";
            this.txtQuickText.Size = new System.Drawing.Size(100, 20);
            this.txtQuickText.TabIndex = 13;
            // 
            // guiStudio
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(1284, 608);
            this.Controls.Add(this.txtQuickText);
            this.Controls.Add(this.fld_pnlAppInfo);
            this.Controls.Add(this.panelContainer1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("guiStudio.IconOptions.Image")));
            this.IsMdiContainer = true;
            this.Name = "guiStudio";
            this.Text = "GG Studio - Designer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorySpinEditSpacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxTables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockSectionManager)).EndInit();
            this.dockSectionPanel.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navbarSectionManager)).EndInit();
            this.panelContainer1.ResumeLayout(false);
            this.dockToolboxPanel.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_navBarToolboxControl)).EndInit();
            this.dockPropertiesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDrawControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_xtraTabbedMdiManager)).EndInit();
            this.fld_pnlAppInfo.ResumeLayout(false);
            this.fld_pnlAppInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuickText.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ImageList fld_imglToolbarManager;
        private BarManager ToolbarManager;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        public BarSubItem fld_barsmnuFile;
        public BarSubItem fld_barsmnuView;
        public BarSubItem fld_barsmnuHelp;
        public BarButtonItem fld_barmnbContents;
        public BarButtonItem fld_barmnbSystemInfo;
        public BarButtonItem fld_barmnbLicenses;
        public BarButtonItem fld_barmnbAbout;
        private Panel fld_pnlAppInfo;
        private Label fld_lblAppInfoBar;
        private BarButtonItem fld_barmnuExit;
        private BarAndDockingController barAndDockingController1;
        private DockManager dockSectionManager;
        private NavBarControl navbarSectionManager;
        private DockPanel dockSectionPanel;
        private ControlContainer dockPanel1_Container;
        private BarButtonItem fld_mnubarbtnPropertyExplorer;
        private DockPanel dockToolboxPanel;
        private ControlContainer controlContainer1;
        private ControlContainer controlContainer2;
        public DockPanel dockPropertiesPanel;
        private BarButtonItem fld_mnubarbtnToolbox;
        private ImageList fld_imglToolbox;
        private AutoHideContainer hideContainerLeft;
        private TableLayoutPanel tableLayoutPanel1;
        private NavBarControl fld_navBarToolboxControl;
        private NavBarGroup fld_navbarGroupComponents;
        private NavBarItem fld_navBarItemLabel;
        private NavBarItem fld_navBarItemButton;
        private NavBarItem fld_navBarItemGrid;
        private NavBarGroup fld_navBarGroupModuleFields;
        private NavBarGroup fld_navBarGroupScreens;
        private NavBarItem fld_navBarItemDataMain;
        private NavBarItem fld_navBarItemDataSubScreen;
        private NavBarItem fld_navBarItemSearchScreen;
        private NavBarItem fld_navBarItemSearchResultsScreen;
        private BarButtonItem fld_mnubarbtnConfigTables;
        private BarButtonItem fld_mnubarbtnImportFunctions;
        private XtraTabbedMdiManager fld_xtraTabbedMdiManager;
        private NavBarItem fld_navBarItemLine;
        private Bar toolbarModuleAction;
        private BarButtonItem fld_barbtnStart;
        private BarButtonItem fld_barbtnClose;
        private Bar toolbarControlFormat;
        private BarButtonItem fld_barbtnFormatNone;
        private BarButtonItem fld_barbtnAlignLeft;
        private BarButtonItem fld_barbtnAlignRight;
        private BarButtonItem fld_barbtnAlignBottom;
        private BarButtonItem fld_barbtnSameWidth;
        private BarButtonItem fld_barbtnSameHeight;
        private BarButtonItem fld_barbtnSameSize;
        private BarButtonItem fld_barbtnHorizontalSpacing;
        private BarButtonItem fld_barbtnVerticalSpacing;
        private BarEditItem fld_barspeSpacing;
        private RepositoryItemSpinEdit repositorySpinEditSpacing;
        private Bar bar1;
        private BarButtonItem fld_barbtnCreateTables;
        private BarButtonItem fld_barbtnImportFunctions;
        private RepositoryItemComboBox repositoryItemComboBoxUserGroup;
        private BarEditItem fld_barcmbModule;
        private RepositoryItemComboBox repositoryItemComboBoxModule;
        private RepositoryItemTextEdit repositoryItemTextEdit1;
        private BarButtonItem fld_barbtnAlignTop;
        private NavBarItem fld_navBarItemSeperate;
        private BarButtonItem fld_barbtnControls;
        private BarButtonItem fld_barbtnFunctionControls;
        private BarButtonItem barButtonItem2;
        private BarButtonItem barButtonItem3;
        private BarButtonItem fld_barbtnModuleFunctions;
        private BarButtonItem fld_barbtnRenameModuleTables;
        private OpenFileDialog fld_openDialogImportGrid;
        public DockPanel panelContainer1;
        private NavBarItem fld_navBarItemBarItem;
        private RepositoryItemCheckEdit repositoryItemCheckEdit1;
        public BarStaticItem fld_barlblFormatDesc;
        private BarButtonItem barButtonItem1;
        private RepositoryItemTextEdit repositoryItemTextEdit2;
        private BarEditItem fld_barcmbTables;
        private RepositoryItemComboBox repositoryItemComboBoxTables;
        private BarButtonItem barButtonItem5;
        private NavBarGroup fld_navBarGroupSearchFields;
        private BarButtonItem fld_barbtnCreateToolbar;
        private BarButtonItem fld_barbtnCompanyConfig;
        private BarButtonItem fld_barbtnSameColor;
        private BarButtonItem fld_barbtnTranslation;
        private BarSubItem fld_barmnuTranslation;
        private BarButtonItem fld_barbtnExport;
        private BarButtonItem fld_barbtnImport;
        private NavBarItem fld_navBarItemCheckEdit;
        private BarButtonItem barButtonItem4;
        private BarButtonItem barButtonLabel;
        private BarButtonItem barButtonItem7;
        private NavBarItem fld_navBarItemTextBox;
        private NavBarItem fld_narBarItemDateEdit;
        private BarButtonItem fld_barbtnTabIndex;
        private NavBarItem fld_navBarItemGroupControl;
        private BarButtonItem barButtonItem8;
        private NavBarItem fld_navBarItemTimeEdit;
        private BarButtonItem barButtonItem9;
        private NavBarItem fld_navBarLookupEdit;
        private NavBarItem fld_navBarPictureEdit;
        private NavBarItem fld_navBarComboBox;
        private BarButtonItem barButtonAddX;
        private BarButtonItem barButtonAddY;
        private BarSubItem barSubItem1;
        private BarButtonItem fld_barbtnExportScreen;
        private BarButtonItem fld_barbtnImportScreen;
        private BarButtonItem fld_barbtnDeleteAllControls;
        private BarStaticItem barStaticItem1;
        private BarStaticItem barStaticItem2;
        private BarSubItem barSubItem3;
        private BarSubItem barSubItem4;
        private BarSubItem barSubItem2;
        private BarButtonItem barButtonItem6;
        private BarStaticItem fld_barlblControlText;
        private BarButtonItem barButtonItem11;
        private BarSubItem barSubItem5;
        private BarButtonItem barButtonItem12;
        private BarButtonItem barButtonItem13;
        private BarButtonItem barButtonItem14;
        private BarButtonItem barButtonItemFieldFormatGroup;
        private BarButtonItem barButtonItem15;
        private BarButtonItem fld_barbtnReportStudio;
        private BarButtonItem fld_barbtnAssignReport;
        private BarButtonItem barButtonItemPasteFeomClipboard;
        private BarButtonItem fld_barbtnGridColumn;
        private BarButtonItem fld_barbuttonCheckGridControl;
        private BarButtonItem barButtonItemCreateUniqueColumn;
        private BarButtonItem fld_barButtonExportControlName;
        private BarButtonItem barButtonItem16;
        private BarButtonItem fld_barButtonImportControlName;
        private BarButtonItem barbtnConfigModuleDisplay;
        private NavBarItem fld_navBarGridLookupEdit;
        private NavBarItem fld_navBarTreeList;
        private BarButtonItem barButtonItem18;
        private Bar bar2;
        private BarSubItem barSubItem6;
        private BarSubItem barSubItem7;
        private BarSubItem barSubItem8;
        private BarButtonItem barButtonItem19;
        private BarSubItem barSubItem9;
        private BarButtonItem barButtonItem20;
        private BarButtonItem barButtonItem21;
        private NavBarItem fld_navBarSplitter;
        private BarButtonItem barButtonItem22;
        private BarButtonItem barButtonItem23;
        private BarButtonItem barButtonItem24;
        private BarButtonItem barButtonItem25;
        private BarButtonItem barButtonItem26;
        private BarCheckItem barCheckItem1;
        private BarButtonItem barButtonItem28;
        private BarButtonItem barButtonItem27;
        private BarEditItem drawControl;
        public RepositoryItemCheckEdit repositoryDrawControl;
        private RepositoryItemTextEdit repositoryItemTextEdit3;
        private RepositoryItemTextEdit repositoryItemTextEdit4;
        public BarEditItem drawControl2;
        private RepositoryItemCheckEdit repositoryItemCheckEdit2;
        public BarEditItem moveLabel;
        private RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private NavBarItem fld_navBarPanel;
        private NavBarItem fld_navBarCalcEdit;
        private BarButtonItem barButtonItem29;
        private BarButtonItem barButtonItem30;
        public Label lblCurrentControlName;
        private NavBarItem fld_navBarPopupContainerControl;
        private NavBarItem fld_navBarPopupContainerEdit;
        public TextEdit txtQuickText;
        private BarButtonItem barbtnTableAlias;
        public BarEditItem fld_barcmbUserGroup;
        private RepositoryItemComboBox repositoryItemComboBox1;
        public BarButtonItem barBtnPermission;
        private NavBarItem fld_navBarItemTabControl;
        private BarButtonItem barButtonItem31;
        private ImageList m_toolbarIcons;
        private BarButtonItem btnDelete;
        private BarSubItem barSubItem10;
        private BarButtonItem barCutBtn;
        private BarButtonItem barPasteBtn;
        private BarButtonItem barButtonItem32;
        public static guiStudio MainScreen;
        private GGPropertyGrid GGPropertyGrid;
        private bool isPropertyTab = true;
        public static string strCurrentActiveControlName;
        private static string strNewControlName;
        #endregion
    }
}