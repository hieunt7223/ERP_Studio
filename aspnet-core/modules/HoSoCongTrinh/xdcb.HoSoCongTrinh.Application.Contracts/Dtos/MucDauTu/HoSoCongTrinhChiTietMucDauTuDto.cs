using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhChiTietMucDauTuDto : FullAuditedEntityDto<Guid>
    {
        public Guid HoSoCongTrinhChiTietId { get; set; }

        public Guid ChiPhiDauTuId { get; set; }

        public decimal SoTien { get; set; }

        public decimal SoTienThamDinh { get; set; }
    }
}