﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using xdcb.QuanLyVon.KeHoachVonNST.Dtos;

namespace xdcb.QuanLyVon.KeHoachVonNSTs
{
    public interface IKeHoachVonNSTAppService : IApplicationService
    {
		#region Generated By Column

		Task<List<KeHoachVonNSTDto>> GetListAsync();

		Task<KeHoachVonNSTDto> GetAsync(Guid id);

		Task<KeHoachVonNSTDto> Create(CreateUpdateKeHoachVonNSTDto input);

		Task<KeHoachVonNSTDto> Update(Guid id, CreateUpdateKeHoachVonNSTDto input);

		Task Delete(Guid id);

		#endregion

		#region Property
		Task<List<KeHoachVonNSTDto>> GetSearchData(int nam, string loaikehoach, string trangthai);
		Task DeleteKeHoachVonNSTDieuChinh(Guid id);
		#endregion
	}
}
