using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.ChucVus
{
    public interface IChucVuRepository : IBasicRepository<ChucVu, Guid>
    {
        Task<PagedResultDto<ChucVu>> SearchAsync(ConditionSearch condition);
    }
}