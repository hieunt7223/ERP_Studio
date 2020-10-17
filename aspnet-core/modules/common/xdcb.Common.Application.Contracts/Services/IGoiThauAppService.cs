using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.GoiThauDtos;

namespace xdcb.Common.DanhMuc.GoiThaus
{
    public interface IGoiThauAppService :
        ICrudAppService<
            GoiThauDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateGoiThauDto,
            CreateUpdateGoiThauDto>
    {
        Task<List<GoiThauDto>> GetListByIds(List<Guid> ids);

        /// <summary>
        /// Get danh sách gói thầu cha
        /// </summary>
        Task<List<GoiThauDto>> GetListParentAsync();

        /// <summary>
        /// Get danh sách gói thầu con, trừ những gói thầu con đã thêm
        /// </summary>
        Task<List<GoiThauDto>> GetListChildAsync(List<Guid> ids);

        /// <summary>
        /// Get danh sách gói thầu con theo id gói thầu cha, trừ những gói thầu con đã thêm
        /// </summary>
        /// <param name="parentId">id cha</param>
        /// <param name="childIds">danh sách id con</param>
        /// <returns></returns>
        Task<List<GoiThauDto>> GetListChildByCriteriaAsync(Guid parentId, List<Guid> childIds);

        /// <summary>
        /// Get all gói thầu
        /// </summary>
        Task<List<GoiThauDto>> GetGoiThausAsync();

        /// <summary>
        /// Search theo tên
        /// </summary>
        Task<List<GoiThauDto>> SearchAsync(string name);
    }
}