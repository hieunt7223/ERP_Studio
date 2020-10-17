using System;
using xdcb.Common.DanhMuc.DonViHanhChinhs;

namespace xdcb.Common.DanhMuc.CongTrinhs
{
    public class DiaDiemXayDung
    {
        public Guid CongTrinhId { get; set; }

        public Guid DonViHanhChinhId { get; set; }

        public string GhiChu { get; set; }

        public CongTrinh CongTrinh { get; set; }

        public DonViHanhChinh DonViHanhChinh { get; set; }
    }
}