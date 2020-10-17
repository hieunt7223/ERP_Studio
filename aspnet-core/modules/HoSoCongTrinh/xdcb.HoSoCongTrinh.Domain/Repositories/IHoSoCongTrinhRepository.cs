using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace xdcb.HoSoCongTrinh.Repositories
{
    public interface IHoSoCongTrinhRepository : IRepository<Entities.HoSoCongTrinh, Guid>
    {
        Task<Entities.HoSoCongTrinh> GetEntityByIdAsync(Guid id);
        bool IsHoSoCongTrinhByCongTrinhId(Guid Id);

        /// <summary>
        /// get danh sách hồ sơ công trình theo công trình
        /// </summary>
        /// <param name="congTrinhId">công trình id</param>
        /// <returns></returns>
        Task<List<Entities.HoSoCongTrinh>> GetListAsyncByCongTrinhId(Guid congTrinhId);
    }
}