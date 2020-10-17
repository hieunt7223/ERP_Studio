using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.DonViHanhChinhs
{
    public interface IDonViHanhChinhRepository : IBasicRepository<DonViHanhChinh, Guid>
    {
        Task<List<DonViHanhChinh>> SearchAsync(string keyword);

        Task<List<DonViHanhChinh>> GetAllAsync();

        Task<List<Guid>> GetChildIdAsync(Guid id);

        /// <summary>
        /// Get danh sach don vi hanh chinh theo list id
        /// </summary>
        /// <param name="ids">danh sach don vi hanh chinh id</param>
        /// <returns></returns>
        Task<List<DonViHanhChinh>> GetListByIdsAsync(List<Guid> ids);

        Task<List<DonViHanhChinh>> GetParentsAsync();

        Task<List<DonViHanhChinh>> GetChildsAsync();

        /// <summary>
        /// Get danh sách đơn vị cấp thành phố huyện thị xã
        /// </summary>
        /// <returns></returns>
        Task<List<DonViHanhChinh>> GetDonViCapThanhPhoHuyenThiXa();

        /// <summary>
        /// Get danh sách đơn vị cấp Phường, xã, thị trấn không bao gồm ids
        /// </summary>
        /// <returns></returns>
        Task<List<DonViHanhChinh>> GetDonViCapPhuongXaThiTranExcludeIdsAsync(List<Guid> ids);
        bool IsMaExist(string ma, Guid id);
        bool IsNameExist(string name, Guid id, Guid? parentId);
    }
}