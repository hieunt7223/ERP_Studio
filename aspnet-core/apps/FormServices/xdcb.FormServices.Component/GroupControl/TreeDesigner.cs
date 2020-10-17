using DevExpress.XtraTreeList.Design;
namespace xdcb.FormServices.Component
{
    public class TreeDesigner : frmEditor
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeDesigner));
            ((System.ComponentModel.ISupportInitialize)(this.btnsPanel)).BeginInit();
            this.btnsPanel.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMainForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Size = new System.Drawing.Size(230, 423);
            // 
            // productLabel
            // 
            this.productLabel.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("productLabel.Appearance.Image")));
            this.productLabel.Appearance.Options.UseImage = true;
            this.productLabel.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.productLabel.IndentBetweenImageAndText = 10;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 423);
            // 
            // pnlMainForm
            // 
            this.pnlMainForm.Size = new System.Drawing.Size(984, 478);
            // 
            // pnlFrame
            // 
            this.pnlFrame.Size = new System.Drawing.Size(754, 388);
            // 
            // TreeDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(984, 478);
            this.IconOptions.ShowIcon = false;
            this.LookAndFeel.SkinName = "DevExpress Design";
            this.LookAndFeel.TouchScaleFactor = 1F;
            this.LookAndFeel.TouchUIMode = DevExpress.Utils.DefaultBoolean.False;
            this.Name = "TreeDesigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.SetChildIndex(this.pnlMainForm, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnsPanel)).EndInit();
            this.btnsPanel.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlMainForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
