using xdcb.FormQLV.TongHopNhuCauVonDonVi;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;

namespace xdcb.FormQLV.TongHopNhuCauVonHangNam
{
    public class TongHopNhuCauVonHangNamModule : BaseModule
    {
        public TongHopNhuCauVonHangNamModule()
        {
            Name = ModuleName.TongHopNhuCauVonHangNam.ToString();
            frmTongHopNhuCauVonDonVi frm = new frmTongHopNhuCauVonDonVi(KeHoachNhuCauVon.HANG_NAM.ToString());
            frm.Text = ModuleName.TongHopNhuCauVonHangNam.GetDescription();
            UIMainForm = frm;
            InitializeModule();
        }
    }
}
