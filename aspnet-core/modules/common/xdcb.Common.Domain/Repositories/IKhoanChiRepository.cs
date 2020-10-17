using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.KhoanChis
{
    public interface IKhoanChiRepository : IBasicRepository<KhoanChi, Guid>
    {
        Task<PagedResultDto<KhoanChi>> SearchAsync(ConditionSearch condition);
    }
}