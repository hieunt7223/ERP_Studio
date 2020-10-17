using System;

namespace xdcb.Common
{
    public class ThuVienVanBanConditionSearch
    {
        public string keyword { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
        public Guid? LoaiVanBan { get; set; }
        public int CapBanHanh { get; set; }
        public Guid? DonViBanHanh { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
    }
}