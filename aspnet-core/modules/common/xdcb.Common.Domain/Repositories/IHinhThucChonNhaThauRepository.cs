using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.HinhThucChonNhaThaus
{
    public interface IHinhThucChonNhaThauRepository : IBasicRepository<HinhThucChonNhaThau, Guid>
    {
        Task<PagedResultDto<HinhThucChonNhaThau>> SearchAsync(ConditionSearch condition);

        /// <summary>
        /// Get danh sachs theo danh sách id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<List<HinhThucChonNhaThau>> GetListByIdsAsync(List<Guid> ids);
    }
}