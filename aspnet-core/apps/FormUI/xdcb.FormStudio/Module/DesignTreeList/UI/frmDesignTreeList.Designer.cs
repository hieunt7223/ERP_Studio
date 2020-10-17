namespace xdcb.FormStudio.DesignTreeList
{
    partial class frmDesignTreeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesignTreeList));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_runDesign = new xdcb.FormServices.Component.GGButton();
            this.lbl_text = new xdcb.FormServices.Component.GGLabel();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.btn_NewBanded = new DevExpress.XtraBars.BarButtonItem();
            this.btn_EditBanded = new DevExpress.XtraBars.BarButtonItem();
            this.btn_NewTreeList = new DevExpress.XtraBars.BarButtonItem();
            this.btn_EditTreeList = new DevExpress.XtraBars.BarButtonItem();
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
            this.tre_DesignTreeList = new DevExpress.XtraTreeList.TreeList();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tre_DesignTreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.tre_DesignTreeList);
            this.panel1.Controls.Add(this.btn_runDesign);
            this.panel1.Controls.Add(this.lbl_text);
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
            this.btn_NewTreeList,
            this.btn_EditTreeList,
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_NewTreeList),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_EditTreeList)});
            this.barSubItem1.Name = "barSubItem1";
            // btn_NewTreeList
            // 
            this.btn_NewTreeList.Caption = "Tạo mới";
            this.btn_NewTreeList.Id = 11;
            this.btn_NewTreeList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_NewGridView.ImageOptions.Image")));
            this.btn_NewTreeList.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_NewGridView.ImageOptions.LargeImage")));
            this.btn_NewTreeList.Name = "btn_NewTreeList";
            this.btn_NewTreeList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_NewTreeList_ItemClick);
            // 
            // btn_EditTreeList
            // 
            this.btn_EditTreeList.Caption = "Chỉnh sửa";
            this.btn_EditTreeList.Id = 12;
            this.btn_EditTreeList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_EditGridView.ImageOptions.Image")));
            this.btn_EditTreeList.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_EditGridView.ImageOptions.LargeImage")));
            this.btn_EditTreeList.Name = "btn_EditTreeList";
            this.btn_EditTreeList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_EditTreeList_ItemClick);
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
            // tre_DesignTreeList
            // 
            this.tre_DesignTreeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tre_DesignTreeList.Location = new System.Drawing.Point(3, 35);
            this.tre_DesignTreeList.MenuManager = this.barManager1;
            this.tre_DesignTreeList.Name = "tre_DesignTreeList";
            this.tre_DesignTreeList.Size = new System.Drawing.Size(846, 397);
            this.tre_DesignTreeList.TabIndex = 3;
            // 
            // frmDesignTreeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 459);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmDesignTreeList";
            this.Text = "Thiết kế  Tree List";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tre_DesignTreeList)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btn_Saveas;
        private FormServices.Component.GGLabel lbl_text;
        private FormServices.Component.GGButton btn_runDesign;
        private DevExpress.XtraBars.BarButtonItem btn_NewBanded1;
        private DevExpress.XtraBars.BarButtonItem btn_EditBanded1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btn_NewTreeList;
        private DevExpress.XtraBars.BarButtonItem btn_EditTreeList;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem btn_NewBanded;
        private DevExpress.XtraBars.BarButtonItem btn_EditBanded;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraTreeList.TreeList tre_DesignTreeList;
    }
}