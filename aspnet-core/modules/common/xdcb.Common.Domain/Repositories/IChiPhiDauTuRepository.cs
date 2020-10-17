using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.ChiPhiDauTus
{
    public interface IChiPhiDauTuRepository : IBasicRepository<ChiPhiDauTu, Guid>
    {
        Task<PagedResultDto<ChiPhiDauTu>> SearchAsync(ConditionSearch condition);

        /// <summary>
        /// get danh sach chi phi dau tu theo ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<List<ChiPhiDauTu>> GetListByIdsAsync(List<Guid> ids);

        /// <summary>
        /// get danh sach chi phi dau tu không bao gồm ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<List<ChiPhiDauTu>> GetListExcludeIdsAsync(List<Guid> ids);
    }
}