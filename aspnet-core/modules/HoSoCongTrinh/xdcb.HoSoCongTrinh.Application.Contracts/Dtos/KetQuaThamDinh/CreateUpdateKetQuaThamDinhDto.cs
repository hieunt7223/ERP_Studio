using System;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CreateUpdateKetQuaThamDinhDto
    {
        public Guid HoSoCongTrinhChiTietId { get; set; }

        public Guid? FileId { get; set; }
    }
}