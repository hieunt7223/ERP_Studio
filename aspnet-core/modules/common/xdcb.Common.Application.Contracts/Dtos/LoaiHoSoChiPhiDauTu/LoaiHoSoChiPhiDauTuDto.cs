using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.LoaiHoSoChiPhiDauTuDtos
{
    public class LoaiHoSoChiPhiDauTuDto : AuditedEntityDto<Guid>
    {
        public Guid LoaiHoSoId { get; set; }

        public Guid ChiPhiDauTuId { get; set; }
    }
}