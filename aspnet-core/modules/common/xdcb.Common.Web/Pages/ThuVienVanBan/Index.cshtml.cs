using System.Collections.Generic;
using System.Threading.Tasks;
using xdcb.Common.DanhMuc.DonViBanHanhDtos;
using xdcb.Common.DanhMuc.DonViBanHanhs;
using xdcb.Common.DanhMuc.LoaiVanBanDtos;
using xdcb.Common.DanhMuc.LoaiVanBans;

namespace xdcb.Common.DanhMuc.ThuVienVanBans
{
    public class IndexModel : Web.Pages.CommonBasePageModel
    {
        public List<LoaiVanBanDto> LoaiVanBanDtos { get; set; }
        public List<DonViBanHanhDto> DonViBanHanhDtos { get; set; }

        private readonly ILoaiVanBanAppService _loaiVanBanAppService;
        private readonly IDonViBanHanhAppService _donViBanHanhAppService;

        public IndexModel(ILoaiVanBanAppService loaiVanBanAppService, IDonViBanHanhAppService donViBanHanhAppService)
        {
            _loaiVanBanAppService = loaiVanBanAppService;
            _donViBanHanhAppService = donViBanHanhAppService;
        }

        public async Task OnGetAsync()
        {
            LoaiVanBanDtos = (List<LoaiVanBanDto>)await _loaiVanBanAppService.GetLoaiVanBanListAsync() ?? new List<LoaiVanBanDto>();
            DonViBanHanhDtos = await _donViBanHanhAppService.GetDonViBanHanhsAsync();
        }
    }
}