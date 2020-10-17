using JetBrains.Annotations;
using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CreateUpdateHoSoCongTrinhChiTietMucDauTuRequest
    {
        public Guid? Id { get; set; }

        public Guid? HoSoCongTrinhChiTietId { get; set; }

        public Guid ChiPhiDauTuId { get; set; }

        public decimal SoTien { get; set; }

        public decimal SoTienThamDinh { get; set; }

        public bool IsDeleted { get; set; }
    }
}