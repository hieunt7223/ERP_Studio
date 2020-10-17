using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.QuanLyVon.EntityFrameworkCore;

namespace xdcb.QuanLyVon.KeHoachTongNguons
{
	/// <summary>
	/// Generated Repositories for Table : KeHoachTongNguon.
	/// </summary>
	public class KeHoachTongNguonRepository : EfCoreRepository<QuanLyVonDbContext, KeHoachTongNguon, Guid>, IKeHoachTongNguonRepository
	{
		public KeHoachTongNguonRepository(IDbContextProvider<QuanLyVonDbContext> dbContextProvider): base(dbContextProvider)
		{
		}
	}
}
