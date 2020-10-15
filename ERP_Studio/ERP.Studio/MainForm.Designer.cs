namespace ERP_Studio
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDrawControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuickText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dockPropertiesPanel
            // 
            this.dockPropertiesPanel.OriginalSize = new System.Drawing.Size(193, 483);
            this.dockPropertiesPanel.Size = new System.Drawing.Size(113, 315);
            this.dockPropertiesPanel.Click += new System.EventHandler(this.dockPropertiesPanel_Click);
            // 
            // panelContainer1
            // 
            this.panelContainer1.Location = new System.Drawing.Point(666, 67);
            this.panelContainer1.OriginalSize = new System.Drawing.Size(120, 200);
            this.panelContainer1.Size = new System.Drawing.Size(120, 370);
            // 
            // txtQuickText
            // 
            // 
            // MainForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 437);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("MainForm.IconOptions.Image")));
            this.Name = "MainForm";
            this.Text = "Thiết kế giao diện hệ thống";
            this.panelContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDrawControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuickText.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}