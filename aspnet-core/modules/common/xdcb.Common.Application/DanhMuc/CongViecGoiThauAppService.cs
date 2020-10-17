using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.DanhMuc.CongViecGoiThauDtos;

namespace xdcb.Common.DanhMuc.CongViecGoiThaus
{
    public class CongViecGoiThauAppService :
        CrudAppService<CongViecGoiThau,
            CongViecGoiThauDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateCongViecGoiThauDto, CreateUpdateCongViecGoiThauDto>,
        ICongViecGoiThauAppService
    {
        public CongViecGoiThauAppService(
            IRepository<CongViecGoiThau, Guid> repository) : base(repository)
        {
        }

        public async Task<List<CongViecGoiThauDto>> GetListByIds(List<Guid> ids)
        {
            var items = await Repository.AsQueryable().Where(s => ids.Contains(s.Id) && !s.IsDeleted).ToListAsync();
            return ObjectMapper.Map<List<CongViecGoiThau>, List<CongViecGoiThauDto>>(items);
        }
    }
}