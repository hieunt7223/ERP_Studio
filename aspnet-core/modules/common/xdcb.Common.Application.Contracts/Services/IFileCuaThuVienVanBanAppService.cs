using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.FileCuaThuVienVanBanDtos;

namespace xdcb.Common.DanhMuc.FileCuaThuVienVanBans
{
    public interface IFileCuaThuVienVanBanAppService :
        ICrudAppService<
            FileCuaThuVienVanBanDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateFileCuaThuVienVanBanDto,
            CreateUpdateFileCuaThuVienVanBanDto>
    {
        Task<IList<Guid>> GetFileIdListAsync(Guid ThuVienVanBanId);

        Task DeleteByFileIdAsync(Guid FileId);

        /// <summary>
        /// Insert fileid theo thư viện văn bản
        /// </summary>
        /// <param name="listFiles"></param>
        /// <returns></returns>
        Task<List<FileCuaThuVienVanBanDto>> InsertMultiAsync(List<CreateUpdateFileCuaThuVienVanBanDto> listFiles);
    }
}