using System;

namespace xdcb.HoSoCongTrinh.Entities
{
    public interface IExtraProperties
    {
        int OrderIndex { get; set; }

        Guid TenantId { get; set; }
    }
}