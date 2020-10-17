using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xdcb.FormQLV.Module.DanhMuc.LoaiKhoan.UI;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;

namespace xdcb.FormQLV.LoaiKhoan
{
    public class LoaiKhoanModule : BaseModule
    {
        public LoaiKhoanModule()
        {
            Name = ModuleName.LoaiKhoan.ToString();
            frmLoaiKhoan frm = new frmLoaiKhoan();
            UIMainForm = frm;
            InitializeModule();
        }
    }
}
