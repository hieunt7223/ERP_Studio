using System;
using System.Collections.Generic;
using System.Text;

namespace xdcb.Common
{
    public class CongTrinhConditionSearch
    {
        public string keyword { get; set; }

        public Guid? chuDauTu { get; set; }
        public Guid? nhomCongTrinh { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
    }
}
