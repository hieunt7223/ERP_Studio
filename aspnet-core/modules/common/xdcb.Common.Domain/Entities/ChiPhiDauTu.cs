using System.Collections.Generic;
using xdcb.Common.DanhMuc.LoaiHoSos;

namespace xdcb.Common.DanhMuc.ChiPhiDauTus
{
    public class ChiPhiDauTu : BaseEntity
    {
        #region Base properties

        public string TenChiPhi { get; set; }

        public string LoaiChiPhi { get; set; }

        public List<LoaiHoSoChiPhiDauTu> LoaiHoSoChiPhiDauTus { get; set; }

        #endregion Base properties
    }
}