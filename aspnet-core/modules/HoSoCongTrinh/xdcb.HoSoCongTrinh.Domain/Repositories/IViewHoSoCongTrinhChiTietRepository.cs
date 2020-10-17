using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using xdcb.HoSoCongTrinh.Entities;

namespace xdcb.HoSoCongTrinh.Repositories
{
    public interface IViewHoSoCongTrinhChiTietRepository : IRepository<vHoSoCongTrinhChiTiet, Guid>
    {
        /// <summary>
        /// Get danh sách hồ sơ công trình chi tiết theo công trình Id
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<List<vHoSoCongTrinhChiTiet>> GetHoSoCongTrinhChiTietAsync(Guid congTrinhId);
    }
}