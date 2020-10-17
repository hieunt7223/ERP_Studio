using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.NghiQuyets
{
    public interface INghiQuyetRepository : IBasicRepository<NghiQuyet, Guid>
    {
        Task<PagedResultDto<NghiQuyet>> SearchAsync(ConditionSearch condition);
        Task<NghiQuyet> GetAsync(Guid Id);
        Task DeleleNghiQuyetCongTrinhByNghiQuyetId(Guid CongTrinhId);

        Task<NghiQuyet> SaveNghiQuyetCongTrinh(NghiQuyet congTrinh);
    }
}