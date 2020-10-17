using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.LoaiVanBans
{
    public interface ILoaiVanBanRepository : IBasicRepository<LoaiVanBan, Guid>
    {
        Task<PagedResultDto<LoaiVanBan>> SearchAsync(ConditionSearch condition);

        IQueryable<LoaiVanBan> GetList();
    }
}