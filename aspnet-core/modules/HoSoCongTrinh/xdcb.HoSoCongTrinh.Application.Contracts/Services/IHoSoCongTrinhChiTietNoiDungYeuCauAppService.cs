using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.HoSoCongTrinh.Dtos;

namespace xdcb.HoSoCongTrinh.Services
{
    public interface IHoSoCongTrinhChiTietNoiDungYeuCauAppService :
        ICrudAppService<
            HoSoCongTrinhChiTietNoiDungYeuCauDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateHoSoCongTrinhChiTietNoiDungYeuCauDto,
            CreateUpdateHoSoCongTrinhChiTietNoiDungYeuCauDto>
    {
        /// <summary>
        /// Get list nội dung yêu cầu theo hồ sơ công trinh chi tiết id
        /// </summary>
        /// <param name="hoSoCongTrinhChiTietId">Hồ sơ công trình chi tiết id</param>
        /// <returns></returns>
        Task<List<HoSoCongTrinhChiTietNoiDungYeuCauDto>> GetNoiDungYeuCausByIdAsync(Guid hoSoCongTrinhChiTietId);
    }
}