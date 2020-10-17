using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.DanhMuc.DoUuTienDtos;
using xdcb.Common.Extensions;

namespace xdcb.Common.DanhMuc.DoUuTiens
{
    public class DoUuTienAppService :
        CrudAppService<DoUuTien,
            DoUuTienDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateDoUuTienDto, CreateUpdateDoUuTienDto>,
        IDoUuTienAppService
    {
        private IDoUuTienRepository _doUuTienRepository;

        public DoUuTienAppService(
            IDoUuTienRepository doUuTienRepository,
            IRepository<DoUuTien, Guid> repository) : base(repository)
        {
            _doUuTienRepository = doUuTienRepository;
        }

        public Dictionary<int, string> GetMaDoUuTiens()
        {
            return Enum.GetValues(typeof(MaDoUuTien))
                       .Cast<MaDoUuTien>()
                       .ToDictionary(t => (int)t, t => t.GetDescription());
        }

        [HttpGet]
        public async Task<PagedResultDto<DoUuTienDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword).ToLower();
            PagedResultDto<DoUuTien> items = await _doUuTienRepository.SearchAsync(condition);
            return new PagedResultDto<DoUuTienDto>(items.TotalCount, ObjectMapper.Map<List<DoUuTien>, List<DoUuTienDto>>(items.Items.ToList()));
        }
    }
}