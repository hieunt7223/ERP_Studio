using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.FileCuaThuVienVanBans
{
    public interface IFileCuaThuVienVanBanRepository : IBasicRepository<FileCuaThuVienVanBan, Guid>
    {
        Task<IList<Guid>> GetFileIdListAsync(Guid ThuVienVanBanId);

        Task<Guid> GetIdByFileIdAsync(Guid FileId);

        /// <summary>
        /// Insert fileid theo thư viện văn bản
        /// </summary>
        /// <param name="listFiles"></param>
        /// <returns></returns>
        Task<List<FileCuaThuVienVanBan>> InsertMultiAsync(List<FileCuaThuVienVanBan> listFiles);
    }
}