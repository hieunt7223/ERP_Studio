using System;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CreateUpdateThanhPhanHoSoFileDto
    {
        public Guid HoSoCongTrinhChiTietThanhPhanHoSoId { get; set; }

        public Guid? FileId { get; set; }
    }
}