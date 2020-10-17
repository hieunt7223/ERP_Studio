using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xdcb.FormQLV.Module.NghiQuyet.UI;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;

namespace xdcb.FormQLV.NghiQuyet
{
    public class NghiQuyetModule: BaseModule
    {
        public NghiQuyetModule()
        {
            Name = ModuleName.NghiQuyet.ToString();
            frmNghiQuyet frm = new frmNghiQuyet();
            UIMainForm = frm;
            InitializeModule();
        }
    }
}
