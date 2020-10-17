using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.DoUuTiens
{
    public interface IDoUuTienRepository : IBasicRepository<DoUuTien, Guid>
    {
        Task<PagedResultDto<DoUuTien>> SearchAsync(ConditionSearch condition);
    }
}