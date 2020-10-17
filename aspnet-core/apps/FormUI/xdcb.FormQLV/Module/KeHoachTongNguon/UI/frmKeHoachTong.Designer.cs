namespace xdcb.FormQLV.KeHoachTongNguon
{
    partial class frmKeHoachTong
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cbbTrangThai = new xdcb.FormServices.Component.GGComboBase();
            this.cbb_LoaiKeHoach = new xdcb.FormServices.Component.GGComboBase();
            this.btn_ReloadData = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
            this.cbe_nam = new xdcb.FormServices.Component.GGComboBoxEdit();
            this.grv_KeHoachTongNguon = new xdcb.FormQLV.KeHoachTongNguon.KeHoachVonGridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ggLabel3 = new xdcb.FormServices.Component.GGLabel();
            this.ggLabel2 = new xdcb.FormServices.Component.GGLabel();
            this.ggLabel1 = new xdcb.FormServices.Component.GGLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_New = new DevExpress.XtraEditors.SimpleButton();
            this.gcl_chitietkehoach = new DevExpress.XtraEditors.GroupControl();
            this.tree_kehoachtongnguonchitietView = new xdcb.FormQLV.KeHoachTongNguon.KeHoachVonChiTietCreateTreeList();
            this.ggPanel1 = new xdcb.FormServices.Component.GGPanel();
            this.ggLabel6 = new xdcb.FormServices.Component.GGLabel();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbe_nam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_KeHoachTongNguon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_chitietkehoach)).BeginInit();
            this.gcl_chitietkehoach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tree_kehoachtongnguonchitietView)).BeginInit();
            this.ggPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.cbbTrangThai);
            this.groupControl1.Controls.Add(this.cbb_LoaiKeHoach);
            this.groupControl1.Controls.Add(this.btn_ReloadData);
            this.groupControl1.Controls.Add(this.btn_Search);
            this.groupControl1.Controls.Add(this.cbe_nam);
            this.groupControl1.Controls.Add(this.grv_KeHoachTongNguon);
            this.groupControl1.Controls.Add(this.ggLabel3);
            this.groupControl1.Controls.Add(this.ggLabel2);
            this.groupControl1.Controls.Add(this.ggLabel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(798, 256);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Kế hoạch tổng nguồn";
            // 
            // cbbTrangThai
            // 
            this.cbbTrangThai.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.cbbTrangThai.ColumnsCaption = null;
            this.cbbTrangThai.DataSource = null;
            this.cbbTrangThai.DisplayMember = null;
            this.cbbTrangThai.DockForIComboBox = System.Windows.Forms.DockStyle.None;
            this.cbbTrangThai.EditValue = null;
            this.cbbTrangThai.EnterMoveNextControl = true;
            this.cbbTrangThai.FieldsName = null;
            this.cbbTrangThai.FontSize = 8.25F;
            this.cbbTrangThai.GGDataMember = "TrangThai";
            this.cbbTrangThai.GGDataSource = "KeHoachTongNguons";
            this.cbbTrangThai.GGFieldGroup = null;
            this.cbbTrangThai.GGFieldRelation = null;
            this.cbbTrangThai.GridColumnAutoWidth = true;
            this.cbbTrangThai.HiddenColumnName = "";
            this.cbbTrangThai.IDBase = null;
            this.cbbTrangThai.Location = new System.Drawing.Point(464, 31);
            this.cbbTrangThai.Name = "cbbTrangThai";
            this.cbbTrangThai.ObjectName = "";
            this.cbbTrangThai.ShowAutoFilterRowOfGrid = true;
            this.cbbTrangThai.ShowButton = false;
            this.cbbTrangThai.Size = new System.Drawing.Size(147, 21);
            this.cbbTrangThai.TabIndex = 2;
            this.cbbTrangThai.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbbTrangThai.ValueMember = null;
            this.cbbTrangThai.WidthOfDropdownGrid = 0;
            this.cbbTrangThai.WidthOfIComboBox = 125;
            // 
            // cbb_LoaiKeHoach
            // 
            this.cbb_LoaiKeHoach.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.cbb_LoaiKeHoach.ColumnsCaption = null;
            this.cbb_LoaiKeHoach.DataSource = null;
            this.cbb_LoaiKeHoach.DisplayMember = null;
            this.cbb_LoaiKeHoach.DockForIComboBox = System.Windows.Forms.DockStyle.None;
            this.cbb_LoaiKeHoach.EditValue = null;
            this.cbb_LoaiKeHoach.EnterMoveNextControl = true;
            this.cbb_LoaiKeHoach.FieldsName = null;
            this.cbb_LoaiKeHoach.FontSize = 8.25F;
            this.cbb_LoaiKeHoach.GGDataMember = "LoaiKeHoach";
            this.cbb_LoaiKeHoach.GGDataSource = "KeHoachTongNguons";
            this.cbb_LoaiKeHoach.GGFieldGroup = null;
            this.cbb_LoaiKeHoach.GGFieldRelation = null;
            this.cbb_LoaiKeHoach.GridColumnAutoWidth = true;
            this.cbb_LoaiKeHoach.HiddenColumnName = "";
            this.cbb_LoaiKeHoach.IDBase = null;
            this.cbb_LoaiKeHoach.Location = new System.Drawing.Point(256, 31);
            this.cbb_LoaiKeHoach.Name = "cbb_LoaiKeHoach";
            this.cbb_LoaiKeHoach.ObjectName = "";
            this.cbb_LoaiKeHoach.ShowAutoFilterRowOfGrid = true;
            this.cbb_LoaiKeHoach.ShowButton = false;
            this.cbb_LoaiKeHoach.Size = new System.Drawing.Size(147, 21);
            this.cbb_LoaiKeHoach.TabIndex = 1;
            this.cbb_LoaiKeHoach.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbb_LoaiKeHoach.ValueMember = null;
            this.cbb_LoaiKeHoach.WidthOfDropdownGrid = 0;
            this.cbb_LoaiKeHoach.WidthOfIComboBox = 125;
            // 
            // btn_ReloadData
            // 
            this.btn_ReloadData.BackgroundImage = global::xdcb.FormQLV.Properties.Resources.button_D6D6D6;
            this.btn_ReloadData.ImageOptions.Image = global::xdcb.FormQLV.Properties.Resources.reload;
            this.btn_ReloadData.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_ReloadData.Location = new System.Drawing.Point(701, 29);
            this.btn_ReloadData.Name = "btn_ReloadData";
            this.btn_ReloadData.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_ReloadData.Size = new System.Drawing.Size(81, 23);
            this.btn_ReloadData.TabIndex = 4;
            this.btn_ReloadData.Text = " Làm mới";
            this.btn_ReloadData.Click += new System.EventHandler(this.btn_ReloadData_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_Search.Appearance.Options.UseForeColor = true;
            this.btn_Search.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btn_Search.AppearanceHovered.Options.UseForeColor = true;
            this.btn_Search.BackgroundImage = global::xdcb.FormQLV.Properties.Resources.button_0E5AD8;
            this.btn_Search.ImageOptions.Image = global::xdcb.FormQLV.Properties.Resources.search;
            this.btn_Search.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_Search.Location = new System.Drawing.Point(614, 29);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Search.Size = new System.Drawing.Size(81, 23);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.Text = " Tìm kiếm";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // cbe_nam
            // 
            this.cbe_nam.GGDataMember = "Nam";
            this.cbe_nam.GGDataSource = "KeHoachTongNguons";
            this.cbe_nam.GGFieldGroup = null;
            this.cbe_nam.GGFieldRelation = null;
            this.cbe_nam.Location = new System.Drawing.Point(39, 32);
            this.cbe_nam.Name = "cbe_nam";
            this.cbe_nam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbe_nam.Size = new System.Drawing.Size(116, 20);
            this.cbe_nam.TabIndex = 0;
            // 
            // grv_KeHoachTongNguon
            // 
            this.grv_KeHoachTongNguon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grv_KeHoachTongNguon.GGDataMember = null;
            this.grv_KeHoachTongNguon.GGDataSource = null;
            this.grv_KeHoachTongNguon.GGFieldGroup = null;
            this.grv_KeHoachTongNguon.GGFieldRelation = null;
            this.grv_KeHoachTongNguon.Location = new System.Drawing.Point(2, 58);
            this.grv_KeHoachTongNguon.MainView = this.gridView1;
            this.grv_KeHoachTongNguon.Name = "grv_KeHoachTongNguon";
            this.grv_KeHoachTongNguon.Size = new System.Drawing.Size(794, 194);
            this.grv_KeHoachTongNguon.TabIndex = 3;
            this.grv_KeHoachTongNguon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grv_KeHoachTongNguon;
            this.gridView1.Name = "gridView1";
            // 
            // ggLabel3
            // 
            this.ggLabel3.GGDataMember = null;
            this.ggLabel3.GGDataSource = null;
            this.ggLabel3.GGFieldGroup = null;
            this.ggLabel3.GGFieldRelation = null;
            this.ggLabel3.Location = new System.Drawing.Point(409, 35);
            this.ggLabel3.Name = "ggLabel3";
            this.ggLabel3.Size = new System.Drawing.Size(49, 13);
            this.ggLabel3.TabIndex = 2;
            this.ggLabel3.Text = "Trạng thái";
            // 
            // ggLabel2
            // 
            this.ggLabel2.GGDataMember = null;
            this.ggLabel2.GGDataSource = null;
            this.ggLabel2.GGFieldGroup = null;
            this.ggLabel2.GGFieldRelation = null;
            this.ggLabel2.Location = new System.Drawing.Point(185, 35);
            this.ggLabel2.Name = "ggLabel2";
            this.ggLabel2.Size = new System.Drawing.Size(65, 13);
            this.ggLabel2.TabIndex = 3;
            this.ggLabel2.Text = "Loại kế hoạch";
            // 
            // ggLabel1
            // 
            this.ggLabel1.GGDataMember = null;
            this.ggLabel1.GGDataSource = null;
            this.ggLabel1.GGFieldGroup = null;
            this.ggLabel1.GGFieldRelation = null;
            this.ggLabel1.Location = new System.Drawing.Point(12, 35);
            this.ggLabel1.Name = "ggLabel1";
            this.ggLabel1.Size = new System.Drawing.Size(21, 13);
            this.ggLabel1.TabIndex = 4;
            this.ggLabel1.Text = "Năm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ExportExcel);
            this.groupBox1.Controls.Add(this.btn_Delete);
            this.groupBox1.Controls.Add(this.btn_Edit);
            this.groupBox1.Controls.Add(this.btn_New);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 480);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(798, 42);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btn_ExportExcel
            // 
            this.btn_ExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ExportExcel.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_ExportExcel.Appearance.Options.UseForeColor = true;
            this.btn_ExportExcel.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btn_ExportExcel.AppearanceHovered.Options.UseForeColor = true;
            this.btn_ExportExcel.BackgroundImage = global::xdcb.FormQLV.Properties.Resources.button_D36425;
            this.btn_ExportExcel.ImageOptions.Image = global::xdcb.FormQLV.Properties.Resources.export;
            this.btn_ExportExcel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_ExportExcel.Location = new System.Drawing.Point(713, 13);
            this.btn_ExportExcel.Name = "btn_ExportExcel";
            this.btn_ExportExcel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_ExportExcel.Size = new System.Drawing.Size(81, 23);
            this.btn_ExportExcel.TabIndex = 3;
            this.btn_ExportExcel.Text = " Xuất file";
            this.btn_ExportExcel.Click += new System.EventHandler(this.btn_ExportExcel_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Delete.BackgroundImage = global::xdcb.FormQLV.Properties.Resources.button_D6D6D6;
            this.btn_Delete.ImageOptions.Image = global::xdcb.FormQLV.Properties.Resources.delete;
            this.btn_Delete.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_Delete.Location = new System.Drawing.Point(452, 13);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Delete.Size = new System.Drawing.Size(81, 23);
            this.btn_Delete.TabIndex = 0;
            this.btn_Delete.Text = " Xóa";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Edit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_Edit.Appearance.Options.UseForeColor = true;
            this.btn_Edit.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btn_Edit.AppearanceHovered.Options.UseForeColor = true;
            this.btn_Edit.BackgroundImage = global::xdcb.FormQLV.Properties.Resources.button_0E5AD8;
            this.btn_Edit.ImageOptions.Image = global::xdcb.FormQLV.Properties.Resources.edit;
            this.btn_Edit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_Edit.Location = new System.Drawing.Point(539, 13);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Edit.Size = new System.Drawing.Size(81, 23);
            this.btn_Edit.TabIndex = 1;
            this.btn_Edit.Text = " Chỉnh sửa";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_New
            // 
            this.btn_New.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_New.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_New.Appearance.Options.UseForeColor = true;
            this.btn_New.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btn_New.AppearanceHovered.Options.UseForeColor = true;
            this.btn_New.BackgroundImage = global::xdcb.FormQLV.Properties.Resources.button_04AC5B;
            this.btn_New.ImageOptions.Image = global::xdcb.FormQLV.Properties.Resources._new;
            this.btn_New.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_New.Location = new System.Drawing.Point(626, 13);
            this.btn_New.Name = "btn_New";
            this.btn_New.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_New.Size = new System.Drawing.Size(81, 23);
            this.btn_New.TabIndex = 0;
            this.btn_New.Text = " Thêm mới";
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // gcl_chitietkehoach
            // 
            this.gcl_chitietkehoach.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcl_chitietkehoach.AppearanceCaption.Options.UseFont = true;
            this.gcl_chitietkehoach.Controls.Add(this.ggLabel6);
            this.gcl_chitietkehoach.Controls.Add(this.tree_kehoachtongnguonchitietView);
            this.gcl_chitietkehoach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcl_chitietkehoach.Location = new System.Drawing.Point(0, 256);
            this.gcl_chitietkehoach.Name = "gcl_chitietkehoach";
            this.gcl_chitietkehoach.Size = new System.Drawing.Size(798, 224);
            this.gcl_chitietkehoach.TabIndex = 1;
            this.gcl_chitietkehoach.Text = "Chi tiết kế hoạch tổng nguồn";
            // 
            // tree_kehoachtongnguonchitietView
            // 
            this.tree_kehoachtongnguonchitietView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tree_kehoachtongnguonchitietView.GGDataMember = null;
            this.tree_kehoachtongnguonchitietView.GGDataSource = null;
            this.tree_kehoachtongnguonchitietView.GGFieldGroup = null;
            this.tree_kehoachtongnguonchitietView.GGFieldRelation = null;
            this.tree_kehoachtongnguonchitietView.Location = new System.Drawing.Point(2, 26);
            this.tree_kehoachtongnguonchitietView.Name = "tree_kehoachtongnguonchitietView";
            this.tree_kehoachtongnguonchitietView.Size = new System.Drawing.Size(794, 193);
            this.tree_kehoachtongnguonchitietView.TabIndex = 0;
            // 
            // ggPanel1
            // 
            this.ggPanel1.AutoScroll = true;
            this.ggPanel1.Controls.Add(this.gcl_chitietkehoach);
            this.ggPanel1.Controls.Add(this.groupBox1);
            this.ggPanel1.Controls.Add(this.groupControl1);
            this.ggPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggPanel1.GGDataMember = null;
            this.ggPanel1.GGDataSource = null;
            this.ggPanel1.GGFieldGroup = null;
            this.ggPanel1.GGFieldRelation = null;
            this.ggPanel1.Location = new System.Drawing.Point(0, 0);
            this.ggPanel1.Name = "ggPanel1";
            this.ggPanel1.Size = new System.Drawing.Size(798, 522);
            this.ggPanel1.TabIndex = 3;
            // 
            // ggLabel6
            // 
            this.ggLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ggLabel6.GGDataMember = null;
            this.ggLabel6.GGDataSource = null;
            this.ggLabel6.GGFieldGroup = null;
            this.ggLabel6.GGFieldRelation = null;
            this.ggLabel6.Location = new System.Drawing.Point(684, 4);
            this.ggLabel6.Name = "ggLabel6";
            this.ggLabel6.Size = new System.Drawing.Size(110, 13);
            this.ggLabel6.TabIndex = 14;
            this.ggLabel6.Text = "Đơn vị tính: Triệu đồng";
            // 
            // frmKeHoachTong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 522);
            this.Controls.Add(this.ggPanel1);
            this.Name = "frmKeHoachTong";
            this.Text = "Danh sách kế hoạch tổng nguồn";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbe_nam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_KeHoachTongNguon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcl_chitietkehoach)).EndInit();
            this.gcl_chitietkehoach.ResumeLayout(false);
            this.gcl_chitietkehoach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tree_kehoachtongnguonchitietView)).EndInit();
            this.ggPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.GroupControl gcl_chitietkehoach;
        private FormServices.Component.GGLabel ggLabel3;
        private FormServices.Component.GGLabel ggLabel2;
        private FormServices.Component.GGLabel ggLabel1;
        private FormQLV.KeHoachTongNguon.KeHoachVonGridView grv_KeHoachTongNguon;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btn_ExportExcel;
        private DevExpress.XtraEditors.SimpleButton btn_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_New;
        private FormServices.Component.GGPanel ggPanel1;
        private FormServices.Component.GGComboBoxEdit cbe_nam;
        private FormServices.Component.GGComboBase cbb_LoaiKeHoach;
        private FormServices.Component.GGComboBase cbbTrangThai;
        private DevExpress.XtraEditors.SimpleButton btn_Search;
        private DevExpress.XtraEditors.SimpleButton btn_ReloadData;
        private KeHoachVonChiTietCreateTreeList tree_kehoachtongnguonchitietView;
        private DevExpress.XtraEditors.SimpleButton btn_Delete;
        private FormServices.Component.GGLabel ggLabel6;
    }
}