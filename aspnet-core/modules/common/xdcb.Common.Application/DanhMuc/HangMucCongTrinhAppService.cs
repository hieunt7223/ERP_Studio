using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.DanhMuc.HangMucCongTrinhDtos;

namespace xdcb.Common.DanhMuc.HangMucCongTrinhs
{
    public class HangMucCongTrinhAppService :
        CrudAppService<HangMucCongTrinh,
            HangMucCongTrinhDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateHangMucCongTrinhDto, CreateUpdateHangMucCongTrinhDto>,
        IHangMucCongTrinhAppService
    {
        private IHangMucCongTrinhRepository _hangMucCongTrinhRepository;

        public HangMucCongTrinhAppService(
            IHangMucCongTrinhRepository hangMucCongTrinhRepository,
            IRepository<HangMucCongTrinh, Guid> repository) : base(repository)
        {
            _hangMucCongTrinhRepository = hangMucCongTrinhRepository;
        }
        [HttpGet]
        public async Task<PagedResultDto<HangMucCongTrinhDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword);
            PagedResultDto<HangMucCongTrinh> items = await _hangMucCongTrinhRepository.SearchAsync(condition);
            return new PagedResultDto<HangMucCongTrinhDto>(items.TotalCount, ObjectMapper.Map<List<HangMucCongTrinh>, List<HangMucCongTrinhDto>>(items.Items.ToList()));
        }
    }
}