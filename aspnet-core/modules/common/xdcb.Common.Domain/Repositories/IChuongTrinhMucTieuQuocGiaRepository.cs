using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGias
{
    public interface IChuongTrinhMucTieuQuocGiaRepository : IBasicRepository<ChuongTrinhMucTieuQuocGia, Guid>
    {
        Task<List<ChuongTrinhMucTieuQuocGia>> SearchAsync(string keyword);

        Task<List<ChuongTrinhMucTieuQuocGia>> GetAllAsync();
        Task<List<ChuongTrinhMucTieuQuocGia>> GetMaChuongTrinhQuocGia();

        Task<List<Guid>> GetChildIdAsync(Guid id);

        /// <summary>
        /// Get danh sách mã chương trình mục tiêu quốc gia con
        /// </summary>
        /// <returns></returns>
        Task<List<ChuongTrinhMucTieuQuocGia>> GetMaConChuongTrinhsAsync();
    }
}