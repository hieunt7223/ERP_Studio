using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.QuanLyVon.EntityFrameworkCore;

namespace xdcb.QuanLyVon.KeHoachTongNguonChiTiets
{
	/// <summary>
	/// Generated Repositories for Table : KeHoachTongNguonChiTiet.
	/// </summary>
	public class KeHoachTongNguonChiTietRepository : EfCoreRepository<QuanLyVonDbContext, KeHoachTongNguonChiTiet, Guid>, IKeHoachTongNguonChiTietRepository
	{
		public KeHoachTongNguonChiTietRepository(IDbContextProvider<QuanLyVonDbContext> dbContextProvider): base(dbContextProvider)
		{
		}
	}
}
