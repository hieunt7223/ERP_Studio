using Humanizer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Users;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using xdcb.Common.DanhMuc.DonViBanHanhDtos;
using xdcb.Common.DanhMuc.DonViHanhChinhDtos;
using xdcb.Common.DanhMuc.GoiThauDtos;
using xdcb.Common.DanhMuc.HinhThucChonNhaThauDtos;
using xdcb.Common.DanhMuc.HinhThucHopDongDtos;
using xdcb.Common.DanhMuc.NguonVonDtos;
using xdcb.Common.DanhMuc.PhuongThucDauThaus;
using xdcb.Common.DanhMuc.ThanhPhanHoSoDtos;
using xdcb.Common.DanhMuc.ThuVienVanBanDtos;
using xdcb.HoSoCongTrinh.Constants;
using xdcb.HoSoCongTrinh.Dtos;
using xdcb.HoSoCongTrinh.Entities;
using xdcb.HoSoCongTrinh.Extensions;

namespace xdcb.HoSoCongTrinh.Services
{
    public partial class HoSoCongTrinhChiTietAppService : HoSoCongTrinhAppServiceBase, IHoSoCongTrinhChiTietAppService
    {
        public async Task<dynamic> GetDataReportAsync(Guid id, Guid chiTietId)
        {
            var hoSoCongTrinh = await _hoSoCongTrinhRepository.GetEntityByIdAsync(id);
            if (hoSoCongTrinh == null) throw new BusinessException("");
            var congTrinhDto = await _congTrinhAppService.GetCongTrinhDetailAsync(hoSoCongTrinh.CongTrinhId);
            var user = await _userManager.GetByIdAsync(_currentUser.GetId());
            var tenChuyenVien = $"{user.Surname} {user.Name}";
            var giaTriCongViecThucHien = 0.0m;
            var giaTriCongViecKhongApDung = 0.0m;
            var giaTriCongViecThuocKeHoach = 0.0m;
            var giaTriCongViecChuaDuDieuKien = 0.0m;
            var goiThauIds = new List<Guid>();
            var donViThucHienIds = new List<Guid>();
            var hinhThucLuaChonIds = new List<Guid>();
            var phuongThucLuaChonIds = new List<Guid>();
            var loaiHopDongIds = new List<Guid>();
            var nguonVonIds = new List<Guid>();
            var thuVienVanBanIds = new List<Guid>();

            var baoCaoLuaChonNhaThau = new BaoCaoLuaChonNhaThau();
            baoCaoLuaChonNhaThau.year = DateTime.Now.ToLocalDate().ToDateTimeDefault(HoSoConstants.DateTimeFormat.YearOnly);
            baoCaoLuaChonNhaThau.month = DateTime.Now.ToLocalDate().ToDateTimeDefault(HoSoConstants.DateTimeFormat.MonthOnly);
            baoCaoLuaChonNhaThau.day = DateTime.Now.ToLocalDate().ToDateTimeDefault(HoSoConstants.DateTimeFormat.DateOnly);
            baoCaoLuaChonNhaThau.tenCongTrinh = congTrinhDto.TenCongTrinh ??= string.Empty;

            var hoSoCongTrinhChiTiet = hoSoCongTrinh.HoSoCongTrinhChiTiets.FirstOrDefault(s => s.Id == chiTietId);
            if (hoSoCongTrinhChiTiet != null)
            {
                goiThauIds.AddRange(hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCongViecs.Where(s => s.CongViecGoiThauId != null).Select(s => (Guid)s.CongViecGoiThauId));
                goiThauIds.AddRange(hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Where(s => s.GoiThauId != null).Select(s => (Guid)s.GoiThauId));
                donViThucHienIds.AddRange(hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCongViecs.Where(s => s.DonViThucHienId != null).Select(s => (Guid)s.DonViThucHienId));
                hinhThucLuaChonIds.AddRange(hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Where(s => s.HinhThucLuaChonNhaThauId != null).Select(s => (Guid)s.HinhThucLuaChonNhaThauId));
                phuongThucLuaChonIds.AddRange(hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Where(s => s.PhuongThucLuaChonNhaThauId != null).Select(s => (Guid)s.PhuongThucLuaChonNhaThauId));
                loaiHopDongIds.AddRange(hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Where(s => s.LoaiHopDongId != null).Select(s => (Guid)s.LoaiHopDongId));
                nguonVonIds.AddRange(hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietNguonVons.Select(s => s.NguonVonId));

                var goiThauDtos = await _goiThauAppServices.GetListByIds(goiThauIds.Distinct().ToList());
                var donViThucHienDtos = await _chuDauTuAppService.GetListByIdsAsync(donViThucHienIds.Distinct().ToList());
                var hinhThucDtos = await _hinhThucChonNhaThauAppService.GetListByIdsAsync(hinhThucLuaChonIds.Distinct().ToList());
                var phuongThucDtos = await _phuongThucChonNhaThauAppService.GetListByIdsAsync(phuongThucLuaChonIds.Distinct().ToList());
                var loaiHopDongDtos = await _loaiHopDongAppService.GetListByIdsAsync(loaiHopDongIds.Distinct().ToList());
                var nguonVonDtos = await _nguonVonAppService.GetNguonVonsByIdsAsync(nguonVonIds.Distinct().ToList());
                // cơ sở pháp lý
                var chiTietCoSoPhapLys = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCoSoPhapLys;
                thuVienVanBanIds.AddRange(chiTietCoSoPhapLys.Where(s => s.ThuVienVanBanId != null).Select(s => (Guid)s.ThuVienVanBanId));
                var thuVienVanBanDtos = await _thuVienVanBanAppService.GetCoSoPhapLyByIds(thuVienVanBanIds);
                baoCaoLuaChonNhaThau.coSoPhapLys = GetDataCoSoPhapLyReport(hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCoSoPhapLys, thuVienVanBanDtos);
                // thanh phan ho so
                var thanhPhanHoSos = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietThanhPhanHoSos.OrderBy(s => s.OrderIndex).ToList();
                var donViBanHanhIds = thanhPhanHoSos.Where(s => s.DonViBanHanhId != null).Select(s => (Guid)s.DonViBanHanhId).ToList();
                var donViBanHanhDtos = await _donViBanHanhAppService.GetListByIds(donViBanHanhIds);
                var thanhPhanHoSoDtos = await _thanhPhanHoSoAppService.GetThanhPhanHoSoByIds(thanhPhanHoSos.Select(s => s.ThanhPhanHoSoId).Distinct().ToList());
                baoCaoLuaChonNhaThau.thanhPhanHoSos = GetDataThanhPhanHoSoReport(thanhPhanHoSos, thanhPhanHoSoDtos, donViBanHanhDtos);

                baoCaoLuaChonNhaThau.tongMucDauTu = $"{hoSoCongTrinhChiTiet.TongMucDauTu.FormatCurrency()} đồng";
                baoCaoLuaChonNhaThau.tongMucDuToan = $"{hoSoCongTrinhChiTiet.TongMucDuToanDuocDuyet.FormatCurrency()} đồng";
                baoCaoLuaChonNhaThau.chuDauTu = congTrinhDto.TenChuDauTu ??= string.Empty;
                baoCaoLuaChonNhaThau.nguonVonDauTus = GetDataNguonVonReport(hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietNguonVons, nguonVonDtos);
                baoCaoLuaChonNhaThau.thoiGianThucHien = $"{congTrinhDto.ThoiGianThucHienTuNgay.ToDateTimeDefault(HoSoConstants.DateTimeFormat.YearOnly)} - {congTrinhDto.ThoiGianThucHienDenNgay.ToDateTimeDefault(HoSoConstants.DateTimeFormat.YearOnly)}";
                // dia diem xay Dung
                var diaDiemXayDungs = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietDiaDiems;
                var donViHanhChinhChaDtos = await _donViHanhChinhAppService.GetDonViCapThanhPhoHuyenThiXa();
                var donViHanhChinhDtos = await _donViHanhChinhAppService.GetListByIdsAsync(diaDiemXayDungs.Select(s => s.DonViHanhChinhId).Distinct().ToList());
                baoCaoLuaChonNhaThau.diaDiemThucHiens = ConvertDiaDiemReport(diaDiemXayDungs, donViHanhChinhChaDtos, donViHanhChinhDtos);
                baoCaoLuaChonNhaThau.quyMoDauTu = _markdown.Transform(hoSoCongTrinhChiTiet.QuyMoDauTu);
                baoCaoLuaChonNhaThau.thamDinhCanCuPhapLys = GetThamDinhCanCuPhapLys(hoSoCongTrinhChiTiet);
                baoCaoLuaChonNhaThau.yKienThamDinhCanCuPhapLy = hoSoCongTrinhChiTiet.YKienThamDinhCanCuPhapLy;
                baoCaoLuaChonNhaThau.congViecDaThucHiens = GetCongViecDaThucHiens(hoSoCongTrinhChiTiet, goiThauDtos, ref giaTriCongViecThucHien);
                baoCaoLuaChonNhaThau.giaTriCongViecThucHien = $"{giaTriCongViecThucHien.FormatCurrency()}";
                baoCaoLuaChonNhaThau.congViecKhongApDungs = GetCongViecKhongApDungs(hoSoCongTrinhChiTiet, goiThauDtos, donViThucHienDtos, ref giaTriCongViecKhongApDung);
                baoCaoLuaChonNhaThau.giaTriCongViecKhongApDung = $"{giaTriCongViecKhongApDung.FormatCurrency()}";
                baoCaoLuaChonNhaThau.congViecThuocKeHoachs = GetCongViecThuocKeHoachs(hoSoCongTrinhChiTiet, goiThauDtos);
                baoCaoLuaChonNhaThau.yKienThamDinhVeNoiDungkeHoachLuaChon = hoSoCongTrinhChiTiet.YKienThamDinhNoiDungKeHoach;
                // TODO get danh sách công việc lựa chọn nhà thầu chưa đủ điều kiện
                baoCaoLuaChonNhaThau.congViecChuaDuDieuKiens = GetCongViecChuaDuDieuKiens(hoSoCongTrinhChiTiet, goiThauDtos, ref giaTriCongViecChuaDuDieuKien);
                baoCaoLuaChonNhaThau.giaTriCongViecChuaDuDieuKien = $"{giaTriCongViecChuaDuDieuKien.FormatCurrency()}";
                baoCaoLuaChonNhaThau.yKienThamDinhVeTongGiaTri = hoSoCongTrinhChiTiet.YKienThamDinhGiaTriCongViec;
                baoCaoLuaChonNhaThau.goiThauKienNghis = GetGoiThauKienNghis(hoSoCongTrinhChiTiet, goiThauDtos, hinhThucDtos, phuongThucDtos, loaiHopDongDtos, ref giaTriCongViecThuocKeHoach);
                baoCaoLuaChonNhaThau.giaTriCongViecThuocKeHoach = $"{giaTriCongViecThuocKeHoach.FormatCurrency()}";
                baoCaoLuaChonNhaThau.giaTriCongViecThuocKeHoachBangChu = Decimal.ToInt64(giaTriCongViecThuocKeHoach).ToWords(new System.Globalization.CultureInfo("vi"));
                var tongGiaTriCacPhanCongViec = giaTriCongViecThucHien + giaTriCongViecKhongApDung + giaTriCongViecThuocKeHoach;
                baoCaoLuaChonNhaThau.tongGiaTriCacPhanCongViec = $"{tongGiaTriCacPhanCongViec.FormatCurrency()}";
                baoCaoLuaChonNhaThau.tenChuyenVien = tenChuyenVien;
                baoCaoLuaChonNhaThau.noiDungTrinhVaKienNghi = _markdown.Transform(hoSoCongTrinhChiTiet.NoiDungTrinhVaKienNghi);
            }

            var jsonData = JsonConvert.SerializeObject(baoCaoLuaChonNhaThau);

            return jsonData;
        }

        public async Task<dynamic> GetDataDieuChinhReportAsync(Guid id, Guid chiTietId)
        {
            var hoSoCongTrinh = await _hoSoCongTrinhRepository.GetEntityByIdAsync(id);
            if (hoSoCongTrinh == null) throw new BusinessException("");
            var congTrinhDto = await _congTrinhAppService.GetCongTrinhDetailAsync(hoSoCongTrinh.CongTrinhId);
            var user = await _userManager.GetByIdAsync(_currentUser.GetId());
            var tenChuyenVien = $"{user.Surname} {user.Name}";
            var goiThauIds = new List<Guid>();
            var thuVienVanBanIds = new List<Guid>();
            var hinhThucLuaChonIds = new List<Guid>();
            var phuongThucLuaChonIds = new List<Guid>();
            var loaiHopDongIds = new List<Guid>();

            var baoCaoDieuChinhLuaChonNhaThau = new BaoCaoDieuChinhLuaChonNhaThau();
            baoCaoDieuChinhLuaChonNhaThau.year = DateTime.Now.ToLocalDate().ToDateTimeDefault(HoSoConstants.DateTimeFormat.YearOnly);
            baoCaoDieuChinhLuaChonNhaThau.month = DateTime.Now.ToLocalDate().ToDateTimeDefault(HoSoConstants.DateTimeFormat.MonthOnly);
            baoCaoDieuChinhLuaChonNhaThau.day = DateTime.Now.ToLocalDate().ToDateTimeDefault(HoSoConstants.DateTimeFormat.DateOnly);
            baoCaoDieuChinhLuaChonNhaThau.tenCongTrinh = congTrinhDto.TenCongTrinh ??= string.Empty;
            var hoSoCongTrinhChiTiet = hoSoCongTrinh.HoSoCongTrinhChiTiets.FirstOrDefault(s => s.Id == chiTietId);
            if (hoSoCongTrinhChiTiet != null)
            {
                goiThauIds.AddRange(hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCongViecs.Where(s => s.CongViecGoiThauId != null).Select(s => (Guid)s.CongViecGoiThauId));
                goiThauIds.AddRange(hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Where(s => s.GoiThauId != null).Select(s => (Guid)s.GoiThauId));
                hinhThucLuaChonIds.AddRange(hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Where(s => s.HinhThucLuaChonNhaThauId != null).Select(s => (Guid)s.HinhThucLuaChonNhaThauId));
                phuongThucLuaChonIds.AddRange(hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Where(s => s.PhuongThucLuaChonNhaThauId != null).Select(s => (Guid)s.PhuongThucLuaChonNhaThauId));
                loaiHopDongIds.AddRange(hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Where(s => s.LoaiHopDongId != null).Select(s => (Guid)s.LoaiHopDongId));
                var goiThauDtos = await _goiThauAppServices.GetListByIds(goiThauIds.Distinct().ToList());
                var hinhThucDtos = await _hinhThucChonNhaThauAppService.GetListByIdsAsync(hinhThucLuaChonIds.Distinct().ToList());
                var phuongThucDtos = await _phuongThucChonNhaThauAppService.GetListByIdsAsync(phuongThucLuaChonIds.Distinct().ToList());
                var loaiHopDongDtos = await _loaiHopDongAppService.GetListByIdsAsync(loaiHopDongIds.Distinct().ToList());
                // cơ sơ pháp lý
                var chiTietCoSoPhapLys = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCoSoPhapLys;
                thuVienVanBanIds.AddRange(chiTietCoSoPhapLys.Where(s => s.ThuVienVanBanId != null).Select(s => (Guid)s.ThuVienVanBanId));
                var thuVienVanBanDtos = await _thuVienVanBanAppService.GetCoSoPhapLyByIds(thuVienVanBanIds);
                baoCaoDieuChinhLuaChonNhaThau.coSoPhapLys = GetDataCoSoPhapLyReport(hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCoSoPhapLys, thuVienVanBanDtos);
                // thanh phan ho so
                var thanhPhanHoSos = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietThanhPhanHoSos.OrderBy(s => s.OrderIndex).ToList();
                var donViBanHanhIds = thanhPhanHoSos.Where(s => s.DonViBanHanhId != null).Select(s => (Guid)s.DonViBanHanhId).ToList();
                var donViBanHanhDtos = await _donViBanHanhAppService.GetListByIds(donViBanHanhIds);
                var thanhPhanHoSoDtos = await _thanhPhanHoSoAppService.GetThanhPhanHoSoByIds(thanhPhanHoSos.Select(s => s.ThanhPhanHoSoId).Distinct().ToList());
                baoCaoDieuChinhLuaChonNhaThau.thanhPhanHoSos = GetDataThanhPhanHoSoReport(thanhPhanHoSos, thanhPhanHoSoDtos, donViBanHanhDtos);
                var chiTietGoiThauDuocPheDuyets = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Where(s => s.LoaiKeHoach == Enums.LoaiCongViecEnums.GOITHAU_DUOC_PHEDUYET).ToList();
                baoCaoDieuChinhLuaChonNhaThau.goiThauDuocPheDuyets = GetGoiThauPheDuyetDieuChinhDeXuats(chiTietGoiThauDuocPheDuyets, goiThauDtos, hinhThucDtos, phuongThucDtos, loaiHopDongDtos);
                var chiTietGoiThauDieuChinhs = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Where(s => s.LoaiKeHoach == Enums.LoaiCongViecEnums.GOITHAU_DENGHI_DIEUCHINH).ToList();
                baoCaoDieuChinhLuaChonNhaThau.goiThauDeNghiDieuChinhs = GetGoiThauPheDuyetDieuChinhDeXuats(chiTietGoiThauDieuChinhs, goiThauDtos, hinhThucDtos, phuongThucDtos, loaiHopDongDtos);
                var chiTietGoiThauDeXuats = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Where(s => s.LoaiKeHoach == Enums.LoaiCongViecEnums.GOITHAU_DEXUAT).ToList();
                baoCaoDieuChinhLuaChonNhaThau.goiThauDeXuats = GetGoiThauPheDuyetDieuChinhDeXuats(chiTietGoiThauDeXuats, goiThauDtos, hinhThucDtos, phuongThucDtos, loaiHopDongDtos);
                baoCaoDieuChinhLuaChonNhaThau.nhanXetDanhGiaCoQuanThamDinh = hoSoCongTrinhChiTiet.DanhGiaCoQuanThamDinh;
                baoCaoDieuChinhLuaChonNhaThau.tenChuyenVien = tenChuyenVien;
                baoCaoDieuChinhLuaChonNhaThau.noiDungTrinhVaKienNghi = _markdown.Transform(hoSoCongTrinhChiTiet.NoiDungTrinhVaKienNghi);
            }

            var jsonData = JsonConvert.SerializeObject(baoCaoDieuChinhLuaChonNhaThau);

            return jsonData;
        }

        public async Task<dynamic> GetDataDeXuatAsync(Guid id, Guid chiTietId)
        {
            var hoSoCongTrinh = await _hoSoCongTrinhRepository.GetEntityByIdAsync(id);
            if (hoSoCongTrinh == null) throw new BusinessException("");
            var congTrinhDto = await _congTrinhAppService.GetCongTrinhDetailAsync(hoSoCongTrinh.CongTrinhId);
            var user = await _userManager.GetByIdAsync(_currentUser.GetId());
            var tenChuyenVien = $"{user.Surname} {user.Name}";

            var baoCaoDeXuatChuTruongDauTu = new BaoCaoDeXuatChuTruongDauTu();
            baoCaoDeXuatChuTruongDauTu.year = DateTime.Now.ToLocalDate().ToDateTimeDefault(HoSoConstants.DateTimeFormat.YearOnly);
            baoCaoDeXuatChuTruongDauTu.month = DateTime.Now.ToLocalDate().ToDateTimeDefault(HoSoConstants.DateTimeFormat.MonthOnly);
            baoCaoDeXuatChuTruongDauTu.day = DateTime.Now.ToLocalDate().ToDateTimeDefault(HoSoConstants.DateTimeFormat.DateOnly);
            baoCaoDeXuatChuTruongDauTu.tenCongTrinh = congTrinhDto.TenCongTrinh ??= string.Empty;
            baoCaoDeXuatChuTruongDauTu.nhomDuAn = congTrinhDto.TenNhomCongTrinh;
            baoCaoDeXuatChuTruongDauTu.tenChuDauTu = congTrinhDto.TenChuDauTu;
            baoCaoDeXuatChuTruongDauTu.thoiGianThucHien = $"{congTrinhDto.ThoiGianThucHienTuNgay.ToDateTimeDefault(HoSoConstants.DateTimeFormat.YearOnly)} - {congTrinhDto.ThoiGianThucHienDenNgay.ToDateTimeDefault(HoSoConstants.DateTimeFormat.YearOnly)}";

            var hoSoCongTrinhChiTiet = hoSoCongTrinh.HoSoCongTrinhChiTiets.FirstOrDefault(s => s.Id == chiTietId);
            if (hoSoCongTrinhChiTiet != null)
            {
                // co so phap ly
                var coSoPhapLys = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCoSoPhapLys.OrderBy(s => s.OrderIndex).ToList();
                var coSoPhapLyIds = coSoPhapLys.Where(s => s.ThuVienVanBanId != null).Select(s => (Guid)s.ThuVienVanBanId);
                var thuVienVanBanDtos = await _thuVienVanBanAppService.GetCoSoPhapLyByIds(coSoPhapLyIds.Distinct().ToList());
                baoCaoDeXuatChuTruongDauTu.coSoPhapLys = GetDataCoSoPhapLyReport(coSoPhapLys, thuVienVanBanDtos);
                // thanh phan ho so
                var thanhPhanHoSos = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietThanhPhanHoSos.OrderBy(s => s.OrderIndex).ToList();
                var donViBanHanhIds = thanhPhanHoSos.Where(s => s.DonViBanHanhId != null).Select(s => (Guid)s.DonViBanHanhId).ToList();
                var donViBanHanhDtos = await _donViBanHanhAppService.GetListByIds(donViBanHanhIds);
                var thanhPhanHoSoDtos = await _thanhPhanHoSoAppService.GetThanhPhanHoSoByIds(thanhPhanHoSos.Select(s => s.ThanhPhanHoSoId).Distinct().ToList());
                baoCaoDeXuatChuTruongDauTu.thanhPhanHoSos = GetDataThanhPhanHoSoReport(thanhPhanHoSos, thanhPhanHoSoDtos, donViBanHanhDtos);
                var thanhPhanHoSo = thanhPhanHoSos.FirstOrDefault();
                baoCaoDeXuatChuTruongDauTu.toTrinhSo = thanhPhanHoSo != null ? thanhPhanHoSo.SoKyHieu : string.Empty;
                baoCaoDeXuatChuTruongDauTu.ngayTrinh = thanhPhanHoSo != null ? thanhPhanHoSo.NgayBanHanh.ToDateTimeDefault(HoSoConstants.DateTimeFormat.Date) : string.Empty;
                // dia diem xay Dung
                var diaDiemXayDungs = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietDiaDiems;
                var donViHanhChinhChaDtos = await _donViHanhChinhAppService.GetDonViCapThanhPhoHuyenThiXa();
                var donViHanhChinhDtos = await _donViHanhChinhAppService.GetListByIdsAsync(diaDiemXayDungs.Select(s => s.DonViHanhChinhId).Distinct().ToList());
                baoCaoDeXuatChuTruongDauTu.diaDiems = ConvertDiaDiemReport(diaDiemXayDungs, donViHanhChinhChaDtos, donViHanhChinhDtos);
                // nguon von
                var nguonVons = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietNguonVons;
                var nguonVonDtos = await _nguonVonAppService.GetNguonVonsByIdsAsync(nguonVons.Select(s => s.NguonVonId).Distinct().ToList());
                baoCaoDeXuatChuTruongDauTu.nguonVons = GetDataNguonVonReport(nguonVons, nguonVonDtos, true);

                var donViPhoiHops = new List<CapQuyetDinhThamDinhDto>();
                if (hoSoCongTrinhChiTiet.DonViPhoiHopThamDinhs != null)
                {
                    try
                    {
                        donViPhoiHops = JsonConvert.DeserializeObject<List<CapQuyetDinhThamDinhDto>>(hoSoCongTrinhChiTiet.DonViPhoiHopThamDinhs);
                    }
                    finally { }
                }
                var chuDauTuDtos = await _chuDauTuAppService.GetListByIdsAsync(GetDonViIds(hoSoCongTrinhChiTiet, donViPhoiHops).Distinct().ToList());
                var donViChuTri = chuDauTuDtos.FirstOrDefault(s => s.Id == (Guid)hoSoCongTrinhChiTiet.DonViChuTriThamDinhId);
                baoCaoDeXuatChuTruongDauTu.donViChuTriThamDinh = donViChuTri != null ? donViChuTri.Ten : string.Empty;
                var capChuTriDauTu = chuDauTuDtos.FirstOrDefault(s => s.Id == (Guid)hoSoCongTrinhChiTiet.CapQuyetDinhChuTruongDauTu);
                baoCaoDeXuatChuTruongDauTu.capQuyetDinhChuTruongDauTu = capChuTriDauTu != null ? capChuTriDauTu.Ten : string.Empty;
                var capDauTu = chuDauTuDtos.FirstOrDefault(s => s.Id == (Guid)hoSoCongTrinhChiTiet.CapQuyetDinhDauTuDuAn);
                baoCaoDeXuatChuTruongDauTu.capQuyetDinhDauTuDuAn = capDauTu != null ? capDauTu.Ten : string.Empty;
                baoCaoDeXuatChuTruongDauTu.tenDonViPhoiHops = GetDonViPhoiHopReport(donViPhoiHops, chuDauTuDtos);
                baoCaoDeXuatChuTruongDauTu.hinhThucThamDinh = hoSoCongTrinhChiTiet.HinhThucThamDinh.GetDescription();
                baoCaoDeXuatChuTruongDauTu.duKienTongMucDauTu = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietNguonVons.Sum(s => s.GiaTriThamDinh).FormatCurrency() + " đồng";
                baoCaoDeXuatChuTruongDauTu.nganhLinhVucSuDung = string.Empty;
                if (hoSoCongTrinhChiTiet.NganhLinhVucSuDungId != null && hoSoCongTrinhChiTiet.NganhLinhVucSuDungId != Guid.Empty)
                {
                    var nganhLinhVucDto = await _nganhLinhVucSuDungAppService.GetAsync((Guid)hoSoCongTrinhChiTiet.NganhLinhVucSuDungId);
                    baoCaoDeXuatChuTruongDauTu.nganhLinhVucSuDung = nganhLinhVucDto != null ? nganhLinhVucDto.TenNganhLinhVucSuDung : string.Empty;
                }
                baoCaoDeXuatChuTruongDauTu.yKienDonViPhoiHop = _markdown.Transform(hoSoCongTrinhChiTiet.YKienThamDinhDonViPhoiHop);
                baoCaoDeXuatChuTruongDauTu.suCanThietDauTuDuAn = hoSoCongTrinhChiTiet.SuCanThietDauTuDuAn ??= string.Empty;
                baoCaoDeXuatChuTruongDauTu.suTuanThuQuyDinh = hoSoCongTrinhChiTiet.SuTuanThuQuyDinh ??= string.Empty;
                baoCaoDeXuatChuTruongDauTu.suPhuHopMucTieuChienLuoc = hoSoCongTrinhChiTiet.SuPhuHopMucTieuChienLuoc ??= string.Empty;
                baoCaoDeXuatChuTruongDauTu.suPhuHopTieuChi = hoSoCongTrinhChiTiet.SuPhuHopMucTieuPhanLoai ??= string.Empty;
                baoCaoDeXuatChuTruongDauTu.cacNoiDungDauTu = _markdown.Transform(hoSoCongTrinhChiTiet.NoiDungDauTu);
                baoCaoDeXuatChuTruongDauTu.yKienDonViThamDinh = hoSoCongTrinhChiTiet.YKienCuaDonViThamDinh ??= string.Empty;
                baoCaoDeXuatChuTruongDauTu.mucTieuDauTu = hoSoCongTrinhChiTiet.MucTieuDauTu ??= string.Empty;
                baoCaoDeXuatChuTruongDauTu.quyMoVaHinhThucDauTu = hoSoCongTrinhChiTiet.QuyMoDauTu ??= string.Empty;
                baoCaoDeXuatChuTruongDauTu.tenChuyenVien = tenChuyenVien;
                baoCaoDeXuatChuTruongDauTu.noiDungTrinhVaKienNghi = _markdown.Transform(hoSoCongTrinhChiTiet.NoiDungTrinhVaKienNghi);
            }

            var jsonData = JsonConvert.SerializeObject(baoCaoDeXuatChuTruongDauTu);

            return jsonData;
        }

        public async Task<dynamic> GetDataDeXuatDieuChinhAsync(Guid id, Guid chiTietId)
        {
            var hoSoCongTrinh = await _hoSoCongTrinhRepository.GetEntityByIdAsync(id);
            if (hoSoCongTrinh == null) throw new BusinessException("");
            var congTrinhDto = await _congTrinhAppService.GetCongTrinhDetailAsync(hoSoCongTrinh.CongTrinhId);

            var baoCaoDeXuatChuTruongDauTu = new BaoCaoDieuChinhChuTruongDauTu();
            baoCaoDeXuatChuTruongDauTu.year = DateTime.Now.ToLocalDate().ToDateTimeDefault(HoSoConstants.DateTimeFormat.YearOnly);
            baoCaoDeXuatChuTruongDauTu.month = DateTime.Now.ToLocalDate().ToDateTimeDefault(HoSoConstants.DateTimeFormat.MonthOnly);
            baoCaoDeXuatChuTruongDauTu.day = DateTime.Now.ToLocalDate().ToDateTimeDefault(HoSoConstants.DateTimeFormat.DateOnly);
            baoCaoDeXuatChuTruongDauTu.tenCongTrinh = congTrinhDto.TenCongTrinh ??= string.Empty;
            baoCaoDeXuatChuTruongDauTu.nhomDuAn = congTrinhDto.TenNhomCongTrinh;
            baoCaoDeXuatChuTruongDauTu.tenChuDauTu = congTrinhDto.TenChuDauTu;

            var hoSoCongTrinhChiTiet = hoSoCongTrinh.HoSoCongTrinhChiTiets.FirstOrDefault(s => s.Id == chiTietId);
            if (hoSoCongTrinhChiTiet != null)
            {
                // co so phap ly
                var coSoPhapLys = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCoSoPhapLys.OrderBy(s => s.OrderIndex).ToList();
                var coSoPhapLyIds = coSoPhapLys.Where(s => s.ThuVienVanBanId != null).Select(s => (Guid)s.ThuVienVanBanId);
                var thuVienVanBanDtos = await _thuVienVanBanAppService.GetCoSoPhapLyByIds(coSoPhapLyIds.Distinct().ToList());
                baoCaoDeXuatChuTruongDauTu.coSoPhapLys = GetDataCoSoPhapLyReport(coSoPhapLys, thuVienVanBanDtos);
                // thanh phan ho so
                var thanhPhanHoSos = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietThanhPhanHoSos.OrderBy(s => s.OrderIndex).ToList();
                var donViBanHanhIds = thanhPhanHoSos.Where(s => s.DonViBanHanhId != null).Select(s => (Guid)s.DonViBanHanhId).ToList();
                var donViBanHanhDtos = await _donViBanHanhAppService.GetListByIds(donViBanHanhIds);
                var thanhPhanHoSoDtos = await _thanhPhanHoSoAppService.GetThanhPhanHoSoByIds(thanhPhanHoSos.Select(s => s.ThanhPhanHoSoId).Distinct().ToList());
                baoCaoDeXuatChuTruongDauTu.thanhPhanHoSos = GetDataThanhPhanHoSoReport(thanhPhanHoSos, thanhPhanHoSoDtos, donViBanHanhDtos);
                var thanhPhanHoSo = thanhPhanHoSos.FirstOrDefault();
                baoCaoDeXuatChuTruongDauTu.toTrinhSo = thanhPhanHoSo != null ? thanhPhanHoSo.SoKyHieu : string.Empty;
                baoCaoDeXuatChuTruongDauTu.ngayTrinh = thanhPhanHoSo != null ? thanhPhanHoSo.NgayBanHanh.ToDateTimeDefault(HoSoConstants.DateTimeFormat.Date) : string.Empty;
                // dia diem xay Dung
                var diaDiemXayDungs = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietDiaDiems;
                var donViHanhChinhChaDtos = await _donViHanhChinhAppService.GetDonViCapThanhPhoHuyenThiXa();
                var donViHanhChinhDtos = await _donViHanhChinhAppService.GetListByIdsAsync(diaDiemXayDungs.Select(s => s.DonViHanhChinhId).Distinct().ToList());
                baoCaoDeXuatChuTruongDauTu.diaDiems = ConvertDiaDiemReport(diaDiemXayDungs, donViHanhChinhChaDtos, donViHanhChinhDtos);
                baoCaoDeXuatChuTruongDauTu.mucDauTuPheDuyet = $"{hoSoCongTrinhChiTiet.MucDauTuPheDuyet.FormatCurrency()} đồng";
                baoCaoDeXuatChuTruongDauTu.mucDauTuBoSung = $"{hoSoCongTrinhChiTiet.MucDauTuBoSung.FormatCurrency()} đồng";
                // nguon von
                var nguonVons = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietNguonVons;
                var nguonVonDtos = await _nguonVonAppService.GetNguonVonsByIdsAsync(nguonVons.Select(s => s.NguonVonId).Distinct().ToList());
                baoCaoDeXuatChuTruongDauTu.nguonVons = GetDataNguonVonReport(nguonVons, nguonVonDtos);
                baoCaoDeXuatChuTruongDauTu.noiDungDieuChinh = _markdown.Transform(hoSoCongTrinhChiTiet.NoiDungQuyMoDauTuDeXuatDieuChinh);
                var donViPhoiHops = new List<CapQuyetDinhThamDinhDto>();
                if (hoSoCongTrinhChiTiet.DonViPhoiHopThamDinhs != null)
                {
                    try
                    {
                        donViPhoiHops = JsonConvert.DeserializeObject<List<CapQuyetDinhThamDinhDto>>(hoSoCongTrinhChiTiet.DonViPhoiHopThamDinhs);
                    }
                    finally { }
                }
                var chuDauTuDtos = await _chuDauTuAppService.GetListByIdsAsync(GetDonViIds(hoSoCongTrinhChiTiet, donViPhoiHops).Distinct().ToList());
                var donViChuTri = chuDauTuDtos.FirstOrDefault(s => s.Id == (Guid)hoSoCongTrinhChiTiet.DonViChuTriThamDinhId);
                baoCaoDeXuatChuTruongDauTu.donViChuTriThamDinh = donViChuTri != null ? donViChuTri.Ten : string.Empty;
                var capChuTriDauTu = chuDauTuDtos.FirstOrDefault(s => s.Id == (Guid)hoSoCongTrinhChiTiet.CapQuyetDinhChuTruongDauTu);
                baoCaoDeXuatChuTruongDauTu.capQuyetDinhChuTruongDauTu = capChuTriDauTu != null ? capChuTriDauTu.Ten : string.Empty;
                var capDauTu = chuDauTuDtos.FirstOrDefault(s => s.Id == (Guid)hoSoCongTrinhChiTiet.CapQuyetDinhDauTuDuAn);
                baoCaoDeXuatChuTruongDauTu.capQuyetDinhDauTuDuAn = capDauTu != null ? capDauTu.Ten : string.Empty;
                baoCaoDeXuatChuTruongDauTu.tenDonViPhoiHops = GetDonViPhoiHopReport(donViPhoiHops, chuDauTuDtos);
                baoCaoDeXuatChuTruongDauTu.hinhThucThamDinh = hoSoCongTrinhChiTiet.HinhThucThamDinh.GetDescription();
                baoCaoDeXuatChuTruongDauTu.suCanThietDauTuDuAn = hoSoCongTrinhChiTiet.SuCanThietDauTuDuAn ??= string.Empty;
                baoCaoDeXuatChuTruongDauTu.suTuanThuQuyDinh = hoSoCongTrinhChiTiet.SuTuanThuQuyDinh ??= string.Empty;
                baoCaoDeXuatChuTruongDauTu.suPhuHopMucTieuChienLuoc = hoSoCongTrinhChiTiet.SuPhuHopMucTieuChienLuoc ??= string.Empty;
                baoCaoDeXuatChuTruongDauTu.suPhuHopTieuChi = hoSoCongTrinhChiTiet.SuPhuHopMucTieuPhanLoai ??= string.Empty;
                baoCaoDeXuatChuTruongDauTu.cacNoiDungDauTu = _markdown.Transform(hoSoCongTrinhChiTiet.NoiDungDauTu);
                baoCaoDeXuatChuTruongDauTu.yKienDonViThamDinh = hoSoCongTrinhChiTiet.YKienCuaDonViThamDinh ??= string.Empty;
                baoCaoDeXuatChuTruongDauTu.noiDungTrinhVaKienNghi = _markdown.Transform(hoSoCongTrinhChiTiet.NoiDungTrinhVaKienNghi);
            }

            var jsonData = JsonConvert.SerializeObject(baoCaoDeXuatChuTruongDauTu);

            return jsonData;
        }

        private List<ThamDinhCoSoPhapLy> GetThamDinhCanCuPhapLys(HoSoCongTrinhChiTiet hoSoCongTrinhChiTiet)
        {
            var list = new List<ThamDinhCoSoPhapLy>();
            var coSoPhapLys = JsonConvert.DeserializeObject<List<KetQuaThamDinhPhapLyDto>>(hoSoCongTrinhChiTiet.KetQuaThamDinhCanCuPhapLys);
            foreach (var item in coSoPhapLys)
            {
                var thamDinh = new ThamDinhCoSoPhapLy();
                thamDinh.noiDungKiemTra = item.TenNoiDungKiemTra;
                if (item.IsKetQuaThamDinh)
                {
                    thamDinh.coKetQua = "X";
                    thamDinh.khongCoKetQua = string.Empty;
                }
                else
                {
                    thamDinh.coKetQua = string.Empty;
                    thamDinh.khongCoKetQua = "X";
                }
                list.Add(thamDinh);
            }
            return list;
        }

        private List<CongViecGoiThau> GetCongViecDaThucHiens(HoSoCongTrinhChiTiet hoSoCongTrinhChiTiet, List<GoiThauDto> goiThauDtos, ref decimal giaTriCongViecThucHien)
        {
            var list = new List<CongViecGoiThau>();
            var listCongViecDaThucHiens = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCongViecs.Where(s => s.LoaiCongViec == Enums.LoaiCongViecEnums.CONGVIEC_DUOC_THUCHIEN);
            giaTriCongViecThucHien = listCongViecDaThucHiens.Sum(s => s.GiaTriThucHien);
            foreach (var item in listCongViecDaThucHiens)
            {
                var congViec = new CongViecGoiThau();
                var goiThau = goiThauDtos.FirstOrDefault(s => s.Id == item.CongViecGoiThauId);
                congViec.noiDungCongViec = goiThau != null ? goiThau.TenGoiThau : string.Empty;
                congViec.donViThucHien = item.DonViThucHien;
                congViec.giaTriThucHien = $"{item.GiaTriThucHien.FormatCurrency()}";
                list.Add(congViec);
            }
            return list;
        }

        private List<CongViecGoiThau> GetCongViecKhongApDungs(HoSoCongTrinhChiTiet hoSoCongTrinhChiTiet,
            List<GoiThauDto> goiThauDtos,
            List<ChuDauTuDto> donViThucHiens,
            ref decimal giaTriCongViecKhongApDung)
        {
            var list = new List<CongViecGoiThau>();
            var listCongViecKhongApDungs = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCongViecs.Where(s => s.LoaiCongViec == Enums.LoaiCongViecEnums.CONGVIEC_KHONG_APDUNG);
            giaTriCongViecKhongApDung = listCongViecKhongApDungs.Sum(s => s.GiaTriThucHien);
            foreach (var item in listCongViecKhongApDungs)
            {
                var congViec = new CongViecGoiThau();
                var goiThau = goiThauDtos.FirstOrDefault(s => s.Id == item.CongViecGoiThauId);
                var donViThucHien = donViThucHiens.FirstOrDefault(s => s.Id == item.DonViThucHienId);
                congViec.noiDungCongViec = goiThau != null ? goiThau.TenGoiThau : string.Empty;
                congViec.donViThucHien = donViThucHien == null ? string.Empty : donViThucHien.Ten;
                congViec.giaTriThucHien = $"{item.GiaTriThucHien.FormatCurrency()}";
                list.Add(congViec);
            }
            return list;
        }

        /// <summary>
        /// get danh sách công việc thuộc kế hoạch lựa chọn nhà thầu
        /// </summary>
        /// <param name="hoSoCongTrinhChiTiet"></param>
        /// <returns></returns>
        private List<ThamDinhCoSoPhapLy> GetCongViecThuocKeHoachs(HoSoCongTrinhChiTiet hoSoCongTrinhChiTiet, List<GoiThauDto> goiThauDtos)
        {
            var list = new List<ThamDinhCoSoPhapLy>();
            var congviecs = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCongViecs.Where(s => s.LoaiCongViec == Enums.LoaiCongViecEnums.CONGVIEC_LUACHON_NHATHAU);
            foreach (var item in congviecs)
            {
                var congViec = new ThamDinhCoSoPhapLy();
                var goiThau = goiThauDtos.FirstOrDefault(s => s.Id == item.CongViecGoiThauId);
                congViec.noiDungKiemTra = goiThau != null ? goiThau.TenGoiThau : string.Empty;
                if (item.IsTuanThuPhuHop)
                {
                    congViec.coKetQua = "X";
                    congViec.khongCoKetQua = string.Empty;
                }
                else
                {
                    congViec.coKetQua = string.Empty;
                    congViec.khongCoKetQua = "X";
                }
                list.Add(congViec);
            }
            return list;
        }

        /// <summary>
        /// get data phần công việc chưa đủ điều kiện lập kế hoạch nhà thầu
        /// </summary>
        /// <param name="hoSoCongTrinhChiTiet"></param>
        /// <returns></returns>
        private List<CongViecGoiThau> GetCongViecChuaDuDieuKiens(HoSoCongTrinhChiTiet hoSoCongTrinhChiTiet, List<GoiThauDto> goiThauDtos, ref decimal giaTriCongViecChuaDuDieuKien)
        {
            var list = new List<CongViecGoiThau>();
            var listCongViecChuaDuDieuKiens = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCongViecs.Where(s => s.LoaiCongViec == Enums.LoaiCongViecEnums.CONGVIEC_CHUADUDIEUKIEN_LUACHON_NHATHAU);
            giaTriCongViecChuaDuDieuKien = listCongViecChuaDuDieuKiens.Sum(s => s.GiaTriThucHien);
            foreach (var item in listCongViecChuaDuDieuKiens)
            {
                var congViec = new CongViecGoiThau();
                var goiThau = goiThauDtos.FirstOrDefault(s => s.Id == item.CongViecGoiThauId);
                congViec.noiDungCongViec = goiThau != null ? goiThau.TenGoiThau : string.Empty;
                congViec.giaTriThucHien = $"{item.GiaTriThucHien.FormatCurrency()}";
                list.Add(congViec);
            }
            return list;
        }

        /// <summary>
        /// get data gói thầu kiến nghị
        /// </summary>
        /// <param name="hoSoCongTrinhChiTiet"></param>
        /// <returns></returns>
        private List<GoiThauKienNghi> GetGoiThauKienNghis(HoSoCongTrinhChiTiet hoSoCongTrinhChiTiet,
            List<GoiThauDto> goiThauDtos,
            List<HinhThucChonNhaThauDto> hinhThucDtos,
            List<PhuongThucDauThauDto> phuongThucDtos,
            List<HinhThucHopDongDto> loaiHopDongDtos,
            ref decimal giaTriCongViecThuocKeHoach)
        {
            var chiTietGoiThaus = hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Where(s => s.LoaiKeHoach == Enums.LoaiCongViecEnums.GOITHAU_KIENNGHI).ToList();
            giaTriCongViecThuocKeHoach = chiTietGoiThaus.Where(s => s.GiaGoiThau != null).Sum(s => (decimal)s.GiaGoiThau);
            return GetGoiThauPheDuyetDieuChinhDeXuats(chiTietGoiThaus, goiThauDtos, hinhThucDtos, phuongThucDtos, loaiHopDongDtos); ;
        }

        private List<string> GetDataThanhPhanHoSoReport(List<HoSoCongTrinhChiTietThanhPhanHoSo> thanhPhanHoSos, List<ThanhPhanHoSoDto> thanhPhanHoSoDtos, List<DonViBanHanhDto> donViBanHanhDtos)
        {
            var list = new List<string>();

            foreach (var item in thanhPhanHoSos)
            {
                var thanhPhanHoSoDto = thanhPhanHoSoDtos.FirstOrDefault(s => s.Id == item.ThanhPhanHoSoId);
                var donViBanHanh = donViBanHanhDtos.FirstOrDefault(s => s.Id == item.DonViBanHanhId);
                if (thanhPhanHoSoDto == null) continue;

                var tenDonViBanHanh = donViBanHanh != null ? donViBanHanh.Ten : string.Empty;
                list.Add($"Căn cứ {thanhPhanHoSoDto.TenThanhPhanHoSo} số {item.SoKyHieu} ngày {item.NgayBanHanh.ToDateTimeDefault(HoSoConstants.DateTimeFormat.Date)} của {tenDonViBanHanh} về {item.TrichYeu};");
                list.Add("\r\n");
            }
            if (list.Any())
            {
                list.RemoveAt(list.Count - 1);
            }
            return list;
        }

        private List<string> GetDataCoSoPhapLyReport(List<HoSoCongTrinhChiTietCoSoPhapLy> chiTietCoSoPhapLys, List<ThuVienVanBanDto> coSoPhapLyDtos)
        {
            var list = new List<string>();

            foreach (var item in chiTietCoSoPhapLys)
            {
                if (item.ThuVienVanBanId != null)
                {
                    var coSoPhapLy = coSoPhapLyDtos.FirstOrDefault(s => s.Id == item.ThuVienVanBanId);
                    if (coSoPhapLy == null) continue;
                    var donViBanHanh = string.Empty;
                    if (!string.IsNullOrEmpty(coSoPhapLy.DonViBanHanh))
                    {
                        donViBanHanh = $" của {coSoPhapLy.DonViBanHanh}";
                    }
                    var trichYeu = string.Empty;
                    if (!string.IsNullOrEmpty(coSoPhapLy.TrichYeu))
                    {
                        trichYeu = $" về {coSoPhapLy.TrichYeu}";
                    }
                    list.Add($"Căn cứ {coSoPhapLy.TenLoaiVanBan} số {coSoPhapLy.SoKyHieu} ngày {coSoPhapLy.NgayBanHanh.ToDateTimeDefault(HoSoConstants.DateTimeFormat.Date)}{donViBanHanh}{trichYeu};");
                    list.Add("\r\n");
                }
                else
                {
                    try
                    {
                        var coSoPhapLyJson = JsonConvert.DeserializeObject<CoSoPhapLyJsonViewModel>(item.NoiDungJson);
                        var donViBanHanh = string.Empty;
                        if (!string.IsNullOrEmpty(coSoPhapLyJson.DonViBanHanh))
                        {
                            donViBanHanh = $" của {coSoPhapLyJson.DonViBanHanh}";
                        }
                        var trichYeu = string.Empty;
                        if (!string.IsNullOrEmpty(coSoPhapLyJson.TrichYeu))
                        {
                            trichYeu = $" về {coSoPhapLyJson.TrichYeu}";
                        }
                        list.Add($"Căn cứ {coSoPhapLyJson.TenLoaiVanBan} số {coSoPhapLyJson.SoKyHieu} ngày {coSoPhapLyJson.NgayBanHanh.ToDateTimeDefault(HoSoConstants.DateTimeFormat.Date)}{donViBanHanh}{trichYeu};");
                        list.Add("\r\n");
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            if (list.Any())
            {
                list.RemoveAt(list.Count - 1);
            }
            return list;
        }

        private List<GoiThauKienNghi> GetGoiThauPheDuyetDieuChinhDeXuats(List<HoSoCongTrinhChiTietGoiThau> chiTietGoiThaus,
            List<GoiThauDto> goiThauDtos,
            List<HinhThucChonNhaThauDto> hinhThucDtos,
            List<PhuongThucDauThauDto> phuongThucDtos,
            List<HinhThucHopDongDto> loaiHopDongDtos)
        {
            var list = new List<GoiThauKienNghi>();
            var chiTietGoiThauChas = chiTietGoiThaus.Where(s => s.GoiThauParentId == null || s.GoiThauParentId == Guid.Empty);
            var index = 1;
            foreach (var item in chiTietGoiThauChas)
            {
                var goiThauKienNghi = new GoiThauKienNghi();
                var goiThauDto = goiThauDtos.FirstOrDefault(s => s.Id == item.GoiThauId);
                goiThauKienNghi.tenGoiThauCha = goiThauDto != null ? $"{index.ToRoman()}. {goiThauDto.TenGoiThau}" : string.Empty;
                var listGoiThauCons = new List<GoiThauCon>();
                foreach (var chiTietGoiThauCon in chiTietGoiThaus.Where(s => s.GoiThauParentId == item.GoiThauId))
                {
                    var goiThauCon = new GoiThauCon();
                    var goiThauConDto = goiThauDtos.FirstOrDefault(s => s.Id == chiTietGoiThauCon.GoiThauId);
                    goiThauCon.tenGoiThau = goiThauConDto != null ? goiThauConDto.TenGoiThau : string.Empty;
                    goiThauCon.giaGoiThau = chiTietGoiThauCon.GiaGoiThau == null ? string.Empty : $"{chiTietGoiThauCon.GiaGoiThau.FormatCurrency()}";
                    var hinhThucDto = hinhThucDtos.FirstOrDefault(s => s.Id == chiTietGoiThauCon.HinhThucLuaChonNhaThauId);
                    goiThauCon.tenHinhThuc = hinhThucDto == null ? string.Empty : hinhThucDto.TenHinhThucChonNhaThau;
                    var phuongThucDto = phuongThucDtos.FirstOrDefault(s => s.Id == chiTietGoiThauCon.PhuongThucLuaChonNhaThauId);
                    goiThauCon.tenPhuongThuc = phuongThucDto == null ? string.Empty : phuongThucDto.TenPhuongThucDauThau;
                    goiThauCon.thoiGianBatDau = chiTietGoiThauCon.ThoiGianBatDau;
                    var loaiHopDongDto = loaiHopDongDtos.FirstOrDefault(s => s.Id == chiTietGoiThauCon.LoaiHopDongId);
                    goiThauCon.loaiHopDong = loaiHopDongDto == null ? string.Empty : loaiHopDongDto.TenHinhThucHopDong;
                    goiThauCon.thoiGianThucHien = chiTietGoiThauCon.ThoiGianThucHien;
                    listGoiThauCons.Add(goiThauCon);
                }
                goiThauKienNghi.goiThauCons = listGoiThauCons;
                list.Add(goiThauKienNghi);
                index++;
            }

            return list;
        }

        private List<Guid> GetDonViIds(HoSoCongTrinhChiTiet hoSoCongTrinhChiTiet, List<CapQuyetDinhThamDinhDto> donViPhoiHops)
        {
            var donViIds = new List<Guid>();
            if (hoSoCongTrinhChiTiet.DonViChuTriThamDinhId != null)
            {
                donViIds.Add((Guid)hoSoCongTrinhChiTiet.DonViChuTriThamDinhId);
            }
            if (hoSoCongTrinhChiTiet.CapQuyetDinhChuTruongDauTu != null)
            {
                donViIds.Add((Guid)hoSoCongTrinhChiTiet.CapQuyetDinhChuTruongDauTu);
            }
            if (hoSoCongTrinhChiTiet.CapQuyetDinhDauTuDuAn != null)
            {
                donViIds.Add((Guid)hoSoCongTrinhChiTiet.CapQuyetDinhDauTuDuAn);
            }
            foreach (var item in donViPhoiHops)
            {
                donViIds.Add(item.Id);
            }
            return donViIds;
        }

        private string GetDonViPhoiHopReport(List<CapQuyetDinhThamDinhDto> donViPhoiHops, List<ChuDauTuDto> chuDauTuDtos)
        {
            var tenDonViPhoiHops = new StringBuilder();
            foreach (var item in donViPhoiHops)
            {
                var donViPhoiHop = chuDauTuDtos.FirstOrDefault(s => s.Id == item.Id);
                if (donViPhoiHop == null) continue;
                tenDonViPhoiHops.Append($"{donViPhoiHop.Ten}, ");
            }
            if (tenDonViPhoiHops.Length > 1)
            {
                tenDonViPhoiHops.Length = tenDonViPhoiHops.Length - 2;
            }
            return tenDonViPhoiHops.ToString();
        }

        private List<string> GetDataNguonVonReport(List<HoSoCongTrinhChiTietNguonVon> nguonVons, List<NguonVonDto> nguonVonDtos, bool isBaoCaoDeXuat = false)
        {
            var list = new List<string>();
            foreach (var item in nguonVons)
            {
                var nguonVonDto = nguonVonDtos.FirstOrDefault(s => s.Id == item.NguonVonId);
                if (nguonVonDto == null) continue;
                if (isBaoCaoDeXuat)
                {
                    list.Add($"- {nguonVonDto.TenNguonVon}: {item.GiaTriThamDinh.FormatCurrency()} đồng.");
                }
                else
                {
                    list.Add($"- {nguonVonDto.TenNguonVon}: {item.GiaTriNguonVon} đồng.");
                }
                list.Add("\r\n");
            }
            if (list.Any())
            {
                list.RemoveAt(list.Count - 1);
            }
            return list;
        }

        private string ConvertDiaDiemReport(List<HoSoCongTrinhChiTietDiaDiem> diaDiems, List<DonViHanhChinhDto> donViHanhChinhChaDtos, List<DonViHanhChinhDto> donViHanhChinhDtos)
        {
            var stringBuilder = new StringBuilder();
            foreach (var item in diaDiems)
            {
                var thanhPhoHuyenThiXa = donViHanhChinhChaDtos.FirstOrDefault(s => s.Id == item.DonViHanhChinhId);
                if (thanhPhoHuyenThiXa != null)
                {
                    stringBuilder.Append($"{thanhPhoHuyenThiXa.TenDonViHanhChinh}.");
                }
                else
                {
                    var phuongXaThiTran = donViHanhChinhDtos.FirstOrDefault(s => s.Id == item.DonViHanhChinhId);
                    if (phuongXaThiTran != null)
                    {
                        var donViHanhChinhChaDto = donViHanhChinhChaDtos.FirstOrDefault(s => s.Id == phuongXaThiTran.ParentId);
                        if (donViHanhChinhChaDto == null) continue;
                        var ghiChu = item.GhiChu != null ? $"{item.GhiChu.Trim()}," : string.Empty;
                        var tenPhuong = phuongXaThiTran.TenDonViHanhChinh != null ? $"{phuongXaThiTran.TenDonViHanhChinh.Trim()}," : string.Empty;
                        var tenThanhPho = donViHanhChinhChaDto.TenDonViHanhChinh != null ? $"{donViHanhChinhChaDto.TenDonViHanhChinh.Trim()}" : string.Empty;
                        stringBuilder.Append($"{ghiChu} {tenPhuong} {tenThanhPho}, tỉnh Quảng Nam.");
                    }
                }
            }

            if (stringBuilder.Length > 0)
            {
                stringBuilder.Length--;
            }

            return stringBuilder.ToString();
        }
    }
}