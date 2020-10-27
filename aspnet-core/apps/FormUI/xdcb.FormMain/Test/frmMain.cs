using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using xdcb.FormMain.Test;

namespace xdcb.FormMain
{
    public partial class frmMain : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void btn_PhieuThu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmPhieuThu frm = new frmPhieuThu();
            frm.Dock = DockStyle.Fill;
            frm.WindowState = FormWindowState.Maximized;
            frm.AutoSize = true;
            frm.MdiParent = this;          
            frm.Show();
        }
    }
}