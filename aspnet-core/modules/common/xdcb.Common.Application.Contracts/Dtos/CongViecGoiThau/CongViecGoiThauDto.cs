using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.CongViecGoiThauDtos
{
    public class CongViecGoiThauDto : AuditedEntityDto<Guid>
    {
        public string TenCongViec { get; set; }
    }
}