using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.NguonVons
{
    public interface INguonVonRepository : IBasicRepository<NguonVon, Guid>
    {
        Task<List<NguonVon>> SearchAsync(string keyword);

        Task<List<NguonVon>> GetAllAsync();

        /// <summary>
        /// get danh sách nguồn vốn đầu tư không bao gồm ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<List<NguonVon>> GetListExcludeIdsAsync(List<Guid> ids);

        Task<List<Guid>> GetChildIdAsync(Guid id);

        Task<List<NguonVon>> GetNguonVonsByIdsAsync(List<Guid> ids);
    }
}