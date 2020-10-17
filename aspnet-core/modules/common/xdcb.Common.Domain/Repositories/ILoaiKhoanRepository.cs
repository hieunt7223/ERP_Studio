using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.LoaiKhoans
{
    public interface ILoaiKhoanRepository : IBasicRepository<LoaiKhoan, Guid>
    {
        Task<List<LoaiKhoan>> SearchAsync(ConditionSearch condition);

        Task<List<LoaiKhoan>> GetAllAsync();

        Task<IList<LoaiKhoan>> GetLoaiAsync();

        Task<List<Guid>> GetChildIdAsync(Guid id);
    }
}