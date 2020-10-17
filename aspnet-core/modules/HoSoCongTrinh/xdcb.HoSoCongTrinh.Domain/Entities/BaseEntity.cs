using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace xdcb.HoSoCongTrinh
{
    public abstract class BaseEntity<T> : FullAuditedAggregateRoot<T>
    {
        public int? OrderIndex { get; set; }

        public Guid? TenantId { get; set; }
    }
}