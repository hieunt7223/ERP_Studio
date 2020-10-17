using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System.Windows.Forms;
using xdcb.FormServices.Component;

namespace xdcb.FormServices.BaseForm
{
    public partial class GGScreen : XtraForm
    {

        public BaseModule Module { get; set; }
        public void InitializeComponent()
        {
            this.SuspendLayout();

            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1023, 548);
            this.IconOptions.Image = Properties.Resources.logo1;
            this.Name = "GGScreen";
            this.FormClosing += new FormClosingEventHandler(this.GGScreen_FormClosing);
            this.ResumeLayout(false);

        }

        private void GGScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);
            FunctionModule.RemoveOpenedModule(Module);
            SplashScreenManager.CloseForm();
        }
    }
}
