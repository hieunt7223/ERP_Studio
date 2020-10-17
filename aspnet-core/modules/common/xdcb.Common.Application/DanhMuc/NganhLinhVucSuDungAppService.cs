using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.DanhMuc.NganhLinhVucSuDungDtos;

namespace xdcb.Common.DanhMuc.NganhLinhVucSuDungs
{
    public class NganhLinhVucSuDungAppService :
        CrudAppService<NganhLinhVucSuDung,
            NganhLinhVucSuDungDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateNganhLinhVucSuDungDto, CreateUpdateNganhLinhVucSuDungDto>,
        INganhLinhVucSuDungAppService
    {
        public NganhLinhVucSuDungAppService(
            IRepository<NganhLinhVucSuDung, Guid> repository) : base(repository)
        {
        }

        public async Task<List<NganhLinhVucSuDungDto>> GetListByIds(List<Guid> ids)
        {
            var items = await Repository.AsQueryable().Where(s => ids.Contains(s.Id) && !s.IsDeleted).ToListAsync();
            return ObjectMapper.Map<List<NganhLinhVucSuDung>, List<NganhLinhVucSuDungDto>>(items);
        }

        [HttpGet]
        public async Task<PagedResultDto<NganhLinhVucSuDungDto>> SearchAsync(ConditionSearch condition)
        {
            if (string.IsNullOrEmpty(condition.keyword)) return await base.GetListAsync(new PagedAndSortedResultRequestDto());
            var items = await Repository.AsQueryable().Where(s => s.TenNganhLinhVucSuDung.Contains(condition.keyword)).Skip(condition.SkipCount).Take(condition.MaxResultCount).AsNoTracking().ToListAsync();
            var totalCount = await Repository.AsQueryable().Where(s => s.TenNganhLinhVucSuDung.Contains(condition.keyword)).AsNoTracking().CountAsync();
            return new PagedResultDto<NganhLinhVucSuDungDto>(totalCount, ObjectMapper.Map<List<NganhLinhVucSuDung>, List<NganhLinhVucSuDungDto>>(items));
        }
    }
}