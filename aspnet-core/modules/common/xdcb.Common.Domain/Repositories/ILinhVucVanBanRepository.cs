using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.LinhVucVanBans
{
    public interface ILinhVucVanBanRepository : IBasicRepository<LinhVucVanBan, Guid>
    {
        Task<PagedResultDto<LinhVucVanBan>> SearchAsync(ConditionSearch condition);
        Task<IList<LinhVucVanBan>> GetListAsync();
    }
}