using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using xdcb.Common;
using xdcb.Common.DanhMuc.CongTrinhDtos;

namespace xdcb.FormServices.SDK
{
    public interface ICongTrinhsApi
    {
        [Post("/api/app/congTrinh/data")]
        Task<CongTrinhDto> Create([Body] CreateUpdateCongTrinhDto info);

        [Get("/api/app/congTrinh")]
        Task<PagedResultDto<CongTrinhDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        [Put("/api/app/congTrinh/{id}/data")]
        Task<CongTrinhDto> Update(Guid Id, [Body] CreateUpdateCongTrinhDto info);

        [Delete("/api/app/congTrinh/{id}")]
        Task DeleteAsync(Guid id);

        [Get("/api/app/congTrinh/{id}")]
        Task<CongTrinhDto> GetAsync(Guid id);

        [Get("/api/app/congTrinh/notPage")]
        Task<List<CongTrinhDto>> GetListNotPageAsync();

        [Put("/api/app/congTrinh/{id}/tongMucDauTu")]
        Task<CongTrinhDto> UpdateTongMucDauTu(Guid id, CreateUpdateCongTrinhDto input);

        [Get("/api​/app​/congTrinh​/searchData​")]
        Task<List<CongTrinhDto>> GetSearchData(string tencongtrinh, Guid chuDauTuId, int nam);

        [Post("/api/app/congTrinh/saveDiaDiemXayDung")]
        Task<CongTrinhDto> SaveDiaDiemXayDung([Body] CreateUpdateCongTrinhDto info);

        [Post("/api/app/congTrinh/{id}/deleleDiaDiemXayDungByCongTrinhId")]
        Task DeleleDiaDiemXayDungByCongTrinhId(Guid id);

        [Get("/api/app/congTrinh/{id}/congTrinhById")]
        Task<CongTrinhDto> GetCongTrinhByIdAsync(Guid id);

        [Get("/api/app/CongTrinh/byChuDauTuId/{ChuDauTuId}")]
        Task<List<CongTrinhDto>> GetListByChuDauTuIdAsync(Guid ChuDauTuId);

        [Get("/api/app/congTrinh/{id}/congTrinhDetail")]
        Task<CongTrinhDto> GetCongTrinhDetailAsync(Guid id);

    }
}
