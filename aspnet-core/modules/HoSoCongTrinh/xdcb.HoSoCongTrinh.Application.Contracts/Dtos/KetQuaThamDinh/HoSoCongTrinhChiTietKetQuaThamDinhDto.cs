using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhChiTietKetQuaThamDinhDto : FullAuditedEntityDto<Guid>
    {
        public Guid HoSoCongTrinhChiTietId { get; set; }

        public Guid? FileId { get; set; }
    }
}