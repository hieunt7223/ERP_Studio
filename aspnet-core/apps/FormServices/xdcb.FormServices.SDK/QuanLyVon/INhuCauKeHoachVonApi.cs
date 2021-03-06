using System;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using xdcb.QuanLyVon.NhuCauKeHoachVon.Dtos;

namespace xdcb.FormServices.SDK
{
    /// <summary>
    /// Generated ISDK for Table : NhuCauKeHoachVon.
    /// </summary>
    public interface INhuCauKeHoachVonsApi
    {
        #region Generated By Column

        [Get("/api/app/NhuCauKeHoachVon")]
        Task<List<NhuCauKeHoachVonDto>> GetListAsync();

        [Post("/api/app/NhuCauKeHoachVon")]
        Task<NhuCauKeHoachVonDto> Create([Body] CreateUpdateNhuCauKeHoachVonDto info);

        [Get("/api/app/NhuCauKeHoachVon/{Id}")]
        Task<NhuCauKeHoachVonDto> GetAsync(Guid Id);

        [Put("/api/app/NhuCauKeHoachVon/{Id}")]
        Task<NhuCauKeHoachVonDto> Update(Guid Id, [Body] CreateUpdateNhuCauKeHoachVonDto info);

        [Delete("/api/app/NhuCauKeHoachVon/{Id}")]
        Task Delete(Guid Id);

        [Get("/api/app/chuDauTu/{id}/nhuCauKeHoachVon")]
        Task<List<NhuCauKeHoachVonDto>> GetListByChuDauTuIDAsync(Guid id);

        [Delete("/api/app/chuDauTu/{id}/nhuCauKeHoachVon")]
        Task DeleteByChuDauTuID(Guid id);

        #endregion

        #region Property
        [Get("/api/app/nhuCauKeHoachVon/searchData/{chuDauTuId}")]
        Task<List<NhuCauKeHoachVonDto>> GetSearchData(int nam, string loaikehoach, string tenkehoach, Guid chuDauTuId);

        [Get("/api/app/nhuCauKeHoachVon/notificationIsNew")]
        Task<NhuCauKeHoachVonDto> GetNotificationIsNew(string tenKeHoach, string loaikehoach, int nam, Guid chuDauTuID);

        [Get("/api/app/nhuCauKeHoachVon/objectYear")]
        Task<List<int>> GetObjectYear();

        [Get("/api/app/nhuCauKeHoachVon/groupData")]
        Task<List<NhuCauKeHoachVonDto>> GetGroupData(int nam, string loaikehoach, string tenkehoach);

        [Get("/api/app/nhuCauKeHoachVon/hangNambyYear")]
        Task<NhuCauKeHoachVonDto> GetHangNamByYear(int nam);
        #endregion
    }
}