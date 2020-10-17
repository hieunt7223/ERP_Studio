using System;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CreateUpdateCoSoPhapLyDto
    {
        public Guid HoSoCongTrinhChiTietId { get; set; }

        public Guid? ThuVienVanBanId { get; set; }

        public CoSoPhapLyJsonViewModel CoSoPhapLyJsonViewModel { get; set; }
    }
}