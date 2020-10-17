using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using xdcb.Common;
using xdcb.Common.DanhMuc.NguonVonDtos;

namespace xdcb.FormServices.SDK
{
    public interface INguonVonsApi
    {
        [Post("/api/app/nguonVon/search")]
        Task<PagedResultDto<NguonVonDto>> SearchAsync(ConditionSearch condition);

        [Post("/api/app/nguonVon")]
        Task<NguonVonDto> CreateAsync(CreateUpdateNguonVonDto input);

        [Get("/api/app/nguonVon")]
        Task<PagedResultDto<NguonVonDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        [Get("/api/app/nguonVon/notPage")]
        Task<List<NguonVonDto>> GetListNotPageAsync();

        [Put("/api/app/nguonVon/{id}")]
        Task<NguonVonDto> UpdateAsync(Guid id, CreateUpdateNguonVonDto input);

        [Delete("/api/app/nguonVon/{id}")]
        Task DeleteAsync(Guid id);

        [Get("/api/app/nguonVon/{id}")]
        Task<NguonVonDto> GetAsync(Guid id);

        [Get("/api/app/nguonVon/search")]
        Task<List<NguonVonDto>> Search(string keyword);
    }
}
