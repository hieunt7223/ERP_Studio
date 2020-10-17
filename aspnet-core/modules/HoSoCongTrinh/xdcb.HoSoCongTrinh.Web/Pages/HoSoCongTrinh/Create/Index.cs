using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using xdcb.HoSoCongTrinh.Dtos;
using System;
using xdcb.HoSoCongTrinh.Services;
using Newtonsoft.Json;
using xdcb.Common.DanhMuc.ChuDauTus;
using Volo.Abp.Users;

namespace xdcb.HoSoCongTrinhs.CreateView
{
    public class IndexModel : HoSoCongTrinh.CommonBasePageModel
    {
        public List<ThongTinChungViewModel> ThongTinChungs { get; set; }

        public List<ListHoSoCongTrinhChiTietViewModel> CongTrinhChiTiets { get; set; }

	    public List<TongMucDauTuViewModel> TongMucDauTus { get; set; }

        public List<DiaDiemThucHienViewModel> DiaDiemThucHiens { get; set; }

        public List<ThanhPhanHoSoViewModel> ThanhPhanHoSos { get; set; }

        public List<CoSoPhapLyViewModel> CoSoPhapLys { get; set; }

        public List<KetQuaThamDinhPhapLyDto> KetQuaThamDinhPhapLys { get; set; }

        public List<CongViecThucHienDto> CongViecThucHiens { get; set; }

        public List<CongViecKhongApDungDto> CongViecKhongApDungs { get; set; }

        public List<CongViecThuocKeHoachDto> CongViecThuocKeHoachs { get; set; }

        public List<CongViecChuaDuDieuKienLapKeHoachDto> CongViecChuaDuDieuKienLapKeHoachs { get; set; }

        public List<HoSoCongTrinhChiTietGoiThauDto> GoiThaus { get; set; }

        public List<KetQuaThamDinhViewModel> KetQuaThamDinhs { get; set; }

        public List<IFormFile> FileUploads { get; set; }

        public List<IFormFile> FileKetQuaThamDinhUploads { get; set; }

        public Guid hoSoCTId { get; set; }

        public Guid? ChuDauTuId { get; set; }

        private readonly IHoSoCongTrinhChiTietAppService _hosoCongTrinhChiTietService;
        private readonly IChuDauTuAppService _chuDauTuAppService;
        private readonly ICurrentUser _currentUser;

        public IndexModel(IHoSoCongTrinhChiTietAppService hosoCongTrinhChiTietService, 
                          IChuDauTuAppService chuDauTuAppService,
                          ICurrentUser currentUser)
        {
            _hosoCongTrinhChiTietService = hosoCongTrinhChiTietService;
            _chuDauTuAppService = chuDauTuAppService;
            _currentUser = currentUser;
        }

        public async Task OnGetAsync(Guid? hoSoCongTrinhId, Guid congTrinhId, Guid loaiHoSoId, string thongTinChung)
        {

            hoSoCTId = hoSoCongTrinhId??new Guid();
            // Set values for Thông tin cơ bản
            ThongTinChungViewModel thongTinChungModel = JsonConvert.DeserializeObject<ThongTinChungViewModel>(thongTinChung);
            thongTinChungModel.LoaiHoSoId = loaiHoSoId;

            if (hoSoCongTrinhId != null)
            {
                thongTinChungModel.HoSoCongTrinhId = hoSoCongTrinhId;
            }

            ThongTinChungs = new List<ThongTinChungViewModel>();
            ThongTinChungs.Add(thongTinChungModel);

            Guid? userId = _currentUser.Id;
            if (userId != null)
            {
                ChuDauTuId = await _chuDauTuAppService.CheckChuDauTuAsync((Guid)userId);
            }
            var filter = new HoSoCongTrinhChiTietInput
            {
                HoSoCongTrinhId = hoSoCongTrinhId,
                CongTrinhId = congTrinhId,
                LoaiHoSoId = loaiHoSoId,
                ChuDauTuId = ChuDauTuId
            };
            // Set values for Thông tin chi tiết
            var items = await _hosoCongTrinhChiTietService.GetHoSoCongTrinhChiTietsAsync(filter);
            CongTrinhChiTiets = items;
        }
    }
}
