using System;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using xdcb.QuanLyVon.KeHoachVonNQ.Dtos;

namespace xdcb.FormServices.SDK
{
	/// <summary>
	/// Generated ISDK for Table : KeHoachVonNQ.
	/// </summary>
	public interface IKeHoachVonNQsApi
	{
		#region Generated By Column

		[Get("/api/app/KeHoachVonNQ")]
		Task<List<KeHoachVonNQDto>> GetListAsync();

		[Post("/api/app/KeHoachVonNQ")]
		Task<KeHoachVonNQDto> Create([Body] CreateUpdateKeHoachVonNQDto info);

		[Get("/api/app/KeHoachVonNQ/{Id}")]
		Task<KeHoachVonNQDto> GetAsync(Guid Id);

		[Put("/api/app/KeHoachVonNQ/{Id}")]
		Task<KeHoachVonNQDto> Update(Guid Id, [Body] CreateUpdateKeHoachVonNQDto info);

		[Delete("/api/app/KeHoachVonNQ/{Id}")]
		Task Delete(Guid Id);

		#endregion

		#region Property
		[Get("/api/app/KeHoachVonNQ/searchData")]
		Task<List<KeHoachVonNQDto>> GetSearchData(int nam, string loaikehoach, string trangthai);

		[Put("/api/app/KeHoachVonNQDieuChinh/{id}")]
		Task DeleteKeHoachVonNQDieuChinh(Guid id);
		#endregion
	}
}