using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xdcb.FormServices.ModuleGroup.Dtos;

namespace xdcb.FormServices.ModuleGroups
{
	/// <summary>
	/// Generated AppService for Table : ModuleGroup.
	/// </summary>
	public class ModuleGroupAppService :FormServicesAppServiceBase, IModuleGroupAppService
	{
		#region Generated By Column

		private readonly IModuleGroupRepository _iModuleGroupRepository;

		public ModuleGroupAppService(IModuleGroupRepository iModuleGroupRepository)
		{
			_iModuleGroupRepository = iModuleGroupRepository;
		}

		public async Task<List<ModuleGroupDto>> GetListAsync()
		{
			var items = await _iModuleGroupRepository.GetListAsync();
			if (items != null && items.Count > 0)
			{
				    items = items.Where(x => x.IsDeleted == false).ToList();
			}
			return new List<ModuleGroupDto>(ObjectMapper.Map<List<ModuleGroup>, List<ModuleGroupDto>>(items));
		}

		public async Task<ModuleGroupDto> GetAsync(Guid id)
		{
			var items = await _iModuleGroupRepository.GetAsync(id);
			if (items != null && items.IsDeleted==true)
			{
				items = null;
			}
			return ObjectMapper.Map<ModuleGroup, ModuleGroupDto>(items);
		}

		public async Task<ModuleGroupDto> Create(CreateUpdateModuleGroupDto input)
		{
			var item = ObjectMapper.Map<CreateUpdateModuleGroupDto, ModuleGroup>(input);
			var data = await _iModuleGroupRepository.InsertAsync(item,true);
			return ObjectMapper.Map<ModuleGroup, ModuleGroupDto>(data);
		}

		public async Task<ModuleGroupDto> Update(Guid id, CreateUpdateModuleGroupDto input)
		{
			var item = await _iModuleGroupRepository.GetAsync(id);
			if (item != null && item.IsDeleted==false)
			{
			 item.ModuleGroupNo = input.ModuleGroupNo;
			 item.ModuleGroupName = input.ModuleGroupName;
			var data = await _iModuleGroupRepository.UpdateAsync(item, true);
			return ObjectMapper.Map<ModuleGroup, ModuleGroupDto>(data);
			}
		return ObjectMapper.Map<ModuleGroup, ModuleGroupDto>(item);
		}

		public async Task Delete(Guid id)
		{
			var item = await _iModuleGroupRepository.GetAsync(id);
			if (item != null && item.IsDeleted==false)
			{
				item.IsDeleted = true;
				await _iModuleGroupRepository.UpdateAsync(item, true);
			}
		}

		#endregion
	}
}