using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xdcb.FormQLV.Module.DanhMuc.ChuongTrinhMucTieuQuocGia.UI;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;

namespace xdcb.FormQLV.ChuongTrinhMucTieuQuocGia
{
    class ChuongTrinhMucTieuQuocGiaModule : BaseModule
    {
        public ChuongTrinhMucTieuQuocGiaModule()
        {
            Name = ModuleName.ChuongTrinhMucTieuQuocGia.ToString();
            frmChuongTrinhMucTieuQuocGia frm = new frmChuongTrinhMucTieuQuocGia();
            UIMainForm = frm;
            InitializeModule();
        }
    }
}
