namespace xdcb.FormStudio
{
    partial class frmAddModule
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
            this.ggGroupBox1 = new xdcb.FormServices.Component.GGGroupBox();
            this.btnCommit = new xdcb.FormServices.Component.GGButton();
            this.btnCancel = new xdcb.FormServices.Component.GGButton();
            this.grb_info = new xdcb.FormServices.Component.GGGroupBox();
            this.txt_STModuleNo = new xdcb.FormServices.Component.GGTextEdit();
            this.txt_STModuleName = new xdcb.FormServices.Component.GGTextEdit();
            this.cbb_STModuleID = new xdcb.FormServices.Component.GGComboBase();
            this.cbb_STSystemID = new xdcb.FormServices.Component.GGComboBase();
            this.ggLabel2 = new xdcb.FormServices.Component.GGLabel();
            this.ggLabel4 = new xdcb.FormServices.Component.GGLabel();
            this.ggLabel3 = new xdcb.FormServices.Component.GGLabel();
            this.ggLabel1 = new xdcb.FormServices.Component.GGLabel();
            this.ggLabel5 = new xdcb.FormServices.Component.GGLabel();
            this.ggGroupBox1.SuspendLayout();
            this.grb_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_STModuleNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_STModuleName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ggGroupBox1
            // 
            this.ggGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ggGroupBox1.Controls.Add(this.btnCommit);
            this.ggGroupBox1.Controls.Add(this.btnCancel);
            this.ggGroupBox1.GGDataMember = null;
            this.ggGroupBox1.GGDataSource = null;
            this.ggGroupBox1.GGFieldGroup = null;
            this.ggGroupBox1.GGFieldRelation = null;
            this.ggGroupBox1.Location = new System.Drawing.Point(1, 142);
            this.ggGroupBox1.Name = "ggGroupBox1";
            this.ggGroupBox1.Size = new System.Drawing.Size(352, 54);
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
            this.btnCommit.ImageOptions.Image = global::xdcb.FormStudio.Properties.Resources.Save;
            this.btnCommit.Location = new System.Drawing.Point(189, 15);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 30);
            this.btnCommit.TabIndex = 0;
            this.btnCommit.Text = "Đồng ý";
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.GGDataMember = null;
            this.btnCancel.GGDataSource = null;
            this.btnCancel.GGFieldGroup = null;
            this.btnCancel.GGFieldRelation = null;
            this.btnCancel.ImageOptions.Image = global::xdcb.FormStudio.Properties.Resources.DeleteS;
            this.btnCancel.Location = new System.Drawing.Point(270, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grb_info
            // 
            this.grb_info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb_info.Controls.Add(this.ggLabel5);
            this.grb_info.Controls.Add(this.txt_STModuleNo);
            this.grb_info.Controls.Add(this.txt_STModuleName);
            this.grb_info.Controls.Add(this.cbb_STModuleID);
            this.grb_info.Controls.Add(this.cbb_STSystemID);
            this.grb_info.Controls.Add(this.ggLabel2);
            this.grb_info.Controls.Add(this.ggLabel4);
            this.grb_info.Controls.Add(this.ggLabel3);
            this.grb_info.Controls.Add(this.ggLabel1);
            this.grb_info.GGDataMember = null;
            this.grb_info.GGDataSource = null;
            this.grb_info.GGFieldGroup = null;
            this.grb_info.GGFieldRelation = null;
            this.grb_info.Location = new System.Drawing.Point(1, 2);
            this.grb_info.Name = "grb_info";
            this.grb_info.Size = new System.Drawing.Size(352, 149);
            this.grb_info.TabIndex = 0;
            this.grb_info.TabStop = false;
            this.grb_info.Text = "Thông tin";
            // 
            // txt_STModuleNo
            // 
            this.txt_STModuleNo.GGDataMember = null;
            this.txt_STModuleNo.GGDataSource = null;
            this.txt_STModuleNo.GGFieldGroup = null;
            this.txt_STModuleNo.GGFieldRelation = null;
            this.txt_STModuleNo.Location = new System.Drawing.Point(96, 100);
            this.txt_STModuleNo.Name = "txt_STModuleNo";
            this.txt_STModuleNo.Size = new System.Drawing.Size(232, 20);
            this.txt_STModuleNo.TabIndex = 3;
            // 
            // txt_STModuleName
            // 
            this.txt_STModuleName.GGDataMember = null;
            this.txt_STModuleName.GGDataSource = null;
            this.txt_STModuleName.GGFieldGroup = null;
            this.txt_STModuleName.GGFieldRelation = null;
            this.txt_STModuleName.Location = new System.Drawing.Point(96, 74);
            this.txt_STModuleName.Name = "txt_STModuleName";
            this.txt_STModuleName.Size = new System.Drawing.Size(232, 20);
            this.txt_STModuleName.TabIndex = 2;
            // 
            // cbb_STModuleID
            // 
            this.cbb_STModuleID.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.cbb_STModuleID.ColumnsCaption = null;
            this.cbb_STModuleID.DataSource = null;
            this.cbb_STModuleID.DisplayMember = null;
            this.cbb_STModuleID.DockForIComboBox = System.Windows.Forms.DockStyle.None;
            this.cbb_STModuleID.EditValue = null;
            this.cbb_STModuleID.EnterMoveNextControl = true;
            this.cbb_STModuleID.FieldsName = null;
            this.cbb_STModuleID.FontSize = 8.25F;
            this.cbb_STModuleID.GGDataMember = "STModuleID";
            this.cbb_STModuleID.GGDataSource = "STModules";
            this.cbb_STModuleID.GGFieldGroup = null;
            this.cbb_STModuleID.GGFieldRelation = null;
            this.cbb_STModuleID.GridColumnAutoWidth = true;
            this.cbb_STModuleID.HiddenColumnName = "";
            this.cbb_STModuleID.IDBase = null;
            this.cbb_STModuleID.Location = new System.Drawing.Point(96, 47);
            this.cbb_STModuleID.Name = "cbb_STModuleID";
            this.cbb_STModuleID.ObjectName = "";
            this.cbb_STModuleID.ShowAutoFilterRowOfGrid = true;
            this.cbb_STModuleID.ShowButton = true;
            this.cbb_STModuleID.Size = new System.Drawing.Size(254, 21);
            this.cbb_STModuleID.TabIndex = 1;
            this.cbb_STModuleID.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbb_STModuleID.ValueMember = null;
            this.cbb_STModuleID.WidthOfDropdownGrid = 0;
            this.cbb_STModuleID.WidthOfIComboBox = 232;
            // 
            // cbb_STSystemID
            // 
            this.cbb_STSystemID.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.cbb_STSystemID.ColumnsCaption = null;
            this.cbb_STSystemID.DataSource = null;
            this.cbb_STSystemID.DisplayMember = null;
            this.cbb_STSystemID.DockForIComboBox = System.Windows.Forms.DockStyle.None;
            this.cbb_STSystemID.EditValue = null;
            this.cbb_STSystemID.EnterMoveNextControl = true;
            this.cbb_STSystemID.FieldsName = null;
            this.cbb_STSystemID.FontSize = 8.25F;
            this.cbb_STSystemID.GGDataMember = "STSystemID";
            this.cbb_STSystemID.GGDataSource = "STSystems";
            this.cbb_STSystemID.GGFieldGroup = null;
            this.cbb_STSystemID.GGFieldRelation = null;
            this.cbb_STSystemID.GridColumnAutoWidth = true;
            this.cbb_STSystemID.HiddenColumnName = "";
            this.cbb_STSystemID.IDBase = null;
            this.cbb_STSystemID.Location = new System.Drawing.Point(96, 20);
            this.cbb_STSystemID.Name = "cbb_STSystemID";
            this.cbb_STSystemID.ObjectName = "";
            this.cbb_STSystemID.ShowAutoFilterRowOfGrid = true;
            this.cbb_STSystemID.ShowButton = true;
            this.cbb_STSystemID.Size = new System.Drawing.Size(254, 21);
            this.cbb_STSystemID.TabIndex = 0;
            this.cbb_STSystemID.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbb_STSystemID.ValueMember = null;
            this.cbb_STSystemID.WidthOfDropdownGrid = 0;
            this.cbb_STSystemID.WidthOfIComboBox = 232;
            // 
            // ggLabel2
            // 
            this.ggLabel2.GGDataMember = null;
            this.ggLabel2.GGDataSource = null;
            this.ggLabel2.GGFieldGroup = null;
            this.ggLabel2.GGFieldRelation = null;
            this.ggLabel2.Location = new System.Drawing.Point(11, 51);
            this.ggLabel2.Name = "ggLabel2";
            this.ggLabel2.Size = new System.Drawing.Size(68, 13);
            this.ggLabel2.TabIndex = 0;
            this.ggLabel2.Text = "Giao diện cha:";
            // 
            // ggLabel4
            // 
            this.ggLabel4.GGDataMember = null;
            this.ggLabel4.GGDataSource = null;
            this.ggLabel4.GGFieldGroup = null;
            this.ggLabel4.GGFieldRelation = null;
            this.ggLabel4.Location = new System.Drawing.Point(11, 103);
            this.ggLabel4.Name = "ggLabel4";
            this.ggLabel4.Size = new System.Drawing.Size(60, 13);
            this.ggLabel4.TabIndex = 0;
            this.ggLabel4.Text = "Mã giao diện";
            // 
            // ggLabel3
            // 
            this.ggLabel3.GGDataMember = null;
            this.ggLabel3.GGDataSource = null;
            this.ggLabel3.GGFieldGroup = null;
            this.ggLabel3.GGFieldRelation = null;
            this.ggLabel3.Location = new System.Drawing.Point(11, 77);
            this.ggLabel3.Name = "ggLabel3";
            this.ggLabel3.Size = new System.Drawing.Size(68, 13);
            this.ggLabel3.TabIndex = 0;
            this.ggLabel3.Text = "Tên giao diện:";
            // 
            // ggLabel1
            // 
            this.ggLabel1.GGDataMember = null;
            this.ggLabel1.GGDataSource = null;
            this.ggLabel1.GGFieldGroup = null;
            this.ggLabel1.GGFieldRelation = null;
            this.ggLabel1.Location = new System.Drawing.Point(11, 23);
            this.ggLabel1.Name = "ggLabel1";
            this.ggLabel1.Size = new System.Drawing.Size(60, 13);
            this.ggLabel1.TabIndex = 0;
            this.ggLabel1.Text = "Phân hệ: (*)";
            // 
            // ggLabel5
            // 
            this.ggLabel5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggLabel5.Appearance.Options.UseFont = true;
            this.ggLabel5.GGDataMember = null;
            this.ggLabel5.GGDataSource = null;
            this.ggLabel5.GGFieldGroup = null;
            this.ggLabel5.GGFieldRelation = null;
            this.ggLabel5.Location = new System.Drawing.Point(96, 126);
            this.ggLabel5.Name = "ggLabel5";
            this.ggLabel5.Size = new System.Drawing.Size(187, 13);
            this.ggLabel5.TabIndex = 4;
            this.ggLabel5.Text = "Vui lòng nhập chữ viết liền, không dấu!";
            // 
            // frmAddModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 197);
            this.Controls.Add(this.grb_info);
            this.Controls.Add(this.ggGroupBox1);
            this.Name = "frmAddModule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm mới giao diện";
            this.ggGroupBox1.ResumeLayout(false);
            this.grb_info.ResumeLayout(false);
            this.grb_info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_STModuleNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_STModuleName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private xdcb.FormServices.Component.GGGroupBox ggGroupBox1;
        private xdcb.FormServices.Component.GGButton btnCommit;
        private xdcb.FormServices.Component.GGButton btnCancel;
        private xdcb.FormServices.Component.GGGroupBox grb_info;
        private xdcb.FormServices.Component.GGLabel ggLabel1;
        private xdcb.FormServices.Component.GGComboBase cbb_STSystemID;
        private xdcb.FormServices.Component.GGLabel ggLabel2;
        private xdcb.FormServices.Component.GGLabel ggLabel4;
        private xdcb.FormServices.Component.GGLabel ggLabel3;
        private xdcb.FormServices.Component.GGComboBase cbb_STModuleID;
        private xdcb.FormServices.Component.GGTextEdit txt_STModuleName;
        private xdcb.FormServices.Component.GGTextEdit txt_STModuleNo;
        private xdcb.FormServices.Component.GGLabel ggLabel5;
    }
}