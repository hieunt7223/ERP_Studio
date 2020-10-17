using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.QuanLyVon.EntityFrameworkCore;

namespace xdcb.QuanLyVon.KeHoachVonNQs
{
	/// <summary>
	/// Generated Repositories for Table : KeHoachVonNQ.
	/// </summary>
	public class KeHoachVonNQRepository : EfCoreRepository<QuanLyVonDbContext, KeHoachVonNQ, Guid>, IKeHoachVonNQRepository
	{
		public KeHoachVonNQRepository(IDbContextProvider<QuanLyVonDbContext> dbContextProvider): base(dbContextProvider)
		{
		}
	}
}
