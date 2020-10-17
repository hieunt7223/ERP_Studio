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
using xdcb.Common.DanhMuc.PhongBanDtos;

namespace xdcb.Common.DanhMuc.PhongBans
{
    public class PhongBanAppService :
        CrudAppService<PhongBan,
            PhongBanDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdatePhongBanDto, CreateUpdatePhongBanDto>,
        IPhongBanAppService
    {
        private readonly IPhongBanRepository _phongBanRepository;

        public PhongBanAppService(
            IPhongBanRepository phongBanRepository,
            IRepository<PhongBan, Guid> repository) : base(repository)
        {
            _phongBanRepository = phongBanRepository;
        }

        [HttpGet]
        public async Task<PagedResultDto<PhongBanDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword);
            PagedResultDto<PhongBan> items = await _phongBanRepository.SearchAsync(condition);
            return new PagedResultDto<PhongBanDto>(items.TotalCount, ObjectMapper.Map<List<PhongBan>, List<PhongBanDto>>(items.Items.ToList()));
        }

        [HttpGet]
        public async Task<dynamic> ExportAsync()
        {
            var list = await Repository.Where(s => !s.IsDeleted).AsNoTracking().ToListAsync();
            var phongBanReports = list.Select(s => new PhongBanReport
            {
                TenPhongBan = s.TenPhongBan,
                MaPhongBan = s.MaPhongBan,
                SoDienThoai = s.SoDienThoai
            });
            return ReportExcelExtensions.GetFileExcel(phongBanReports, ExcelBorderStyle.Dotted, "Danh mục Phòng ban", "PhongBan");
        }
    }
}