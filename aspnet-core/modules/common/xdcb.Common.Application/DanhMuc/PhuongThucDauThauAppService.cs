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
using xdcb.Common.DanhMuc.PhuongThucDauThauDtos;

namespace xdcb.Common.DanhMuc.PhuongThucDauThaus
{
    public class PhuongThucDauThauAppService :
        CrudAppService<PhuongThucDauThau,
            PhuongThucDauThauDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdatePhuongThucDauThauDto, CreateUpdatePhuongThucDauThauDto>,
        IPhuongThucDauThauAppService
    {
        private readonly IPhuongThucDauThauRepository _phuongThucDauThauRepository;

        public PhuongThucDauThauAppService(
            IPhuongThucDauThauRepository phuongThucDauThauRepository,
            IRepository<PhuongThucDauThau, Guid> repository) : base(repository)
        {
            _phuongThucDauThauRepository = phuongThucDauThauRepository;
        }

        public async Task<List<PhuongThucDauThauDto>> GetListByIdsAsync(List<Guid> ids)
        {
            var items = await _phuongThucDauThauRepository.GetListByIds(ids);
            return ObjectMapper.Map<List<PhuongThucDauThau>, List<PhuongThucDauThauDto>>(items);
        }

        [HttpGet]
        public async Task<PagedResultDto<PhuongThucDauThauDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword);
            PagedResultDto<PhuongThucDauThau> items = await _phuongThucDauThauRepository.SearchAsync(condition);
            return new PagedResultDto<PhuongThucDauThauDto>(items.TotalCount, ObjectMapper.Map<List<PhuongThucDauThau>, List<PhuongThucDauThauDto>>(items.Items.ToList()));
        }

        [HttpGet]
        public async Task<dynamic> ExportAsync()
        {
            var list = await Repository.Where(s => !s.IsDeleted).AsNoTracking().ToListAsync();
            var listReport = list.Select(s => new PhuongThucLuaChonReport
            {
                TenPhuongThucChonNhaThau = s.TenPhuongThucDauThau
            });
            return ReportExcelExtensions.GetFileExcel(listReport, ExcelBorderStyle.Dotted, "Danh mục Phương thức lựa chọn nhà thầu", "PhuongThucLuaChonNhaThau");
        }
    }
}