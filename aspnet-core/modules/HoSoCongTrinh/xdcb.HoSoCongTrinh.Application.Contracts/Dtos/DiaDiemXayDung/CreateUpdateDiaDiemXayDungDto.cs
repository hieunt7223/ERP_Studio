using System;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CreateUpdateDiaDiemXayDungDto
    {
        public Guid HoSoCongTrinhChiTietId { get; set; }

        public Guid DonViHanhChinhId { get; set; }

        public string GhiChu { get; set; }
    }
}