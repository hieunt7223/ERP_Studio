using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;

namespace xdcb.FormQLV.TongHopGiaiNgan
{
    public class TongHopGiaiNganModule : BaseModule
    {
        public TongHopGiaiNganModule()
        {
            Name = ModuleName.TongHopGiaiNgan.ToString();
            frmTongHopGiaiNgan frm = new frmTongHopGiaiNgan();
            frm.Text = ModuleName.TongHopGiaiNgan.GetDescription();
            UIMainForm = frm;
            InitializeModule();
        }
    }
}
