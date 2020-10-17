using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.ThuVienVanBanDtos;

namespace xdcb.Common.DanhMuc.ThuVienVanBans
{
    public interface IThuVienVanBanAppService :
        ICrudAppService<
            ThuVienVanBanDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateThuVienVanBanDto,
            CreateUpdateThuVienVanBanDto>
    {
        Task<PagedResultDto<ThuVienVanBanDto>> SearchAsync(string condition);

        Task DeleteThuVienVanBan(Guid id);

        /// <summary>
        /// get list thu vien van ban theo list id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<List<ThuVienVanBanDto>> GetCoSoPhapLyByIds(List<Guid> ids);

        /// <summary>
        /// get key, value của enum cấp ban hành
        /// </summary>
        /// <returns></returns>
        Dictionary<int, string> GetCapBanHanhs();
    }
}