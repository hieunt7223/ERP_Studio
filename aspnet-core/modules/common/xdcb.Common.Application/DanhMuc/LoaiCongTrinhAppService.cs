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
using xdcb.Common.DanhMuc.LoaiCongTrinhDtos;

namespace xdcb.Common.DanhMuc.LoaiCongTrinhs
{
    public class LoaiCongTrinhAppService :
        CrudAppService<LoaiCongTrinh,
            LoaiCongTrinhDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateLoaiCongTrinhDto, CreateUpdateLoaiCongTrinhDto>,
        ILoaiCongTrinhAppService
    {
        private readonly ILoaiCongTrinhRepository _loaiCongTrinhRepository;

        public LoaiCongTrinhAppService(
            ILoaiCongTrinhRepository loaiCongTrinhRepository,
            IRepository<LoaiCongTrinh, Guid> repository) : base(repository)
        {
            _loaiCongTrinhRepository = loaiCongTrinhRepository;
        }

        public async Task<List<LoaiCongTrinhDto>> GetLoaiCongTrinhsAsync()
        {
            var items = await _loaiCongTrinhRepository.GetLoaiCongTrinhsAsync();
            return ObjectMapper.Map<List<LoaiCongTrinh>, List<LoaiCongTrinhDto>>(items);
        }

        [HttpGet]
        public async Task<PagedResultDto<LoaiCongTrinhDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword).ToLower();
            PagedResultDto<LoaiCongTrinh> items = await _loaiCongTrinhRepository.SearchAsync(condition);
            return new PagedResultDto<LoaiCongTrinhDto>(items.TotalCount, ObjectMapper.Map<List<LoaiCongTrinh>, List<LoaiCongTrinhDto>>(items.Items.ToList()));
        }

        [HttpGet]
        public async Task<dynamic> ReportAsync()
        {
            var list = await Repository.Where(r => !r.IsDeleted).AsNoTracking().ToListAsync();
            var listReport = list.Select(s => new LoaiCongTrinhReportDto
            {
                MaLoaiCongTrinh = s.MaLoaiCongTrinh,
                TenLoaiCongTrinh = s.TenLoaiCongTrinh,
                MoTa = s.MoTa
            });
            return ReportExcelExtensions.GetFileExcel(listReport, ExcelBorderStyle.Dotted, "Danh mục Loại công trình", "LoaiCongTrinh");
        }
    }
}