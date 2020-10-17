using System.Collections.Generic;
using xdcb.Common.DanhMuc.CongTrinhs;

namespace xdcb.Common.DanhMuc.NhomCongTrinhs
{
    public class NhomCongTrinh : BaseEntity
    {
        #region Base properties

        public string MaNhomCongTrinh { get; set; }
        public string TenNhomCongTrinh { get; set; }
        public string MoTa { get; set; }

        public List<CongTrinh> CongTrinhs { get; set; }

        #endregion Base properties
    }
}