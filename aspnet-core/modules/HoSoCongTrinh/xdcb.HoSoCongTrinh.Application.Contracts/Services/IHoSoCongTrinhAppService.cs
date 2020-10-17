using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.HoSoCongTrinh.Dtos;

namespace xdcb.HoSoCongTrinh.Services
{
    public interface IHoSoCongTrinhAppService : ICrudAppService<
            HoSoCongTrinhDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateHoSoCongTrinhDto,
            CreateUpdateHoSoCongTrinhDto>
    {
        Task<HoSoCongTrinhListDto<HoSoCongTrinhViewModel>> GetHoSoCongTrinhsAsync(HoSoCongTrinhSearchInput searchInput);

        Task<dynamic> ReportAsync(Guid id);

        bool IsHoSoCongTrinhByCongTrinhId(Guid Id);
    }
}