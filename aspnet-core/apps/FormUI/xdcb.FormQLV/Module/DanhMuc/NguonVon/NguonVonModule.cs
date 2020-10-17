using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xdcb.FormQLV.Module.DanhMuc.NguonVon.UI;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;

namespace xdcb.FormQLV.NguonVon
{
    public class NguonVonModule : BaseModule
    {
        public NguonVonModule()
        {
            Name = ModuleName.NguonVon.ToString();
            frmNguonVon frm = new frmNguonVon();
            UIMainForm = frm;
            InitializeModule();
        }
    }
}
