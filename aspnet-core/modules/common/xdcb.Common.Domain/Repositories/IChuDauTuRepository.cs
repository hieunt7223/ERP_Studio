using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.ChuDauTus
{
    public interface IChuDauTuRepository : IRepository<ChuDauTu, Guid>
    {
        Task<PagedResultDto<ChuDauTu>> SearchAsync(ConditionSearch condition);

        Task<List<ChuDauTu>> GetListAsync();

        Task<List<ChuDauTu>> GetListByIdsAsync(List<Guid> ids);
    }
}