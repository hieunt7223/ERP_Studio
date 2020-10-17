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
using xdcb.Common.DanhMuc.DonViBanHanhDtos;

namespace xdcb.Common.DanhMuc.DonViBanHanhs
{
    public class DonViBanHanhAppService :
        CrudAppService<DonViBanHanh,
            DonViBanHanhDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateDonViBanHanhDto, CreateUpdateDonViBanHanhDto>,
        IDonViBanHanhAppService
    {
        public DonViBanHanhAppService(
            IRepository<DonViBanHanh, Guid> repository) : base(repository)
        {
        }

        public async Task<List<DonViBanHanhDto>> GetDonViBanHanhsAsync()
        {
            var items = await Repository.AsQueryable().Where(s => !s.IsDeleted).AsNoTracking().ToListAsync();
            return ObjectMapper.Map<List<DonViBanHanh>, List<DonViBanHanhDto>>(items);
        }

        public async Task<List<DonViBanHanhDto>> GetListByIds(List<Guid> ids)
        {
            var items = await Repository.AsQueryable().Where(s => ids.Contains(s.Id) && !s.IsDeleted).AsNoTracking().ToListAsync();
            return ObjectMapper.Map<List<DonViBanHanh>, List<DonViBanHanhDto>>(items);
        }

        public async Task<PagedResultDto<DonViBanHanhDto>> SearchAsync(ConditionSearch condition)
        {
            if (string.IsNullOrEmpty(condition.keyword)) return await base.GetListAsync(new PagedAndSortedResultRequestDto());
            var items = await Repository.AsQueryable().Where(s => s.Ten.Contains(condition.keyword)).Skip(condition.SkipCount).Take(condition.MaxResultCount).AsNoTracking().ToListAsync();
            var totalCount = await Repository.AsQueryable().Where(s => s.Ten.Contains(condition.keyword)).AsNoTracking().CountAsync();
            return new PagedResultDto<DonViBanHanhDto>(totalCount, ObjectMapper.Map<List<DonViBanHanh>, List<DonViBanHanhDto>>(items));
        }

        [HttpGet]
        public async Task<dynamic> ReportAsync()
        {
            var list = await Repository.Where(r => !r.IsDeleted).AsNoTracking().ToListAsync();
            var listReport = list.Select(s => new DonViBanHanhReportDto { Ten = s.Ten });
            return ReportExcelExtensions.GetFileExcel(listReport, ExcelBorderStyle.Dotted, "Danh mục Đơn vị ban hành", "DonViBanHanh");
        }
    }
}