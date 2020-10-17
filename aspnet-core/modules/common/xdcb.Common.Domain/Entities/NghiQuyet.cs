using System;
using System.Collections.Generic;
using xdcb.Common.DanhMuc.CongTrinhs;

namespace xdcb.Common.DanhMuc.NghiQuyets
{
    public class NghiQuyet : BaseEntity
    {
        #region Base properties

        public string SoVanBan { get; set; }

        public DateTime NgayBanHanh { get; set; }
        public string TrichYeu { get; set; }

        public bool IsTheoDoi { get; set; }

        public List<NghiQuyetCongTrinh> NghiQuyetCongTrinhs { get; set; }

        #endregion Base properties
    }
}