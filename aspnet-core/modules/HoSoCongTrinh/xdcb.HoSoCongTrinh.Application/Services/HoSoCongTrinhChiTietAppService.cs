using MarkdownSharp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Authorization;
using Volo.Abp.Identity;
using Volo.Abp.Users;
using xdcb.Common.DanhMuc.ChiPhiDauTuDtos;
using xdcb.Common.DanhMuc.ChiPhiDauTus;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using xdcb.Common.DanhMuc.ChuDauTus;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using xdcb.Common.DanhMuc.CongTrinhs;
using xdcb.Common.DanhMuc.DonViBanHanhDtos;
using xdcb.Common.DanhMuc.DonViBanHanhs;
using xdcb.Common.DanhMuc.DonViHanhChinhDtos;
using xdcb.Common.DanhMuc.DonViHanhChinhs;
using xdcb.Common.DanhMuc.GoiThauDtos;
using xdcb.Common.DanhMuc.GoiThaus;
using xdcb.Common.DanhMuc.HinhThucChonNhaThauDtos;
using xdcb.Common.DanhMuc.HinhThucChonNhaThaus;
using xdcb.Common.DanhMuc.HinhThucHopDongDtos;
using xdcb.Common.DanhMuc.HinhThucHopDongs;
using xdcb.Common.DanhMuc.LoaiHoSoChiPhiDauTuDtos;
using xdcb.Common.DanhMuc.LoaiHoSoCoSoPhapLyDtos;
using xdcb.Common.DanhMuc.LoaiHoSoDtos;
using xdcb.Common.DanhMuc.LoaiHoSos;
using xdcb.Common.DanhMuc.LoaiHoSoThanhPhanHoSoDtos;
using xdcb.Common.DanhMuc.NganhLinhVucSuDungDtos;
using xdcb.Common.DanhMuc.NganhLinhVucSuDungs;
using xdcb.Common.DanhMuc.NguonVonDtos;
using xdcb.Common.DanhMuc.NguonVons;
using xdcb.Common.DanhMuc.PhuongThucDauThaus;
using xdcb.Common.DanhMuc.ThanhPhanHoSoDtos;
using xdcb.Common.DanhMuc.ThanhPhanHoSos;
using xdcb.Common.DanhMuc.ThuVienVanBanDtos;
using xdcb.Common.DanhMuc.ThuVienVanBans;
using xdcb.FileService.DocumentStoreDtos;
using xdcb.FileService.DocumentStores;
using xdcb.HoSoCongTrinh.Constants;
using xdcb.HoSoCongTrinh.Dtos;
using xdcb.HoSoCongTrinh.Entities;
using xdcb.HoSoCongTrinh.Enums;
using xdcb.HoSoCongTrinh.Extensions;
using xdcb.HoSoCongTrinh.Permissions;
using xdcb.HoSoCongTrinh.Repositories;

namespace xdcb.HoSoCongTrinh.Services
{
    public partial class HoSoCongTrinhChiTietAppService : HoSoCongTrinhAppServiceBase, IHoSoCongTrinhChiTietAppService
    {
        #region repository & services

        private readonly IHoSoCongTrinhRepository _hoSoCongTrinhRepository;

        // services
        private readonly ICongTrinhAppService _congTrinhAppService;

        private readonly ILoaiHoSoAppService _loaiHoSoAppService;
        private readonly IDonViHanhChinhAppService _donViHanhChinhAppService;
        private readonly IChiPhiDauTuAppService _chiPhiDauTuAppService;
        private readonly IThanhPhanHoSoAppService _thanhPhanHoSoAppService;
        private readonly IThuVienVanBanAppService _thuVienVanBanAppService;
        private readonly IDocumentStoreAppService _documentStoreAppService;
        private readonly INguonVonAppService _nguonVonAppService;
        private readonly INganhLinhVucSuDungAppService _nganhLinhVucSuDungAppService;
        private readonly IChuDauTuAppService _chuDauTuAppService;
        private readonly IDonViBanHanhAppService _donViBanHanhAppService;
        private readonly IGoiThauAppService _goiThauAppServices;
        private readonly IHinhThucChonNhaThauAppService _hinhThucChonNhaThauAppService;
        private readonly IPhuongThucDauThauAppService _phuongThucChonNhaThauAppService;
        private readonly IHinhThucHopDongAppService _loaiHopDongAppService;
        private readonly IAuthorizationService _authorization;
        private readonly ICurrentUser _currentUser;
        private readonly IdentityUserManager _userManager;
        private readonly Markdown _markdown;

        #endregion repository & services

        #region constructor

        public HoSoCongTrinhChiTietAppService(
            IHoSoCongTrinhRepository hoSoCongTrinhRepository,
            ICongTrinhAppService congTrinhAppService,
            ILoaiHoSoAppService loaiHoSoAppService,
            IDonViHanhChinhAppService donViHanhChinhAppService,
            IChiPhiDauTuAppService chiPhiDauTuAppService,
            IThanhPhanHoSoAppService thanhPhanHoSoAppService,
            IThuVienVanBanAppService thuVienVanBanAppService,
            IDocumentStoreAppService documentStoreAppService,
            INguonVonAppService nguonVonAppService,
            INganhLinhVucSuDungAppService nganhLinhVucSuDungAppService,
            IChuDauTuAppService chuDauTuAppService,
            IDonViBanHanhAppService donViBanHanhAppService,
            IGoiThauAppService goiThauAppServices,
            IHinhThucChonNhaThauAppService hinhThucChonNhaThauAppService,
            IPhuongThucDauThauAppService phuongThucChonNhaThauAppService,
            IHinhThucHopDongAppService loaiHopDongAppService,
            IAuthorizationService authorization,
            ICurrentUser currentUser,
            IdentityUserManager userManager
            )
        {
            _hoSoCongTrinhRepository = hoSoCongTrinhRepository;
            _congTrinhAppService = congTrinhAppService;
            _loaiHoSoAppService = loaiHoSoAppService;
            _donViHanhChinhAppService = donViHanhChinhAppService;
            _chiPhiDauTuAppService = chiPhiDauTuAppService;
            _thanhPhanHoSoAppService = thanhPhanHoSoAppService;
            _thuVienVanBanAppService = thuVienVanBanAppService;
            _documentStoreAppService = documentStoreAppService;
            _nguonVonAppService = nguonVonAppService;
            _nganhLinhVucSuDungAppService = nganhLinhVucSuDungAppService;
            _chuDauTuAppService = chuDauTuAppService;
            _donViBanHanhAppService = donViBanHanhAppService;
            _goiThauAppServices = goiThauAppServices;
            _hinhThucChonNhaThauAppService = hinhThucChonNhaThauAppService;
            _phuongThucChonNhaThauAppService = phuongThucChonNhaThauAppService;
            _loaiHopDongAppService = loaiHopDongAppService;
            _authorization = authorization;
            _currentUser = currentUser;
            _userManager = userManager;
            _markdown = new Markdown();
        }

        #endregion constructor

        /// <summary>
        /// Trường hợp add LoaiHoId !=null, công trình id != null
        /// Trường hợp update,view HoSoCongTrinhId != null, CongTrinhId != null
        /// TODO refactor
        /// refactor giảm số lần query database ở
        /// địa điểm xây dựng, thành phần hồ sơ,
        /// cơ sở pháp lý, chi phí đầu tư
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<List<ListHoSoCongTrinhChiTietViewModel>> GetHoSoCongTrinhChiTietsAsync(HoSoCongTrinhChiTietInput input)
        {
            var permission = await _authorization.IsGrantedAsync(HoSoCongTrinhPermissions.Read);
            if (!permission) throw new AbpAuthorizationException(HoSoConstants.Messages.MSG_NotPermission);
            var hoSoCongTrinhs = await _hoSoCongTrinhRepository.GetListAsyncByCongTrinhId(input.CongTrinhId);
            var thanhPhanHoSoIds = new List<Guid>();
            var thuVienVanBanIds = new List<Guid>();
            var donViHanhChinhIds = new List<Guid>();
            var nguonVonIds = new List<Guid>();
            var nganhLinhVucSuDungIds = new List<Guid>();
            var chuDauTuIds = new List<Guid>();
            var donViBanHanhIds = new List<Guid>();
            var congViecGoiThauIds = new List<Guid>();
            var phuongThucLuaChonNhaThauIds = new List<Guid>();
            var hinhThucLuaChonNhaThauIds = new List<Guid>();
            var loaiHopDongIds = new List<Guid>();

            CongTrinhDto newCongTrinhDto = null;
            LoaiHoSoDto newLoaiHoSoDto = null;

            if (input.LoaiHoSoId != null)
            {
                newCongTrinhDto = await _congTrinhAppService.GetCongTrinhByIdAsync(input.CongTrinhId);
                newLoaiHoSoDto = await _loaiHoSoAppService.GetLoaiHoSoByIdAsync((Guid)input.LoaiHoSoId);
                donViHanhChinhIds.AddRange(newCongTrinhDto.DiaDiemXayDungs.Select(s => s.DonViHanhChinhId));
                thanhPhanHoSoIds.AddRange(newLoaiHoSoDto.LoaiHoSoThanhPhanHoSos.Select(s => s.ThanhPhanHoSoId));
                thuVienVanBanIds.AddRange(newLoaiHoSoDto.LoaiHoSoCoSoPhapLys.Select(s => s.ThuVienVanBanId));
            }

            var diaDiemXayDungs = hoSoCongTrinhs.SelectMany(s => s.HoSoCongTrinhChiTiets).SelectMany(s => s.HoSoCongTrinhChiTietDiaDiems).ToList();
            var thanhPhanHoSos = hoSoCongTrinhs.SelectMany(s => s.HoSoCongTrinhChiTiets).SelectMany(s => s.HoSoCongTrinhChiTietThanhPhanHoSos).ToList();
            var coSoPhapLys = hoSoCongTrinhs.SelectMany(s => s.HoSoCongTrinhChiTiets).SelectMany(s => s.HoSoCongTrinhChiTietCoSoPhapLys).ToList();
            var ketQuaThamDinhs = hoSoCongTrinhs.SelectMany(s => s.HoSoCongTrinhChiTiets).SelectMany(s => s.HoSoCongTrinhChiTietKetQuaThamDinhs).ToList();
            var nguonVons = hoSoCongTrinhs.SelectMany(s => s.HoSoCongTrinhChiTiets).SelectMany(s => s.HoSoCongTrinhChiTietNguonVons).ToList();
            var goiThauCongViecs = hoSoCongTrinhs.SelectMany(s => s.HoSoCongTrinhChiTiets).SelectMany(s => s.HoSoCongTrinhChiTietCongViecs).ToList();
            var goiThaus = hoSoCongTrinhs.SelectMany(s => s.HoSoCongTrinhChiTiets).SelectMany(s => s.HoSoCongTrinhChiTietGoiThaus);
            thanhPhanHoSoIds.AddRange(thanhPhanHoSos.Select(s => s.ThanhPhanHoSoId));
            donViBanHanhIds.AddRange(thanhPhanHoSos.Where(s => s.DonViBanHanhId != null).Select(s => (Guid)s.DonViBanHanhId));
            thuVienVanBanIds.AddRange(coSoPhapLys.Where(s => s.ThuVienVanBanId != null).Select(s => (Guid)s.ThuVienVanBanId));
            donViHanhChinhIds.AddRange(diaDiemXayDungs.Select(s => s.DonViHanhChinhId));
            nguonVonIds.AddRange(nguonVons.Select(s => s.NguonVonId));
            nganhLinhVucSuDungIds.AddRange(hoSoCongTrinhs.SelectMany(s => s.HoSoCongTrinhChiTiets).Where(s => s.NganhLinhVucSuDungId != null).Select(s => (Guid)s.NganhLinhVucSuDungId).ToList());
            chuDauTuIds.AddRange(hoSoCongTrinhs.SelectMany(s => s.HoSoCongTrinhChiTiets).Where(s => s.DonViChuTriThamDinhId != null).Select(s => (Guid)s.DonViChuTriThamDinhId).ToList());
            chuDauTuIds.AddRange(hoSoCongTrinhs.SelectMany(s => s.HoSoCongTrinhChiTiets).Where(s => s.DonViChuTriThamDinhId != null).Select(s => (Guid)s.CapQuyetDinhChuTruongDauTu).ToList());
            chuDauTuIds.AddRange(hoSoCongTrinhs.SelectMany(s => s.HoSoCongTrinhChiTiets).Where(s => s.DonViChuTriThamDinhId != null).Select(s => (Guid)s.CapQuyetDinhDauTuDuAn).ToList());
            chuDauTuIds.AddRange(thanhPhanHoSos.Where(s => s.DonViBanHanhId != null).Select(s => (Guid)s.DonViBanHanhId).ToList());
            var donViPhoiHopJsons = hoSoCongTrinhs.SelectMany(s => s.HoSoCongTrinhChiTiets).Where(s => s.DonViPhoiHopThamDinhs != null).Select(s => s.DonViPhoiHopThamDinhs);
            foreach (var item in donViPhoiHopJsons)
            {
                try
                {
                    chuDauTuIds.AddRange(JsonConvert.DeserializeObject<List<CapQuyetDinhThamDinhDto>>(item).Select(s => s.Id));
                }
                catch (Exception)
                {
                    continue;
                }
            }
            // công việc thực hiện
            congViecGoiThauIds.AddRange(goiThauCongViecs.Where(s => s.CongViecGoiThauId != null).Select(s => (Guid)s.CongViecGoiThauId));
            congViecGoiThauIds.AddRange(goiThaus.Where(s => s.GoiThauId != null).Select(s => (Guid)s.GoiThauId));
            phuongThucLuaChonNhaThauIds.AddRange(goiThaus.Where(s => s.PhuongThucLuaChonNhaThauId != null).Select(s => (Guid)s.PhuongThucLuaChonNhaThauId));
            hinhThucLuaChonNhaThauIds.AddRange(goiThaus.Where(s => s.HinhThucLuaChonNhaThauId != null).Select(s => (Guid)s.HinhThucLuaChonNhaThauId));
            loaiHopDongIds.AddRange(goiThaus.Where(s => s.LoaiHopDongId != null).Select(s => (Guid)s.LoaiHopDongId));
            var thanhPhanHoSoDtos = await _thanhPhanHoSoAppService.GetThanhPhanHoSoByIds(thanhPhanHoSoIds.Distinct().ToList());
            var thuVienVanBanDtos = await _thuVienVanBanAppService.GetCoSoPhapLyByIds(thuVienVanBanIds.Distinct().ToList());
            var donViHanhChinhDtos = await _donViHanhChinhAppService.GetListByIdsAsync(donViHanhChinhIds.Distinct().ToList());
            var donViHanhChinhChaDtos = await _donViHanhChinhAppService.GetDonViCapThanhPhoHuyenThiXa();
            var nguonVonDtos = await _nguonVonAppService.GetNguonVonsByIdsAsync(nguonVonIds.Distinct().ToList());
            var nganhLinhVucSuDungDtos = await _nganhLinhVucSuDungAppService.GetListByIds(nganhLinhVucSuDungIds.Distinct().ToList());
            var chuDauTuDtos = await _chuDauTuAppService.GetListByIdsAsync(chuDauTuIds.Distinct().ToList());
            var donViBanHanhDtos = await _donViBanHanhAppService.GetListByIds(donViBanHanhIds.Distinct().ToList());
            var loaiHoSoDtos = await _loaiHoSoAppService.GetLoaiHoSoDuocApDungAsync();
            var congViecGoiThauDtos = await _goiThauAppServices.GetListByIds(congViecGoiThauIds.Distinct().ToList());
            var phuongThucLuaChonNhaThauDtos = await _phuongThucChonNhaThauAppService.GetListByIdsAsync(phuongThucLuaChonNhaThauIds.Distinct().ToList());
            var hinhThucLuaChonNhaThauDtos = await _hinhThucChonNhaThauAppService.GetListByIdsAsync(hinhThucLuaChonNhaThauIds.Distinct().ToList());
            var loaiHopDongDtos = await _loaiHopDongAppService.GetListByIdsAsync(loaiHopDongIds.Distinct().ToList());
            // get file ids của thành phần hồ sơ, cơ sở pháp lý và kết quả thẩm định
            var fileIds = GetFileIds(thanhPhanHoSos, ketQuaThamDinhs, thuVienVanBanDtos);

            var filesInfo = await _documentStoreAppService.GetFilesInfoByIdsAsync(fileIds.Distinct().ToList());

            // convert địa điểm sang viewmodel
            var diaDiemXayDungViewModels = ConvertDiaDiemThucHien(diaDiemXayDungs, donViHanhChinhChaDtos, donViHanhChinhDtos);

            // convert nguon von
            var nguonVonViewModels = ConvertNguonVon(nguonVonDtos, nguonVons);

            // convert tp hồ sơ sang viewmodel
            var tpHoSoViewModels = ConvertThanhPhanHoSo(thanhPhanHoSos, thanhPhanHoSoDtos, donViBanHanhDtos, filesInfo);

            // convert cơ sở pháp lý sang viewmodel
            var csPhapLyViewModels = ConvertCoSoPhapLy(coSoPhapLys, thuVienVanBanDtos, filesInfo);

            // convert kết quả thẩm định sang viewmodel
            var kqThamDinhViewMdels = ConvertKetQuaThamDinh(ketQuaThamDinhs, filesInfo);

            // cong viec goi thau

            var items = new List<ListHoSoCongTrinhChiTietViewModel>();
            // view detail, update
            var hoSoChiTiets = ConvertHoSoCongTrinhChiTiet(hoSoCongTrinhs, loaiHoSoDtos, input, diaDiemXayDungViewModels,
                nguonVonViewModels, chuDauTuDtos, nganhLinhVucSuDungDtos, congViecGoiThauDtos, phuongThucLuaChonNhaThauDtos, hinhThucLuaChonNhaThauDtos,
                loaiHopDongDtos, tpHoSoViewModels, csPhapLyViewModels, kqThamDinhViewMdels);
            items.AddRange(hoSoChiTiets);
            // view tao moi
            if (newCongTrinhDto != null && newLoaiHoSoDto != null)
            {
                AddNewHoSoCongTrinh(items, thanhPhanHoSoDtos, thuVienVanBanDtos, filesInfo, donViHanhChinhChaDtos, donViHanhChinhDtos, newCongTrinhDto, newLoaiHoSoDto, input);
            }
            return items;
        }

        #region get data cho view xem chi tiết và view update, view tạo mới

        private List<ListHoSoCongTrinhChiTietViewModel> ConvertHoSoCongTrinhChiTiet(
           List<Entities.HoSoCongTrinh> hoSoCongTrinhs,
           List<LoaiHoSoDto> loaiHoSos, HoSoCongTrinhChiTietInput input,
           List<DiaDiemThucHienViewModel> diaDiemXayDungs,
           List<HoSoCongTrinhChiTietNguonVonDto> nguonVonChiTietDtos,
           List<ChuDauTuDto> chuDauTuDtos,
           List<NganhLinhVucSuDungDto> nganhLinhVucSuDungDtos,
           List<GoiThauDto> congViecGoiThauDtos,
           List<PhuongThucDauThauDto> phuongThucLuaChonNhaThauDtos,
           List<HinhThucChonNhaThauDto> hinhThucLuaChonNhaThauDtos,
           List<HinhThucHopDongDto> loaiHopDongDtos,
           List<ThanhPhanHoSoViewModel> tpHoSos,
           List<CoSoPhapLyViewModel> csPhapLys,
           List<KetQuaThamDinhViewModel> kqThamDinhs
           )
        {
            var items = new List<ListHoSoCongTrinhChiTietViewModel>();

            foreach (var hoSoCongTrinh in hoSoCongTrinhs)
            {
                var hoSoCongTrinhViewModel = new ListHoSoCongTrinhChiTietViewModel();
                hoSoCongTrinhViewModel.HoSoCongTrinhId = hoSoCongTrinh.Id;
                hoSoCongTrinhViewModel.CongTrinhId = hoSoCongTrinh.CongTrinhId;
                hoSoCongTrinhViewModel.LoaiHoSoId = hoSoCongTrinh.LoaiHoSoId;
                var loaiHoSo = loaiHoSos.FirstOrDefault(s => s.Id == hoSoCongTrinh.LoaiHoSoId);
                hoSoCongTrinhViewModel.TenLoaiHoSo = loaiHoSo != null ? loaiHoSo.TenLoaiHoSo : string.Empty;
                hoSoCongTrinhViewModel.HanXuLy = hoSoCongTrinh.HanXuLy;
                hoSoCongTrinhViewModel.TrangThai = (int)hoSoCongTrinh.TrangThai;
                hoSoCongTrinhViewModel.SoLanDieuChinh = hoSoCongTrinh.SoLanDieuChinh;

                var trangThai = new TrangThaiXuLyViewModel();
                trangThai.Ma = Enum.GetName(typeof(TrangThaiEnums), hoSoCongTrinh.TrangThai);
                trangThai.Ten = ((TrangThaiEnums)Enum.Parse(typeof(TrangThaiEnums), trangThai.Ma)).GetDescription();
                hoSoCongTrinhViewModel.TrangThaiXuLy = trangThai;

                foreach (var hoSoChiTiet in hoSoCongTrinh.HoSoCongTrinhChiTiets)
                {
                    var hoSoChiTietViewModel = new HoSoCongTrinhChiTietViewModel();
                    hoSoChiTietViewModel.HoSoCongTrinhChiTietId = hoSoChiTiet.Id;
                    hoSoChiTietViewModel.SoLanDieuChinhChiTiet = hoSoChiTiet.SoLanDieuChinh;
                    if (hoSoChiTiet.HanXuLy != null)
                        hoSoChiTietViewModel.HanXuLyChiTiet = (DateTime)hoSoChiTiet.HanXuLy;
                    hoSoChiTietViewModel.TrangThaiChiTiet = (int)hoSoChiTiet.TrangThai;
                    hoSoChiTietViewModel.TenViewLoaiHoSo = loaiHoSo != null ? loaiHoSo.TenViewLoaiHoSo : string.Empty;

                    if (hoSoCongTrinh.Id == input.HoSoCongTrinhId &&
                        hoSoCongTrinh.SoLanDieuChinh == hoSoChiTiet.SoLanDieuChinh &&
                        input.LoaiHoSoId == null
                        )
                    {
                        hoSoChiTietViewModel.Expand = true;
                        hoSoCongTrinhViewModel.Expand = true;
                    }

                    // trạng thái hồ sơ công trình chi tiết
                    var trangThaiChiTiet = new TrangThaiXuLyViewModel();
                    trangThaiChiTiet.Ma = Enum.GetName(typeof(TrangThaiEnums), hoSoChiTiet.TrangThai);
                    trangThaiChiTiet.Ten = ((TrangThaiEnums)Enum.Parse(typeof(TrangThaiEnums), trangThaiChiTiet.Ma)).GetDescription();
                    hoSoChiTietViewModel.TrangThaiXuLy = trangThaiChiTiet;
                    hoSoChiTietViewModel.TenViewLoaiHoSo = loaiHoSo != null ? loaiHoSo.TenViewLoaiHoSo : string.Empty;
                    var thongTinChiTietViewModel = new ThongTinChiTietViewModel();
                    thongTinChiTietViewModel.SuCanThietDauTu = hoSoChiTiet.SuCanThietDauTu;
                    thongTinChiTietViewModel.QuyMoDauTu = hoSoChiTiet.QuyMoDauTu;
                    thongTinChiTietViewModel.NguonVonDauTu = hoSoChiTiet.NguonVonDauTu;
                    thongTinChiTietViewModel.MucTieuDauTu = hoSoChiTiet.MucTieuDauTu;
                    thongTinChiTietViewModel.MucDauTuPheDuyet = hoSoChiTiet.MucDauTuPheDuyet;
                    thongTinChiTietViewModel.MucDauTuBoSung = hoSoChiTiet.MucDauTuBoSung;
                    thongTinChiTietViewModel.TongMucDauTu = hoSoChiTiet.TongMucDauTu;
                    thongTinChiTietViewModel.MucDuToanDuocDuyet = hoSoChiTiet.TongMucDuToanDuocDuyet;
                    thongTinChiTietViewModel.NoiDungQuyMoDauTuPheDuyet = hoSoChiTiet.NoiDungQuyMoDauTuPheDuyet;
                    thongTinChiTietViewModel.NoiDungQuyMoDauTuDeXuatDieuChinh = _markdown.Transform(hoSoChiTiet.NoiDungQuyMoDauTuDeXuatDieuChinh);
                    var nganhLinhVucSuDungDto = nganhLinhVucSuDungDtos.FirstOrDefault(s => s.Id == hoSoChiTiet.NganhLinhVucSuDungId);
                    thongTinChiTietViewModel.NganhLinhVucSuDung = new NganhLinhVucDto()
                    {
                        NganhLinhVucSuDungId = hoSoChiTiet.NganhLinhVucSuDungId ??= Guid.Empty,
                        TenNganhLinhVucSuDung = nganhLinhVucSuDungDto != null ? nganhLinhVucSuDungDto.TenNganhLinhVucSuDung : string.Empty
                    };

                    thongTinChiTietViewModel.DiaDiemThucHiens = diaDiemXayDungs.Where(s => s.HoSoCongTrinhChiTietId == hoSoChiTiet.Id).ToList();
                    // nguon von
                    thongTinChiTietViewModel.NguonVons = nguonVonChiTietDtos.Where(s => s.HoSoCongTrinhChiTietId == hoSoChiTiet.Id).ToList();

                    hoSoChiTietViewModel.ThongTinChiTiet = thongTinChiTietViewModel;
                    // thành phần hồ sơ
                    hoSoChiTietViewModel.ThanhPhanHoSos = tpHoSos.Where(s => s.HoSoCongTrinhChiTietId == hoSoChiTiet.Id).OrderByDescending(s => s.BatBuoc).ToList();
                    // cơ sơ pháp lý
                    hoSoChiTietViewModel.CoSoPhapLys = csPhapLys.Where(s => s.HoSoCongTrinhChiTietId == hoSoChiTiet.Id).ToList();
                    // ý kiến thẩm định
                    var yKienThamDinh = new ThamDinhDto();
                    var donViChuTriThamDinh = new CapQuyetDinhThamDinhDto();
                    donViChuTriThamDinh.Id = hoSoChiTiet.DonViChuTriThamDinhId ??= Guid.Empty;
                    donViChuTriThamDinh.Ten = chuDauTuDtos.FirstOrDefault(s => s.Id == hoSoChiTiet.DonViChuTriThamDinhId) != null ?
                        chuDauTuDtos.FirstOrDefault(s => s.Id == hoSoChiTiet.DonViChuTriThamDinhId).Ten : string.Empty;
                    yKienThamDinh.DonViChuTriThamDinh = donViChuTriThamDinh;

                    var capQuyetDinhChuTruong = new CapQuyetDinhThamDinhDto();
                    capQuyetDinhChuTruong.Id = hoSoChiTiet.CapQuyetDinhChuTruongDauTu ??= Guid.Empty;
                    capQuyetDinhChuTruong.Ten = chuDauTuDtos.FirstOrDefault(s => s.Id == hoSoChiTiet.DonViChuTriThamDinhId) != null ?
                        chuDauTuDtos.FirstOrDefault(s => s.Id == hoSoChiTiet.DonViChuTriThamDinhId).Ten : string.Empty;
                    yKienThamDinh.CapQuyetDinhChuTruong = capQuyetDinhChuTruong;

                    var capQuyetDinhDauTuDuAn = new CapQuyetDinhThamDinhDto();
                    capQuyetDinhDauTuDuAn.Id = hoSoChiTiet.CapQuyetDinhDauTuDuAn ??= Guid.Empty;
                    capQuyetDinhDauTuDuAn.Ten = chuDauTuDtos.FirstOrDefault(s => s.Id == hoSoChiTiet.DonViChuTriThamDinhId) != null ?
                        chuDauTuDtos.FirstOrDefault(s => s.Id == hoSoChiTiet.DonViChuTriThamDinhId).Ten : string.Empty;
                    yKienThamDinh.CapQuyetDinhDauTuDuAn = capQuyetDinhDauTuDuAn;
                    try
                    {
                        yKienThamDinh.DonViPhoiHopThamDinhs = JsonConvert.DeserializeObject<List<CapQuyetDinhThamDinhDto>>(hoSoChiTiet.DonViPhoiHopThamDinhs);
                        foreach (var item in yKienThamDinh.DonViPhoiHopThamDinhs)
                        {
                            item.Ten = chuDauTuDtos.FirstOrDefault(s => s.Id == item.Id) != null ?
                            chuDauTuDtos.FirstOrDefault(s => s.Id == item.Id).Ten : string.Empty;
                        }
                    }
                    catch (Exception)
                    {
                        yKienThamDinh.DonViPhoiHopThamDinhs = new List<CapQuyetDinhThamDinhDto>();
                    }
                    yKienThamDinh.YKienThamDinhDonViPhoiHop = _markdown.Transform(hoSoChiTiet.YKienThamDinhDonViPhoiHop);
                    yKienThamDinh.HinhThucThamDinh = hoSoChiTiet.HinhThucThamDinh;
                    yKienThamDinh.SuCanThietDauTuDuAn = hoSoChiTiet.SuCanThietDauTuDuAn;
                    yKienThamDinh.SuTuanThuQuyDinh = hoSoChiTiet.SuTuanThuQuyDinh;
                    yKienThamDinh.SuPhuHopMucTieuChienLuoc = hoSoChiTiet.SuPhuHopMucTieuChienLuoc;
                    yKienThamDinh.SuPhuHopMucTieuPhanLoai = hoSoChiTiet.SuPhuHopMucTieuPhanLoai;
                    yKienThamDinh.NoiDungDauTu = _markdown.Transform(hoSoChiTiet.NoiDungDauTu);
                    yKienThamDinh.YKienCuaDonViThamDinh = hoSoChiTiet.YKienCuaDonViThamDinh;
                    yKienThamDinh.NoiDungTrinhVaKienNghi = _markdown.Transform(hoSoChiTiet.NoiDungTrinhVaKienNghi);

                    hoSoChiTietViewModel.YKienThamDinh = yKienThamDinh;
                    hoSoChiTietViewModel.ThamDinhGoiThau = ConvertThamDinhGoiThau(hoSoChiTiet, congViecGoiThauDtos, hinhThucLuaChonNhaThauDtos, phuongThucLuaChonNhaThauDtos, chuDauTuDtos, loaiHopDongDtos);
                    hoSoChiTietViewModel.ThamDinhDieuChinhGoiThau = ConvertThamDinhDieuChinhGoiThau(hoSoChiTiet, congViecGoiThauDtos, hinhThucLuaChonNhaThauDtos, phuongThucLuaChonNhaThauDtos, loaiHopDongDtos);
                    // kết quả thẩm định
                    hoSoChiTietViewModel.KetQuaThamDinhs = kqThamDinhs.Where(s => s.HoSoCongTrinhChiTietId == hoSoChiTiet.Id).ToList();
                    hoSoCongTrinhViewModel.HoSoCongTrinhChiTiets.Add(hoSoChiTietViewModel);
                }

                items.Add(hoSoCongTrinhViewModel);
            }
            return items;
        }

        private void AddNewHoSoCongTrinh(
            List<ListHoSoCongTrinhChiTietViewModel> hoSoCongTrinhs,
            List<ThanhPhanHoSoDto> thanhPhanHoSoDtos,
            List<ThuVienVanBanDto> thuVienVanBanDtos,
            List<DocumentStoreDto> filesInfo,
            List<DonViHanhChinhDto> thanhPhoHuyenThiXas,
            List<DonViHanhChinhDto> donViHanhChinhDtos,
            CongTrinhDto congTrinhDto, LoaiHoSoDto loaiHoSoDto,
            HoSoCongTrinhChiTietInput input)
        {
            var hoSoCongTrinhViewModel = new ListHoSoCongTrinhChiTietViewModel();

            hoSoCongTrinhViewModel.LoaiHoSoId = loaiHoSoDto.Id;
            hoSoCongTrinhViewModel.TenLoaiHoSo = loaiHoSoDto.TenLoaiHoSo;

            // nếu hồ sơ công trình của chủ đầu tư có trạng thái đang soạn or đang xử lý thì không cho tạo mới
            if (input.ChuDauTuId != null && hoSoCongTrinhs.Any())
            {
                foreach (var hoSo in hoSoCongTrinhs)
                {
                    if (hoSo.TrangThai == (int)TrangThaiEnums.DANG_SOAN || hoSo.TrangThai == (int)TrangThaiEnums.DANG_XU_LY)
                    {
                        throw new BusinessException("400", "Không thể tạo mới loại hồ sơ này");
                    }
                }
            }

            var ngayXuLys = new List<int>()
            {
                loaiHoSoDto.ThoiGianXuLyQuyDinhNhomA ?? 0,
                loaiHoSoDto.ThoiGianXuLyQuyDinhNhomB ?? 0,
                loaiHoSoDto.ThoiGianXuLyQuyDinhNhomC ?? 0,
            };

            var hsCongTrinhChiTiet = AddNewHoSoCongTrinhChiTiet(congTrinhDto, loaiHoSoDto, input.ChuDauTuId, thanhPhoHuyenThiXas, donViHanhChinhDtos, thanhPhanHoSoDtos, thuVienVanBanDtos, filesInfo);

            var hoSoCongTrinh = hoSoCongTrinhs.FirstOrDefault(s => s.LoaiHoSoId == input.LoaiHoSoId);

            // không phải loại điều chỉnh
            if (!loaiHoSoDto.IsDieuChinh)
            {
                if (hoSoCongTrinh != null) throw new BusinessException("400", "Loại hồ sơ này đã tồn tại");
                hsCongTrinhChiTiet.HanXuLyChiTiet = DateTime.UtcNow.ToLocalDate().AddWorkdays(ngayXuLys.OrderByDescending(s => s).FirstOrDefault());
                hoSoCongTrinhViewModel.TrangThaiXuLy = hsCongTrinhChiTiet.TrangThaiXuLy;
                hoSoCongTrinhViewModel.HanXuLy = hsCongTrinhChiTiet.HanXuLyChiTiet;
                hoSoCongTrinhViewModel.Expand = hsCongTrinhChiTiet.Expand;
                hoSoCongTrinhViewModel.HoSoCongTrinhChiTiets.Add(hsCongTrinhChiTiet);
                hoSoCongTrinhs.Add(hoSoCongTrinhViewModel);
            }
            // là loại điều chỉnh
            else
            {
                // trường hợp tạo mới thì add thêm vào hồ sơ điều chỉnh đã có
                if (hoSoCongTrinh != null)
                {
                    hsCongTrinhChiTiet.SoLanDieuChinhChiTiet = hoSoCongTrinh.HoSoCongTrinhChiTiets.Select(s => s.SoLanDieuChinhChiTiet).OrderByDescending(s => s).FirstOrDefault() + 1;
                    hsCongTrinhChiTiet.HanXuLyChiTiet = DateTime.UtcNow.ToLocalDate().AddWorkdays(ngayXuLys.OrderByDescending(s => s).FirstOrDefault());
                    hoSoCongTrinh.Expand = hsCongTrinhChiTiet.Expand;
                    hoSoCongTrinh.TrangThaiXuLy = hsCongTrinhChiTiet.TrangThaiXuLy;
                    hoSoCongTrinh.HanXuLy = hsCongTrinhChiTiet.HanXuLyChiTiet;
                    hoSoCongTrinh.HoSoCongTrinhChiTiets.Add(hsCongTrinhChiTiet);
                }
                // trường hợp tạo mới hồ sơ điều chỉnh lần đầu
                else
                {
                    hsCongTrinhChiTiet.SoLanDieuChinhChiTiet = 1;
                    hsCongTrinhChiTiet.HanXuLyChiTiet = DateTime.UtcNow.ToLocalDate().AddWorkdays(ngayXuLys.OrderByDescending(s => s).FirstOrDefault());
                    hoSoCongTrinhViewModel.Expand = hsCongTrinhChiTiet.Expand;
                    hoSoCongTrinhViewModel.HanXuLy = hsCongTrinhChiTiet.HanXuLyChiTiet;
                    hoSoCongTrinhViewModel.TrangThaiXuLy = hsCongTrinhChiTiet.TrangThaiXuLy;
                    hoSoCongTrinhViewModel.HoSoCongTrinhChiTiets.Add(hsCongTrinhChiTiet);
                    hoSoCongTrinhs.Add(hoSoCongTrinhViewModel);
                }
            }
        }

        private HoSoCongTrinhChiTietViewModel AddNewHoSoCongTrinhChiTiet(CongTrinhDto congTrinhDto, LoaiHoSoDto loaiHoSoDto, Guid? chuDauTuId,
            List<DonViHanhChinhDto> thanhPhoHuyenThiXas, List<DonViHanhChinhDto> donViHanhChinhDtos,
            List<ThanhPhanHoSoDto> thanhPhanHoSoDtos, List<ThuVienVanBanDto> thuVienVanBanDtos, List<DocumentStoreDto> filesInfo)
        {
            var hoSoChiTietViewModel = new HoSoCongTrinhChiTietViewModel();
            var trangThai = new TrangThaiXuLyViewModel();
            if (chuDauTuId == null)
            {
                trangThai.Ma = Enum.GetName(typeof(TrangThaiEnums), TrangThaiEnums.DANG_XU_LY);
                trangThai.Ten = ((TrangThaiEnums)Enum.Parse(typeof(TrangThaiEnums), trangThai.Ma)).GetDescription();
            }
            else
            {
                trangThai.Ma = Enum.GetName(typeof(TrangThaiEnums), TrangThaiEnums.DANG_SOAN);
                trangThai.Ten = ((TrangThaiEnums)Enum.Parse(typeof(TrangThaiEnums), trangThai.Ma)).GetDescription();
            }

            hoSoChiTietViewModel.TrangThaiXuLy = trangThai;
            hoSoChiTietViewModel.Expand = true;
            hoSoChiTietViewModel.TenViewLoaiHoSo = loaiHoSoDto.TenViewLoaiHoSo;
            // thông tin chi tiết
            var thongTinChiTiet = new ThongTinChiTietViewModel();
            // địa điểm thực hiện
            thongTinChiTiet.DiaDiemThucHiens = ConvertDiaDiemThucHienCreate(congTrinhDto.DiaDiemXayDungs, thanhPhoHuyenThiXas, donViHanhChinhDtos);

            hoSoChiTietViewModel.ThongTinChiTiet = thongTinChiTiet;

            // thành phần hồ sơ
            hoSoChiTietViewModel.ThanhPhanHoSos = ConvertThanhPhanHoSoCreate(loaiHoSoDto.LoaiHoSoThanhPhanHoSos, thanhPhanHoSoDtos);

            // cơ sơ pháp lý
            hoSoChiTietViewModel.CoSoPhapLys = ConvertCoSoPhapLyCreate(loaiHoSoDto.LoaiHoSoCoSoPhapLys, thuVienVanBanDtos, filesInfo);
            return hoSoChiTietViewModel;
        }

        private ThamDinhGoiThauDto ConvertThamDinhGoiThau(HoSoCongTrinhChiTiet hoSoCongTrinhChiTiet,
            List<GoiThauDto> congViecGoiThauDtos,
            List<HinhThucChonNhaThauDto> hinhThucChonNhaThauDtos,
            List<PhuongThucDauThauDto> phuongThucChonNhaThauDtos,
            List<ChuDauTuDto> donViThucHienDtos,
            List<HinhThucHopDongDto> loaiHopDongDtos
            )
        {
            var thamDinhGoiThau = new ThamDinhGoiThauDto();
            thamDinhGoiThau.YKienThamDinhCanCuPhapLy = hoSoCongTrinhChiTiet.YKienThamDinhCanCuPhapLy;
            thamDinhGoiThau.YKienThamDinhNoiDungKeHoach = hoSoCongTrinhChiTiet.YKienThamDinhNoiDungKeHoach;
            thamDinhGoiThau.YKienThamDinhGiaTriCongViec = hoSoCongTrinhChiTiet.YKienThamDinhGiaTriCongViec;
            thamDinhGoiThau.NoiDungTrinhVaKienNghi = _markdown.Transform(hoSoCongTrinhChiTiet.NoiDungTrinhVaKienNghi);
            try
            {
                thamDinhGoiThau.CanCuPhapLys = JsonConvert.DeserializeObject<List<KetQuaThamDinhPhapLyDto>>(hoSoCongTrinhChiTiet.KetQuaThamDinhCanCuPhapLys);
            }
            catch (Exception)
            {
                thamDinhGoiThau.CanCuPhapLys = new List<KetQuaThamDinhPhapLyDto>();
            }

            var congViecDaThucHiens = new List<CongViecThucHienDto>();
            var chiTietCongViecDaThucHiens = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCongViecs.Where(s => s.LoaiCongViec == LoaiCongViecEnums.CONGVIEC_DUOC_THUCHIEN);
            foreach (var item in chiTietCongViecDaThucHiens)
            {
                var congViecThucHien = new CongViecThucHienDto();
                congViecThucHien.Id = item.Id;
                congViecThucHien.CongViecGoiThauId = item.CongViecGoiThauId ??= Guid.Empty;
                congViecThucHien.HoSoCongTrinhChiTietId = item.HoSoCongTrinhChiTietId;
                var congViecGoiThauDto = congViecGoiThauDtos.FirstOrDefault(s => s.Id == item.CongViecGoiThauId);
                congViecThucHien.TenNoiDungCongViec = congViecGoiThauDto != null ? congViecGoiThauDto.TenGoiThau : string.Empty;
                congViecThucHien.DonViThucHien = item.DonViThucHien;
                congViecThucHien.GiaTriThucHien = item.GiaTriThucHien;
                congViecDaThucHiens.Add(congViecThucHien);
            }
            thamDinhGoiThau.CongViecThucHiens = congViecDaThucHiens;

            var congViecKhongApDungs = new List<CongViecKhongApDungDto>();
            var chiTietCongViecKhongApDungs = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCongViecs.Where(s => s.LoaiCongViec == LoaiCongViecEnums.CONGVIEC_KHONG_APDUNG);
            foreach (var item in chiTietCongViecKhongApDungs)
            {
                var congViecKhongApDung = new CongViecKhongApDungDto();
                congViecKhongApDung.Id = item.Id;
                congViecKhongApDung.CongViecGoiThauId = item.CongViecGoiThauId ??= Guid.Empty;
                congViecKhongApDung.HoSoCongTrinhChiTietId = item.HoSoCongTrinhChiTietId;
                var congViecGoiThauDto = congViecGoiThauDtos.FirstOrDefault(s => s.Id == item.CongViecGoiThauId);
                congViecKhongApDung.TenNoiDungCongViec = congViecGoiThauDto != null ? congViecGoiThauDto.TenGoiThau : string.Empty;
                var donViThucHienDto = donViThucHienDtos.FirstOrDefault(s => s.Id == item.DonViThucHienId);
                congViecKhongApDung.DonViThucHienId = item.DonViThucHienId ??= Guid.Empty;
                congViecKhongApDung.TenDonViThucHien = donViThucHienDto != null ? donViThucHienDto.Ten : string.Empty;
                congViecKhongApDung.GiaTriThucHien = item.GiaTriThucHien;
                congViecKhongApDungs.Add(congViecKhongApDung);
            }
            thamDinhGoiThau.CongViecKhongApDungs = congViecKhongApDungs;

            var congViecLuaChonNhaThaus = new List<CongViecThuocKeHoachDto>();
            var chiTietCongViecLuaChonNhaThaus = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCongViecs.Where(s => s.LoaiCongViec == LoaiCongViecEnums.CONGVIEC_LUACHON_NHATHAU);
            foreach (var item in chiTietCongViecLuaChonNhaThaus)
            {
                var congViecThuocKeHoach = new CongViecThuocKeHoachDto();
                congViecThuocKeHoach.Id = item.Id;
                congViecThuocKeHoach.CongViecGoiThauId = item.CongViecGoiThauId ??= Guid.Empty;
                congViecThuocKeHoach.HoSoCongTrinhChiTietId = item.HoSoCongTrinhChiTietId;
                var congViecGoiThauDto = congViecGoiThauDtos.FirstOrDefault(s => s.Id == item.CongViecGoiThauId);
                congViecThuocKeHoach.TenNoiDungKiemTra = congViecGoiThauDto != null ? congViecGoiThauDto.TenGoiThau : string.Empty;
                congViecThuocKeHoach.IsTuanThuPhuHop = item.IsTuanThuPhuHop;
                congViecLuaChonNhaThaus.Add(congViecThuocKeHoach);
            }
            thamDinhGoiThau.CongViecThuocKeHoachs = congViecLuaChonNhaThaus;

            var congViecChuaDuDieuKienLuaChonNhaThaus = new List<CongViecChuaDuDieuKienLapKeHoachDto>();
            var chuaDuDieuKienLuaChonNhaThaus = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCongViecs.Where(s => s.LoaiCongViec == LoaiCongViecEnums.CONGVIEC_CHUADUDIEUKIEN_LUACHON_NHATHAU);
            foreach (var item in chuaDuDieuKienLuaChonNhaThaus)
            {
                var congViecChuaDuDieuKien = new CongViecChuaDuDieuKienLapKeHoachDto();
                congViecChuaDuDieuKien.Id = item.Id;
                congViecChuaDuDieuKien.CongViecGoiThauId = item.CongViecGoiThauId ??= Guid.Empty;
                congViecChuaDuDieuKien.HoSoCongTrinhChiTietId = item.HoSoCongTrinhChiTietId;
                var congViecGoiThauDto = congViecGoiThauDtos.FirstOrDefault(s => s.Id == item.CongViecGoiThauId);
                congViecChuaDuDieuKien.TenNoiDungKiemTra = congViecGoiThauDto != null ? congViecGoiThauDto.TenGoiThau : string.Empty;
                congViecChuaDuDieuKien.GiaTri = item.GiaTriThucHien;
                congViecChuaDuDieuKienLuaChonNhaThaus.Add(congViecChuaDuDieuKien);
            }
            thamDinhGoiThau.CongViecChuaDuDieuKienLapKeHoachs = congViecChuaDuDieuKienLuaChonNhaThaus;

            var goiThauKienNghis = new List<HoSoCongTrinhChiTietGoiThauDto>();
            var chiTietGoiThaus = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus;
            foreach (var item in chiTietGoiThaus)
            {
                var chiTietGoiThauDto = ObjectMapper.Map<HoSoCongTrinhChiTietGoiThau, HoSoCongTrinhChiTietGoiThauDto>(item);
                var goiThauDto = congViecGoiThauDtos.FirstOrDefault(s => s.Id == item.GoiThauId);
                chiTietGoiThauDto.TenGoiThau = goiThauDto != null ? goiThauDto.TenGoiThau : string.Empty;
                var hinhThucChonNhaThau = hinhThucChonNhaThauDtos.FirstOrDefault(s => s.Id == item.HinhThucLuaChonNhaThauId);
                chiTietGoiThauDto.TenHinhThucLuaChonNhaThau = hinhThucChonNhaThau != null ? hinhThucChonNhaThau.TenHinhThucChonNhaThau : string.Empty;
                var phuongThucChonNhaThau = phuongThucChonNhaThauDtos.FirstOrDefault(s => s.Id == item.PhuongThucLuaChonNhaThauId);
                chiTietGoiThauDto.TenPhuongThucLuaChonNhaThau = phuongThucChonNhaThau != null ? phuongThucChonNhaThau.TenPhuongThucDauThau : string.Empty;
                var loaiHopDongDto = loaiHopDongDtos.FirstOrDefault(s => s.Id == item.LoaiHopDongId);
                chiTietGoiThauDto.TenLoaiHopDong = loaiHopDongDto != null ? loaiHopDongDto.TenHinhThucHopDong : string.Empty;
                goiThauKienNghis.Add(chiTietGoiThauDto);
            }
            thamDinhGoiThau.GoiThauThamDinhs = goiThauKienNghis;
            return thamDinhGoiThau;
        }

        private ThamDinhDieuChinhGoiThauDto ConvertThamDinhDieuChinhGoiThau(HoSoCongTrinhChiTiet hoSoCongTrinhChiTiet,
            List<GoiThauDto> goiThauDtos,
            List<HinhThucChonNhaThauDto> hinhThucChonNhaThauDtos,
            List<PhuongThucDauThauDto> phuongThucChonNhaThauDtos,
            List<HinhThucHopDongDto> loaiHopDongDtos)
        {
            var thamDinhDieuChinh = new ThamDinhDieuChinhGoiThauDto();
            thamDinhDieuChinh.DanhGiaCoQuanThamDinh = hoSoCongTrinhChiTiet.DanhGiaCoQuanThamDinh;
            thamDinhDieuChinh.NoiDungTrinhVaKienNghi = _markdown.Transform(hoSoCongTrinhChiTiet.NoiDungTrinhVaKienNghi);
            // danh sách gói thầu thuộc kế hoạch nhà thầu đã phê duyệt
            var goiThauDuocPheDuyets = new List<HoSoCongTrinhChiTietGoiThauDto>();
            var chiTietGoiThaus = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Where(s => s.LoaiKeHoach == LoaiCongViecEnums.GOITHAU_DUOC_PHEDUYET);
            foreach (var item in chiTietGoiThaus)
            {
                var chiTietGoiThauDto = ObjectMapper.Map<HoSoCongTrinhChiTietGoiThau, HoSoCongTrinhChiTietGoiThauDto>(item);
                var goiThau = goiThauDtos.FirstOrDefault(s => s.Id == item.GoiThauId);
                chiTietGoiThauDto.TenGoiThau = goiThau != null ? goiThau.TenGoiThau : string.Empty;
                var hinhThucChonNhaThau = hinhThucChonNhaThauDtos.FirstOrDefault(s => s.Id == item.HinhThucLuaChonNhaThauId);
                chiTietGoiThauDto.TenHinhThucLuaChonNhaThau = hinhThucChonNhaThau != null ? hinhThucChonNhaThau.TenHinhThucChonNhaThau : string.Empty;
                var phuongThucChonNhaThau = phuongThucChonNhaThauDtos.FirstOrDefault(s => s.Id == item.PhuongThucLuaChonNhaThauId);
                chiTietGoiThauDto.TenPhuongThucLuaChonNhaThau = phuongThucChonNhaThau != null ? phuongThucChonNhaThau.TenPhuongThucDauThau : string.Empty;
                var loaiHopDong = loaiHopDongDtos.FirstOrDefault(s => s.Id == item.LoaiHopDongId);
                chiTietGoiThauDto.TenLoaiHopDong = loaiHopDong != null ? loaiHopDong.TenHinhThucHopDong : string.Empty;
                goiThauDuocPheDuyets.Add(chiTietGoiThauDto);
            }
            thamDinhDieuChinh.GoiThauDuocPheDuyets = goiThauDuocPheDuyets;

            // danh sách gói thầu đề nghị điều chỉnh
            var goiThauDeNghiDieuChinhs = new List<HoSoCongTrinhChiTietGoiThauDto>();
            var chiTietGoiThauDieuChinhs = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Where(s => s.LoaiKeHoach == LoaiCongViecEnums.GOITHAU_DENGHI_DIEUCHINH);
            foreach (var item in chiTietGoiThauDieuChinhs)
            {
                var chiTietGoiThauDieuChinhDto = ObjectMapper.Map<HoSoCongTrinhChiTietGoiThau, HoSoCongTrinhChiTietGoiThauDto>(item);
                var goiThau = goiThauDtos.FirstOrDefault(s => s.Id == item.GoiThauId);
                chiTietGoiThauDieuChinhDto.TenGoiThau = goiThau != null ? goiThau.TenGoiThau : string.Empty;
                var hinhThucChonNhaThau = hinhThucChonNhaThauDtos.FirstOrDefault(s => s.Id == item.HinhThucLuaChonNhaThauId);
                chiTietGoiThauDieuChinhDto.TenHinhThucLuaChonNhaThau = hinhThucChonNhaThau != null ? hinhThucChonNhaThau.TenHinhThucChonNhaThau : string.Empty;
                var phuongThucChonNhaThau = phuongThucChonNhaThauDtos.FirstOrDefault(s => s.Id == item.PhuongThucLuaChonNhaThauId);
                chiTietGoiThauDieuChinhDto.TenPhuongThucLuaChonNhaThau = phuongThucChonNhaThau != null ? phuongThucChonNhaThau.TenPhuongThucDauThau : string.Empty;
                var loaiHopDong = loaiHopDongDtos.FirstOrDefault(s => s.Id == item.LoaiHopDongId);
                chiTietGoiThauDieuChinhDto.TenLoaiHopDong = loaiHopDong != null ? loaiHopDong.TenHinhThucHopDong : string.Empty;
                goiThauDeNghiDieuChinhs.Add(chiTietGoiThauDieuChinhDto);
            }
            thamDinhDieuChinh.GoiThauDeNghiDieuChinhs = goiThauDeNghiDieuChinhs;

            // danh sách gói thầu đề xuất
            var goiThauDeXuats = new List<HoSoCongTrinhChiTietGoiThauDto>();
            var chiTietGoiThauDeXuats = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Where(s => s.LoaiKeHoach == LoaiCongViecEnums.GOITHAU_DEXUAT);
            foreach (var item in chiTietGoiThauDeXuats)
            {
                var chiTietGoiThauDeXuatDto = ObjectMapper.Map<HoSoCongTrinhChiTietGoiThau, HoSoCongTrinhChiTietGoiThauDto>(item);
                var goiThau = goiThauDtos.FirstOrDefault(s => s.Id == item.GoiThauId);
                chiTietGoiThauDeXuatDto.TenGoiThau = goiThau != null ? goiThau.TenGoiThau : string.Empty;
                var hinhThucChonNhaThau = hinhThucChonNhaThauDtos.FirstOrDefault(s => s.Id == item.HinhThucLuaChonNhaThauId);
                chiTietGoiThauDeXuatDto.TenHinhThucLuaChonNhaThau = hinhThucChonNhaThau != null ? hinhThucChonNhaThau.TenHinhThucChonNhaThau : string.Empty;
                goiThauDeXuats.Add(chiTietGoiThauDeXuatDto);
            }
            thamDinhDieuChinh.GoiThauDeXuats = goiThauDeXuats;

            return thamDinhDieuChinh;
        }

        #endregion get data cho view xem chi tiết và view update, view tạo mới

        #region create view model

        private List<ListHoSoCongTrinhChiTietViewModel> GetListHoSoCongTrinhChiTiet(
            List<ListHoSoCongTrinhChiTietViewModel> groupHoSoCongTrinhs,
            List<LoaiHoSoDto> loaiHoSos, HoSoCongTrinhChiTietInput input,
            List<DiaDiemThucHienViewModel> diaDiemXayDungs,
            List<TongMucDauTuViewModel> mucDauTuViewModels,
            List<ThanhPhanHoSoViewModel> tpHoSos,
            List<CoSoPhapLyViewModel> csPhapLys,
            List<KetQuaThamDinhViewModel> kqThamDinhs
            )
        {
            var items = new List<ListHoSoCongTrinhChiTietViewModel>();
            foreach (var item in groupHoSoCongTrinhs)
            {
                var loaiHoSoDto = loaiHoSos.FirstOrDefault(s => s.Id == item.LoaiHoSoId);
                item.TenLoaiHoSo = loaiHoSoDto != null ? loaiHoSoDto.TenLoaiHoSo : string.Empty;

                var trangThai = new TrangThaiXuLyViewModel();
                trangThai.Ma = Enum.GetName(typeof(TrangThaiEnums), item.TrangThai);
                trangThai.Ten = ((TrangThaiEnums)Enum.Parse(typeof(TrangThaiEnums), trangThai.Ma)).GetDescription();
                item.TrangThaiXuLy = trangThai;

                foreach (var hoSoChiTiet in item.HoSoCongTrinhChiTiets)
                {
                    if (item.HoSoCongTrinhId == input.HoSoCongTrinhId &&
                        item.SoLanDieuChinh == hoSoChiTiet.SoLanDieuChinhChiTiet &&
                        input.LoaiHoSoId == null
                        )
                    {
                        hoSoChiTiet.Expand = true;
                        item.Expand = true;
                    }

                    // trạng thái hồ sơ công trình chi tiết
                    var trangThaiChiTiet = new TrangThaiXuLyViewModel();
                    trangThaiChiTiet.Ma = Enum.GetName(typeof(TrangThaiEnums), hoSoChiTiet.TrangThaiChiTiet);
                    trangThaiChiTiet.Ten = ((TrangThaiEnums)Enum.Parse(typeof(TrangThaiEnums), trangThaiChiTiet.Ma)).GetDescription();
                    hoSoChiTiet.TrangThaiXuLy = trangThaiChiTiet;

                    // địa điểm thực hiện
                    hoSoChiTiet.ThongTinChiTiet.DiaDiemThucHiens = diaDiemXayDungs.Where(s => s.HoSoCongTrinhChiTietId == hoSoChiTiet.HoSoCongTrinhChiTietId).ToList();
                    // tổng mức đầu tư
                    hoSoChiTiet.ThongTinChiTiet.TongMucDauTus = mucDauTuViewModels.Where(s => s.HoSoCongTrinhChiTietId == hoSoChiTiet.HoSoCongTrinhChiTietId).ToList();

                    // thành phần hồ sơ
                    hoSoChiTiet.ThanhPhanHoSos = tpHoSos.Where(s => s.HoSoCongTrinhChiTietId == hoSoChiTiet.HoSoCongTrinhChiTietId).OrderByDescending(s => s.BatBuoc).ToList();
                    // cơ sơ pháp lý
                    hoSoChiTiet.CoSoPhapLys = csPhapLys.Where(s => s.HoSoCongTrinhChiTietId == hoSoChiTiet.HoSoCongTrinhChiTietId).ToList();
                    // kết quả thẩm định
                    hoSoChiTiet.KetQuaThamDinhs = kqThamDinhs.Where(s => s.HoSoCongTrinhChiTietId == hoSoChiTiet.HoSoCongTrinhChiTietId).ToList();
                }

                items.Add(item);
            }
            return items;
        }

        private async Task AddNewHoSoCongTrinhAsync(List<ListHoSoCongTrinhChiTietViewModel> items,
            HoSoCongTrinhChiTietInput input, List<DonViHanhChinhDto> donViHanhChinhChas)
        {
            var newCongTrinh = await _congTrinhAppService.GetCongTrinhByIdAsync(input.CongTrinhId);
            var hsChiTietViewModel = new ListHoSoCongTrinhChiTietViewModel();

            var newHoSo = await _loaiHoSoAppService.GetLoaiHoSoByIdAsync((Guid)input.LoaiHoSoId);
            if (newHoSo == null) throw new BusinessException("400", "Không tồn tại loại hồ sơ này");
            hsChiTietViewModel.LoaiHoSoId = newHoSo.Id;
            hsChiTietViewModel.TenLoaiHoSo = newHoSo.TenLoaiHoSo;

            // nếu hồ sơ công trình của chủ đầu tư có trạng thái đang soạn or đang xử lý thì không cho tạo mới
            if (input.ChuDauTuId != null && items.Any())
            {
                foreach (var hoSo in items)
                {
                    if (hoSo.TrangThai == (int)TrangThaiEnums.DANG_SOAN || hoSo.TrangThai == (int)TrangThaiEnums.DANG_XU_LY)
                    {
                        throw new BusinessException("400", "Không thể tạo mới loại hồ sơ này");
                    }
                }
            }

            var ngayXuLys = new List<int>()
            {
                newHoSo.ThoiGianXuLyQuyDinhNhomA ?? 0,
                newHoSo.ThoiGianXuLyQuyDinhNhomB ?? 0,
                newHoSo.ThoiGianXuLyQuyDinhNhomC ?? 0,
            };

            var hsCongTrinhChiTiet = await AddNewLoaiHoSo(newHoSo, newCongTrinh, donViHanhChinhChas, input.ChuDauTuId);
            var item = items.FirstOrDefault(s => s.LoaiHoSoId == input.LoaiHoSoId);

            // không phải loại điều chỉnh
            if (!newHoSo.IsDieuChinh)
            {
                if (item != null) throw new BusinessException("400", "Loại hồ sơ này đã tồn tại");
                hsCongTrinhChiTiet.HanXuLyChiTiet = DateTime.UtcNow.ToLocalDate().AddWorkdays(ngayXuLys.OrderByDescending(s => s).FirstOrDefault());
                hsChiTietViewModel.TrangThaiXuLy = hsCongTrinhChiTiet.TrangThaiXuLy;
                hsChiTietViewModel.HanXuLy = hsCongTrinhChiTiet.HanXuLyChiTiet;
                hsChiTietViewModel.Expand = hsCongTrinhChiTiet.Expand;
                hsChiTietViewModel.HoSoCongTrinhChiTiets.Add(hsCongTrinhChiTiet);
                items.Add(hsChiTietViewModel);
            }
            // là loại điều chỉnh
            else
            {
                // trường hợp tạo mới thì add thêm vào hồ sơ điều chỉnh đã có
                if (item != null)
                {
                    hsCongTrinhChiTiet.SoLanDieuChinhChiTiet = item.HoSoCongTrinhChiTiets.Select(s => s.SoLanDieuChinhChiTiet).OrderByDescending(s => s).FirstOrDefault() + 1;
                    hsCongTrinhChiTiet.HanXuLyChiTiet = DateTime.UtcNow.ToLocalDate().AddWorkdays(ngayXuLys.OrderByDescending(s => s).FirstOrDefault());
                    item.Expand = hsCongTrinhChiTiet.Expand;
                    item.TrangThaiXuLy = hsCongTrinhChiTiet.TrangThaiXuLy;
                    item.HanXuLy = hsCongTrinhChiTiet.HanXuLyChiTiet;
                    item.HoSoCongTrinhChiTiets.Add(hsCongTrinhChiTiet);
                }
                // trường hợp tạo mới hồ sơ điều chỉnh lần đầu
                else
                {
                    hsCongTrinhChiTiet.SoLanDieuChinhChiTiet = 1;
                    hsCongTrinhChiTiet.HanXuLyChiTiet = DateTime.UtcNow.ToLocalDate().AddWorkdays(ngayXuLys.OrderByDescending(s => s).FirstOrDefault());
                    hsChiTietViewModel.Expand = hsCongTrinhChiTiet.Expand;
                    hsChiTietViewModel.HanXuLy = hsCongTrinhChiTiet.HanXuLyChiTiet;
                    hsChiTietViewModel.TrangThaiXuLy = hsCongTrinhChiTiet.TrangThaiXuLy;
                    hsChiTietViewModel.HoSoCongTrinhChiTiets.Add(hsCongTrinhChiTiet);
                    items.Add(hsChiTietViewModel);
                }
            }
        }

        #endregion create view model

        #region define view model cho hồ sơ công trình view,update

        /// <summary>
        /// Get list fileIds từ thành phần hồ sơ và kết quả thẩm định
        /// </summary>
        /// <param name="thanhPhanHoSos"></param>
        /// <param name="ketQuaThamDinhs"></param>
        /// <returns></returns>
        private List<Guid> GetFileIds(
            List<HoSoCongTrinhChiTietThanhPhanHoSo> thanhPhanHoSos,
            List<HoSoCongTrinhChiTietKetQuaThamDinh> ketQuaThamDinhs,
            List<ThuVienVanBanDto> thuVienVanBanDtos)
        {
            var fileIds = new List<Guid>();
            foreach (var item in thanhPhanHoSos)
            {
                fileIds.AddRange(item.HoSoCongTrinhChiTietThanhPhanHoSoFiles.Where(s => s.FileId != null).Select(s => (Guid)s.FileId));
            }

            foreach (var item in ketQuaThamDinhs)
            {
                if (item.FileId != null)
                {
                    fileIds.Add((Guid)item.FileId);
                }
            }

            foreach (var item in thuVienVanBanDtos)
            {
                fileIds.AddRange(item.Files.Where(s => s.FileId != null).Select(s => (Guid)s.FileId));
            }
            return fileIds;
        }

        private List<DiaDiemThucHienViewModel> ConvertDiaDiemThucHien(List<HoSoCongTrinhChiTietDiaDiem> diaDiems, List<DonViHanhChinhDto> donViHanhChinhChas, List<DonViHanhChinhDto> donViHanhChinhCons)
        {
            var diaDiemXayDung = new List<DiaDiemThucHienViewModel>();
            foreach (var item in diaDiems)
            {
                var diaDiem = new DiaDiemThucHienViewModel();
                diaDiem.Id = item.Id;
                diaDiem.HoSoCongTrinhChiTietId = item.HoSoCongTrinhChiTietId;

                var thanhPhoHuyenThiXa = donViHanhChinhChas.FirstOrDefault(s => s.Id == item.DonViHanhChinhId);
                if (thanhPhoHuyenThiXa != null)
                {
                    diaDiem.DonViHanhChinhChaId = thanhPhoHuyenThiXa.Id;
                    diaDiem.ThanhPho = thanhPhoHuyenThiXa.TenDonViHanhChinh;
                }
                else
                {
                    var phuongXaThiTran = donViHanhChinhCons.FirstOrDefault(s => s.Id == item.DonViHanhChinhId);
                    if (phuongXaThiTran != null)
                    {
                        diaDiem.DonViHanhChinhId = item.DonViHanhChinhId;
                        diaDiem.Phuong = phuongXaThiTran.TenDonViHanhChinh;
                        var thanhPhoHuyenThiXaCon = donViHanhChinhChas.FirstOrDefault(s => s.Id == phuongXaThiTran.ParentId);
                        if (thanhPhoHuyenThiXaCon != null)
                        {
                            diaDiem.DonViHanhChinhChaId = thanhPhoHuyenThiXaCon.Id;
                            diaDiem.ThanhPho = thanhPhoHuyenThiXaCon.TenDonViHanhChinh;
                        }
                    }
                }

                diaDiem.GhiChu = item.GhiChu;

                diaDiemXayDung.Add(diaDiem);
            }

            return diaDiemXayDung;
        }

        private List<HoSoCongTrinhChiTietNguonVonDto> ConvertNguonVon(List<NguonVonDto> nguonVonDtos,
            List<HoSoCongTrinhChiTietNguonVon> hoSoCongTrinhChiTietNguonVons)
        {
            var nguonVonChiTietDtos = new List<HoSoCongTrinhChiTietNguonVonDto>();
            foreach (var item in hoSoCongTrinhChiTietNguonVons)
            {
                var nguonVonChiTietDto = new HoSoCongTrinhChiTietNguonVonDto();
                var nguonVonDto = nguonVonDtos.FirstOrDefault(s => s.Id == item.NguonVonId);
                nguonVonChiTietDto.HoSoCongTrinhChiTietId = item.HoSoCongTrinhChiTietId;
                nguonVonChiTietDto.NguonVonId = nguonVonDto != null ? nguonVonDto.Id : Guid.Empty;
                nguonVonChiTietDto.TenNguonVon = nguonVonDto != null ? nguonVonDto.TenNguonVon : string.Empty;
                nguonVonChiTietDto.GiaTriDeNghi = item.GiaTriDeNghi;
                nguonVonChiTietDto.GiaTriThamDinh = item.GiaTriThamDinh;
                nguonVonChiTietDto.GiaTriNguonVon = item.GiaTriNguonVon;
                nguonVonChiTietDtos.Add(nguonVonChiTietDto);
            }

            return nguonVonChiTietDtos;
        }

        private List<TongMucDauTuViewModel> ConvertMucDauTu(List<HoSoCongTrinhChiTietMucDauTu> mucDauTus, List<ChiPhiDauTuDto> chiPhiDauTus)
        {
            var mucDauTuViewModels = new List<TongMucDauTuViewModel>();
            foreach (var item in mucDauTus)
            {
                var mucDauTu = new TongMucDauTuViewModel();
                mucDauTu.Id = item.Id;
                mucDauTu.ChiPhiId = item.ChiPhiDauTuId;
                mucDauTu.HoSoCongTrinhChiTietId = item.HoSoCongTrinhChiTietId;
                mucDauTu.TenChiPhi = chiPhiDauTus.FirstOrDefault(s => s.Id == item.ChiPhiDauTuId) != null ?
                                     chiPhiDauTus.FirstOrDefault(s => s.Id == item.ChiPhiDauTuId).TenChiPhi : string.Empty;
                mucDauTu.DonViTrinh = item.SoTien;
                mucDauTu.ThamDinhDeNghi = item.SoTienThamDinh;
                mucDauTu.IsBatBuoc = item.IsBatBuoc;

                mucDauTuViewModels.Add(mucDauTu);
            }

            return mucDauTuViewModels;
        }

        /// <summary>
        /// convert sang thành phần hồ sơ viewmodel
        /// </summary>
        /// <param name="thanhPhanHoSos"></param>
        /// <param name="tpHoSoServices"></param>
        /// <returns></returns>
        private List<ThanhPhanHoSoViewModel> ConvertThanhPhanHoSo(List<HoSoCongTrinhChiTietThanhPhanHoSo> thanhPhanHoSos, List<ThanhPhanHoSoDto> tpHoSoServices, List<DonViBanHanhDto> donViBanHanhs, List<DocumentStoreDto> filesInfo)
        {
            var tpHoSos = new List<ThanhPhanHoSoViewModel>();
            foreach (var item in thanhPhanHoSos)
            {
                var tphoso = new ThanhPhanHoSoViewModel();
                tphoso.Id = item.Id;
                tphoso.ThanhPhanHoSoId = item.ThanhPhanHoSoId;

                tphoso.HoSoCongTrinhChiTietId = item.HoSoCongTrinhChiTietId;
                tphoso.BatBuoc = item.IsBatBuoc;
                tphoso.SoQuyetDinh = item.SoKyHieu ??= string.Empty;
                tphoso.NgayBanHanh = item.NgayBanHanh;
                tphoso.NgayBanHanhFormat = item.NgayBanHanh.ToDateTimeDefault(HoSoConstants.DateTimeFormat.Date);
                tphoso.DonViBanHanhId = item.DonViBanHanhId;
                tphoso.TenDonViBanHanh = donViBanHanhs.FirstOrDefault(s => s.Id == item.DonViBanHanhId) != null ?
                                         donViBanHanhs.FirstOrDefault(s => s.Id == item.DonViBanHanhId).Ten : string.Empty;
                tphoso.TrichYeu = item.TrichYeu;

                var tpHoSoDto = tpHoSoServices.FirstOrDefault(s => s.Id == item.ThanhPhanHoSoId);
                if (tpHoSoDto != null)
                {
                    tphoso.ThongTinThanhPhanHoSo = tpHoSoDto.TenThanhPhanHoSo;
                    tphoso.LoaiVanBanId = tpHoSoDto.LoaiVanBanId ??= Guid.Empty;
                }
                var files = filesInfo.Where(s => item.HoSoCongTrinhChiTietThanhPhanHoSoFiles.Select(s => s.FileId).Contains(s.Id)).Select(f => new HoSoFile()
                {
                    Id = f.Id,
                    TenFile = f.TenFile,
                    LinkDownload = f.Url
                });
                tphoso.Files = files.ToList();

                tpHoSos.Add(tphoso);
            }
            return tpHoSos;
        }

        /// <summary>
        /// TODO cơ sở pháp lý file
        /// </summary>
        /// <param name="coSoPhapLys"></param>
        /// <param name="csPhapLyServices"></param>
        /// <returns></returns>
        private List<CoSoPhapLyViewModel> ConvertCoSoPhapLy(
            List<HoSoCongTrinhChiTietCoSoPhapLy> coSoPhapLys,
            List<ThuVienVanBanDto> csPhapLyServices,
            List<DocumentStoreDto> filesInfo)
        {
            var csPhapLys = new List<CoSoPhapLyViewModel>();
            foreach (var item in coSoPhapLys)
            {
                var csPhapLy = new CoSoPhapLyViewModel();
                csPhapLy.Id = item.Id;
                csPhapLy.HoSoCongTrinhChiTietId = item.HoSoCongTrinhChiTietId;
                // trường hợp cơ sở pháp lý lưu ở nguồn thư viện văn bản
                if (item.ThuVienVanBanId != null)
                {
                    csPhapLy.ThuVienVanBanId = item.ThuVienVanBanId;
                    var thuVienVanBan = csPhapLyServices.FirstOrDefault(s => s.Id == item.ThuVienVanBanId);
                    if (thuVienVanBan != null)
                    {
                        csPhapLy.NoiDung = $"Nghị định số {thuVienVanBan.SoKyHieu} ngày {thuVienVanBan.NgayBanHanh.ToDateTimeDefault(HoSoConstants.DateTimeFormat.Date)} của {thuVienVanBan.DonViBanHanh} về {thuVienVanBan.TrichYeu}";
                        var files = filesInfo.Where(s => thuVienVanBan.Files.Select(s => s.FileId).Contains(s.Id))
                            .Select(f => new HoSoFile()
                            {
                                Id = f.Id,
                                TenFile = f.TenFile,
                                LinkDownload = f.Url
                            });
                        csPhapLy.Files = files.ToList();
                    }
                }
                else // lưu trong field json
                {
                    try
                    {
                        var coSoPhapLyJson = JsonConvert.DeserializeObject<CoSoPhapLyJsonViewModel>(item.NoiDungJson);
                        csPhapLy.NoiDung = $"Nghị định số {coSoPhapLyJson.SoKyHieu} ngày {coSoPhapLyJson.NgayBanHanh.ToDateTimeDefault(HoSoConstants.DateTimeFormat.Date)} của {coSoPhapLyJson.DonViBanHanh} về {coSoPhapLyJson.TrichYeu}";
                        csPhapLy.CoSoPhapLyJsonViewModel = coSoPhapLyJson;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }

                csPhapLys.Add(csPhapLy);
            }
            return csPhapLys;
        }

        /// <summary>
        /// TODO add file
        /// </summary>
        /// <param name="ketQuaThamDinhs"></param>
        /// <returns></returns>
        private List<KetQuaThamDinhViewModel> ConvertKetQuaThamDinh(List<HoSoCongTrinhChiTietKetQuaThamDinh> ketQuaThamDinhs, List<DocumentStoreDto> filesInfo)
        {
            var kqThamDinhs = new List<KetQuaThamDinhViewModel>();
            var filesIds = ketQuaThamDinhs.Where(s => s.FileId != null).Select(s => s.FileId).Distinct().ToList();
            var files = filesInfo.Where(s => filesIds.Contains(s.Id)).Select(f => new HoSoFile()
            {
                Id = f.Id,
                TenFile = f.TenFile,
                LinkDownload = f.Url
            }).ToList();

            foreach (var item in ketQuaThamDinhs)
            {
                var kqThamDinh = new KetQuaThamDinhViewModel();
                kqThamDinh.Id = item.Id;
                kqThamDinh.HoSoCongTrinhChiTietId = item.HoSoCongTrinhChiTietId;

                if (item.FileId != null)
                {
                    kqThamDinh.File = files.FirstOrDefault(s => s.Id == item.FileId);
                }

                kqThamDinhs.Add(kqThamDinh);
            }
            return kqThamDinhs;
        }

        #endregion define view model cho hồ sơ công trình view,update

        private async Task<HoSoCongTrinhChiTietViewModel> AddNewLoaiHoSo(LoaiHoSoDto loaiHoSoDto, CongTrinhDto congTrinhDto, List<DonViHanhChinhDto> donViHanhChinhChas, Guid? chuDauTuId)
        {
            var hoSoCongTrinhChiTiet = new HoSoCongTrinhChiTietViewModel();
            var trangThai = new TrangThaiXuLyViewModel();
            if (chuDauTuId == null)
            {
                trangThai.Ma = Enum.GetName(typeof(TrangThaiEnums), TrangThaiEnums.DANG_XU_LY);
                trangThai.Ten = ((TrangThaiEnums)Enum.Parse(typeof(TrangThaiEnums), trangThai.Ma)).GetDescription();
            }
            else
            {
                trangThai.Ma = Enum.GetName(typeof(TrangThaiEnums), TrangThaiEnums.DANG_SOAN);
                trangThai.Ten = ((TrangThaiEnums)Enum.Parse(typeof(TrangThaiEnums), trangThai.Ma)).GetDescription();
            }

            hoSoCongTrinhChiTiet.TrangThaiXuLy = trangThai;
            hoSoCongTrinhChiTiet.Expand = true;
            // thông tin chi tiết
            var thongTinChiTiet = new ThongTinChiTietViewModel();
            // địa điểm thực hiện

            thongTinChiTiet.DiaDiemThucHiens = await ConvertDiaDiemThucHienCreate(congTrinhDto.DiaDiemXayDungs, donViHanhChinhChas);
            // tổng mức đầu tư

            thongTinChiTiet.TongMucDauTus = await ConvertMucDauTuCreate(loaiHoSoDto.LoaiHoSoChiPhiDauTus);

            hoSoCongTrinhChiTiet.ThongTinChiTiet = thongTinChiTiet;

            // thành phần hồ sơ
            hoSoCongTrinhChiTiet.ThanhPhanHoSos = await ConvertThanhPhanHoSoCreate(loaiHoSoDto.LoaiHoSoThanhPhanHoSos);
            // cơ sơ pháp lý
            //hoSoCongTrinhChiTiet.CoSoPhapLys = await ConvertCoSoPhapLyCreate(loaiHoSoDto.LoaiHoSoCoSoPhapLys);

            return hoSoCongTrinhChiTiet;
        }

        #region define viewmodel cho trường hợp tạo mới

        /// <summary>
        /// Trường hợp create convert địa điểm xây dựng
        /// </summary>
        private async Task<List<DiaDiemThucHienViewModel>> ConvertDiaDiemThucHienCreate(List<DiaDiemXayDungDto> diaDiemXayDungs, List<DonViHanhChinhDto> donViHanhChinhChas)
        {
            var diaDiemThucHiens = new List<DiaDiemThucHienViewModel>();
            var donViHanhChinhs = await _donViHanhChinhAppService.GetListByIdsAsync(diaDiemXayDungs.Select(s => s.DonViHanhChinhId).ToList());
            foreach (var item in diaDiemXayDungs)
            {
                var donViDto = donViHanhChinhs.FirstOrDefault(s => s.Id == item.DonViHanhChinhId);
                if (donViDto != null)
                {
                    var diaDiem = new DiaDiemThucHienViewModel();
                    var donViHanhChinhChaDto = donViHanhChinhChas.FirstOrDefault(s => s.Id == donViDto.Id);
                    if (donViHanhChinhChaDto != null)
                    {
                        diaDiem.DonViHanhChinhChaId = donViHanhChinhChaDto.Id;
                        diaDiem.ThanhPho = donViHanhChinhChaDto.TenDonViHanhChinh;
                    }
                    else
                    {
                        diaDiem.DonViHanhChinhId = donViDto.Id;
                        diaDiem.Phuong = donViDto.TenDonViHanhChinh;
                        var thanhPhoDto = donViHanhChinhChas.FirstOrDefault(s => s.Id == donViDto.ParentId);
                        if (thanhPhoDto != null)
                        {
                            diaDiem.DonViHanhChinhChaId = thanhPhoDto.Id;
                            diaDiem.ThanhPho = thanhPhoDto.TenCapDonVi;
                        }
                    }
                    diaDiem.GhiChu = item.GhiChu;

                    diaDiemThucHiens.Add(diaDiem);
                }
            }

            return diaDiemThucHiens;
        }

        /// <summary>
        /// Trường hợp create convert địa điểm xây dựng
        /// </summary>
        private List<DiaDiemThucHienViewModel> ConvertDiaDiemThucHienCreate(List<DiaDiemXayDungDto> diaDiemXayDungs, List<DonViHanhChinhDto> thanhPhoHuyenThiXas, List<DonViHanhChinhDto> donViHanhChinhDtos)
        {
            var diaDiemThucHiens = new List<DiaDiemThucHienViewModel>();
            foreach (var item in diaDiemXayDungs)
            {
                var donViHanhChinhChaDto = thanhPhoHuyenThiXas.FirstOrDefault(s => s.Id == item.DonViHanhChinhId);
                if (donViHanhChinhChaDto != null)
                {
                    diaDiemThucHiens.Add(new DiaDiemThucHienViewModel { DonViHanhChinhChaId = donViHanhChinhChaDto.Id, ThanhPho = donViHanhChinhChaDto.TenDonViHanhChinh, GhiChu = item.GhiChu });
                }
                else
                {
                    var donViHanhChinhConDto = donViHanhChinhDtos.FirstOrDefault(s => s.Id == item.DonViHanhChinhId);
                    if (donViHanhChinhConDto == null) continue;
                    diaDiemThucHiens.Add(new DiaDiemThucHienViewModel
                    {
                        DonViHanhChinhChaId = (Guid)donViHanhChinhConDto.ParentId,
                        DonViHanhChinhId = donViHanhChinhConDto.Id,
                        ThanhPho = thanhPhoHuyenThiXas.FirstOrDefault(s => s.Id == donViHanhChinhConDto.ParentId) != null ?
                                   thanhPhoHuyenThiXas.FirstOrDefault(s => s.Id == donViHanhChinhConDto.ParentId).TenDonViHanhChinh : string.Empty,
                        Phuong = donViHanhChinhConDto.TenDonViHanhChinh,
                        GhiChu = item.GhiChu
                    });
                }
            }
            return diaDiemThucHiens;
        }

        /// <summary>
        /// Trường hợp create convert thành phần hồ sơ
        /// </summary>
        private async Task<List<ThanhPhanHoSoViewModel>> ConvertThanhPhanHoSoCreate(List<LoaiHoSoThanhPhanHoSoDto> loaiHoSoThanhPhanHoSos)
        {
            var tpHoSos = new List<ThanhPhanHoSoViewModel>();
            var tpHoSoServices = await _thanhPhanHoSoAppService.GetThanhPhanHoSoByIds(loaiHoSoThanhPhanHoSos.Select(s => s.ThanhPhanHoSoId).Distinct().ToList());
            foreach (var item in loaiHoSoThanhPhanHoSos)
            {
                var tpHoSoDto = tpHoSoServices.FirstOrDefault(s => s.Id == item.ThanhPhanHoSoId);
                if (tpHoSoDto != null)
                {
                    var tphoso = new ThanhPhanHoSoViewModel();
                    tphoso.Id = item.Id;
                    tphoso.ThanhPhanHoSoId = tpHoSoDto.Id;
                    tphoso.LoaiVanBanId = tpHoSoDto.LoaiVanBanId ??= Guid.Empty;
                    tphoso.BatBuoc = item.BatBuoc;
                    tphoso.ThongTinThanhPhanHoSo = tpHoSoDto.TenThanhPhanHoSo ??= string.Empty;
                    tpHoSos.Add(tphoso);
                }
            }
            return tpHoSos;
        }

        /// <summary>
        /// Trường hợp create convert thành phần hồ sơ
        /// </summary>
        private List<ThanhPhanHoSoViewModel> ConvertThanhPhanHoSoCreate(List<LoaiHoSoThanhPhanHoSoDto> loaiHoSoThanhPhanHoSos, List<ThanhPhanHoSoDto> thanhPhanHoSoDtos)
        {
            var tpHoSos = new List<ThanhPhanHoSoViewModel>();
            foreach (var item in loaiHoSoThanhPhanHoSos)
            {
                var thanhPhanHoSoDto = thanhPhanHoSoDtos.FirstOrDefault(s => s.Id == item.ThanhPhanHoSoId);
                if (thanhPhanHoSoDto != null)
                {
                    var tphoso = new ThanhPhanHoSoViewModel();
                    tphoso.ThanhPhanHoSoId = thanhPhanHoSoDto.Id;
                    tphoso.LoaiVanBanId = thanhPhanHoSoDto.LoaiVanBanId ??= Guid.Empty;
                    tphoso.BatBuoc = item.BatBuoc;
                    tphoso.ThongTinThanhPhanHoSo = thanhPhanHoSoDto.TenThanhPhanHoSo ??= string.Empty;
                    tpHoSos.Add(tphoso);
                }
            }
            return tpHoSos;
        }

        /// <summary>
        /// Trường hợp create convert mức đầu tư
        /// </summary>
        private async Task<List<TongMucDauTuViewModel>> ConvertMucDauTuCreate(List<LoaiHoSoChiPhiDauTuDto> loaiHoSoChiPhiDauTus)
        {
            var mucDauTuViewModels = new List<TongMucDauTuViewModel>();
            var chiPhiDauTus = await _chiPhiDauTuAppService.GetListByIdsAsync(loaiHoSoChiPhiDauTus.Select(s => s.ChiPhiDauTuId).ToList());
            foreach (var item in loaiHoSoChiPhiDauTus)
            {
                var chiPhiDto = chiPhiDauTus.FirstOrDefault(s => s.Id == item.ChiPhiDauTuId);
                if (chiPhiDto != null)
                {
                    var mucDauTu = new TongMucDauTuViewModel();
                    mucDauTu.Id = item.Id;
                    mucDauTu.ChiPhiId = chiPhiDto.Id;
                    mucDauTu.TenChiPhi = chiPhiDto.TenChiPhi ??= string.Empty;
                    mucDauTu.IsBatBuoc = true;
                    mucDauTuViewModels.Add(mucDauTu);
                }
            }

            return mucDauTuViewModels;
        }

        /// <summary>
        /// Trường hợp create convert cơ sở pháp lý
        /// </summary>
        private List<CoSoPhapLyViewModel> ConvertCoSoPhapLyCreate(List<LoaiHoSoCoSoPhapLyDto> coSoPhapLys,
            List<ThuVienVanBanDto> thuVienVanBanDtos,
            List<DocumentStoreDto> filesInfo)
        {
            var csPhapLys = new List<CoSoPhapLyViewModel>();
            foreach (var item in coSoPhapLys)
            {
                var thuVienVanBan = thuVienVanBanDtos.FirstOrDefault(s => s.Id == item.ThuVienVanBanId);
                if (thuVienVanBan != null)
                {
                    var csPhapLy = new CoSoPhapLyViewModel();
                    csPhapLy.Id = item.Id;
                    csPhapLy.ThuVienVanBanId = thuVienVanBan.Id;
                    csPhapLy.NoiDung = $"Nghị định số {thuVienVanBan.SoKyHieu} ngày {thuVienVanBan.NgayBanHanh.ToDateTimeDefault(HoSoConstants.DateTimeFormat.Date)} của {thuVienVanBan.DonViBanHanh} về {thuVienVanBan.TrichYeu}";
                    var files = filesInfo.Where(s => thuVienVanBan.Files.Select(s => s.FileId).Contains(s.Id))
                             .Select(f => new HoSoFile()
                             {
                                 Id = f.Id,
                                 TenFile = f.TenFile,
                                 LinkDownload = f.Url
                             });
                    csPhapLy.Files = files.ToList();
                    csPhapLys.Add(csPhapLy);
                }
            }
            return csPhapLys;
        }

        #endregion define viewmodel cho trường hợp tạo mới
    }
}