using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;

namespace xdcb.FormQLV.CongTrinh
{
    public partial class CongTrinhModule : BaseModule
    {
        public CongTrinhModule()
        {
            Name = ModuleName.CongTrinh.ToString();
            frmCongTrinh frm = new frmCongTrinh();
            UIMainForm = frm;
            InitializeModule();
        }
    }
}
