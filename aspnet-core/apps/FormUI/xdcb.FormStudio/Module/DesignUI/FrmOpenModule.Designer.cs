namespace xdcb.FormStudio
{
    partial class FrmOpenModule
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, null, true, true);
            this.panel1 = new System.Windows.Forms.Panel();
            this.ggGroupBox1 = new xdcb.FormServices.Component.GGGroupBox();
            this.btnCommit = new xdcb.FormServices.Component.GGButton();
            this.btnCancel = new xdcb.FormServices.Component.GGButton();
            this.gb_thongtin = new System.Windows.Forms.GroupBox();
            this.gcl_STModules = new xdcb.FormServices.Component.GGGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1.SuspendLayout();
            this.ggGroupBox1.SuspendLayout();
            this.gb_thongtin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcl_STModules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.ggGroupBox1);
            this.panel1.Controls.Add(this.gb_thongtin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 433);
            this.panel1.TabIndex = 0;
            // 
            // ggGroupBox1
            // 
            this.ggGroupBox1.Controls.Add(this.btnCommit);
            this.ggGroupBox1.Controls.Add(this.btnCancel);
            this.ggGroupBox1.GGDataMember = null;
            this.ggGroupBox1.GGDataSource = null;
            this.ggGroupBox1.GGFieldGroup = null;
            this.ggGroupBox1.GGFieldRelation = null;
            this.ggGroupBox1.Location = new System.Drawing.Point(3, 376);
            this.ggGroupBox1.Name = "ggGroupBox1";
            this.ggGroupBox1.Size = new System.Drawing.Size(673, 54);
            this.ggGroupBox1.TabIndex = 1;
            this.ggGroupBox1.TabStop = false;
            // 
            // btnCommit
            // 
            this.btnCommit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommit.GGDataMember = null;
            this.btnCommit.GGDataSource = null;
            this.btnCommit.GGFieldGroup = null;
            this.btnCommit.GGFieldRelation = null;
            this.btnCommit.Image = global::xdcb.FormStudio.Properties.Resources.Save;
            this.btnCommit.Location = new System.Drawing.Point(510, 15);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 30);
            this.btnCommit.TabIndex = 3;
            this.btnCommit.Text = "Đồng ý";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.GGDataMember = null;
            this.btnCancel.GGDataSource = null;
            this.btnCancel.GGFieldGroup = null;
            this.btnCancel.GGFieldRelation = null;
            this.btnCancel.Image = global::xdcb.FormStudio.Properties.Resources.DeleteS;
            this.btnCancel.Location = new System.Drawing.Point(591, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Thoát";
            // 
            // gb_thongtin
            // 
            this.gb_thongtin.Controls.Add(this.gcl_STModules);
            this.gb_thongtin.Location = new System.Drawing.Point(3, 3);
            this.gb_thongtin.Name = "gb_thongtin";
            this.gb_thongtin.Size = new System.Drawing.Size(673, 373);
            this.gb_thongtin.TabIndex = 0;
            this.gb_thongtin.TabStop = false;
            this.gb_thongtin.Text = "Danh sách màn hình";
            // 
            // gcl_STModules
            // 
            this.gcl_STModules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcl_STModules.GGDataMember = null;
            this.gcl_STModules.GGDataSource = "STModules";
            this.gcl_STModules.GGFieldGroup = null;
            this.gcl_STModules.GGFieldRelation = null;
            this.gcl_STModules.Location = new System.Drawing.Point(6, 20);
            this.gcl_STModules.MainView = this.gridView1;
            this.gcl_STModules.Name = "gcl_STModules";
            this.gcl_STModules.Size = new System.Drawing.Size(661, 347);
            this.gcl_STModules.TabIndex = 0;
            this.gcl_STModules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gcl_STModules;
            this.gridView1.Name = "gridView1";
            // 
            // FrmOpenModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 433);
            this.Controls.Add(this.panel1);
            this.Name = "FrmOpenModule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách màn hình";
            this.panel1.ResumeLayout(false);
            this.ggGroupBox1.ResumeLayout(false);
            this.gb_thongtin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcl_STModules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gb_thongtin;
        private xdcb.FormServices.Component.GGGridControl gcl_STModules;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private xdcb.FormServices.Component.GGGroupBox ggGroupBox1;
        private xdcb.FormServices.Component.GGButton btnCommit;
        private xdcb.FormServices.Component.GGButton btnCancel;
    }
}