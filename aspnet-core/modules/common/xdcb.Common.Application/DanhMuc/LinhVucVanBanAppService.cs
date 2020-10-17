using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.DanhMuc.LinhVucVanBanDtos;

namespace xdcb.Common.DanhMuc.LinhVucVanBans
{
    public class LinhVucVanBanAppService :
        CrudAppService<LinhVucVanBan,
            LinhVucVanBanDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateLinhVucVanBanDto, CreateUpdateLinhVucVanBanDto>,
        ILinhVucVanBanAppService
    {
        private readonly ILinhVucVanBanRepository _linhVucVanBanRepository;

        public LinhVucVanBanAppService(
            ILinhVucVanBanRepository linhVucVanBanRepository,
            IRepository<LinhVucVanBan, Guid> repository) : base(repository)
        {
            _linhVucVanBanRepository = linhVucVanBanRepository;
        }
        [HttpGet]
        public async Task<PagedResultDto<LinhVucVanBanDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword);
            PagedResultDto<LinhVucVanBan> items = await _linhVucVanBanRepository.SearchAsync(condition);
            return new PagedResultDto<LinhVucVanBanDto>(items.TotalCount, ObjectMapper.Map<List<LinhVucVanBan>, List<LinhVucVanBanDto>>(items.Items.ToList()));
        }
        public async Task<IList<LinhVucVanBanDto>> GetLinhVucVanBanListAsync()
        {
            List<LinhVucVanBan> items = (List<LinhVucVanBan>)await _linhVucVanBanRepository.GetListAsync();
            return ObjectMapper.Map<IList<LinhVucVanBan>, IList<LinhVucVanBanDto>>(items);
        }
    }
}