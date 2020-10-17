using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.ThuVienVanBans
{
    public interface IThuVienVanBanRepository : IRepository<ThuVienVanBan, Guid>
    {
        Task<PagedResultDto<ThuVienVanBan>> SearchAsync(ThuVienVanBanConditionSearch condition);

        Task<PagedResultDto<ThuVienVanBan>> GetListAsync(PagedAndSortedResultRequestDto input);

        Task<List<ThuVienVanBan>> GetCoSoPhapLyByIds(List<Guid> ids);
    }
}