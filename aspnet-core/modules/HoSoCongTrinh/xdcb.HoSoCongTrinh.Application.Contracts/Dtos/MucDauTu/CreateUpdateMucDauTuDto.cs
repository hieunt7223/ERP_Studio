using System;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CreateUpdateMucDauTuDto
    {
        public Guid Id { get; set; }

        public Guid HoSoCongTrinhChiTietId { get; set; }

        public Guid ChiPhiDauTuId { get; set; }

        public decimal SoTien { get; set; }

        public decimal SoTienThamDinh { get; set; }

        public bool IsBatBuoc { get; set; }
    }
}