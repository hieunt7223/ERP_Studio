namespace xdcb.FormQLV.Module.NghiQuyet.UI
{
    partial class frmNghiQuyet
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtTrichYeu = new xdcb.FormServices.Component.GGTextEdit();
            this.ggLabel1 = new xdcb.FormServices.Component.GGLabel();
            this.ggPanel1 = new xdcb.FormServices.Component.GGPanel();
            this.ggGroupControl1 = new xdcb.FormServices.Component.GGGroupControl();
            this.grl_DanhsachNghiQuyet = new xdcb.FormServices.Component.GGGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btn_ReloadData = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_New = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrichYeu.Properties)).BeginInit();
            this.ggPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggGroupControl1)).BeginInit();
            this.ggGroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grl_DanhsachNghiQuyet)).BeginInit();
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
            this.groupBox1.Location = new System.Drawing.Point(0, 259);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(873, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btn_ReloadData);
            this.groupControl1.Controls.Add(this.btn_Search);
            this.groupControl1.Controls.Add(this.txtTrichYeu);
            this.groupControl1.Controls.Add(this.ggLabel1);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(867, 60);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Điều kiện lọc";
            // 
            // txtTrichYeu
            // 
            this.txtTrichYeu.GGDataMember = null;
            this.txtTrichYeu.GGDataSource = null;
            this.txtTrichYeu.GGFieldGroup = null;
            this.txtTrichYeu.GGFieldRelation = null;
            this.txtTrichYeu.Location = new System.Drawing.Point(87, 32);
            this.txtTrichYeu.Name = "txtTrichYeu";
            this.txtTrichYeu.Size = new System.Drawing.Size(508, 20);
            this.txtTrichYeu.TabIndex = 1;
            // 
            // ggLabel1
            // 
            this.ggLabel1.GGDataMember = null;
            this.ggLabel1.GGDataSource = null;
            this.ggLabel1.GGFieldGroup = null;
            this.ggLabel1.GGFieldRelation = null;
            this.ggLabel1.Location = new System.Drawing.Point(12, 35);
            this.ggLabel1.Name = "ggLabel1";
            this.ggLabel1.Size = new System.Drawing.Size(44, 13);
            this.ggLabel1.TabIndex = 0;
            this.ggLabel1.Text = "Trích yếu";
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
            this.ggPanel1.Size = new System.Drawing.Size(873, 309);
            this.ggPanel1.TabIndex = 5;
            // 
            // ggGroupControl1
            // 
            this.ggGroupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ggGroupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggGroupControl1.AppearanceCaption.Options.UseFont = true;
            this.ggGroupControl1.Controls.Add(this.grl_DanhsachNghiQuyet);
            this.ggGroupControl1.GGDataMember = null;
            this.ggGroupControl1.GGDataSource = null;
            this.ggGroupControl1.GGFieldGroup = null;
            this.ggGroupControl1.GGFieldRelation = null;
            this.ggGroupControl1.Location = new System.Drawing.Point(3, 69);
            this.ggGroupControl1.Name = "ggGroupControl1";
            this.ggGroupControl1.Size = new System.Drawing.Size(867, 184);
            this.ggGroupControl1.TabIndex = 2;
            this.ggGroupControl1.Text = "Danh sách nghị quyết";
            // 
            // grl_DanhsachNghiQuyet
            // 
            this.grl_DanhsachNghiQuyet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grl_DanhsachNghiQuyet.GGDataMember = null;
            this.grl_DanhsachNghiQuyet.GGDataSource = null;
            this.grl_DanhsachNghiQuyet.GGFieldGroup = null;
            this.grl_DanhsachNghiQuyet.GGFieldRelation = null;
            this.grl_DanhsachNghiQuyet.Location = new System.Drawing.Point(2, 23);
            this.grl_DanhsachNghiQuyet.MainView = this.gridView1;
            this.grl_DanhsachNghiQuyet.Name = "grl_DanhsachNghiQuyet";
            this.grl_DanhsachNghiQuyet.Size = new System.Drawing.Size(863, 159);
            this.grl_DanhsachNghiQuyet.TabIndex = 0;
            this.grl_DanhsachNghiQuyet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grl_DanhsachNghiQuyet;
            this.gridView1.Name = "gridView1";
            // 
            // btn_ReloadData
            // 
            this.btn_ReloadData.BackgroundImage = global::xdcb.FormQLV.Properties.Resources.button_D6D6D6;
            this.btn_ReloadData.ImageOptions.Image = global::xdcb.FormQLV.Properties.Resources.reload;
            this.btn_ReloadData.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_ReloadData.Location = new System.Drawing.Point(708, 29);
            this.btn_ReloadData.Name = "btn_ReloadData";
            this.btn_ReloadData.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_ReloadData.Size = new System.Drawing.Size(81, 23);
            this.btn_ReloadData.TabIndex = 8;
            this.btn_ReloadData.Text = " Làm mới";
            this.btn_ReloadData.Click += new System.EventHandler(this.btn_Search_Click);
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
            this.btn_Search.Location = new System.Drawing.Point(621, 29);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Search.Size = new System.Drawing.Size(81, 23);
            this.btn_Search.TabIndex = 7;
            this.btn_Search.Text = " Tìm kiếm";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
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
            this.btn_ExportExcel.Location = new System.Drawing.Point(789, 20);
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
            this.btn_Delete.Location = new System.Drawing.Point(528, 20);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Delete.Size = new System.Drawing.Size(81, 23);
            this.btn_Delete.TabIndex = 4;
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
            this.btn_Edit.Location = new System.Drawing.Point(615, 20);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Edit.Size = new System.Drawing.Size(81, 23);
            this.btn_Edit.TabIndex = 5;
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
            this.btn_New.Location = new System.Drawing.Point(702, 20);
            this.btn_New.Name = "btn_New";
            this.btn_New.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_New.Size = new System.Drawing.Size(81, 23);
            this.btn_New.TabIndex = 6;
            this.btn_New.Text = " Thêm mới";
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // frmNghiQuyet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 309);
            this.Controls.Add(this.ggPanel1);
            this.Name = "frmNghiQuyet";
            this.Text = "Danh mục nghị quyết";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrichYeu.Properties)).EndInit();
            this.ggPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ggGroupControl1)).EndInit();
            this.ggGroupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grl_DanhsachNghiQuyet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private FormServices.Component.GGTextEdit txtTrichYeu;
        private FormServices.Component.GGLabel ggLabel1;
        private FormServices.Component.GGPanel ggPanel1;
        private FormServices.Component.GGGroupControl ggGroupControl1;
        private FormServices.Component.GGGridControl grl_DanhsachNghiQuyet;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.SimpleButton btn_ReloadData;
        private DevExpress.XtraEditors.SimpleButton btn_Search;
        private DevExpress.XtraEditors.SimpleButton btn_ExportExcel;
        private DevExpress.XtraEditors.SimpleButton btn_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_New;
    }
}