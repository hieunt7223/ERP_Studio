namespace xdcb.FormQLV.CongTrinh
{
    partial class guiDonViHanhChinh
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
            this.ggPanel1 = new xdcb.FormServices.Component.GGPanel();
            this.tree_DonViHanhChinh = new xdcb.FormServices.Component.GGTreeList();
            this.ggGroupBox1 = new xdcb.FormServices.Component.GGGroupBox();
            this.btn_DongY = new xdcb.FormServices.Component.GGButton();
            this.btn_Cancel = new xdcb.FormServices.Component.GGButton();
            this.ggPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tree_DonViHanhChinh)).BeginInit();
            this.ggGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ggPanel1
            // 
            this.ggPanel1.AutoScroll = true;
            this.ggPanel1.Controls.Add(this.tree_DonViHanhChinh);
            this.ggPanel1.Controls.Add(this.ggGroupBox1);
            this.ggPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggPanel1.GGDataMember = null;
            this.ggPanel1.GGDataSource = null;
            this.ggPanel1.GGFieldGroup = null;
            this.ggPanel1.GGFieldRelation = null;
            this.ggPanel1.Location = new System.Drawing.Point(0, 0);
            this.ggPanel1.Name = "ggPanel1";
            this.ggPanel1.Size = new System.Drawing.Size(882, 545);
            this.ggPanel1.TabIndex = 0;
            // 
            // tree_DonViHanhChinh
            // 
            this.tree_DonViHanhChinh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tree_DonViHanhChinh.GGDataMember = null;
            this.tree_DonViHanhChinh.GGDataSource = null;
            this.tree_DonViHanhChinh.GGFieldGroup = null;
            this.tree_DonViHanhChinh.GGFieldRelation = null;
            this.tree_DonViHanhChinh.Location = new System.Drawing.Point(3, 3);
            this.tree_DonViHanhChinh.Name = "tree_DonViHanhChinh";
            this.tree_DonViHanhChinh.Size = new System.Drawing.Size(875, 488);
            this.tree_DonViHanhChinh.TabIndex = 3;
            // 
            // ggGroupBox1
            // 
            this.ggGroupBox1.Controls.Add(this.btn_DongY);
            this.ggGroupBox1.Controls.Add(this.btn_Cancel);
            this.ggGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ggGroupBox1.GGDataMember = null;
            this.ggGroupBox1.GGDataSource = null;
            this.ggGroupBox1.GGFieldGroup = null;
            this.ggGroupBox1.GGFieldRelation = null;
            this.ggGroupBox1.Location = new System.Drawing.Point(0, 497);
            this.ggGroupBox1.Name = "ggGroupBox1";
            this.ggGroupBox1.Size = new System.Drawing.Size(882, 48);
            this.ggGroupBox1.TabIndex = 2;
            this.ggGroupBox1.TabStop = false;
            // 
            // btn_DongY
            // 
            this.btn_DongY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DongY.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_DongY.Appearance.Options.UseForeColor = true;
            this.btn_DongY.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btn_DongY.AppearanceHovered.Options.UseForeColor = true;
            this.btn_DongY.BackgroundImage = global::xdcb.FormQLV.Properties.Resources.button_0E5AD8;
            this.btn_DongY.GGDataMember = null;
            this.btn_DongY.GGDataSource = null;
            this.btn_DongY.GGFieldGroup = null;
            this.btn_DongY.GGFieldRelation = null;
            this.btn_DongY.ImageOptions.Image = global::xdcb.FormQLV.Properties.Resources._new;
            this.btn_DongY.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_DongY.Location = new System.Drawing.Point(740, 15);
            this.btn_DongY.Name = "btn_DongY";
            this.btn_DongY.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_DongY.Size = new System.Drawing.Size(66, 23);
            this.btn_DongY.TabIndex = 0;
            this.btn_DongY.Text = " Chọn";
            this.btn_DongY.Click += new System.EventHandler(this.btn_DongY_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.BackgroundImage = global::xdcb.FormQLV.Properties.Resources.button_D6D6D6;
            this.btn_Cancel.GGDataMember = null;
            this.btn_Cancel.GGDataSource = null;
            this.btn_Cancel.GGFieldGroup = null;
            this.btn_Cancel.GGFieldRelation = null;
            this.btn_Cancel.ImageOptions.Image = global::xdcb.FormQLV.Properties.Resources.Dong;
            this.btn_Cancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_Cancel.Location = new System.Drawing.Point(812, 15);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Cancel.Size = new System.Drawing.Size(66, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = " Đóng";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // guiDonViHanhChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 545);
            this.Controls.Add(this.ggPanel1);
            this.Name = "guiDonViHanhChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn vị hành chính";
            this.ggPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tree_DonViHanhChinh)).EndInit();
            this.ggGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FormServices.Component.GGPanel ggPanel1;
        private FormServices.Component.GGGroupBox ggGroupBox1;
        private FormServices.Component.GGButton btn_Cancel;
        private FormServices.Component.GGButton btn_DongY;
        private FormServices.Component.GGTreeList tree_DonViHanhChinh;
    }
}