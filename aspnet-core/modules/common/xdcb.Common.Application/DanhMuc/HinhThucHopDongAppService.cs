using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.DanhMuc.HinhThucHopDongDtos;

namespace xdcb.Common.DanhMuc.HinhThucHopDongs
{
    public class HinhThucHopDongAppService :
        CrudAppService<HinhThucHopDong,
            HinhThucHopDongDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateHinhThucHopDongDto, CreateUpdateHinhThucHopDongDto>,
        IHinhThucHopDongAppService
    {
        private IHinhThucHopDongRepository _hinhThucHopDongRepository;

        public HinhThucHopDongAppService(
            IHinhThucHopDongRepository hinhThucHopDongRepository,
            IRepository<HinhThucHopDong, Guid> repository) : base(repository)
        {
            _hinhThucHopDongRepository = hinhThucHopDongRepository;
        }

        public async Task<List<HinhThucHopDongDto>> GetListByIdsAsync(List<Guid> ids)
        {
            var items = await _hinhThucHopDongRepository.GetListByIdsAsync(ids);
            return ObjectMapper.Map<List<HinhThucHopDong>, List<HinhThucHopDongDto>>(items);
        }

        [HttpGet]
        public bool IsNameExist(string name, Guid id)
        {
            return _hinhThucHopDongRepository.IsNameExist(name, id);
        }

        [HttpGet]
        public async Task<PagedResultDto<HinhThucHopDongDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword);
            PagedResultDto<HinhThucHopDong> items = await _hinhThucHopDongRepository.SearchAsync(condition);
            return new PagedResultDto<HinhThucHopDongDto>(items.TotalCount, ObjectMapper.Map<List<HinhThucHopDong>, List<HinhThucHopDongDto>>(items.Items.ToList()));
        }
    }
}