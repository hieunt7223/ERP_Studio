using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.HinhThucHopDongs
{
    public interface IHinhThucHopDongRepository : IBasicRepository<HinhThucHopDong, Guid>
    {
        Task<PagedResultDto<HinhThucHopDong>> SearchAsync(ConditionSearch condition);
        bool IsNameExist(string name, Guid id);

        /// <summary>
        /// get danh sách theo danh sách ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<List<HinhThucHopDong>> GetListByIdsAsync(List<Guid> ids);
    }
}