using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace xdcb.Common.DanhMuc
{
    public abstract class BaseEntity : FullAuditedAggregateRoot<Guid>
    {
        public int OrderIndex { get; set; }

        public Guid TenantId { get; set; }
    }
}