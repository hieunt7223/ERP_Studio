using System;
using System.Collections.Generic;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CoSoPhapLyJsonViewModel
    {
        public string SoKyHieu { get; set; }

        public DateTime NgayBanHanh { get; set; }

        public string DonViBanHanh { get; set; }

        public int CapBanHanh { get; set; }

        public Guid LoaiVanBanId { get; set; }

        public string TenLoaiVanBan { get; set; }

        public Guid LinhVucVanBan { get; set; }

        public string TrichYeu { get; set; }

        public List<HoSoFile> Files { get; set; }
    }
}