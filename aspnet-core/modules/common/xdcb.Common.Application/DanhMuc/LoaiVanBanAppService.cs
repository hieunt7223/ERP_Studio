using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.DanhMuc.LoaiVanBanDtos;

namespace xdcb.Common.DanhMuc.LoaiVanBans
{
    public class LoaiVanBanAppService :
        CrudAppService<LoaiVanBan,
            LoaiVanBanDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateLoaiVanBanDto, CreateUpdateLoaiVanBanDto>,
        ILoaiVanBanAppService
    {
        private readonly ILoaiVanBanRepository _loaiVanBanRepository;

        public LoaiVanBanAppService(
            ILoaiVanBanRepository loaiVanBanRepository,
            IRepository<LoaiVanBan, Guid> repository) : base(repository)
        {
            _loaiVanBanRepository = loaiVanBanRepository;
        }
        [HttpGet]
        public async Task<PagedResultDto<LoaiVanBanDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword);
            PagedResultDto<LoaiVanBan> items = await _loaiVanBanRepository.SearchAsync(condition);
            return new PagedResultDto<LoaiVanBanDto>(items.TotalCount, ObjectMapper.Map<List<LoaiVanBan>, List<LoaiVanBanDto>>(items.Items.ToList()));
        }

        public async Task<IList<LoaiVanBanDto>> GetLoaiVanBanListAsync()
        {
            List<LoaiVanBan> items = await _loaiVanBanRepository.GetList().ToListAsync();
            return ObjectMapper.Map<IList<LoaiVanBan>, IList<LoaiVanBanDto>>(items);
        }
    }
}