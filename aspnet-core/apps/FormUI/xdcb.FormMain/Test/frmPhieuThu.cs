using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using xdcb.FormServices.BaseForm;

namespace xdcb.FormMain.Test
{
    public partial class frmPhieuThu : GGScreen
    {
        public frmPhieuThu()
        {
            InitializeComponent();
            pn_Search.Visible = false;
        }

        private void ggComboBase2_Load(object sender, EventArgs e)
        {

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            pn_Search.Visible = !pn_Search.Visible;
        }
    }
}