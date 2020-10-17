using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.DanhMuc.GoiThauDtos;
using xdcb.Common.DanhMuc.LoaiGoiThaus;

namespace xdcb.Common.DanhMuc.GoiThaus
{
    public class LoaiGoiThauAppService :
        CrudAppService<LoaiGoiThau,
            LoaiGoiThauDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateLoaiGoiThauDto, CreateUpdateLoaiGoiThauDto>,
        ILoaiGoiThauAppService
    {
        public LoaiGoiThauAppService(
            IRepository<LoaiGoiThau, Guid> repository) : base(repository)
        {
        }

        public async Task<List<LoaiGoiThauDto>> GetListByIds(List<Guid> ids)
        {
            var items = await Repository.AsQueryable().Where(s => ids.Contains(s.Id) && !s.IsDeleted).ToListAsync();
            return ObjectMapper.Map<List<LoaiGoiThau>, List<LoaiGoiThauDto>>(items);
        }
    }
}