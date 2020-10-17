using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using xdcb.HoSoCongTrinh.Entities;

namespace xdcb.HoSoCongTrinh.Repositories
{
    public interface INoiDungYeuCauRepository : IRepository<HoSoCongTrinhChiTietNoiDungYeuCau, Guid>
    {
        /// <summary>
        /// Get list Nội dung yêu cầu theo hồ sơ công trình chi tiết Id
        /// </summary>
        /// <param name="hoSoCongTrinhChiTietId"></param>
        /// <returns></returns>
        Task<List<HoSoCongTrinhChiTietNoiDungYeuCau>> GetNoiDungYeuCausByIdAsync(Guid hoSoCongTrinhChiTietId);
    }
}