using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.FormServices.ModuleGroup.Dtos
{
	/// <summary>
	/// Generated Contracts Dto for Table : ModuleGroup.
	/// </summary>
	public class ModuleGroupDto : FullAuditedEntityDto<Guid>
	{
		#region Generated By Column

		public string ModuleGroupNo { get; set; }

		public string ModuleGroupName { get; set; }

		#endregion
	}
}