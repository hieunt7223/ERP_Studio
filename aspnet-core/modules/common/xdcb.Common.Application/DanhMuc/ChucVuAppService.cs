using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.DanhMuc.ChucVuDtos;

namespace xdcb.Common.DanhMuc.ChucVus
{
    public class ChucVuAppService :
        CrudAppService<ChucVu,
            ChucVuDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateChucVuDto, CreateUpdateChucVuDto>,
        IChucVuAppService
    {
        private IChucVuRepository _chucVuRepository;

        public ChucVuAppService(
            IChucVuRepository chucVuRepository,
            IRepository<ChucVu, Guid> repository) : base(repository)
        {
            _chucVuRepository = chucVuRepository;
        }
        [HttpGet]
        public async Task<PagedResultDto<ChucVuDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword).ToLower();
            PagedResultDto<ChucVu> items = await _chucVuRepository.SearchAsync(condition);
            return new PagedResultDto<ChucVuDto>(items.TotalCount, ObjectMapper.Map<List<ChucVu>, List<ChucVuDto>>(items.Items.ToList()));
        }
    }
}