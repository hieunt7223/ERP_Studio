using System;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class ThongTinChungViewModel
    {
        public Guid? HoSoCongTrinhId { get; set; }

        public Guid LoaiHoSoId { get; set; }

        public CongTrinhViewModel CongTrinh { get; set; }

        public ChuDauTuViewModel ChuDauTu { get; set; }
    }
}