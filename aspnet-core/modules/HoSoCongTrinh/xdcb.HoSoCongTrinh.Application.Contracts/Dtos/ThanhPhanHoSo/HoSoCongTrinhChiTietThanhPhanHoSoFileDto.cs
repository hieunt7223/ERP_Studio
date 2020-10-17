using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhChiTietThanhPhanHoSoFileDto : FullAuditedEntityDto<Guid>
    {
        public Guid HoSoCongTrinhChiTietThanhPhanHoSoId { get; set; }

        public Guid? FileId { get; set; }
    }
}