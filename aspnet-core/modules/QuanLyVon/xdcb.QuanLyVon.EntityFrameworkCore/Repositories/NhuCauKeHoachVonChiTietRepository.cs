using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.QuanLyVon.EntityFrameworkCore;

namespace xdcb.QuanLyVon.NhuCauKeHoachVonChiTiets
{
	/// <summary>
	/// Generated Repositories for Table : NhuCauKeHoachVonChiTiet.
	/// </summary>
	public class NhuCauKeHoachVonChiTietRepository : EfCoreRepository<QuanLyVonDbContext, NhuCauKeHoachVonChiTiet, Guid>, INhuCauKeHoachVonChiTietRepository
	{
		public NhuCauKeHoachVonChiTietRepository(IDbContextProvider<QuanLyVonDbContext> dbContextProvider): base(dbContextProvider)
		{
		}
	}
}
