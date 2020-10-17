using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.DonViHanhChinhDtos;

namespace xdcb.Common.DanhMuc.DonViHanhChinhs
{
    public interface IDonViHanhChinhAppService :
        ICrudAppService<
            DonViHanhChinhDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateDonViHanhChinhDto,
            CreateUpdateDonViHanhChinhDto>
    {
        Task<List<DonViHanhChinhDto>> GetAllAsync();

        Task<List<DonViHanhChinhDto>> SearchAsync(string keyword);

        Task<List<DonViHanhChinhDto>> GetSelectAsync();

        /// <summary>
        /// Get danh sách đơn vị hành chinh theo ids
        /// </summary>
        /// <param name="ids">Danh sách Id</param>
        /// <returns></returns>
        Task<List<DonViHanhChinhDto>> GetListByIdsAsync(List<Guid> ids);

        /// <summary>
        /// Get danh sách đơn vị hành chinh Cha
        /// </summary>
        /// <returns></returns>
        Task<List<DonViHanhChinhDto>> GetParentsAsync();

        /// <summary>
        /// Get danh sách đơn vị hành chinh Con
        /// </summary>
        /// <returns></returns>
        Task<List<DonViHanhChinhDto>> GetChildsAsync();

        /// <summary>
        /// get key, value của enum đơn vị hành chính
        /// </summary>
        /// <returns></returns>
        Dictionary<int, string> GetCapDonVis();

        /// <summary>
        /// Get danh sách đơn vị cấp thành phố huyện thị xã
        /// </summary>
        /// <returns></returns>
        Task<List<DonViHanhChinhDto>> GetDonViCapThanhPhoHuyenThiXa();

        /// <summary>
        /// Get danh sách đơn vị cấp Phường, xã, thị trấn không bao gồm ids
        /// </summary>
        /// <returns></returns>
        Task<List<DonViHanhChinhDto>> GetDonViCapPhuongXaThiTranExcludeIdsAsync(List<Guid> ids);
        bool IsMaExist(string ma, Guid id);
        bool IsNameExist(string name, Guid id, Guid? parentId);
    }
}