using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.LoaiKhoanDtos;

namespace xdcb.Common.DanhMuc.LoaiKhoans
{
    public interface ILoaiKhoanAppService :
        ICrudAppService<
            LoaiKhoanDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateLoaiKhoanDto,
            CreateUpdateLoaiKhoanDto>
    {
        Task<List<LoaiKhoanDto>> GetAllAsync();

        Task<List<LoaiKhoanDto>> SearchAsync(ConditionSearch condition);

        Task<IList<LoaiKhoanDto>> GetLoaiAsync();

        /// <summary>
        /// get key, value của enum loại loại-khoản
        /// </summary>
        /// <returns></returns>
        Dictionary<int, string> GetLoaiKhoanTypes();
    }
}