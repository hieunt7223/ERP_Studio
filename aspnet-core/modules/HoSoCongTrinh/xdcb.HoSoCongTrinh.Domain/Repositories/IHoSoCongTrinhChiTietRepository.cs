using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using xdcb.HoSoCongTrinh.Dtos;
using xdcb.HoSoCongTrinh.Dtos.HoSoCongTrinh;
using xdcb.HoSoCongTrinh.Entities;

namespace xdcb.HoSoCongTrinh.Repositories
{
    public interface IHoSoCongTrinhChiTietRepository : IRepository<HoSoCongTrinhChiTiet, Guid>
    {
        Task<HoSoCongTrinhChiTiet> InsertHoSoCongTrinhChiTiet(HoSoCongTrinhChiTiet model);

        Task<bool> UpdateHoSoCongTrinhChiTiet(HoSoCongTrinhChiTiet model);
    }
}