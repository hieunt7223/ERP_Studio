using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.NganhLinhVucSuDungDtos
{
    public class NganhLinhVucSuDungDto : AuditedEntityDto<Guid>
    {
        public string TenNganhLinhVucSuDung { get; set; }
    }
}