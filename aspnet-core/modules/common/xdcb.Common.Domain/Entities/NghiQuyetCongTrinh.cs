using System;
using System.Collections.Generic;
using System.Text;
using xdcb.Common.DanhMuc.NghiQuyets;

namespace xdcb.Common.DanhMuc.CongTrinhs
{
    public class NghiQuyetCongTrinh
    {
        public Guid CongTrinhId { get; set; }

        public Guid NghiQuyetId { get; set; }

        public CongTrinh CongTrinh { get; set; }

        public NghiQuyet NghiQuyet { get; set; }
    }
}
