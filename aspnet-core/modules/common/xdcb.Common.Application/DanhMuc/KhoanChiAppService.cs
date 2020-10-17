using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.DanhMuc.KhoanChiDtos;

namespace xdcb.Common.DanhMuc.KhoanChis
{
    public class KhoanChiAppService :
        CrudAppService<KhoanChi,
            KhoanChiDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateKhoanChiDto, CreateUpdateKhoanChiDto>,
        IKhoanChiAppService
    {
        private readonly IKhoanChiRepository _khoanChiRepository;

        public KhoanChiAppService(
            IKhoanChiRepository khoanChiRepository,
            IRepository<KhoanChi, Guid> repository) : base(repository)
        {
            _khoanChiRepository = khoanChiRepository;
        }
        [HttpGet]
        public async Task<PagedResultDto<KhoanChiDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword);
            PagedResultDto<KhoanChi> items = await _khoanChiRepository.SearchAsync(condition);
            return new PagedResultDto<KhoanChiDto>(items.TotalCount, ObjectMapper.Map<List<KhoanChi>, List<KhoanChiDto>>(items.Items.ToList()));
        }
    }
}