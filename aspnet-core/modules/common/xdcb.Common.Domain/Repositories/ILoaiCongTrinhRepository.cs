using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.LoaiCongTrinhs
{
    public interface ILoaiCongTrinhRepository : IBasicRepository<LoaiCongTrinh, Guid>
    {
        Task<PagedResultDto<LoaiCongTrinh>> SearchAsync(ConditionSearch condition);

        /// <summary>
        /// get danh sách loại công trình 
        /// </summary>
        /// <returns></returns>
        Task<List<LoaiCongTrinh>> GetLoaiCongTrinhsAsync();
    }
}