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
using xdcb.Common.DanhMuc.ChiPhiDauTuDtos;

namespace xdcb.Common.DanhMuc.ChiPhiDauTus
{
    public class ChiPhiDauTuAppService :
        CrudAppService<ChiPhiDauTu,
            ChiPhiDauTuDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateChiPhiDauTuDto, CreateUpdateChiPhiDauTuDto>,
        IChiPhiDauTuAppService
    {
        private readonly IChiPhiDauTuRepository _chiPhiDauTuRepository;

        public ChiPhiDauTuAppService(
            IChiPhiDauTuRepository chiPhiDauTuRepository,
            IRepository<ChiPhiDauTu, Guid> repository) : base(repository)
        {
            _chiPhiDauTuRepository = chiPhiDauTuRepository;
        }

        public async Task<List<ChiPhiDauTuDto>> GetListByIdsAsync(List<Guid> ids)
        {
            var items = await _chiPhiDauTuRepository.GetListByIdsAsync(ids);
            return ObjectMapper.Map<List<ChiPhiDauTu>, List<ChiPhiDauTuDto>>(items);
        }

        [HttpGet]
        public async Task<PagedResultDto<ChiPhiDauTuDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword);
            PagedResultDto<ChiPhiDauTu> items = await _chiPhiDauTuRepository.SearchAsync(condition);
            return new PagedResultDto<ChiPhiDauTuDto>(items.TotalCount, ObjectMapper.Map<List<ChiPhiDauTu>, List<ChiPhiDauTuDto>>(items.Items.ToList()));
        }

        public async Task<List<ChiPhiDauTuDto>> GetListExcludeIdsAsync(List<Guid> ids)
        {
            var items = await _chiPhiDauTuRepository.GetListExcludeIdsAsync(ids);
            return ObjectMapper.Map<List<ChiPhiDauTu>, List<ChiPhiDauTuDto>>(items);
        }

        public async Task<List<ChiPhiDauTuDto>> GetChiPhisAsync()
        {
            var items = await _chiPhiDauTuRepository.GetListAsync();
            return ObjectMapper.Map<List<ChiPhiDauTu>, List<ChiPhiDauTuDto>>(items);
        }

        [HttpGet]
        public async Task<dynamic> ReportAsync()
        {
            var list = await Repository.Where(r => !r.IsDeleted).AsNoTracking().ToListAsync();
            var listReport = list.Select(s => new ChiPhiDauTuReportDto { TenChiPhi = s.TenChiPhi, LoaiChiPhi = s.LoaiChiPhi });
            return ReportExcelExtensions.GetFileExcel(listReport, ExcelBorderStyle.Dotted, "Danh mục Chi phí đầu tư", "ChiPhiDauTu");
        }
    }
}