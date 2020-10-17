using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.Application.Extensions;
using xdcb.Common.DanhMuc.HinhThucChonNhaThauDtos;

namespace xdcb.Common.DanhMuc.HinhThucChonNhaThaus
{
    public class HinhThucChonNhaThauAppService :
        CrudAppService<HinhThucChonNhaThau,
            HinhThucChonNhaThauDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateHinhThucChonNhaThauDto, CreateUpdateHinhThucChonNhaThauDto>,
        IHinhThucChonNhaThauAppService
    {
        private readonly IHinhThucChonNhaThauRepository _hinhThucChonNhaThauRepository;

        public HinhThucChonNhaThauAppService(
            IHinhThucChonNhaThauRepository hinhThucChonNhaThauRepository,
            IRepository<HinhThucChonNhaThau, Guid> repository) : base(repository)
        {
            _hinhThucChonNhaThauRepository = hinhThucChonNhaThauRepository;
        }

        public async Task<List<HinhThucChonNhaThauDto>> GetListByIdsAsync(List<Guid> ids)
        {
            var items = await _hinhThucChonNhaThauRepository.GetListByIdsAsync(ids);
            return ObjectMapper.Map<List<HinhThucChonNhaThau>, List<HinhThucChonNhaThauDto>>(items);
        }

        [HttpGet]
        public async Task<PagedResultDto<HinhThucChonNhaThauDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword);
            PagedResultDto<HinhThucChonNhaThau> items = await _hinhThucChonNhaThauRepository.SearchAsync(condition);
            return new PagedResultDto<HinhThucChonNhaThauDto>(items.TotalCount, ObjectMapper.Map<List<HinhThucChonNhaThau>, List<HinhThucChonNhaThauDto>>(items.Items.ToList()));
        }

        [HttpGet]
        public async Task<dynamic> ExportAsync()
        {
            var list = await Repository.Where(s => !s.IsDeleted).AsNoTracking().ToListAsync();
            var listReport = list.Select(s => new HinhThucChonNhaThauReport { TenHinhThucChonNhaThau = s.TenHinhThucChonNhaThau });
            return ReportExcelExtensions.GetFileExcel(listReport, ExcelBorderStyle.Dotted, "Danh mục Hình thức lựa chọn nhà thầu", "HinhThucLuaChonNhaThau");
        }
    }
}