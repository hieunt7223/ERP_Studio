using System;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using xdcb.FormServices.ModuleGroup.Dtos;

namespace xdcb.FormServices.SDK
{
	/// <summary>
	/// Generated ISDK for Table : ModuleGroup.
	/// </summary>
	public interface IModuleGroupsApi
	{
		#region Generated By Column

		[Get("/api/app/ModuleGroup")]
		Task<List<ModuleGroupDto>> GetListAsync();

		[Post("/api/app/ModuleGroup")]
		Task<ModuleGroupDto> Create([Body] CreateUpdateModuleGroupDto info);

		[Get("/api/app/ModuleGroup/{Id}")]
		Task<ModuleGroupDto> GetAsync(Guid Id);

		[Put("/api/app/ModuleGroup/{Id}")]
		Task<ModuleGroupDto> Update(Guid Id, [Body] CreateUpdateModuleGroupDto info);

		[Delete("/api/app/ModuleGroup/{Id}")]
		Task Delete(Guid Id);

		#endregion
	}
}