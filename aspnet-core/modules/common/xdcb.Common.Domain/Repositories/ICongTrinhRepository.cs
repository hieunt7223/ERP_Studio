using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.CongTrinhs
{
    public interface ICongTrinhRepository : IRepository<CongTrinh, Guid>
    {
        /// <summary>
        /// Get công trình và list địa điểm xây dựng theo công trình id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CongTrinh> GetCongTrinhByIdAsync(Guid id);

        Task DeleleDiaDiemXayDungByCongTrinhId(Guid CongTrinhId);

        Task<CongTrinh> SaveDiaDiemXayDung(CongTrinh congTrinh);
        bool IsMaExist(string ma, Guid id);
        bool IsNameExist(string name,Guid id);

        Task<PagedResultDto<CongTrinh>> SearchAsync(CongTrinhConditionSearch condition);
    }
}