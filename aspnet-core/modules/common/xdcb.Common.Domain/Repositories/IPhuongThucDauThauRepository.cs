using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.PhuongThucDauThaus
{
    public interface IPhuongThucDauThauRepository : IBasicRepository<PhuongThucDauThau, Guid>
    {
        Task<PagedResultDto<PhuongThucDauThau>> SearchAsync(ConditionSearch condition);

        /// <summary>
        /// get danh sachs theo list ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<List<PhuongThucDauThau>> GetListByIds(List<Guid> ids);
    }
}