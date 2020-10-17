using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.CongTrinhDtos;

namespace xdcb.Common.DanhMuc.CongTrinhs
{
    public interface ICongTrinhAppService : ICrudAppService<
            CongTrinhDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateCongTrinhDto,
            CreateUpdateCongTrinhDto>
    {
        Task<int> CountAsync();

        /// <summary>
        /// Get công trình theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CongTrinhDto> GetCongTrinhByIdAsync(Guid id);
        Task<List<CongTrinhDto>> GetListNotPageAsync();
        Task<CongTrinhDto> UpdateTongMucDauTu(Guid id, CreateUpdateCongTrinhDto input);
        Task<List<CongTrinhDto>> GetSearchData(string tencongtrinh, Guid chuDauTuId, int nam);
        Task<CongTrinhDto> CreateData(CreateUpdateCongTrinhDto input);
        Task<CongTrinhDto> UpdateData(Guid id, CreateUpdateCongTrinhDto input);
        Task DeleleDiaDiemXayDungByCongTrinhId(Guid id);
        Task<CongTrinhDto> SaveDiaDiemXayDung(CreateUpdateCongTrinhDto info);
        Task<PagedResultDto<CongTrinhDto>> SearchAsync(CongTrinhConditionSearch condition);
        Task<CongTrinhDto> GetCongTrinhDetailAsync(Guid id);
        bool IsMaExist(string ma,Guid id);
        bool IsNameExist(string name,Guid id);
        Task<List<CongTrinhDto>> GetListByChuDauTuIdAsync(Guid ChuDauTuId);
    }
}