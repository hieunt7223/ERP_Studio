using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.NguonVonDtos;

namespace xdcb.Common.DanhMuc.NguonVons
{
    public interface INguonVonAppService :
        ICrudAppService<
            NguonVonDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateNguonVonDto,
            CreateUpdateNguonVonDto>
    {
        Task<List<NguonVonDto>> SearchAsync(string keyword);

        Task<List<NguonVonDto>> GetListNguonVonMeAsync();

        Task<List<NguonVonDto>> GetAllAsync();

        Task<List<NguonVonDto>> GetListExcludeIdsAsync(List<Guid> ids);

        Task<List<NguonVonDto>> GetListNotPageAsync();

        Task<List<NguonVonDto>> GetNguonVonsByIdsAsync(List<Guid> ids);
    }
}