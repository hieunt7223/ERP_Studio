using System;
using System.Collections.Generic;
using xdcb.Common.DanhMuc.CongTrinhs;

namespace xdcb.Common.DanhMuc.DonViHanhChinhs
{
    public class DonViHanhChinh : BaseEntity
    {
        #region Base properties

        public string MaDonViHanhChinh { get; set; }

        public string TenDonViHanhChinh { get; set; }

        public int CapDonViHanhChinh { get; set; }

        public Guid? ParentId { get; set; }

        public List<DiaDiemXayDung> DiaDiemXayDungs { get; set; }

        #endregion Base properties
    }
}