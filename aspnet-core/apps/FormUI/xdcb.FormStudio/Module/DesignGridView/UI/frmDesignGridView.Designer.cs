namespace xdcb.FormStudio.DesignGridView
{
    partial class frmDesignGridView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesignGridView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_runDesign = new xdcb.FormServices.Component.GGButton();
            this.lbl_text = new xdcb.FormServices.Component.GGLabel();
            this.grd_DesignGrid = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btn_NewGridView = new DevExpress.XtraBars.BarButtonItem();
            this.btn_EditGridView = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.btn_NewBanded = new DevExpress.XtraBars.BarButtonItem();
            this.btn_EditBanded = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Save = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Saveas = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btn_design = new DevExpress.XtraBars.BarButtonItem();
            this.btn_NewGridView1 = new DevExpress.XtraBars.BarButtonItem();
            this.btn_EditGridView1 = new DevExpress.XtraBars.BarButtonItem();
            this.btn_NewBanded1 = new DevExpress.XtraBars.BarButtonItem();
            this.btn_EditBanded1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DesignGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btn_runDesign);
            this.panel1.Controls.Add(this.lbl_text);
            this.panel1.Controls.Add(this.grd_DesignGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 435);
            this.panel1.TabIndex = 0;
            // 
            // btn_runDesign
            // 
            this.btn_runDesign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_runDesign.GGDataMember = null;
            this.btn_runDesign.GGDataSource = null;
            this.btn_runDesign.GGFieldGroup = null;
            this.btn_runDesign.GGFieldRelation = null;
            this.btn_runDesign.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_runDesign.ImageOptions.Image")));
            this.btn_runDesign.Location = new System.Drawing.Point(763, 7);
            this.btn_runDesign.Name = "btn_runDesign";
            this.btn_runDesign.Size = new System.Drawing.Size(86, 23);
            this.btn_runDesign.TabIndex = 2;
            this.btn_runDesign.Text = "Run Design";
            this.btn_runDesign.Click += new System.EventHandler(this.btn_runDesign_Click);
            // 
            // lbl_text
            // 
            this.lbl_text.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lbl_text.Appearance.Options.UseFont = true;
            this.lbl_text.Appearance.Options.UseForeColor = true;
            this.lbl_text.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_text.GGDataMember = null;
            this.lbl_text.GGDataSource = null;
            this.lbl_text.GGFieldGroup = null;
            this.lbl_text.GGFieldRelation = null;
            this.lbl_text.Location = new System.Drawing.Point(7, 6);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(750, 23);
            this.lbl_text.TabIndex = 1;
            this.lbl_text.Text = "ggLabel1";
            // 
            // grd_DesignGrid
            // 
            this.grd_DesignGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_DesignGrid.Location = new System.Drawing.Point(0, 35);
            this.grd_DesignGrid.MainView = this.bandedGridView1;
            this.grd_DesignGrid.MenuManager = this.barManager1;
            this.grd_DesignGrid.Name = "grd_DesignGrid";
            this.grd_DesignGrid.Size = new System.Drawing.Size(852, 400);
            this.grd_DesignGrid.TabIndex = 0;
            this.grd_DesignGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1,
            this.gridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand4,
            this.gridBand5});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn1});
            this.bandedGridView1.GridControl = this.grd_DesignGrid;
            this.bandedGridView1.Name = "bandedGridView1";
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.Caption = "bandedGridColumn1";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_design,
            this.btn_Save,
            this.barSubItem1,
            this.btn_NewGridView1,
            this.btn_EditGridView1,
            this.btn_Saveas,
            this.btn_NewBanded1,
            this.btn_EditBanded1,
            this.barSubItem2,
            this.barButtonItem1,
            this.barSubItem3,
            this.btn_NewGridView,
            this.btn_EditGridView,
            this.btn_NewBanded,
            this.btn_EditBanded});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 19;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Save, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Saveas, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "File";
            this.barSubItem1.Id = 2;
            this.barSubItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem1.ImageOptions.Image")));
            this.barSubItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSubItem1.ImageOptions.LargeImage")));
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem3)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "GridView";
            this.barSubItem2.Id = 8;
            this.barSubItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem2.ImageOptions.Image")));
            this.barSubItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSubItem2.ImageOptions.LargeImage")));
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_NewGridView),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_EditGridView)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btn_NewGridView
            // 
            this.btn_NewGridView.Caption = "Tạo mới";
            this.btn_NewGridView.Id = 11;
            this.btn_NewGridView.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_NewGridView.ImageOptions.Image")));
            this.btn_NewGridView.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_NewGridView.ImageOptions.LargeImage")));
            this.btn_NewGridView.Name = "btn_NewGridView";
            this.btn_NewGridView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_NewGridView_ItemClick);
            // 
            // btn_EditGridView
            // 
            this.btn_EditGridView.Caption = "Chỉnh sửa";
            this.btn_EditGridView.Id = 12;
            this.btn_EditGridView.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_EditGridView.ImageOptions.Image")));
            this.btn_EditGridView.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_EditGridView.ImageOptions.LargeImage")));
            this.btn_EditGridView.Name = "btn_EditGridView";
            this.btn_EditGridView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_EditGridView_ItemClick);
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "BandGridView";
            this.barSubItem3.Id = 10;
            this.barSubItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem3.ImageOptions.Image")));
            this.barSubItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSubItem3.ImageOptions.LargeImage")));
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_NewBanded),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_EditBanded)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // btn_NewBanded
            // 
            this.btn_NewBanded.Caption = "Tạo mới";
            this.btn_NewBanded.Id = 13;
            this.btn_NewBanded.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_NewBanded.ImageOptions.Image")));
            this.btn_NewBanded.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_NewBanded.ImageOptions.LargeImage")));
            this.btn_NewBanded.Name = "btn_NewBanded";
            this.btn_NewBanded.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_NewBanded_ItemClick);
            // 
            // btn_EditBanded
            // 
            this.btn_EditBanded.Caption = "Chỉnh sửa";
            this.btn_EditBanded.Id = 14;
            this.btn_EditBanded.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_EditBanded.ImageOptions.Image")));
            this.btn_EditBanded.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_EditBanded.ImageOptions.LargeImage")));
            this.btn_EditBanded.Name = "btn_EditBanded";
            this.btn_EditBanded.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_EditBanded_ItemClick);
            // 
            // btn_Save
            // 
            this.btn_Save.Caption = "Save";
            this.btn_Save.Id = 1;
            this.btn_Save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.ImageOptions.Image")));
            this.btn_Save.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Save.ImageOptions.LargeImage")));
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Save_ItemClick);
            // 
            // btn_Saveas
            // 
            this.btn_Saveas.Caption = "Save as";
            this.btn_Saveas.Id = 5;
            this.btn_Saveas.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Saveas.ImageOptions.Image")));
            this.btn_Saveas.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Saveas.ImageOptions.LargeImage")));
            this.btn_Saveas.Name = "btn_Saveas";
            this.btn_Saveas.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Saveas_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(852, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 459);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(852, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 435);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(852, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 435);
            // 
            // btn_design
            // 
            this.btn_design.Caption = "Tạo mới Gridview";
            this.btn_design.Id = 0;
            this.btn_design.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_design.ImageOptions.Image")));
            this.btn_design.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_design.ImageOptions.LargeImage")));
            this.btn_design.Name = "btn_design";
            // 
            // btn_NewGridView1
            // 
            this.btn_NewGridView1.Id = 15;
            this.btn_NewGridView1.Name = "btn_NewGridView1";
            // 
            // btn_EditGridView1
            // 
            this.btn_EditGridView1.Id = 16;
            this.btn_EditGridView1.Name = "btn_EditGridView1";
            // 
            // btn_NewBanded1
            // 
            this.btn_NewBanded1.Id = 17;
            this.btn_NewBanded1.Name = "btn_NewBanded1";
            // 
            // btn_EditBanded1
            // 
            this.btn_EditBanded1.Id = 18;
            this.btn_EditBanded1.Name = "btn_EditBanded1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "BandedGridView";
            this.barButtonItem1.Id = 9;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grd_DesignGrid;
            this.gridView1.Name = "gridView1";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand3});
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 145;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "gridBand2";
            this.gridBand2.Columns.Add(this.bandedGridColumn1);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 0;
            this.gridBand2.Width = 75;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "gridBand3";
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 1;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "gridBand4";
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 1;
            // 
            // gridBand5
            // 
            this.gridBand5.Caption = "gridBand5";
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 2;
            // 
            // frmDesignGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 459);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmDesignGridView";
            this.Text = "Thiết kế GridView";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_DesignGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btn_design;
        private DevExpress.XtraBars.BarButtonItem btn_Save;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btn_NewGridView1;
        private DevExpress.XtraBars.BarButtonItem btn_EditGridView1;
        private DevExpress.XtraGrid.GridControl grd_DesignGrid;
        private DevExpress.XtraBars.BarButtonItem btn_Saveas;
        private FormServices.Component.GGLabel lbl_text;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private FormServices.Component.GGButton btn_runDesign;
        private DevExpress.XtraBars.BarButtonItem btn_NewBanded1;
        private DevExpress.XtraBars.BarButtonItem btn_EditBanded1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btn_NewGridView;
        private DevExpress.XtraBars.BarButtonItem btn_EditGridView;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem btn_NewBanded;
        private DevExpress.XtraBars.BarButtonItem btn_EditBanded;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
    }
}