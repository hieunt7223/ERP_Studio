using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.GoiThauDtos
{
    public class LoaiGoiThauDto : AuditedEntityDto<Guid>
    {
        public string TenLoaiGoiThau { get; set; }
    }
}