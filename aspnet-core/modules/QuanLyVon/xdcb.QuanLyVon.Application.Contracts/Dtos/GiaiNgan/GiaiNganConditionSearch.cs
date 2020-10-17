using System;

namespace xdcb.QuanLyVon.GiaiNgan.Dtos
{
    public class GiaiNganConditionSearch
    {
        public int Nam { get; set; }
        public bool? IsKeHoachKeoDai { get; set; }
        public Guid ChuDauTuId { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
    }
}
