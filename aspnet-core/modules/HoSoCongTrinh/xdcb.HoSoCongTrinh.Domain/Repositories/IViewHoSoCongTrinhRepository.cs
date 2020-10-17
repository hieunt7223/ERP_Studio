using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using xdcb.HoSoCongTrinh.Dtos;
using xdcb.HoSoCongTrinh.Entities;

namespace xdcb.HoSoCongTrinh.Repositories
{
    public interface IViewHoSoCongTrinhRepository : IRepository<vHoSoCongTrinh, Guid>
    {
        /// <summary>
        /// Get danh sách hồ sơ công trình theo theo điều kiện search
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<List<vHoSoCongTrinh>> GetListHoSoCongTrinhAsync(HoSoCongTrinhSearchInput condition);

        Task<int> CountAsync(HoSoCongTrinhSearchInput condition);
    }
}