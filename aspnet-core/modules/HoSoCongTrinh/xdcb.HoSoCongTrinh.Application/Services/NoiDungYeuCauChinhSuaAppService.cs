using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.HoSoCongTrinh.Dtos;
using xdcb.HoSoCongTrinh.Entities;
using xdcb.HoSoCongTrinh.Repositories;

namespace xdcb.HoSoCongTrinh.Services
{
    public class NoiDungYeuCauChinhSuaAppService :
        CrudAppService<HoSoCongTrinhChiTietNoiDungYeuCau,
            HoSoCongTrinhChiTietNoiDungYeuCauDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateHoSoCongTrinhChiTietNoiDungYeuCauDto, CreateUpdateHoSoCongTrinhChiTietNoiDungYeuCauDto>,
        IHoSoCongTrinhChiTietNoiDungYeuCauAppService
    {
        private readonly INoiDungYeuCauRepository _noiDungYeuCauRepository;

        public NoiDungYeuCauChinhSuaAppService(INoiDungYeuCauRepository noiDungYeuCauRepository) : base(noiDungYeuCauRepository)
        {
            _noiDungYeuCauRepository = noiDungYeuCauRepository;
        }

        public async Task<List<HoSoCongTrinhChiTietNoiDungYeuCauDto>> GetNoiDungYeuCausByIdAsync(Guid hoSoCongTrinhChiTietId)
        {
            var items = await _noiDungYeuCauRepository.GetNoiDungYeuCausByIdAsync(hoSoCongTrinhChiTietId);
            return ObjectMapper.Map<List<HoSoCongTrinhChiTietNoiDungYeuCau>, List<HoSoCongTrinhChiTietNoiDungYeuCauDto>>(items);
        }
    }
}