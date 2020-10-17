using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.LoaiHoSos
{
    public interface ILoaiHoSoRepository : IRepository<LoaiHoSo, Guid>
    {
        Task<List<LoaiHoSo>> GetLoaiHoSoDuocApDungAsync(bool apDung = true);
        Task<PagedResultDto<LoaiHoSo>> SearchAsync(ConditionSearch condition);
        Task<List<LoaiHoSo>> GetAllAsync();

        /// <summary>
        /// Get loại hồ sơ theo id
        /// </summary>
        /// <param name="id">Id loại hồ sơ</param>
        /// <returns></returns>
        Task<LoaiHoSo> GetLoaiHoSoByIdAsync(Guid id);
    }
}