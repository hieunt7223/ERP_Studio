using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace xdcb.QuanLyVon.KeHoachVonNSTWChiTiets
{
	/// <summary>
	/// Generated Domain Repositories for Table : KeHoachVonNSTWChiTiet.
	/// </summary>
	public interface IKeHoachVonNSTWChiTietRepository : IBasicRepository<KeHoachVonNSTWChiTiet, Guid>
	{
		Task<List<KeHoachVonNSTWChiTiet>> GetDataLuyKeByNam(int nam);
	}
}
