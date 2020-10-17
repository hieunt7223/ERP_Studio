namespace xdcb.FormQLV.CongTrinh
{
    partial class frmCongTrinh
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_New = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cbe_Nam = new xdcb.FormServices.Component.GGComboBoxEdit();
            this.ggLabel17 = new xdcb.FormServices.Component.GGLabel();
            this.cbb_ChuDauTu = new xdcb.FormServices.Component.GGComboBase();
            this.btn_ReloadData = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
            this.txtTenCongTrinh = new xdcb.FormServices.Component.GGTextEdit();
            this.ggLabel3 = new xdcb.FormServices.Component.GGLabel();
            this.ggLabel1 = new xdcb.FormServices.Component.GGLabel();
            this.ggPanel1 = new xdcb.FormServices.Component.GGPanel();
            this.ggGroupControl1 = new xdcb.FormServices.Component.GGGroupControl();
            this.ggLabel6 = new xdcb.FormServices.Component.GGLabel();
            this.grl_DanhsachCongTrinh = new xdcb.FormServices.Component.GGGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbe_Nam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenCongTrinh.Properties)).BeginInit();
            this.ggPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggGroupControl1)).BeginInit();
            this.ggGroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grl_DanhsachCongTrinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ExportExcel);
            this.groupBox1.Controls.Add(this.btn_Delete);
            this.groupBox1.Controls.Add(this.btn_Edit);
            this.groupBox1.Controls.Add(this.btn_New);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 438);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1025, 50);
            this.groupBox1.TabIndex = 1;
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
            this.btn_ExportExcel.Location = new System.Drawing.Point(941, 20);
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
            this.btn_Delete.Location = new System.Drawing.Point(680, 20);
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
            this.btn_Edit.Location = new System.Drawing.Point(767, 20);
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
            this.btn_New.Location = new System.Drawing.Point(854, 20);
            this.btn_New.Name = "btn_New";
            this.btn_New.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_New.Size = new System.Drawing.Size(81, 23);
            this.btn_New.TabIndex = 2;
            this.btn_New.Text = " Thêm mới";
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.cbe_Nam);
            this.groupControl1.Controls.Add(this.ggLabel17);
            this.groupControl1.Controls.Add(this.cbb_ChuDauTu);
            this.groupControl1.Controls.Add(this.btn_ReloadData);
            this.groupControl1.Controls.Add(this.btn_Search);
            this.groupControl1.Controls.Add(this.txtTenCongTrinh);
            this.groupControl1.Controls.Add(this.ggLabel3);
            this.groupControl1.Controls.Add(this.ggLabel1);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1019, 60);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Điều kiện lọc";
            // 
            // cbe_Nam
            // 
            this.cbe_Nam.GGDataMember = "";
            this.cbe_Nam.GGDataSource = "";
            this.cbe_Nam.GGFieldGroup = null;
            this.cbe_Nam.GGFieldRelation = null;
            this.cbe_Nam.Location = new System.Drawing.Point(652, 32);
            this.cbe_Nam.Name = "cbe_Nam";
            this.cbe_Nam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbe_Nam.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cbe_Nam.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cbe_Nam.Properties.MaxLength = 4;
            this.cbe_Nam.Size = new System.Drawing.Size(106, 20);
            this.cbe_Nam.TabIndex = 2;
            // 
            // ggLabel17
            // 
            this.ggLabel17.GGDataMember = null;
            this.ggLabel17.GGDataSource = null;
            this.ggLabel17.GGFieldGroup = null;
            this.ggLabel17.GGFieldRelation = null;
            this.ggLabel17.Location = new System.Drawing.Point(573, 35);
            this.ggLabel17.Name = "ggLabel17";
            this.ggLabel17.Size = new System.Drawing.Size(73, 13);
            this.ggLabel17.TabIndex = 8;
            this.ggLabel17.Text = "Năm thực hiện:";
            // 
            // cbb_ChuDauTu
            // 
            this.cbb_ChuDauTu.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.cbb_ChuDauTu.ColumnsCaption = null;
            this.cbb_ChuDauTu.DataSource = null;
            this.cbb_ChuDauTu.DisplayMember = null;
            this.cbb_ChuDauTu.DockForIComboBox = System.Windows.Forms.DockStyle.None;
            this.cbb_ChuDauTu.EditValue = null;
            this.cbb_ChuDauTu.EnterMoveNextControl = true;
            this.cbb_ChuDauTu.FieldsName = null;
            this.cbb_ChuDauTu.FontSize = 8.25F;
            this.cbb_ChuDauTu.GGDataMember = "";
            this.cbb_ChuDauTu.GGDataSource = "";
            this.cbb_ChuDauTu.GGFieldGroup = null;
            this.cbb_ChuDauTu.GGFieldRelation = null;
            this.cbb_ChuDauTu.GridColumnAutoWidth = true;
            this.cbb_ChuDauTu.HiddenColumnName = "";
            this.cbb_ChuDauTu.IDBase = null;
            this.cbb_ChuDauTu.Location = new System.Drawing.Point(368, 31);
            this.cbb_ChuDauTu.Name = "cbb_ChuDauTu";
            this.cbb_ChuDauTu.ObjectName = "";
            this.cbb_ChuDauTu.ShowAutoFilterRowOfGrid = true;
            this.cbb_ChuDauTu.ShowButton = false;
            this.cbb_ChuDauTu.Size = new System.Drawing.Size(193, 21);
            this.cbb_ChuDauTu.TabIndex = 1;
            this.cbb_ChuDauTu.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbb_ChuDauTu.ValueMember = null;
            this.cbb_ChuDauTu.WidthOfDropdownGrid = 0;
            this.cbb_ChuDauTu.WidthOfIComboBox = 171;
            // 
            // btn_ReloadData
            // 
            this.btn_ReloadData.BackgroundImage = global::xdcb.FormQLV.Properties.Resources.button_D6D6D6;
            this.btn_ReloadData.ImageOptions.Image = global::xdcb.FormQLV.Properties.Resources.reload;
            this.btn_ReloadData.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_ReloadData.Location = new System.Drawing.Point(867, 30);
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
            this.btn_Search.Location = new System.Drawing.Point(780, 30);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Search.Size = new System.Drawing.Size(81, 23);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.Text = " Tìm kiếm";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // txtTenCongTrinh
            // 
            this.txtTenCongTrinh.GGDataMember = null;
            this.txtTenCongTrinh.GGDataSource = null;
            this.txtTenCongTrinh.GGFieldGroup = null;
            this.txtTenCongTrinh.GGFieldRelation = null;
            this.txtTenCongTrinh.Location = new System.Drawing.Point(87, 32);
            this.txtTenCongTrinh.Name = "txtTenCongTrinh";
            this.txtTenCongTrinh.Size = new System.Drawing.Size(188, 20);
            this.txtTenCongTrinh.TabIndex = 0;
            // 
            // ggLabel3
            // 
            this.ggLabel3.GGDataMember = null;
            this.ggLabel3.GGDataSource = null;
            this.ggLabel3.GGFieldGroup = null;
            this.ggLabel3.GGFieldRelation = null;
            this.ggLabel3.Location = new System.Drawing.Point(308, 35);
            this.ggLabel3.Name = "ggLabel3";
            this.ggLabel3.Size = new System.Drawing.Size(54, 13);
            this.ggLabel3.TabIndex = 2;
            this.ggLabel3.Text = "Chủ đầu tư";
            // 
            // ggLabel1
            // 
            this.ggLabel1.GGDataMember = null;
            this.ggLabel1.GGDataSource = null;
            this.ggLabel1.GGFieldGroup = null;
            this.ggLabel1.GGFieldRelation = null;
            this.ggLabel1.Location = new System.Drawing.Point(12, 35);
            this.ggLabel1.Name = "ggLabel1";
            this.ggLabel1.Size = new System.Drawing.Size(69, 13);
            this.ggLabel1.TabIndex = 0;
            this.ggLabel1.Text = "Tên công trình";
            // 
            // ggPanel1
            // 
            this.ggPanel1.AutoScroll = true;
            this.ggPanel1.Controls.Add(this.ggGroupControl1);
            this.ggPanel1.Controls.Add(this.groupBox1);
            this.ggPanel1.Controls.Add(this.groupControl1);
            this.ggPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggPanel1.GGDataMember = null;
            this.ggPanel1.GGDataSource = null;
            this.ggPanel1.GGFieldGroup = null;
            this.ggPanel1.GGFieldRelation = null;
            this.ggPanel1.Location = new System.Drawing.Point(0, 0);
            this.ggPanel1.Name = "ggPanel1";
            this.ggPanel1.Size = new System.Drawing.Size(1025, 488);
            this.ggPanel1.TabIndex = 4;
            // 
            // ggGroupControl1
            // 
            this.ggGroupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ggGroupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggGroupControl1.AppearanceCaption.Options.UseFont = true;
            this.ggGroupControl1.Controls.Add(this.ggLabel6);
            this.ggGroupControl1.Controls.Add(this.grl_DanhsachCongTrinh);
            this.ggGroupControl1.GGDataMember = null;
            this.ggGroupControl1.GGDataSource = null;
            this.ggGroupControl1.GGFieldGroup = null;
            this.ggGroupControl1.GGFieldRelation = null;
            this.ggGroupControl1.Location = new System.Drawing.Point(3, 69);
            this.ggGroupControl1.Name = "ggGroupControl1";
            this.ggGroupControl1.Size = new System.Drawing.Size(1019, 363);
            this.ggGroupControl1.TabIndex = 2;
            this.ggGroupControl1.Text = "Danh sách công trình";
            // 
            // ggLabel6
            // 
            this.ggLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ggLabel6.GGDataMember = null;
            this.ggLabel6.GGDataSource = null;
            this.ggLabel6.GGFieldGroup = null;
            this.ggLabel6.GGFieldRelation = null;
            this.ggLabel6.Location = new System.Drawing.Point(906, 4);
            this.ggLabel6.Name = "ggLabel6";
            this.ggLabel6.Size = new System.Drawing.Size(110, 13);
            this.ggLabel6.TabIndex = 14;
            this.ggLabel6.Text = "Đơn vị tính: Triệu đồng";
            // 
            // grl_DanhsachCongTrinh
            // 
            this.grl_DanhsachCongTrinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grl_DanhsachCongTrinh.GGDataMember = null;
            this.grl_DanhsachCongTrinh.GGDataSource = null;
            this.grl_DanhsachCongTrinh.GGFieldGroup = null;
            this.grl_DanhsachCongTrinh.GGFieldRelation = null;
            this.grl_DanhsachCongTrinh.Location = new System.Drawing.Point(2, 23);
            this.grl_DanhsachCongTrinh.MainView = this.gridView1;
            this.grl_DanhsachCongTrinh.Name = "grl_DanhsachCongTrinh";
            this.grl_DanhsachCongTrinh.Size = new System.Drawing.Size(1015, 338);
            this.grl_DanhsachCongTrinh.TabIndex = 0;
            this.grl_DanhsachCongTrinh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grl_DanhsachCongTrinh;
            this.gridView1.Name = "gridView1";
            // 
            // frmCongTrinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 488);
            this.Controls.Add(this.ggPanel1);
            this.Name = "frmCongTrinh";
            this.Text = "Danh mục công trình";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbe_Nam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenCongTrinh.Properties)).EndInit();
            this.ggPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ggGroupControl1)).EndInit();
            this.ggGroupControl1.ResumeLayout(false);
            this.ggGroupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grl_DanhsachCongTrinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private FormServices.Component.GGLabel ggLabel3;
        private FormServices.Component.GGLabel ggLabel1;
        private FormServices.Component.GGPanel ggPanel1;
        private FormServices.Component.GGTextEdit txtTenCongTrinh;
        private FormServices.Component.GGGroupControl ggGroupControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private FormServices.Component.GGGridControl grl_DanhsachCongTrinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btn_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_New;
        private DevExpress.XtraEditors.SimpleButton btn_ReloadData;
        private DevExpress.XtraEditors.SimpleButton btn_Search;
        private FormServices.Component.GGLabel ggLabel6;
        private DevExpress.XtraEditors.SimpleButton btn_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_ExportExcel;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private FormServices.Component.GGComboBase cbb_ChuDauTu;
        private FormServices.Component.GGLabel ggLabel17;
        private FormServices.Component.GGComboBoxEdit cbe_Nam;
    }
}