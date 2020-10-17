namespace xdcb.FormQLV.TongHopNhuCauVonDonVi
{
    partial class frmTongHopNhuCauVonDonVi
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.ggGroupControl2 = new xdcb.FormServices.Component.GGGroupControl();
            this.grd_tongnhucauvondonvi = new xdcb.FormServices.Component.GGGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ggLabel4 = new xdcb.FormServices.Component.GGLabel();
            this.ggGroupControl1 = new xdcb.FormServices.Component.GGGroupControl();
            this.btn_ReloadData = new DevExpress.XtraEditors.SimpleButton();
            this.cbb_LoaiKeHoach = new xdcb.FormServices.Component.GGComboBase();
            this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
            this.cbe_Nam = new xdcb.FormServices.Component.GGComboBoxEdit();
            this.ggLabel3 = new xdcb.FormServices.Component.GGLabel();
            this.ggLabel2 = new xdcb.FormServices.Component.GGLabel();
            this.btn_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggGroupControl2)).BeginInit();
            this.ggGroupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_tongnhucauvondonvi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ggGroupControl1)).BeginInit();
            this.ggGroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbe_Nam.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.ggGroupControl2);
            this.panel1.Controls.Add(this.ggGroupControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(881, 450);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Edit);
            this.groupBox1.Controls.Add(this.btn_ExportExcel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 401);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(881, 49);
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
            this.btn_ExportExcel.Location = new System.Drawing.Point(795, 17);
            this.btn_ExportExcel.Name = "btn_ExportExcel";
            this.btn_ExportExcel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_ExportExcel.Size = new System.Drawing.Size(81, 23);
            this.btn_ExportExcel.TabIndex = 0;
            this.btn_ExportExcel.Text = " Xuất file";
            this.btn_ExportExcel.Click += new System.EventHandler(this.btn_ExportExcel_Click);
            // 
            // ggGroupControl2
            // 
            this.ggGroupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ggGroupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggGroupControl2.AppearanceCaption.Options.UseFont = true;
            this.ggGroupControl2.Controls.Add(this.grd_tongnhucauvondonvi);
            this.ggGroupControl2.Controls.Add(this.ggLabel4);
            this.ggGroupControl2.GGDataMember = null;
            this.ggGroupControl2.GGDataSource = null;
            this.ggGroupControl2.GGFieldGroup = null;
            this.ggGroupControl2.GGFieldRelation = null;
            this.ggGroupControl2.Location = new System.Drawing.Point(3, 71);
            this.ggGroupControl2.Name = "ggGroupControl2";
            this.ggGroupControl2.Size = new System.Drawing.Size(875, 324);
            this.ggGroupControl2.TabIndex = 1;
            this.ggGroupControl2.Text = "Danh sách nhu cầu vốn đơn vị";
            // 
            // grd_tongnhucauvondonvi
            // 
            this.grd_tongnhucauvondonvi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_tongnhucauvondonvi.GGDataMember = null;
            this.grd_tongnhucauvondonvi.GGDataSource = null;
            this.grd_tongnhucauvondonvi.GGFieldGroup = null;
            this.grd_tongnhucauvondonvi.GGFieldRelation = null;
            this.grd_tongnhucauvondonvi.Location = new System.Drawing.Point(2, 23);
            this.grd_tongnhucauvondonvi.MainView = this.gridView1;
            this.grd_tongnhucauvondonvi.Name = "grd_tongnhucauvondonvi";
            this.grd_tongnhucauvondonvi.Size = new System.Drawing.Size(871, 299);
            this.grd_tongnhucauvondonvi.TabIndex = 2;
            this.grd_tongnhucauvondonvi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grd_tongnhucauvondonvi;
            this.gridView1.Name = "gridView1";
            // 
            // ggLabel4
            // 
            this.ggLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ggLabel4.GGDataMember = null;
            this.ggLabel4.GGDataSource = null;
            this.ggLabel4.GGFieldGroup = null;
            this.ggLabel4.GGFieldRelation = null;
            this.ggLabel4.Location = new System.Drawing.Point(760, 4);
            this.ggLabel4.Name = "ggLabel4";
            this.ggLabel4.Size = new System.Drawing.Size(110, 13);
            this.ggLabel4.TabIndex = 0;
            this.ggLabel4.Text = "Đơn vị tính: Triệu đồng";
            // 
            // ggGroupControl1
            // 
            this.ggGroupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ggGroupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggGroupControl1.AppearanceCaption.Options.UseFont = true;
            this.ggGroupControl1.Controls.Add(this.btn_ReloadData);
            this.ggGroupControl1.Controls.Add(this.cbb_LoaiKeHoach);
            this.ggGroupControl1.Controls.Add(this.btn_Search);
            this.ggGroupControl1.Controls.Add(this.cbe_Nam);
            this.ggGroupControl1.Controls.Add(this.ggLabel3);
            this.ggGroupControl1.Controls.Add(this.ggLabel2);
            this.ggGroupControl1.GGDataMember = null;
            this.ggGroupControl1.GGDataSource = null;
            this.ggGroupControl1.GGFieldGroup = null;
            this.ggGroupControl1.GGFieldRelation = null;
            this.ggGroupControl1.Location = new System.Drawing.Point(3, 3);
            this.ggGroupControl1.Name = "ggGroupControl1";
            this.ggGroupControl1.Size = new System.Drawing.Size(875, 62);
            this.ggGroupControl1.TabIndex = 0;
            this.ggGroupControl1.Text = "Điều kiện lọc";
            // 
            // btn_ReloadData
            // 
            this.btn_ReloadData.BackgroundImage = global::xdcb.FormQLV.Properties.Resources.button_D6D6D6;
            this.btn_ReloadData.ImageOptions.Image = global::xdcb.FormQLV.Properties.Resources.reload;
            this.btn_ReloadData.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_ReloadData.Location = new System.Drawing.Point(499, 31);
            this.btn_ReloadData.Name = "btn_ReloadData";
            this.btn_ReloadData.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_ReloadData.Size = new System.Drawing.Size(81, 23);
            this.btn_ReloadData.TabIndex = 3;
            this.btn_ReloadData.Text = " Làm mới";
            this.btn_ReloadData.Click += new System.EventHandler(this.btn_ReloadData_Click);
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
            this.cbb_LoaiKeHoach.GGDataMember = null;
            this.cbb_LoaiKeHoach.GGDataSource = null;
            this.cbb_LoaiKeHoach.GGFieldGroup = null;
            this.cbb_LoaiKeHoach.GGFieldRelation = null;
            this.cbb_LoaiKeHoach.GridColumnAutoWidth = true;
            this.cbb_LoaiKeHoach.HiddenColumnName = "";
            this.cbb_LoaiKeHoach.IDBase = null;
            this.cbb_LoaiKeHoach.Location = new System.Drawing.Point(259, 32);
            this.cbb_LoaiKeHoach.Name = "cbb_LoaiKeHoach";
            this.cbb_LoaiKeHoach.ObjectName = "";
            this.cbb_LoaiKeHoach.ShowAutoFilterRowOfGrid = true;
            this.cbb_LoaiKeHoach.ShowButton = false;
            this.cbb_LoaiKeHoach.Size = new System.Drawing.Size(148, 21);
            this.cbb_LoaiKeHoach.TabIndex = 1;
            this.cbb_LoaiKeHoach.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbb_LoaiKeHoach.ValueMember = null;
            this.cbb_LoaiKeHoach.WidthOfDropdownGrid = 0;
            this.cbb_LoaiKeHoach.WidthOfIComboBox = 126;
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
            this.btn_Search.Location = new System.Drawing.Point(412, 31);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Search.Size = new System.Drawing.Size(81, 23);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = " Tìm kiếm";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // cbe_Nam
            // 
            this.cbe_Nam.GGDataMember = null;
            this.cbe_Nam.GGDataSource = null;
            this.cbe_Nam.GGFieldGroup = null;
            this.cbe_Nam.GGFieldRelation = null;
            this.cbe_Nam.Location = new System.Drawing.Point(43, 32);
            this.cbe_Nam.Name = "cbe_Nam";
            this.cbe_Nam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbe_Nam.Size = new System.Drawing.Size(116, 20);
            this.cbe_Nam.TabIndex = 0;
            // 
            // ggLabel3
            // 
            this.ggLabel3.GGDataMember = null;
            this.ggLabel3.GGDataSource = null;
            this.ggLabel3.GGFieldGroup = null;
            this.ggLabel3.GGFieldRelation = null;
            this.ggLabel3.Location = new System.Drawing.Point(184, 35);
            this.ggLabel3.Name = "ggLabel3";
            this.ggLabel3.Size = new System.Drawing.Size(69, 13);
            this.ggLabel3.TabIndex = 0;
            this.ggLabel3.Text = "Loại kế hoạch:";
            // 
            // ggLabel2
            // 
            this.ggLabel2.GGDataMember = null;
            this.ggLabel2.GGDataSource = null;
            this.ggLabel2.GGFieldGroup = null;
            this.ggLabel2.GGFieldRelation = null;
            this.ggLabel2.Location = new System.Drawing.Point(12, 35);
            this.ggLabel2.Name = "ggLabel2";
            this.ggLabel2.Size = new System.Drawing.Size(25, 13);
            this.ggLabel2.TabIndex = 0;
            this.ggLabel2.Text = "Năm:";
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
            this.btn_Edit.Location = new System.Drawing.Point(708, 17);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Edit.Size = new System.Drawing.Size(81, 23);
            this.btn_Edit.TabIndex = 2;
            this.btn_Edit.Text = " Chỉnh sửa";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // frmTongHopNhuCauVonDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 450);
            this.Controls.Add(this.panel1);
            this.Name = "frmTongHopNhuCauVonDonVi";
            this.Text = "Tổng hợp nhu cầu vốn đơn vị";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ggGroupControl2)).EndInit();
            this.ggGroupControl2.ResumeLayout(false);
            this.ggGroupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_tongnhucauvondonvi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ggGroupControl1)).EndInit();
            this.ggGroupControl1.ResumeLayout(false);
            this.ggGroupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbe_Nam.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FormServices.Component.GGGroupControl ggGroupControl1;
        private FormServices.Component.GGLabel ggLabel2;
        private FormServices.Component.GGComboBoxEdit cbe_Nam;
        private FormServices.Component.GGLabel ggLabel3;
        private DevExpress.XtraEditors.SimpleButton btn_Search;
        private FormServices.Component.GGGroupControl ggGroupControl2;
        private FormServices.Component.GGLabel ggLabel4;
        private FormServices.Component.GGComboBase cbb_LoaiKeHoach;
        private FormServices.Component.GGGridControl grd_tongnhucauvondonvi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btn_ReloadData;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btn_ExportExcel;
        private DevExpress.XtraEditors.SimpleButton btn_Edit;
    }
}