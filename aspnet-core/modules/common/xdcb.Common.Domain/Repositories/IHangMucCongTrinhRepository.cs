using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.HangMucCongTrinhs
{
    public interface IHangMucCongTrinhRepository : IBasicRepository<HangMucCongTrinh, Guid>
    {
        Task<PagedResultDto<HangMucCongTrinh>> SearchAsync(ConditionSearch condition);
    }
}