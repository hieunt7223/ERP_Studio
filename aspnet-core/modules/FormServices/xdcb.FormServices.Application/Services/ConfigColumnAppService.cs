using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xdcb.FormServices.ConfigColumns.Dtos;

namespace xdcb.FormServices.ConfigColumns
{
    public class ConfigColumnAppService : FormServicesAppServiceBase, IConfigColumnAppService
    {
        private readonly IConfigColumnRepository _iConfigColumnRepository;

        public ConfigColumnAppService(IConfigColumnRepository iConfigColumnRepository)
        {
            _iConfigColumnRepository = iConfigColumnRepository;
        }

        public async Task<List<ConfigColumnDto>> GetListAsync()
        {
            var items = await _iConfigColumnRepository.GetListAsync();

            return new List<ConfigColumnDto>(
                ObjectMapper.Map<List<ConfigColumn>, List<ConfigColumnDto>>(items)
            );
        }

        public async Task<List<ConfigColumnDto>> GetListByTableNameAsync(string tableName)
        {
            var items = await _iConfigColumnRepository.GetListAsync();
            if (items != null && items.Count > 0)
                items = items.Where(x => x.ConfigColumnTableName == tableName && x.Status == "Alive").ToList();
            return new List<ConfigColumnDto>(
                ObjectMapper.Map<List<ConfigColumn>, List<ConfigColumnDto>>(items)
            );
        }

        public async Task<ConfigColumnDto> GetAsync(int id)
        {
            var blog = await _iConfigColumnRepository.GetAsync(id);

            return ObjectMapper.Map<ConfigColumn, ConfigColumnDto>(blog);
        }



        public async Task<ConfigColumnDto> Create(ConfigColumnDto input)
        {
            var newConfigColumn = await _iConfigColumnRepository.InsertAsync(new ConfigColumn()
            {
                ConfigColumnName = input.ConfigColumnName,
                Status = "Alive",
                ConfigColumnCaption = input.ConfigColumnCaption,
                ConfigColumnVisibleIndex = input.ConfigColumnVisibleIndex,
                ConfigColumnDataType = input.ConfigColumnName,
                ConfigColumnLength = input.ConfigColumnLength,
                ConfigColumnAllowEdit = input.ConfigColumnAllowEdit,
                ConfigColumnIsVisible = input.ConfigColumnIsVisible,
                ConfigColumnDisplayFormat = input.ConfigColumnDisplayFormat,
                ConfigColumnTableName = input.ConfigColumnTableName,
                ConfigColumnFunctionCode = input.ConfigColumnFunctionCode,
                ConfigColumnDataSource = input.ConfigColumnDataSource,
                ConfigColumnDisplayMember = input.ConfigColumnDisplayMember,
                ConfigColumnValueMember = input.ConfigColumnValueMember,
                ConfigColumnFilter = input.ConfigColumnFilter,
            });

            return ObjectMapper.Map<ConfigColumn, ConfigColumnDto>(newConfigColumn);
        }

        public async Task<ConfigColumnDto> Update(int id, ConfigColumnDto input)
        {
            var item = await _iConfigColumnRepository.GetAsync(id);
            item.ConfigColumnName = input.ConfigColumnName;
            item.ConfigColumnCaption = input.ConfigColumnCaption;
            item.ConfigColumnVisibleIndex = input.ConfigColumnVisibleIndex;
            item.ConfigColumnDataType = input.ConfigColumnName;
            item.ConfigColumnLength = input.ConfigColumnLength;
            item.ConfigColumnAllowEdit = input.ConfigColumnAllowEdit;
            item.ConfigColumnDisplayFormat = input.ConfigColumnDisplayFormat;
            item.ConfigColumnTableName = input.ConfigColumnTableName;
            item.ConfigColumnFunctionCode = input.ConfigColumnFunctionCode;
            item.ConfigColumnDataSource = input.ConfigColumnDataSource;
            item.ConfigColumnDisplayMember = input.ConfigColumnDisplayMember;
            item.ConfigColumnValueMember = input.ConfigColumnValueMember;
            item.ConfigColumnFilter = input.ConfigColumnFilter;
            item.ConfigColumnIsVisible = input.ConfigColumnIsVisible;
            await _iConfigColumnRepository.UpdateAsync(item);
            return ObjectMapper.Map<ConfigColumn, ConfigColumnDto>(item);
        }

        public async Task Delete(int id)
        {
            await _iConfigColumnRepository.DeleteAsync(id);
        }
    }
}