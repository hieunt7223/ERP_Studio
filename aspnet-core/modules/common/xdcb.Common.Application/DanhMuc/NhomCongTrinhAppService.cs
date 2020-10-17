using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.DanhMuc.NhomCongTrinhDtos;

namespace xdcb.Common.DanhMuc.NhomCongTrinhs
{
    public class NhomCongTrinhAppService :
        CrudAppService<NhomCongTrinh,
            NhomCongTrinhDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateNhomCongTrinhDto, CreateUpdateNhomCongTrinhDto>,
        INhomCongTrinhAppService
    {
        private readonly INhomCongTrinhRepository _nhomCongTrinhRepository;

        public NhomCongTrinhAppService(
            INhomCongTrinhRepository nhomCongTrinhRepository,
            IRepository<NhomCongTrinh, Guid> repository) : base(repository)
        {
            _nhomCongTrinhRepository = nhomCongTrinhRepository;
        }
      
        [HttpGet]
        public async Task<PagedResultDto<NhomCongTrinhDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword).ToLower();
            PagedResultDto<NhomCongTrinh> items = await _nhomCongTrinhRepository.SearchAsync(condition);
            return new PagedResultDto<NhomCongTrinhDto>(items.TotalCount, ObjectMapper.Map<List<NhomCongTrinh>, List<NhomCongTrinhDto>>(items.Items.ToList()));
        }

        public async Task<List<NhomCongTrinhDto>> GetNhomCongTrinhsAsync()
        {
            var items = await _nhomCongTrinhRepository.GetNhomCongTrinhsAsync();
            return ObjectMapper.Map<List<NhomCongTrinh>, List<NhomCongTrinhDto>>(items);
        }

    }
}