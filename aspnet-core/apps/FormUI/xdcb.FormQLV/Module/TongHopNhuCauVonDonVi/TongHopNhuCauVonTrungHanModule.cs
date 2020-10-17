using xdcb.FormQLV.TongHopNhuCauVonDonVi;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;

namespace xdcb.FormQLV.TongHopNhuCauVonTrungHan
{
    public class TongHopNhuCauVonTrungHanModule : BaseModule
    {
        public TongHopNhuCauVonTrungHanModule()
        {
            Name = ModuleName.TongHopNhuCauVonTrungHan.ToString();
            frmTongHopNhuCauVonDonVi frm = new frmTongHopNhuCauVonDonVi(KeHoachNhuCauVon.TRUNG_HAN.ToString());
            frm.Text = ModuleName.TongHopNhuCauVonTrungHan.GetDescription();
            UIMainForm = frm;
            InitializeModule();
        }
    }
}
