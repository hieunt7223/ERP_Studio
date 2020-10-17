using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhChiTietGoiThauFileDto : FullAuditedEntityDto<Guid>
    {
        public Guid HoSoCongTrinhChiTietGoiThauId { get; set; }

        public Guid FileId { get; set; }
    }
}