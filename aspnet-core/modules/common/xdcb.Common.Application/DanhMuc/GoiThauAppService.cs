using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.GoiThauDtos;

namespace xdcb.Common.DanhMuc.GoiThaus
{
    public class GoiThauAppService :
        CrudAppService<GoiThau,
            GoiThauDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateGoiThauDto, CreateUpdateGoiThauDto>,
        IGoiThauAppService
    {
        private readonly IGoiThauRepository _goiThauRepository;

        public GoiThauAppService(
            IGoiThauRepository goiThauRepository) : base(goiThauRepository)
        {
            _goiThauRepository = goiThauRepository;
        }

        public async Task<List<GoiThauDto>> GetGoiThausAsync()
        {
            var items = await Repository.AsQueryable().Where(s => !s.IsDeleted).AsNoTracking().ToListAsync();
            return ObjectMapper.Map<List<GoiThau>, List<GoiThauDto>>(items);
        }

        public async Task<List<GoiThauDto>> GetListByIds(List<Guid> ids)
        {
            var items = await Repository.AsQueryable().Where(s => ids.Contains(s.Id) && !s.IsDeleted).AsNoTracking().ToListAsync();
            return ObjectMapper.Map<List<GoiThau>, List<GoiThauDto>>(items);
        }

        public async Task<List<GoiThauDto>> GetListChildAsync(List<Guid> ids)
        {
            var items = await Repository.AsQueryable().Where(s => s.GoiThauParentId != null && !s.IsDeleted).AsNoTracking().ToListAsync();
            var filterItems = items.Where(s => !ids.Contains(s.Id)).ToList();
            return ObjectMapper.Map<List<GoiThau>, List<GoiThauDto>>(filterItems);
        }

        public async Task<List<GoiThauDto>> GetListChildByCriteriaAsync(Guid parentId, List<Guid> childIds)
        {
            var items = await Repository.AsQueryable().Where(s => s.GoiThauParentId == parentId && !s.IsDeleted).AsNoTracking().ToListAsync();
            var filterItems = items.Where(s => !childIds.Contains(s.Id)).ToList();
            return ObjectMapper.Map<List<GoiThau>, List<GoiThauDto>>(filterItems);
        }

        public async Task<List<GoiThauDto>> GetListParentAsync()
        {
            var items = await Repository.AsQueryable().Where(s => s.GoiThauParentId == null && !s.IsDeleted).AsNoTracking().ToListAsync();
            return ObjectMapper.Map<List<GoiThau>, List<GoiThauDto>>(items);
        }

        public override async Task DeleteAsync(Guid id)
        {
            await _goiThauRepository.DeleteByParentIdAsync(id);
        }

        [HttpGet]
        public async Task<List<GoiThauDto>> SearchAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return await GetGoiThausAsync();
            var items = await Repository.AsQueryable().Where(s => s.TenGoiThau.Contains(name) && !s.IsDeleted).AsNoTracking().ToListAsync();
            var goiThauDtos = ObjectMapper.Map<List<GoiThau>, List<GoiThauDto>>(items);
            var listParentId = new List<Guid>();
            var listId = items.Select(s => s.Id);

            foreach (var item in goiThauDtos)
            {
                if (item.GoiThauParentId != null)
                {
                    if (listId.Any(s => s == (Guid)item.GoiThauParentId))
                    {
                        continue;
                    }
                    listParentId.Add((Guid)item.GoiThauParentId);
                }
            }
            var parentItems = await GetListByIds(listParentId);
            var result = goiThauDtos.Union(parentItems);
            return result.ToList();
        }
    }
}