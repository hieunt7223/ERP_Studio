using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.PhongBans
{
    public interface IPhongBanRepository : IBasicRepository<PhongBan, Guid>
    {
        Task<PagedResultDto<PhongBan>> SearchAsync(ConditionSearch condition);
    }
}