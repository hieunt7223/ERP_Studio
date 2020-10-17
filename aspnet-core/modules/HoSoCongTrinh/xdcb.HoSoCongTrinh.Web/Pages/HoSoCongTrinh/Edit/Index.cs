using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using xdcb.HoSoCongTrinh.Dtos;
using System;
using xdcb.HoSoCongTrinh.Services;
using Newtonsoft.Json;
using xdcb.Common.DanhMuc.ChuDauTus;
using Volo.Abp.Users;

namespace xdcb.HoSoCongTrinhs.EditView
{
    public class IndexModel : HoSoCongTrinh.CommonBasePageModel
    {
        public List<ThongTinChungViewModel> ThongTinChungs { get; set; }

        public List<ListHoSoCongTrinhChiTietViewModel> CongTrinhChiTiets { get; set; }

        public List<TongMucDauTuViewModel> TongMucDauTus { get; set; }

        public List<DiaDiemThucHienViewModel> DiaDiemThucHiens { get; set; }

        public List<ThanhPhanHoSoViewModel> ThanhPhanHoSos { get; set; }

        public List<CoSoPhapLyViewModel> CoSoPhapLys { get; set; }

        public List<KetQuaThamDinhViewModel> KetQuaThamDinhs { get; set; }

        public List<IFormFile> FileUploads { get; set; }
        public List<IFormFile> FileKetQuaThamDinhUploadsEdit { get; set; }
        public Guid hoSoCTId { get; set; }

        public readonly IHoSoCongTrinhChiTietAppService _hoSoCongTrinhChiTietAppService;

        public IndexModel(IHoSoCongTrinhChiTietAppService hoSoCongTrinhChiTietAppService)
        {
            _hoSoCongTrinhChiTietAppService = hoSoCongTrinhChiTietAppService;
        }

        public async Task OnGetAsync(Guid hoSoCongTrinhId, Guid congTrinhId, string thongTinChung)
        {
            hoSoCTId = hoSoCongTrinhId;
            var filter = new HoSoCongTrinhChiTietInput
            {
                HoSoCongTrinhId = hoSoCongTrinhId,
                CongTrinhId = congTrinhId
            };
            ThongTinChungViewModel thongTinChungModel = JsonConvert.DeserializeObject<ThongTinChungViewModel>(thongTinChung);
            thongTinChungModel.HoSoCongTrinhId = hoSoCongTrinhId;
            ThongTinChungs = new List<ThongTinChungViewModel>();
            ThongTinChungs.Add(thongTinChungModel);
            CongTrinhChiTiets = await _hoSoCongTrinhChiTietAppService.GetHoSoCongTrinhChiTietsAsync(filter)??new List<ListHoSoCongTrinhChiTietViewModel>();
        }
    }
}
