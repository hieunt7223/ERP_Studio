namespace xdcb.FormServices.BaseForm
{
    partial class guiLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ggGroupBox2 = new xdcb.FormServices.Component.GGGroupBox();
            this.ggLabel3 = new xdcb.FormServices.Component.GGLabel();
            this.txt_Password = new xdcb.FormServices.Component.GGTextEdit();
            this.txt_UserName = new xdcb.FormServices.Component.GGTextEdit();
            this.ggLabel2 = new xdcb.FormServices.Component.GGLabel();
            this.ggLabel1 = new xdcb.FormServices.Component.GGLabel();
            this.ggGroupBox1 = new xdcb.FormServices.Component.GGGroupBox();
            this.btn_Login = new xdcb.FormServices.Component.GGButton();
            this.btn_Cancel = new xdcb.FormServices.Component.GGButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).BeginInit();
            this.ggGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ggGroupBox2);
            this.panel1.Controls.Add(this.ggLabel3);
            this.panel1.Controls.Add(this.txt_Password);
            this.panel1.Controls.Add(this.txt_UserName);
            this.panel1.Controls.Add(this.ggLabel2);
            this.panel1.Controls.Add(this.ggLabel1);
            this.panel1.Controls.Add(this.ggGroupBox1);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 152);
            this.panel1.TabIndex = 0;
            // 
            // ggGroupBox2
            // 
            this.ggGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.ggGroupBox2.ForeColor = System.Drawing.Color.Transparent;
            this.ggGroupBox2.GGDataMember = null;
            this.ggGroupBox2.GGDataSource = null;
            this.ggGroupBox2.GGFieldGroup = null;
            this.ggGroupBox2.GGFieldRelation = null;
            this.ggGroupBox2.Location = new System.Drawing.Point(6, 35);
            this.ggGroupBox2.Name = "ggGroupBox2";
            this.ggGroupBox2.Size = new System.Drawing.Size(293, 12);
            this.ggGroupBox2.TabIndex = 6;
            this.ggGroupBox2.TabStop = false;
            // 
            // ggLabel3
            // 
            this.ggLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggLabel3.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.ggLabel3.Appearance.Options.UseFont = true;
            this.ggLabel3.Appearance.Options.UseForeColor = true;
            this.ggLabel3.GGDataMember = null;
            this.ggLabel3.GGDataSource = null;
            this.ggLabel3.GGFieldGroup = null;
            this.ggLabel3.GGFieldRelation = null;
            this.ggLabel3.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.ggLabel3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ggLabel3.ImageOptions.Image")));
            this.ggLabel3.Location = new System.Drawing.Point(7, 7);
            this.ggLabel3.Name = "ggLabel3";
            this.ggLabel3.Size = new System.Drawing.Size(182, 36);
            this.ggLabel3.TabIndex = 5;
            this.ggLabel3.Text = "Đăng nhập hệ thống";
            // 
            // txt_Password
            // 
            this.txt_Password.GGDataMember = null;
            this.txt_Password.GGDataSource = null;
            this.txt_Password.GGFieldGroup = null;
            this.txt_Password.GGFieldRelation = null;
            this.txt_Password.Location = new System.Drawing.Point(109, 82);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Properties.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(190, 20);
            this.txt_Password.TabIndex = 3;
            // 
            // txt_UserName
            // 
            this.txt_UserName.GGDataMember = null;
            this.txt_UserName.GGDataSource = null;
            this.txt_UserName.GGFieldGroup = null;
            this.txt_UserName.GGFieldRelation = null;
            this.txt_UserName.Location = new System.Drawing.Point(109, 56);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(190, 20);
            this.txt_UserName.TabIndex = 2;
            // 
            // ggLabel2
            // 
            this.ggLabel2.GGDataMember = null;
            this.ggLabel2.GGDataSource = null;
            this.ggLabel2.GGFieldGroup = null;
            this.ggLabel2.GGFieldRelation = null;
            this.ggLabel2.Location = new System.Drawing.Point(12, 85);
            this.ggLabel2.Name = "ggLabel2";
            this.ggLabel2.Size = new System.Drawing.Size(62, 13);
            this.ggLabel2.TabIndex = 1;
            this.ggLabel2.Text = "Mật khẩu:(*)";
            // 
            // ggLabel1
            // 
            this.ggLabel1.GGDataMember = null;
            this.ggLabel1.GGDataSource = null;
            this.ggLabel1.GGFieldGroup = null;
            this.ggLabel1.GGFieldRelation = null;
            this.ggLabel1.Location = new System.Drawing.Point(12, 59);
            this.ggLabel1.Name = "ggLabel1";
            this.ggLabel1.Size = new System.Drawing.Size(90, 13);
            this.ggLabel1.TabIndex = 1;
            this.ggLabel1.Text = "Tên đăng nhập:(*)";
            // 
            // ggGroupBox1
            // 
            this.ggGroupBox1.Controls.Add(this.btn_Login);
            this.ggGroupBox1.Controls.Add(this.btn_Cancel);
            this.ggGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ggGroupBox1.GGDataMember = null;
            this.ggGroupBox1.GGDataSource = null;
            this.ggGroupBox1.GGFieldGroup = null;
            this.ggGroupBox1.GGFieldRelation = null;
            this.ggGroupBox1.Location = new System.Drawing.Point(0, 109);
            this.ggGroupBox1.Name = "ggGroupBox1";
            this.ggGroupBox1.Size = new System.Drawing.Size(307, 43);
            this.ggGroupBox1.TabIndex = 4;
            this.ggGroupBox1.TabStop = false;
            // 
            // btn_Login
            // 
            this.btn_Login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Login.GGDataMember = null;
            this.btn_Login.GGDataSource = null;
            this.btn_Login.GGFieldGroup = null;
            this.btn_Login.GGFieldRelation = null;
            this.btn_Login.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Login.ImageOptions.Image")));
            this.btn_Login.Location = new System.Drawing.Point(148, 13);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(85, 23);
            this.btn_Login.TabIndex = 0;
            this.btn_Login.Text = "Đăng nhập";
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.GGDataMember = null;
            this.btn_Cancel.GGDataSource = null;
            this.btn_Cancel.GGFieldGroup = null;
            this.btn_Cancel.GGFieldRelation = null;
            this.btn_Cancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.ImageOptions.Image")));
            this.btn_Cancel.Location = new System.Drawing.Point(239, 13);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(62, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Thoát";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // guiLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 152);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("guiLogin.IconOptions.Image")));
            this.Name = "guiLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.guiLogin_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).EndInit();
            this.ggGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Component.GGGroupBox ggGroupBox1;
        private Component.GGButton btn_Cancel;
        private Component.GGButton btn_Login;
        private Component.GGTextEdit txt_Password;
        private Component.GGTextEdit txt_UserName;
        private Component.GGLabel ggLabel2;
        private Component.GGLabel ggLabel1;
        private Component.GGLabel ggLabel3;
        private Component.GGGroupBox ggGroupBox2;
    }
}