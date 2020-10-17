using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using xdcb.FormServices.ConfigColumns.Dtos;

namespace xdcb.FormServices.ConfigColumns
{
    public interface IConfigColumnAppService : IApplicationService
    {
        Task<List<ConfigColumnDto>> GetListAsync();

        Task<ConfigColumnDto> GetAsync(int id);

        Task<List<ConfigColumnDto>> GetListByTableNameAsync(string tableName);

        Task<ConfigColumnDto> Create(ConfigColumnDto input);

        Task<ConfigColumnDto> Update(int id, ConfigColumnDto input);

        Task Delete(int id);
    }
}