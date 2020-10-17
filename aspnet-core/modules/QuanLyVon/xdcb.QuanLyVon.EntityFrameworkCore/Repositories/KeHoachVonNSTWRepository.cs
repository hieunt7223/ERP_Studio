using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.QuanLyVon.EntityFrameworkCore;

namespace xdcb.QuanLyVon.KeHoachVonNSTWs
{
	/// <summary>
	/// Generated Repositories for Table : KeHoachVonNSTW.
	/// </summary>
	public class KeHoachVonNSTWRepository : EfCoreRepository<QuanLyVonDbContext, KeHoachVonNSTW, Guid>, IKeHoachVonNSTWRepository
	{
		public KeHoachVonNSTWRepository(IDbContextProvider<QuanLyVonDbContext> dbContextProvider): base(dbContextProvider)
		{
		}
	}
}
