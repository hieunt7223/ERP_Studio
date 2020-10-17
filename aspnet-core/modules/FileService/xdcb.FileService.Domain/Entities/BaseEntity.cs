using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace xdcb.FileService
{
    public abstract class BaseEntity : FullAuditedAggregateRoot<Guid>
    {
        public int OrderIndex { get; set; }

        public Guid TenantId { get; set; }
    }
}
