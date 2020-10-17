using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.LoaiCongTrinhDtos;

namespace xdcb.Common.DanhMuc.LoaiCongTrinhs
{
    public interface ILoaiCongTrinhAppService :
        ICrudAppService<
            LoaiCongTrinhDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateLoaiCongTrinhDto,
            CreateUpdateLoaiCongTrinhDto>
    {
        Task<PagedResultDto<LoaiCongTrinhDto>> SearchAsync(ConditionSearch condition);

        /// <summary>
        /// get danh sách loại công trình
        /// </summary>
        /// <returns></returns>
        Task<List<LoaiCongTrinhDto>> GetLoaiCongTrinhsAsync();

        /// <summary>
        /// export excel loại công trình
        /// </summary>
        /// <returns></returns>
        Task<dynamic> ReportAsync();
    }
}