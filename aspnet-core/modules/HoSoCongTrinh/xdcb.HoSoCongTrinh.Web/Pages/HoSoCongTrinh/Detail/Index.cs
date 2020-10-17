using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xdcb.HoSoCongTrinh.Dtos;
using xdcb.HoSoCongTrinh.Services;

namespace xdcb.HoSoCongTrinhs.DetailView
{
    public class IndexModel : HoSoCongTrinh.CommonBasePageModel
    {
        public List<ThongTinChungViewModel> ThongTinChungs { get; set; }

        public List<ListHoSoCongTrinhChiTietViewModel> CongTrinhChiTiets { get; set; }

        private readonly IHoSoCongTrinhChiTietAppService _hoSoCongTrinhChiTietAppService;

        public IndexModel(IHoSoCongTrinhChiTietAppService hoSoCongTrinhChiTietAppService)
        {
            _hoSoCongTrinhChiTietAppService = hoSoCongTrinhChiTietAppService;
        }

        public async Task OnGetAsync(Guid hoSoCongTrinhId, Guid congTrinhId, string thongTinChung)
        {
            var thongTinChungModel = JsonConvert.DeserializeObject<ThongTinChungViewModel>(thongTinChung);
            ThongTinChungs = new List<ThongTinChungViewModel>();
            ThongTinChungs.Add(thongTinChungModel);
            thongTinChungModel.HoSoCongTrinhId = hoSoCongTrinhId;

            var filter = new HoSoCongTrinhChiTietInput()
            {
                HoSoCongTrinhId = hoSoCongTrinhId,
                CongTrinhId = congTrinhId,
            };
            var hoSoCongTrinhChiTiets = await _hoSoCongTrinhChiTietAppService.GetHoSoCongTrinhChiTietsAsync(filter);
            CongTrinhChiTiets = hoSoCongTrinhChiTiets;
        }
    }
}