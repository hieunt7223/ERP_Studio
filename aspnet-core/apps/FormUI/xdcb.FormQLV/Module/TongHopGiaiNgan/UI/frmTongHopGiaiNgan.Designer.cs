namespace xdcb.FormQLV.TongHopGiaiNgan
{
    partial class frmTongHopGiaiNgan
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
            this.ggLabel6 = new xdcb.FormServices.Component.GGLabel();
            this.grd_danhsach = new xdcb.FormServices.Component.GGGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cbb_LoaiKeHoach = new xdcb.FormServices.Component.GGComboBase();
            this.cbe_Nam = new xdcb.FormServices.Component.GGComboBoxEdit();
            this.ggLabel2 = new xdcb.FormServices.Component.GGLabel();
            this.ggLabel1 = new xdcb.FormServices.Component.GGLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.ggPanel1 = new xdcb.FormServices.Component.GGPanel();
            this.ggGroupControl1 = new xdcb.FormServices.Component.GGGroupControl();
            this.btn_ReloadData = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_danhsach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbe_Nam.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.ggPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggGroupControl1)).BeginInit();
            this.ggGroupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.ggLabel6);
            this.groupControl1.Controls.Add(this.grd_danhsach);
            this.groupControl1.Location = new System.Drawing.Point(3, 73);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(838, 394);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Danh sách tổng hợp giải ngân";
            // 
            // ggLabel6
            // 
            this.ggLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ggLabel6.GGDataMember = null;
            this.ggLabel6.GGDataSource = null;
            this.ggLabel6.GGFieldGroup = null;
            this.ggLabel6.GGFieldRelation = null;
            this.ggLabel6.Location = new System.Drawing.Point(725, 4);
            this.ggLabel6.Name = "ggLabel6";
            this.ggLabel6.Size = new System.Drawing.Size(110, 13);
            this.ggLabel6.TabIndex = 13;
            this.ggLabel6.Text = "Đơn vị tính: Triệu đồng";
            // 
            // grd_danhsach
            // 
            this.grd_danhsach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_danhsach.GGDataMember = null;
            this.grd_danhsach.GGDataSource = null;
            this.grd_danhsach.GGFieldGroup = null;
            this.grd_danhsach.GGFieldRelation = null;
            this.grd_danhsach.Location = new System.Drawing.Point(2, 23);
            this.grd_danhsach.MainView = this.gridView1;
            this.grd_danhsach.Name = "grd_danhsach";
            this.grd_danhsach.Size = new System.Drawing.Size(834, 369);
            this.grd_danhsach.TabIndex = 0;
            this.grd_danhsach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grd_danhsach;
            this.gridView1.Name = "gridView1";
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
            this.cbb_LoaiKeHoach.Location = new System.Drawing.Point(81, 31);
            this.cbb_LoaiKeHoach.Name = "cbb_LoaiKeHoach";
            this.cbb_LoaiKeHoach.ObjectName = "";
            this.cbb_LoaiKeHoach.ShowAutoFilterRowOfGrid = true;
            this.cbb_LoaiKeHoach.ShowButton = false;
            this.cbb_LoaiKeHoach.Size = new System.Drawing.Size(147, 21);
            this.cbb_LoaiKeHoach.TabIndex = 0;
            this.cbb_LoaiKeHoach.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbb_LoaiKeHoach.ValueMember = null;
            this.cbb_LoaiKeHoach.WidthOfDropdownGrid = 0;
            this.cbb_LoaiKeHoach.WidthOfIComboBox = 125;
            // 
            // cbe_Nam
            // 
            this.cbe_Nam.GGDataMember = "Nam";
            this.cbe_Nam.GGDataSource = "KeHoachTongNguons";
            this.cbe_Nam.GGFieldGroup = null;
            this.cbe_Nam.GGFieldRelation = null;
            this.cbe_Nam.Location = new System.Drawing.Point(261, 32);
            this.cbe_Nam.Name = "cbe_Nam";
            this.cbe_Nam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbe_Nam.Size = new System.Drawing.Size(116, 20);
            this.cbe_Nam.TabIndex = 1;
            // 
            // ggLabel2
            // 
            this.ggLabel2.GGDataMember = null;
            this.ggLabel2.GGDataSource = null;
            this.ggLabel2.GGFieldGroup = null;
            this.ggLabel2.GGFieldRelation = null;
            this.ggLabel2.Location = new System.Drawing.Point(10, 35);
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
            this.ggLabel1.Location = new System.Drawing.Point(234, 35);
            this.ggLabel1.Name = "ggLabel1";
            this.ggLabel1.Size = new System.Drawing.Size(21, 13);
            this.ggLabel1.TabIndex = 4;
            this.ggLabel1.Text = "Năm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ExportExcel);
            this.groupBox1.Controls.Add(this.btn_Edit);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 473);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(844, 49);
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
            this.btn_ExportExcel.Location = new System.Drawing.Point(757, 17);
            this.btn_ExportExcel.Name = "btn_ExportExcel";
            this.btn_ExportExcel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_ExportExcel.Size = new System.Drawing.Size(81, 23);
            this.btn_ExportExcel.TabIndex = 1;
            this.btn_ExportExcel.Text = " Xuất file";
            this.btn_ExportExcel.Click += new System.EventHandler(this.btn_ExportExcel_Click);
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
            this.btn_Edit.Location = new System.Drawing.Point(670, 17);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Edit.Size = new System.Drawing.Size(81, 23);
            this.btn_Edit.TabIndex = 0;
            this.btn_Edit.Text = " Chỉnh sửa";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
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
            this.ggPanel1.Size = new System.Drawing.Size(844, 522);
            this.ggPanel1.TabIndex = 0;
            // 
            // ggGroupControl1
            // 
            this.ggGroupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ggGroupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggGroupControl1.AppearanceCaption.Options.UseFont = true;
            this.ggGroupControl1.Controls.Add(this.btn_ReloadData);
            this.ggGroupControl1.Controls.Add(this.btn_Search);
            this.ggGroupControl1.Controls.Add(this.ggLabel1);
            this.ggGroupControl1.Controls.Add(this.cbb_LoaiKeHoach);
            this.ggGroupControl1.Controls.Add(this.ggLabel2);
            this.ggGroupControl1.Controls.Add(this.cbe_Nam);
            this.ggGroupControl1.GGDataMember = null;
            this.ggGroupControl1.GGDataSource = null;
            this.ggGroupControl1.GGFieldGroup = null;
            this.ggGroupControl1.GGFieldRelation = null;
            this.ggGroupControl1.Location = new System.Drawing.Point(2, 3);
            this.ggGroupControl1.Name = "ggGroupControl1";
            this.ggGroupControl1.Size = new System.Drawing.Size(839, 64);
            this.ggGroupControl1.TabIndex = 0;
            this.ggGroupControl1.Text = "Điều kiện lọc";
            // 
            // btn_ReloadData
            // 
            this.btn_ReloadData.BackgroundImage = global::xdcb.FormQLV.Properties.Resources.button_D6D6D6;
            this.btn_ReloadData.ImageOptions.Image = global::xdcb.FormQLV.Properties.Resources.reload;
            this.btn_ReloadData.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_ReloadData.Location = new System.Drawing.Point(481, 30);
            this.btn_ReloadData.Name = "btn_ReloadData";
            this.btn_ReloadData.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_ReloadData.Size = new System.Drawing.Size(81, 23);
            this.btn_ReloadData.TabIndex = 3;
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
            this.btn_Search.Location = new System.Drawing.Point(394, 30);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Search.Size = new System.Drawing.Size(81, 23);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = " Tìm kiếm";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // frmTongHopGiaiNgan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 522);
            this.Controls.Add(this.ggPanel1);
            this.Name = "frmTongHopGiaiNgan";
            this.Text = "Tổng hợp giải ngân";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_danhsach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbe_Nam.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ggPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ggGroupControl1)).EndInit();
            this.ggGroupControl1.ResumeLayout(false);
            this.ggGroupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private FormServices.Component.GGLabel ggLabel2;
        private FormServices.Component.GGLabel ggLabel1;
        private FormServices.Component.GGPanel ggPanel1;
        private FormServices.Component.GGComboBoxEdit cbe_Nam;
        private FormServices.Component.GGComboBase cbb_LoaiKeHoach;
        private FormServices.Component.GGGroupControl ggGroupControl1;
        private FormServices.Component.GGGridControl grd_danhsach;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private FormServices.Component.GGLabel ggLabel6;
        private DevExpress.XtraEditors.SimpleButton btn_ExportExcel;
        private DevExpress.XtraEditors.SimpleButton btn_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_ReloadData;
        private DevExpress.XtraEditors.SimpleButton btn_Search;
    }
}