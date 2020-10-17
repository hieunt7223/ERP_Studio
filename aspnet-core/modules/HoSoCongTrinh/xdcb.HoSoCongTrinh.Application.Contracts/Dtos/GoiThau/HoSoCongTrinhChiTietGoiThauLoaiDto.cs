using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhChiTietGoiThauLoaiDto : FullAuditedEntityDto<Guid>
    {
        public string TenLoaiGoiThau { get; set; }

        public string MoTa { get; set; }
    }
}