namespace xdcb.FormQLV.Module.DanhMuc.LoaiKhoan.UI
{
    partial class frmLoaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoaiKhoan));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btn_ReloadData = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
            this.txtTuKhoa = new xdcb.FormServices.Component.GGTextEdit();
            this.ggLabel1 = new xdcb.FormServices.Component.GGLabel();
            this.ggPanel1 = new xdcb.FormServices.Component.GGPanel();
            this.ggGroupControl1 = new xdcb.FormServices.Component.GGGroupControl();
            this.tree_danhsachloaikhoan = new xdcb.FormServices.Component.GGTreeList();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuKhoa.Properties)).BeginInit();
            this.ggPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggGroupControl1)).BeginInit();
            this.ggGroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tree_danhsachloaikhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ExportExcel);
            this.groupBox1.Controls.Add(this.btn_Delete);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 346);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 50);
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
            this.btn_ExportExcel.Location = new System.Drawing.Point(791, 20);
            this.btn_ExportExcel.Name = "btn_ExportExcel";
            this.btn_ExportExcel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_ExportExcel.Size = new System.Drawing.Size(81, 23);
            this.btn_ExportExcel.TabIndex = 7;
            this.btn_ExportExcel.Text = " Xuất file";
            this.btn_ExportExcel.Click += new System.EventHandler(this.btn_ExportExcel_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Delete.BackgroundImage = global::xdcb.FormQLV.Properties.Resources.button_D6D6D6;
            this.btn_Delete.ImageOptions.Image = global::xdcb.FormQLV.Properties.Resources.delete;
            this.btn_Delete.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_Delete.Location = new System.Drawing.Point(701, 20);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Delete.Size = new System.Drawing.Size(81, 23);
            this.btn_Delete.TabIndex = 6;
            this.btn_Delete.Text = " Xóa";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btn_ReloadData);
            this.groupControl1.Controls.Add(this.btn_Search);
            this.groupControl1.Controls.Add(this.txtTuKhoa);
            this.groupControl1.Controls.Add(this.ggLabel1);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(869, 60);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Điều kiện lọc";
            // 
            // btn_ReloadData
            // 
            this.btn_ReloadData.BackgroundImage = global::xdcb.FormQLV.Properties.Resources.button_D6D6D6;
            this.btn_ReloadData.ImageOptions.Image = global::xdcb.FormQLV.Properties.Resources.reload;
            this.btn_ReloadData.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_ReloadData.Location = new System.Drawing.Point(713, 29);
            this.btn_ReloadData.Name = "btn_ReloadData";
            this.btn_ReloadData.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_ReloadData.Size = new System.Drawing.Size(81, 23);
            this.btn_ReloadData.TabIndex = 10;
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
            this.btn_Search.Location = new System.Drawing.Point(626, 29);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Search.Size = new System.Drawing.Size(81, 23);
            this.btn_Search.TabIndex = 9;
            this.btn_Search.Text = " Tìm kiếm";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.GGDataMember = null;
            this.txtTuKhoa.GGDataSource = null;
            this.txtTuKhoa.GGFieldGroup = null;
            this.txtTuKhoa.GGFieldRelation = null;
            this.txtTuKhoa.Location = new System.Drawing.Point(87, 32);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(508, 20);
            this.txtTuKhoa.TabIndex = 1;
            // 
            // ggLabel1
            // 
            this.ggLabel1.GGDataMember = null;
            this.ggLabel1.GGDataSource = null;
            this.ggLabel1.GGFieldGroup = null;
            this.ggLabel1.GGFieldRelation = null;
            this.ggLabel1.Location = new System.Drawing.Point(12, 35);
            this.ggLabel1.Name = "ggLabel1";
            this.ggLabel1.Size = new System.Drawing.Size(46, 13);
            this.ggLabel1.TabIndex = 0;
            this.ggLabel1.Text = "Từ khóa :";
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
            this.ggPanel1.Size = new System.Drawing.Size(875, 396);
            this.ggPanel1.TabIndex = 6;
            // 
            // ggGroupControl1
            // 
            this.ggGroupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ggGroupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggGroupControl1.AppearanceCaption.Options.UseFont = true;
            this.ggGroupControl1.Controls.Add(this.tree_danhsachloaikhoan);
            this.ggGroupControl1.GGDataMember = null;
            this.ggGroupControl1.GGDataSource = null;
            this.ggGroupControl1.GGFieldGroup = null;
            this.ggGroupControl1.GGFieldRelation = null;
            this.ggGroupControl1.Location = new System.Drawing.Point(3, 69);
            this.ggGroupControl1.Name = "ggGroupControl1";
            this.ggGroupControl1.Size = new System.Drawing.Size(869, 271);
            this.ggGroupControl1.TabIndex = 2;
            this.ggGroupControl1.Text = "Danh sách loại khoản";
            // 
            // tree_danhsachloaikhoan
            // 
            this.tree_danhsachloaikhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tree_danhsachloaikhoan.GGDataMember = null;
            this.tree_danhsachloaikhoan.GGDataSource = null;
            this.tree_danhsachloaikhoan.GGFieldGroup = null;
            this.tree_danhsachloaikhoan.GGFieldRelation = null;
            this.tree_danhsachloaikhoan.Location = new System.Drawing.Point(-6, 26);
            this.tree_danhsachloaikhoan.Name = "tree_danhsachloaikhoan";
            this.tree_danhsachloaikhoan.Size = new System.Drawing.Size(880, 239);
            this.tree_danhsachloaikhoan.TabIndex = 14;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.TransparentColor = System.Drawing.Color.White;
            this.imageCollection1.Images.SetKeyName(0, "group2_16x16.png");
            // 
            // frmLoaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 396);
            this.Controls.Add(this.ggPanel1);
            this.Name = "frmLoaiKhoan";
            this.Text = "Danh mục loại khoản";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuKhoa.Properties)).EndInit();
            this.ggPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ggGroupControl1)).EndInit();
            this.ggGroupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tree_danhsachloaikhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private FormServices.Component.GGTextEdit txtTuKhoa;
        private FormServices.Component.GGLabel ggLabel1;
        private FormServices.Component.GGPanel ggPanel1;
        private FormServices.Component.GGGroupControl ggGroupControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private FormServices.Component.GGTreeList tree_danhsachloaikhoan;
        private DevExpress.XtraEditors.SimpleButton btn_ReloadData;
        private DevExpress.XtraEditors.SimpleButton btn_Search;
        private DevExpress.XtraEditors.SimpleButton btn_ExportExcel;
        private DevExpress.XtraEditors.SimpleButton btn_Delete;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}