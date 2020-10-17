using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using xdcb.QuanLyVon.KeHoachVonNSTW.Dtos;

namespace xdcb.QuanLyVon.KeHoachVonNSTWs
{
	/// <summary>
	/// Generated IAppService for Table : KeHoachVonNSTW.
	/// </summary>
	public interface IKeHoachVonNSTWAppService : IApplicationService
	{
		#region Generated By Column

		Task<List<KeHoachVonNSTWDto>> GetListAsync();

		Task<KeHoachVonNSTWDto> GetAsync(Guid id);

		Task<KeHoachVonNSTWDto> Create(CreateUpdateKeHoachVonNSTWDto input);

		Task<KeHoachVonNSTWDto> Update(Guid id, CreateUpdateKeHoachVonNSTWDto input);

		Task Delete(Guid id);

		#endregion

		#region Property
		Task<List<KeHoachVonNSTWDto>> GetSearchData(int nam, string loaikehoach, string trangthai);
		Task DeleteKeHoachVonNSTWDieuChinh(Guid id);
		#endregion
	}
}