using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xdcb.FormQLV.NhuCauVonDonVi;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;

namespace xdcb.FormQLV.NhuCauVonTrungHan
{
    public class NhuCauVonTrungHanModule : BaseModule
    {
        public NhuCauVonTrungHanModule()
        {
            Name = ModuleName.NhuCauVonTrungHan.ToString();
            frmNhuCauVonDonVi frm = new frmNhuCauVonDonVi(DateTime.Now.Year.ToString(), LoaiKeHoachNhuCauVon.DAU_NAM.ToString(), KeHoachNhuCauVon.TRUNG_HAN.ToString());
            frm.Text = ModuleName.NhuCauVonTrungHan.GetDescription();
            UIMainForm = frm;
            InitializeModule();
        }
    }
}
