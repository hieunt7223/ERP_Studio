using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.FormServices.EntityFrameworkCore;

namespace xdcb.FormServices.ModuleGroups
{
	/// <summary>
	/// Generated Repositories for Table : ModuleGroup.
	/// </summary>
	public class ModuleGroupRepository : EfCoreRepository<FormServicesDbContext, ModuleGroup, Guid>, IModuleGroupRepository
	{
		public ModuleGroupRepository(IDbContextProvider<FormServicesDbContext> dbContextProvider): base(dbContextProvider)
		{
		}
	}
}
