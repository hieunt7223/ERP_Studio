using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.NhomCongTrinhs
{
    public interface INhomCongTrinhRepository : IBasicRepository<NhomCongTrinh, Guid>
    {
        Task<PagedResultDto<NhomCongTrinh>> SearchAsync(ConditionSearch condition);

        Task<List<NhomCongTrinh>> GetNhomCongTrinhsAsync();
    }
}