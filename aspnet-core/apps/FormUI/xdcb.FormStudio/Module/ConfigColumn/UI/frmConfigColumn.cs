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

namespace xdcb.FormStudio.Form.ConfigColumn
{
    public partial class frmConfigColumn : GGScreen
    {
        public Panel pnview;
        public frmConfigColumn()
        {
            InitializeComponent();
            pnview = panelview;
        }
        private void ggTextEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}