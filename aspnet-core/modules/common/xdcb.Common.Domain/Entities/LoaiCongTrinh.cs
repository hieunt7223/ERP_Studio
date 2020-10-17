using System.Collections.Generic;
using xdcb.Common.DanhMuc.CongTrinhs;

namespace xdcb.Common.DanhMuc.LoaiCongTrinhs
{
    public class LoaiCongTrinh : BaseEntity
    {
        #region Base properties

        public string MaLoaiCongTrinh { get; set; }
        public string TenLoaiCongTrinh { get; set; }
        public string MoTa { get; set; }

        public List<CongTrinh> CongTrinhs { get; set; }

        #endregion Base properties
    }
}