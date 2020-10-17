using System;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class FormModel
    {
        public HoSoCongTrinhChiTietViewModel HoSoCongTrinhChiTiet { get; set; }

        public Guid HoSoCongTrinhId { get; set; }

        public string ActionName { get; set; }
    }
}