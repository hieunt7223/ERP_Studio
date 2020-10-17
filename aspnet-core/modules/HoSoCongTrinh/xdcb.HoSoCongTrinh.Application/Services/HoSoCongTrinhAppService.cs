using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Users;
using xdcb.Common.DanhMuc.ChuDauTus;
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGias;
using xdcb.Common.DanhMuc.CongTrinhs;
using xdcb.Common.DanhMuc.DonViHanhChinhs;
using xdcb.Common.DanhMuc.LoaiCongTrinhs;
using xdcb.Common.DanhMuc.LoaiHoSos;
using xdcb.Common.DanhMuc.LoaiKhoans;
using xdcb.Common.DanhMuc.NhomCongTrinhs;
using xdcb.Common.DanhMuc.ThanhPhanHoSos;
using xdcb.Common.DanhMuc.ThuVienVanBans;
using xdcb.HoSoCongTrinh.Constants;
using xdcb.HoSoCongTrinh.Dtos;
using xdcb.HoSoCongTrinh.Entities;
using xdcb.HoSoCongTrinh.Enums;
using xdcb.HoSoCongTrinh.Extensions;
using xdcb.HoSoCongTrinh.Permissions;
using xdcb.HoSoCongTrinh.Repositories;

namespace xdcb.HoSoCongTrinh.Services
{
    public class HoSoCongTrinhAppService : CrudAppService<Entities.HoSoCongTrinh, HoSoCongTrinhDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateHoSoCongTrinhDto, CreateUpdateHoSoCongTrinhDto>,
        IHoSoCongTrinhAppService
    {
        private readonly IViewHoSoCongTrinhRepository _viewHoSoCongTrinhRepository;
        private readonly IHoSoCongTrinhRepository _hoSoCongTrinhRepository;
        private readonly IHoSoCongTrinhChiTietRepository _hoSoCongTrinhChiTietRepository;

        private readonly IChuDauTuAppService _chuDauTuAppService;
        private readonly ILoaiKhoanAppService _loaiKhoanAppService;
        private readonly IChuongTrinhMucTieuQuocGiaAppService _chuongTrinhMucTieuQuocGiaAppService;
        private readonly INhomCongTrinhAppService _nhomCongTrinhAppService;
        private readonly ILoaiCongTrinhAppService _loaiCongTrinhAppService;
        private readonly ILoaiHoSoAppService _loaiHoSoAppService;
        private readonly ICongTrinhAppService _congTrinhAppService;
        private readonly IThuVienVanBanAppService _thuVienVanBanAppService;
        private readonly IThanhPhanHoSoAppService _thanhPhanHoSoAppService;
        private readonly IDonViHanhChinhAppService _donViHanhChinhAppService;
        private readonly ICurrentUser _currentUser;
        private readonly IAuthorizationService _authorization;

        public HoSoCongTrinhAppService(
            IViewHoSoCongTrinhRepository viewHoSoCongTrinhRepository,
            IHoSoCongTrinhRepository hoSoCongTrinhRepository,
            IHoSoCongTrinhChiTietRepository hoSoCongTrinhChiTietRepository,
            IChuDauTuAppService chuDauTuAppService,
            ILoaiKhoanAppService loaiKhoanAppService,
            IChuongTrinhMucTieuQuocGiaAppService chuongTrinhMucTieuQuocGiaAppService,
            INhomCongTrinhAppService nhomCongTrinhAppService,
            ILoaiCongTrinhAppService loaiCongTrinhAppService,
            ILoaiHoSoAppService loaiHoSoAppService,
            ICongTrinhAppService congTrinhAppService,
            IThuVienVanBanAppService thuVienVanBanAppService,
            IThanhPhanHoSoAppService thanhPhanHoSoAppService,
            ICurrentUser currentUser,
            IAuthorizationService authorization,
            IDonViHanhChinhAppService donViHanhChinhAppService) : base(hoSoCongTrinhRepository)
        {
            _viewHoSoCongTrinhRepository = viewHoSoCongTrinhRepository;
            _hoSoCongTrinhRepository = hoSoCongTrinhRepository;
            _hoSoCongTrinhChiTietRepository = hoSoCongTrinhChiTietRepository;
            _chuDauTuAppService = chuDauTuAppService ?? throw new ArgumentNullException(nameof(chuDauTuAppService));
            _loaiKhoanAppService = loaiKhoanAppService ?? throw new ArgumentNullException(nameof(loaiKhoanAppService));
            _chuongTrinhMucTieuQuocGiaAppService = chuongTrinhMucTieuQuocGiaAppService ?? throw new ArgumentNullException(nameof(chuongTrinhMucTieuQuocGiaAppService));
            _nhomCongTrinhAppService = nhomCongTrinhAppService ?? throw new ArgumentNullException(nameof(nhomCongTrinhAppService));
            _loaiCongTrinhAppService = loaiCongTrinhAppService ?? throw new ArgumentNullException(nameof(loaiCongTrinhAppService));
            _loaiHoSoAppService = loaiHoSoAppService ?? throw new ArgumentNullException(nameof(loaiHoSoAppService));
            _congTrinhAppService = congTrinhAppService;
            _thuVienVanBanAppService = thuVienVanBanAppService;
            _thanhPhanHoSoAppService = thanhPhanHoSoAppService;
            _donViHanhChinhAppService = donViHanhChinhAppService;
            _currentUser = currentUser;
            _authorization = authorization;
        }

        /// <summary>
        /// TODO refactor performance
        /// TODO refactor if-else
        /// TODO action theo role
        /// </summary>
        public async Task<HoSoCongTrinhListDto<HoSoCongTrinhViewModel>> GetHoSoCongTrinhsAsync(HoSoCongTrinhSearchInput searchInput)
        {
            var permission = await _authorization.IsGrantedAsync(HoSoCongTrinhPermissions.Default);
            if (!permission) throw new AbpAuthorizationException(HoSoConstants.Messages.MSG_NotPermission);
            // get danh sách công trình, hồ sơ công trình theo filter
            var data = new HoSoCongTrinhListDto<HoSoCongTrinhViewModel>();
            var totalCount = await _viewHoSoCongTrinhRepository.CountAsync(searchInput);
            data.TotalCount = totalCount;

            var hosoCongTrinhs = await _viewHoSoCongTrinhRepository.GetListHoSoCongTrinhAsync(searchInput);
            var chuDauTus = await _chuDauTuAppService.GetChuDauTuListAsync();
            var loaiKhoans = await _loaiKhoanAppService.GetLoaiAsync();
            var chuongTrinhs = await _chuongTrinhMucTieuQuocGiaAppService.GetMaConChuongTrinhsAsync();
            var nhomCongTrinhs = await _nhomCongTrinhAppService.GetNhomCongTrinhsAsync();
            var loaiCongTrinhs = await _loaiCongTrinhAppService.GetLoaiCongTrinhsAsync();
            var loaiHoSos = await _loaiHoSoAppService.GetLoaiHoSoDuocApDungAsync();
            var currentUserId = _currentUser.Id;
            var currentChuDauTuId = await _chuDauTuAppService.CheckChuDauTuAsync((Guid)currentUserId);

            // group hsct
            var items = new List<HoSoCongTrinhViewModel>();
            var groupHoSosByCongTrinh = hosoCongTrinhs
                .GroupBy(s => new
                {
                    s.Id,
                    s.TenCongTrinh,
                    s.MaCongTrinh,
                    s.ChuDauTuId,
                    s.LoaiKhoanId,
                    s.CTMTQuocGiaId,
                    s.LoaiCongTrinhId,
                    s.NhomCongTrinhId,
                    s.ThoiGianThucHienTuNgay,
                    s.ThoiGianThucHienDenNgay,
                    s.DienTich
                });

            var index = searchInput.Skip + 1;
            foreach (var item in groupHoSosByCongTrinh)
            {
                var hsct = new HoSoCongTrinhViewModel();

                hsct.Stt = index;
                // thông tin công trình
                var thongTinCongTrinh = new CongTrinhViewModel();
                thongTinCongTrinh.Id = item.Key.Id;
                thongTinCongTrinh.Ten = item.Key.TenCongTrinh;
                thongTinCongTrinh.MaCongTrinh = item.Key.MaCongTrinh;

                var loaiKhoan = loaiKhoans.FirstOrDefault(s => s.Id == item.Key.LoaiKhoanId);
                if (loaiKhoan != null)
                {
                    thongTinCongTrinh.MaLoaiKhoan = loaiKhoan.TenLoaiKhoan;
                }

                var chuongTrinhMucTieuQuocGia = chuongTrinhs.FirstOrDefault(s => s.Id == item.Key.CTMTQuocGiaId);
                if (chuongTrinhMucTieuQuocGia != null)
                {
                    thongTinCongTrinh.MaChuongTrinhMucTieuQuocGia = chuongTrinhMucTieuQuocGia.TenChuongTrinhMucTieuQuocGia;
                }

                var nhomCongTrinh = nhomCongTrinhs.FirstOrDefault(s => s.Id == item.Key.NhomCongTrinhId);
                if (nhomCongTrinh != null)
                {
                    thongTinCongTrinh.NhomCongTrinh = nhomCongTrinh.TenNhomCongTrinh;
                }

                var loaiCongTrinh = loaiCongTrinhs.FirstOrDefault(s => s.Id == item.Key.LoaiCongTrinhId);
                if (loaiCongTrinh != null)
                {
                    thongTinCongTrinh.LoaiCongTrinh = loaiCongTrinh.TenLoaiCongTrinh;
                }
                thongTinCongTrinh.ThoiGianThucHienTuNgay = $"{item.Key.ThoiGianThucHienTuNgay.ToDateTimeDefault(HoSoConstants.DateTimeFormat.YearOnly)}";
                thongTinCongTrinh.ThoiGianThucHienDenNgay = $"{item.Key.ThoiGianThucHienDenNgay.ToDateTimeDefault(HoSoConstants.DateTimeFormat.YearOnly)}";
                thongTinCongTrinh.DienTich = item.Key.DienTich;
                hsct.CongTrinh = thongTinCongTrinh;

                var chuDauTu = new ChuDauTuViewModel();
                chuDauTu.Id = item.Key.ChuDauTuId;
                var chuDauTuService = chuDauTus.FirstOrDefault(s => s.Id == item.Key.ChuDauTuId);
                if (chuDauTuService != null)
                {
                    chuDauTu.Ten = chuDauTuService.Ten;
                }
                hsct.ChuDauTu = chuDauTu;

                // check công trình có hồ sơ
                if (item.FirstOrDefault().HoSoCongTrinhId != null)
                {
                    var sttHoSo = 1;
                    foreach (var hs in item)
                    {
                        var hoso = new HoSoViewModel();
                        hoso.Stt = $"{index}.{sttHoSo}";
                        hoso.LoaiHoSoId = hs.LoaiHoSoId;
                        var loaiHoSo = loaiHoSos.FirstOrDefault(s => s.Id == hs.LoaiHoSoId);
                        if (loaiHoSo != null)
                        {
                            hoso.TenLoaiHoSo = loaiHoSo.TenLoaiHoSo;
                            hoso.IsDieuChinh = loaiHoSo.IsDieuChinh;
                        }
                        hoso.HoSoCongTrinhId = hs.HoSoCongTrinhId;
                        var trangThai = new TrangThaiXuLyViewModel();
                        trangThai.Ma = Enum.GetName(typeof(TrangThaiEnums), hs.TrangThai);
                        trangThai.Ten = ((TrangThaiEnums)Enum.Parse(typeof(TrangThaiEnums), trangThai.Ma)).GetDescription();
                        hoso.TrangThaiXuLy = trangThai;

                        // check hiển thị hạn xử lý
                        if (hs.TrangThai == (int)TrangThaiEnums.DANG_XU_LY && hs.HanXuLy != null)
                        {
                            var diffDate = CompareDateTime((DateTime)hs.HanXuLy);
                            hoso.HanXuLy = $"{hs.HanXuLy.ToDateTimeDefault(HoSoConstants.DateTimeFormat.Date)}";
                            hoso.NgayXuLy = diffDate;
                        }
                        // số lần điều chỉnh
                        hoso.SoLanDieuChinh = hs.SoLanDieuChinh;

                        // define action theo trang thai
                        hoso.Action = CheckActionViewModel((int)hs.TrangThai, (bool)hs.IsChuDauTu, hoso.IsDieuChinh, currentChuDauTuId);
                        hsct.HoSos.Add(hoso);

                        sttHoSo++;
                    }
                }

                if (hsct.HoSos.Count < loaiHoSos.Count)
                {
                    hsct.Action = new ActionViewModel()
                    {
                        Add = true,
                    };
                }

                index++;

                items.Add(hsct);
            }
            data.Items = items;

            return data;
        }

        private static ActionViewModel CheckActionViewModel(int trangThai, bool isChuDauTuCreate, bool isDieuChinh, Guid? currentChuDauTuId)
        {
            var action = new ActionViewModel();
            action.Add = (trangThai == (int)TrangThaiEnums.HOAN_THANH) && isDieuChinh;
            if (currentChuDauTuId != null)// Role Chủ đầu tư
            {
                action.Edit = (trangThai == (int)TrangThaiEnums.DANG_SOAN) || (trangThai == (int)TrangThaiEnums.YEU_CAU_CHINH_SUA);
                action.Delete = (trangThai == (int)TrangThaiEnums.DANG_SOAN);
            }
            else // Chuyên viên
            {
                action.Edit = (trangThai == (int)TrangThaiEnums.DANG_XU_LY);
                action.Delete = (trangThai == (int)TrangThaiEnums.DANG_XU_LY) && !isChuDauTuCreate;
            }
            return action;
        }

        #region add, update and delete

        /// <summary>
        /// Create hồ sơ công trình
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<HoSoCongTrinhDto> CreateAsync(CreateUpdateHoSoCongTrinhDto input)
        {
            var permission = await _authorization.IsGrantedAsync(HoSoCongTrinhPermissions.Create);
            if (!permission) throw new AbpAuthorizationException(HoSoConstants.Messages.MSG_NotPermission);
            var currentUserId = _currentUser.Id;
            var currentChuDauTuId = await _chuDauTuAppService.CheckChuDauTuAsync((Guid)currentUserId);
            var hoSoCongTrinhInput = base.MapToEntity(input);
            CreateMapHoSoCongTrinh(hoSoCongTrinhInput, input, currentChuDauTuId);
            var hoSoCongTrinh = await GetEntityByIdAsync(input.Id);
            if (hoSoCongTrinh == null)
            {
                EntityHelper.TrySetId(hoSoCongTrinhInput, GuidGenerator.Create);
                if (currentChuDauTuId != null) hoSoCongTrinhInput.IsChuDauTu = true;
                await _hoSoCongTrinhRepository.InsertAsync(hoSoCongTrinhInput);
            }
            else // trường hợp thêm mới điều chỉnh
            {
                var hoSoChiTiet = hoSoCongTrinhInput.HoSoCongTrinhChiTiets.FirstOrDefault();
                await _hoSoCongTrinhChiTietRepository.InsertAsync(hoSoChiTiet);

                hoSoCongTrinh.TrangThai = hoSoChiTiet.TrangThai;
                hoSoCongTrinh.HanXuLy = (DateTime)hoSoChiTiet.HanXuLy;
                hoSoCongTrinh.SoLanDieuChinh = hoSoChiTiet.SoLanDieuChinh;
                hoSoCongTrinh.IsChuDauTu = hoSoChiTiet.IsChuDauTu;
                await _hoSoCongTrinhRepository.UpdateAsync(hoSoCongTrinh);
            }
            return MapToGetOutputDto(hoSoCongTrinhInput);
        }

        /// <summary>
        /// Update hồ sơ công trình
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<HoSoCongTrinhDto> UpdateAsync(Guid id, CreateUpdateHoSoCongTrinhDto input)
        {
            // TODO change logic update -> update entity đối với những prop có sự thay đổi value
            var permission = await _authorization.IsGrantedAsync(HoSoCongTrinhPermissions.Update);
            if (!permission) throw new AbpAuthorizationException(HoSoConstants.Messages.MSG_NotPermission);
            var hsct = await GetEntityByIdAsync(id);
            await UpdateMapHoSoCongTrinh(hsct, input);
            await _hoSoCongTrinhRepository.UpdateAsync(hsct);
            return MapToGetOutputDto(hsct);
        }

        /// <summary>
        /// Xóa hồ sơ công trình
        /// </summary>
        /// <param name="id"> Id hồ sơ công trình</param>
        public override async Task DeleteAsync(Guid id)
        {
            var permission = await _authorization.IsGrantedAsync(HoSoCongTrinhPermissions.Delete);
            if (!permission) throw new AbpAuthorizationException(HoSoConstants.Messages.MSG_NotPermission);

            var hsct = await GetEntityByIdAsync(id);
            if (hsct == null) throw new BusinessException("Không tồn tại hồ sơ công trình để xóa");

            var currentUserId = _currentUser.Id;
            var currentChuDauTuId = await _chuDauTuAppService.CheckChuDauTuAsync((Guid)currentUserId);
            if (currentChuDauTuId == null)// là chuyên viên
            {
                // validate chuyên viên không được xóa hsct của chủ đầu tư tạo
                if (hsct.IsChuDauTu) throw new AbpAuthorizationException(HoSoConstants.Messages.MSG_NotPermission);
            }
            else // là chủ đầu tư
            {
                // chủ đầu tư không được xóa hồ sơ có trạng thái khác trạng thái đang soạn
                if (hsct.TrangThai != TrangThaiEnums.DANG_SOAN)
                {
                    throw new BusinessException("Hồ sơ này không được xóa");
                }
                // chủ đầu tư không được xóa hồ sơ do chuyên viên tạo
                if (!hsct.IsChuDauTu)
                {
                    throw new AbpAuthorizationException(HoSoConstants.Messages.MSG_NotPermission);
                }
            }

            var hoSoCongTrinhChiTiet = hsct.HoSoCongTrinhChiTiets.OrderByDescending(s => s.CreationTime).FirstOrDefault();
            if (hoSoCongTrinhChiTiet == null) throw new BusinessException("400", "Không tồn tại hồ sơ để xóa");
            hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietDiaDiems.Clear();
            hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietNguonVons.Clear();
            hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCoSoPhapLys.Clear();
            hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietKetQuaThamDinhs.Clear();
            hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietThanhPhanHoSos.ForEach(x => x.HoSoCongTrinhChiTietThanhPhanHoSoFiles.Clear());
            hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietThanhPhanHoSos.Clear();

            if (hsct.HoSoCongTrinhChiTiets.Count > 1) // loại hồ sơ điều chỉnh
            {
                hsct.HoSoCongTrinhChiTiets.Remove(hoSoCongTrinhChiTiet);
                var hoSoChiTietLatest = hsct.HoSoCongTrinhChiTiets.OrderByDescending(s => s.CreationTime).FirstOrDefault();
                hsct.TrangThai = hoSoChiTietLatest.TrangThai;
                hsct.SoLanDieuChinh = hoSoChiTietLatest.SoLanDieuChinh;
                hsct.HanXuLy = (DateTime)hoSoChiTietLatest.HanXuLy;

                await _hoSoCongTrinhRepository.UpdateAsync(hsct);
            }
            else
            {
                hsct.HoSoCongTrinhChiTiets.Clear();
                await _hoSoCongTrinhRepository.DeleteAsync(hsct);
            }
        }

        protected override Task<Entities.HoSoCongTrinh> GetEntityByIdAsync(Guid id)
        {
            return _hoSoCongTrinhRepository.GetEntityByIdAsync(id);
        }

        private void CreateMapHoSoCongTrinh(Entities.HoSoCongTrinh hsct, CreateUpdateHoSoCongTrinhDto input, Guid? currentChuDauTuId)
        {
            var hoSoCongTrinhChiTietDto = input.HoSoCongTrinhChiTietDtos.FirstOrDefault();
            var hoSoCongTrinhChiTiet = ObjectMapper.Map<CreateUpdateHoSoCongTrinhChiTietDto, HoSoCongTrinhChiTiet>(hoSoCongTrinhChiTietDto);

            if (hoSoCongTrinhChiTietDto.YKienThamDinh != null)
            {
                try
                {
                    hoSoCongTrinhChiTiet.DonViPhoiHopThamDinhs = JsonConvert.SerializeObject(hoSoCongTrinhChiTietDto.YKienThamDinh.DonViPhoiHopThamDinhs);
                }
                catch (Exception)
                {
                    throw new BusinessException("Không đúng format");
                }
            }

            EntityHelper.TrySetId(hoSoCongTrinhChiTiet, GuidGenerator.Create);
            if (currentChuDauTuId != null) hoSoCongTrinhChiTiet.IsChuDauTu = true;
            hsct.HoSoCongTrinhChiTiets.Add(hoSoCongTrinhChiTiet);
            // add địa điểm xây dựng
            AddOrUpdateHoSoCongTrinhChiTietDiaDiem(hoSoCongTrinhChiTiet, hoSoCongTrinhChiTietDto);
            // add nguồn vốn
            AddOrUpdateHoSoCongTrinhChiTietNguonVon(hoSoCongTrinhChiTiet, hoSoCongTrinhChiTietDto);
            // add cơ sở pháp lý
            AddOrUpdateHoSoCongTrinhChiTietCoSoPhapLy(hoSoCongTrinhChiTiet, hoSoCongTrinhChiTietDto);
            // add kết quả thẩm địnhư
            AddOrUpdateHoSoCongTrinhChiTietKetQuaThamDinh(hoSoCongTrinhChiTiet, hoSoCongTrinhChiTietDto);
            // add thành phần hồ sơ
            AddOrUpdateHoSoCongTrinhChiTietThanhPhanHoSo(hoSoCongTrinhChiTiet, hoSoCongTrinhChiTietDto);

            // add, update danh sách công việc thuộc loại hồ sơ 3
            if (hoSoCongTrinhChiTietDto.ThamDinhGoiThau != null)
                AddOrUpdateHoSoCongTrinhChiTietCongViecGoiThau(hoSoCongTrinhChiTiet, hoSoCongTrinhChiTietDto);
            if (hoSoCongTrinhChiTietDto.ThamDinhDieuChinhGoiThau != null)
                // add, update danh sách công việc thuộc loại hồ sơ 4
                AddOrUpdateHoSoCongTrinhChiTietGoiThau(hoSoCongTrinhChiTiet, hoSoCongTrinhChiTietDto);
        }

        private async Task UpdateMapHoSoCongTrinh(Entities.HoSoCongTrinh hsct, CreateUpdateHoSoCongTrinhDto input)
        {
            var hoSoCongTrinhChiTietDto = input.HoSoCongTrinhChiTietDtos.FirstOrDefault();
            var loaiHoSo = await _loaiHoSoAppService.GetLoaiHoSoByIdAsync(input.LoaiHoSoId);
            if (loaiHoSo == null) throw new BusinessException("400", "Không tồn tại loại hồ sơ để cập nhật");
            // update hồ sơ công trình
            if (loaiHoSo.IsDieuChinh) // loại điều chỉnh
            {
                hsct.TrangThai = hoSoCongTrinhChiTietDto.TrangThai;
                hsct.HanXuLy = hoSoCongTrinhChiTietDto.HanXuLy;
                hsct.SoLanDieuChinh = hoSoCongTrinhChiTietDto.SoLanDieuChinh;
            }
            else // không phải loại điều chỉnh
            {
                hsct.TrangThai = hoSoCongTrinhChiTietDto.TrangThai;
            }

            var hoSoCongTrinhChiTiet = hsct.HoSoCongTrinhChiTiets.FirstOrDefault(s => s.Id == hoSoCongTrinhChiTietDto.Id);
            if (hoSoCongTrinhChiTiet == null) throw new BusinessException("400", "Không tồn tại hồ sơ để cập nhật");
            // update hồ sơ công trình chi tiết
            UpdateHoSoCongTrinhChiTiet(hoSoCongTrinhChiTiet, hoSoCongTrinhChiTietDto);
            // update dia diem
            hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietDiaDiems.Clear();
            AddOrUpdateHoSoCongTrinhChiTietDiaDiem(hoSoCongTrinhChiTiet, hoSoCongTrinhChiTietDto);
            // update Nguồn vốn
            hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietNguonVons.Clear();
            AddOrUpdateHoSoCongTrinhChiTietNguonVon(hoSoCongTrinhChiTiet, hoSoCongTrinhChiTietDto);
            // update cơ sở pháp lý
            hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCoSoPhapLys.Clear();
            AddOrUpdateHoSoCongTrinhChiTietCoSoPhapLy(hoSoCongTrinhChiTiet, hoSoCongTrinhChiTietDto);
            // update kết quả thẩm định
            hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietKetQuaThamDinhs.Clear();
            AddOrUpdateHoSoCongTrinhChiTietKetQuaThamDinh(hoSoCongTrinhChiTiet, hoSoCongTrinhChiTietDto);
            // update thành phần hồ sơ
            hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietThanhPhanHoSos.Clear();
            AddOrUpdateHoSoCongTrinhChiTietThanhPhanHoSo(hoSoCongTrinhChiTiet, hoSoCongTrinhChiTietDto);

            // update công việc gói thầu
            if (hoSoCongTrinhChiTietDto.ThamDinhGoiThau != null)
            {
                hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCongViecs.Clear();
                hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Clear();
                AddOrUpdateHoSoCongTrinhChiTietCongViecGoiThau(hoSoCongTrinhChiTiet, hoSoCongTrinhChiTietDto);
            }

            // update gói thầu
            if (hoSoCongTrinhChiTietDto.ThamDinhDieuChinhGoiThau != null)
            {
                hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Clear();
                AddOrUpdateHoSoCongTrinhChiTietGoiThau(hoSoCongTrinhChiTiet, hoSoCongTrinhChiTietDto);
            }
        }

        private void UpdateHoSoCongTrinhChiTiet(HoSoCongTrinhChiTiet hoSoCongTrinhChiTiet, CreateUpdateHoSoCongTrinhChiTietDto hoSoCongTrinhChiTietDto)
        {
            hoSoCongTrinhChiTiet.TrangThai = hoSoCongTrinhChiTietDto.TrangThai;
            hoSoCongTrinhChiTiet.HanXuLy = hoSoCongTrinhChiTietDto.HanXuLy;
            hoSoCongTrinhChiTiet.SoLanDieuChinh = hoSoCongTrinhChiTietDto.SoLanDieuChinh;
            hoSoCongTrinhChiTiet.QuyMoDauTu = hoSoCongTrinhChiTietDto.QuyMoDauTu;
            hoSoCongTrinhChiTiet.SuCanThietDauTu = hoSoCongTrinhChiTietDto.SuCanThietDauTu;
            hoSoCongTrinhChiTiet.MucTieuDauTu = hoSoCongTrinhChiTietDto.MucTieuDauTu;
            hoSoCongTrinhChiTiet.NganhLinhVucSuDungId = hoSoCongTrinhChiTietDto.NganhLinhVucSuDungId;
            hoSoCongTrinhChiTiet.TongMucDauTu = hoSoCongTrinhChiTietDto.TongMucDauTu;
            hoSoCongTrinhChiTiet.TongMucDuToanDuocDuyet = hoSoCongTrinhChiTietDto.MucDuToanDuocDuyet;
            if (hoSoCongTrinhChiTietDto.YKienThamDinh != null)
            {
                if (hoSoCongTrinhChiTietDto.YKienThamDinh.DonViChuTriThamDinh != null)
                    hoSoCongTrinhChiTiet.DonViChuTriThamDinhId = hoSoCongTrinhChiTietDto.YKienThamDinh.DonViChuTriThamDinh.Id;
                try
                {
                    if (hoSoCongTrinhChiTietDto.YKienThamDinh.DonViPhoiHopThamDinhs != null)
                        hoSoCongTrinhChiTiet.DonViPhoiHopThamDinhs = JsonConvert.SerializeObject(hoSoCongTrinhChiTietDto.YKienThamDinh.DonViPhoiHopThamDinhs);
                }
                catch (Exception)
                {
                    throw new BusinessException("Không đúng format");
                }
                hoSoCongTrinhChiTiet.HinhThucThamDinh = hoSoCongTrinhChiTietDto.YKienThamDinh.HinhThucThamDinh;
                if (hoSoCongTrinhChiTietDto.YKienThamDinh.CapQuyetDinhChuTruong != null)
                    hoSoCongTrinhChiTiet.CapQuyetDinhChuTruongDauTu = hoSoCongTrinhChiTietDto.YKienThamDinh.CapQuyetDinhChuTruong.Id;
                if (hoSoCongTrinhChiTietDto.YKienThamDinh.CapQuyetDinhDauTuDuAn != null)
                    hoSoCongTrinhChiTiet.CapQuyetDinhDauTuDuAn = hoSoCongTrinhChiTietDto.YKienThamDinh.CapQuyetDinhDauTuDuAn.Id;
                hoSoCongTrinhChiTiet.YKienThamDinhDonViPhoiHop = hoSoCongTrinhChiTietDto.YKienThamDinh.YKienThamDinhDonViPhoiHop;
                hoSoCongTrinhChiTiet.SuCanThietDauTuDuAn = hoSoCongTrinhChiTietDto.YKienThamDinh.SuCanThietDauTuDuAn;
                hoSoCongTrinhChiTiet.SuTuanThuQuyDinh = hoSoCongTrinhChiTietDto.YKienThamDinh.SuTuanThuQuyDinh;
                hoSoCongTrinhChiTiet.SuPhuHopMucTieuChienLuoc = hoSoCongTrinhChiTietDto.YKienThamDinh.SuPhuHopMucTieuChienLuoc;
                hoSoCongTrinhChiTiet.SuPhuHopMucTieuPhanLoai = hoSoCongTrinhChiTietDto.YKienThamDinh.SuPhuHopMucTieuPhanLoai;
                hoSoCongTrinhChiTiet.NoiDungDauTu = hoSoCongTrinhChiTietDto.YKienThamDinh.NoiDungDauTu;
                hoSoCongTrinhChiTiet.YKienCuaDonViThamDinh = hoSoCongTrinhChiTietDto.YKienThamDinh.YKienCuaDonViThamDinh;
                hoSoCongTrinhChiTiet.NoiDungTrinhVaKienNghi = hoSoCongTrinhChiTietDto.YKienThamDinh.NoiDungTrinhVaKienNghi;
                hoSoCongTrinhChiTiet.MucDauTuPheDuyet = hoSoCongTrinhChiTietDto.MucDauTuPheDuyet;
                hoSoCongTrinhChiTiet.MucDauTuBoSung = hoSoCongTrinhChiTietDto.MucDauTuBoSung;
                hoSoCongTrinhChiTiet.NoiDungQuyMoDauTuPheDuyet = hoSoCongTrinhChiTietDto.NoiDungQuyMoDauTuPheDuyet;
                hoSoCongTrinhChiTiet.NoiDungQuyMoDauTuDeXuatDieuChinh = hoSoCongTrinhChiTietDto.NoiDungQuyMoDauTuDeXuatDieuChinh;
            }
        }

        private void AddOrUpdateHoSoCongTrinhChiTietDiaDiem(HoSoCongTrinhChiTiet hoSoCongTrinhChiTiet, CreateUpdateHoSoCongTrinhChiTietDto hoSoCongTrinhChiTietDto)
        {
            foreach (var item in hoSoCongTrinhChiTietDto.DiaDiemXayDungs)
            {
                var diaDiem = new HoSoCongTrinhChiTietDiaDiem(GuidGenerator.Create(), hoSoCongTrinhChiTiet.Id, item.DonViHanhChinhId, item.GhiChu);
                hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietDiaDiems.Add(diaDiem);
            }
        }

        private void AddOrUpdateHoSoCongTrinhChiTietNguonVon(HoSoCongTrinhChiTiet hoSoCongTrinhChiTiet, CreateUpdateHoSoCongTrinhChiTietDto hoSoCongTrinhChiTietDto)
        {
            foreach (var item in hoSoCongTrinhChiTietDto.NguonVons)
            {
                var nguonVon = new HoSoCongTrinhChiTietNguonVon(GuidGenerator.Create(), hoSoCongTrinhChiTiet.Id, item.NguonVonId, item.GiaTriDeNghi, item.GiaTriThamDinh, item.GiaTriNguonVon);
                hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietNguonVons.Add(nguonVon);
            }
        }

        private void AddOrUpdateHoSoCongTrinhChiTietCoSoPhapLy(HoSoCongTrinhChiTiet hoSoCongTrinhChiTiet, CreateUpdateHoSoCongTrinhChiTietDto hoSoCongTrinhChiTietDto)
        {
            foreach (var item in hoSoCongTrinhChiTietDto.CoSoPhapLys)
            {
                if (item.ThuVienVanBanId == null)
                {
                    try
                    {
                        var noiDungJson = JsonConvert.SerializeObject(item.CoSoPhapLyJsonViewModel);
                        var coSoPhapLy = new HoSoCongTrinhChiTietCoSoPhapLy(GuidGenerator.Create(), hoSoCongTrinhChiTiet.Id, noiDungJson);
                        hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCoSoPhapLys.Add(coSoPhapLy);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                else
                {
                    var coSoPhapLy = new HoSoCongTrinhChiTietCoSoPhapLy(GuidGenerator.Create(), hoSoCongTrinhChiTiet.Id, item.ThuVienVanBanId);
                    hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCoSoPhapLys.Add(coSoPhapLy);
                }
            }
        }

        private void AddOrUpdateHoSoCongTrinhChiTietKetQuaThamDinh(HoSoCongTrinhChiTiet hoSoCongTrinhChiTiet, CreateUpdateHoSoCongTrinhChiTietDto hoSoCongTrinhChiTietDto)
        {
            foreach (var item in hoSoCongTrinhChiTietDto.KetQuaThamDinhs)
            {
                var ketQuaThamDinh = new HoSoCongTrinhChiTietKetQuaThamDinh(GuidGenerator.Create(), hoSoCongTrinhChiTiet.Id, item.FileId);
                hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietKetQuaThamDinhs.Add(ketQuaThamDinh);
            }
        }

        private void AddOrUpdateHoSoCongTrinhChiTietThanhPhanHoSo(HoSoCongTrinhChiTiet hoSoCongTrinhChiTiet, CreateUpdateHoSoCongTrinhChiTietDto hoSoCongTrinhChiTietDto)
        {
            var index = 1;
            foreach (var item in hoSoCongTrinhChiTietDto.ThanhPhanHoSos)
            {
                var thanhPhanHoSo = new HoSoCongTrinhChiTietThanhPhanHoSo(GuidGenerator.Create(), hoSoCongTrinhChiTiet.Id, item.ThanhPhanHoSoId);
                thanhPhanHoSo.DonViBanHanhId = item.DonViBanHanhId;
                thanhPhanHoSo.SoKyHieu = item.SoKyHieu;
                thanhPhanHoSo.NgayBanHanh = item.NgayBanHanh;
                thanhPhanHoSo.TrichYeu = item.TrichYeu;
                thanhPhanHoSo.IsBatBuoc = item.BatBuoc;
                thanhPhanHoSo.OrderIndex = index;
                foreach (var itemFile in item.HoSoCongTrinhChiTietThanhPhanHoSoFileDtos)
                {
                    var file = new HoSoCongTrinhChiTietThanhPhanHoSoFile(GuidGenerator.Create(), thanhPhanHoSo.Id, itemFile.FileId);
                    thanhPhanHoSo.HoSoCongTrinhChiTietThanhPhanHoSoFiles.Add(file);
                }
                hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietThanhPhanHoSos.Add(thanhPhanHoSo);
                index++;
            }
        }

        private void AddOrUpdateHoSoCongTrinhChiTietCongViecGoiThau(HoSoCongTrinhChiTiet hoSoCongTrinhChiTiet, CreateUpdateHoSoCongTrinhChiTietDto hoSoCongTrinhChiTietDto)
        {
            try
            {
                hoSoCongTrinhChiTiet.KetQuaThamDinhCanCuPhapLys = JsonConvert.SerializeObject(hoSoCongTrinhChiTietDto.ThamDinhGoiThau.CanCuPhapLys);
            }
            catch (Exception)
            {
                hoSoCongTrinhChiTiet.KetQuaThamDinhCanCuPhapLys = "[]";
            }
            hoSoCongTrinhChiTiet.YKienThamDinhCanCuPhapLy = hoSoCongTrinhChiTietDto.ThamDinhGoiThau.YKienThamDinhCanCuPhapLy;
            hoSoCongTrinhChiTiet.YKienThamDinhNoiDungKeHoach = hoSoCongTrinhChiTietDto.ThamDinhGoiThau.YKienThamDinhNoiDungKeHoach;
            hoSoCongTrinhChiTiet.YKienThamDinhGiaTriCongViec = hoSoCongTrinhChiTietDto.ThamDinhGoiThau.YKienThamDinhGiaTriCongViec;
            hoSoCongTrinhChiTiet.NoiDungTrinhVaKienNghi = hoSoCongTrinhChiTietDto.ThamDinhGoiThau.NoiDungTrinhVaKienNghi;
            // Phần công việc đã thực hiện
            foreach (var item in hoSoCongTrinhChiTietDto.ThamDinhGoiThau.CongViecThucHiens)
            {
                var goiThauCongViec = new HoSoCongTrinhChiTietCongViec(GuidGenerator.Create(), hoSoCongTrinhChiTiet.Id);
                goiThauCongViec.CongViecGoiThauId = item.CongViecGoiThauId;
                goiThauCongViec.DonViThucHien = item.DonViThucHien;
                goiThauCongViec.GiaTriThucHien = item.GiaTriThucHien;
                goiThauCongViec.LoaiCongViec = LoaiCongViecEnums.CONGVIEC_DUOC_THUCHIEN;
                hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCongViecs.Add(goiThauCongViec);
            }

            // Phần công việc không áp dụng được một trong các hình thức lựa chọn nhà thầu
            foreach (var item in hoSoCongTrinhChiTietDto.ThamDinhGoiThau.CongViecKhongApDungs)
            {
                var goiThauCongViec = new HoSoCongTrinhChiTietCongViec(GuidGenerator.Create(), hoSoCongTrinhChiTiet.Id);
                goiThauCongViec.CongViecGoiThauId = item.CongViecGoiThauId;
                goiThauCongViec.DonViThucHienId = item.DonViThucHienId;
                goiThauCongViec.GiaTriThucHien = item.GiaTriThucHien;
                goiThauCongViec.LoaiCongViec = LoaiCongViecEnums.CONGVIEC_KHONG_APDUNG;
                hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCongViecs.Add(goiThauCongViec);
            }

            // Phần công việc thuộc kế hoạch lựa chọn nhà thầu
            foreach (var item in hoSoCongTrinhChiTietDto.ThamDinhGoiThau.CongViecThuocKeHoachs)
            {
                var goiThauCongViec = new HoSoCongTrinhChiTietCongViec(GuidGenerator.Create(), hoSoCongTrinhChiTiet.Id);
                goiThauCongViec.CongViecGoiThauId = item.CongViecGoiThauId;
                goiThauCongViec.IsTuanThuPhuHop = item.IsTuanThuPhuHop;
                goiThauCongViec.LoaiCongViec = LoaiCongViecEnums.CONGVIEC_LUACHON_NHATHAU;
                hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCongViecs.Add(goiThauCongViec);
            }

            // Phần công việc chưa đủ điều kiện lựa chọn nhà thầu
            foreach (var item in hoSoCongTrinhChiTietDto.ThamDinhGoiThau.CongViecChuaDuDieuKienLapKeHoachs)
            {
                var goiThauCongViec = new HoSoCongTrinhChiTietCongViec(GuidGenerator.Create(), hoSoCongTrinhChiTiet.Id);
                goiThauCongViec.CongViecGoiThauId = item.CongViecGoiThauId;
                goiThauCongViec.GiaTriThucHien = item.GiaTri;
                goiThauCongViec.LoaiCongViec = LoaiCongViecEnums.CONGVIEC_CHUADUDIEUKIEN_LUACHON_NHATHAU;
                hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietCongViecs.Add(goiThauCongViec);
            }

            // danh sách gói thầu kiến nghị
            foreach (var item in hoSoCongTrinhChiTietDto.ThamDinhGoiThau.GoiThauThamDinhs)
            {
                var goiThau = new HoSoCongTrinhChiTietGoiThau(GuidGenerator.Create(), hoSoCongTrinhChiTiet.Id, item.GoiThauId, item.GiaGoiThau, item.HinhThucLuaChonNhaThauId,
                    item.PhuongThucLuaChonNhaThauId, item.LoaiHopDongId, item.ThoiGianBatDau, item.ThoiGianThucHien);
                goiThau.GoiThauParentId = item.GoiThauParentId;
                goiThau.LoaiKeHoach = LoaiCongViecEnums.GOITHAU_KIENNGHI;
                hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Add(goiThau);
            }
        }

        private void AddOrUpdateHoSoCongTrinhChiTietGoiThau(HoSoCongTrinhChiTiet hoSoCongTrinhChiTiet, CreateUpdateHoSoCongTrinhChiTietDto hoSoCongTrinhChiTietDto)
        {
            hoSoCongTrinhChiTiet.DanhGiaCoQuanThamDinh = hoSoCongTrinhChiTietDto.ThamDinhDieuChinhGoiThau.DanhGiaCoQuanThamDinh;
            hoSoCongTrinhChiTiet.NoiDungTrinhVaKienNghi = hoSoCongTrinhChiTietDto.ThamDinhDieuChinhGoiThau.NoiDungTrinhVaKienNghi;

            // Danh sách gói thầu được phê duyệt
            foreach (var item in hoSoCongTrinhChiTietDto.ThamDinhDieuChinhGoiThau.GoiThauDuocPheDuyets)
            {
                var goiThau = new HoSoCongTrinhChiTietGoiThau(GuidGenerator.Create(), hoSoCongTrinhChiTiet.Id, item.GoiThauId, item.GiaGoiThau, item.HinhThucLuaChonNhaThauId,
                    item.PhuongThucLuaChonNhaThauId, item.LoaiHopDongId, item.ThoiGianBatDau, item.ThoiGianThucHien);
                goiThau.GoiThauParentId = item.GoiThauParentId;
                goiThau.LoaiKeHoach = LoaiCongViecEnums.GOITHAU_DUOC_PHEDUYET;
                hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Add(goiThau);
            }

            // Danh sách gói thầu được phê duyệt
            foreach (var item in hoSoCongTrinhChiTietDto.ThamDinhDieuChinhGoiThau.GoiThauDeNghiDieuChinhs)
            {
                var goiThau = new HoSoCongTrinhChiTietGoiThau(GuidGenerator.Create(), hoSoCongTrinhChiTiet.Id, item.GoiThauId, item.GiaGoiThau, item.HinhThucLuaChonNhaThauId,
                    item.PhuongThucLuaChonNhaThauId, item.LoaiHopDongId, item.ThoiGianBatDau, item.ThoiGianThucHien);
                goiThau.GoiThauParentId = item.GoiThauParentId;
                goiThau.LoaiKeHoach = LoaiCongViecEnums.GOITHAU_DENGHI_DIEUCHINH;
                hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Add(goiThau);
            }

            // Danh sách gói thầu được phê duyệt
            foreach (var item in hoSoCongTrinhChiTietDto.ThamDinhDieuChinhGoiThau.GoiThauDeXuats)
            {
                var goiThau = new HoSoCongTrinhChiTietGoiThau(GuidGenerator.Create(), hoSoCongTrinhChiTiet.Id, item.GoiThauId, item.GiaGoiThau, item.HinhThucLuaChonNhaThauId,
                    item.PhuongThucLuaChonNhaThauId, item.LoaiHopDongId, item.ThoiGianBatDau, item.ThoiGianThucHien);
                goiThau.GoiThauParentId = item.GoiThauParentId;
                goiThau.LoaiKeHoach = LoaiCongViecEnums.GOITHAU_DEXUAT;
                hoSoCongTrinhChiTiet.HoSoCongTrinhChiTietGoiThaus.Add(goiThau);
            }
        }

        #endregion add, update and delete

        private static double CompareDateTime(DateTime dateTime)
        {
            var dtUtc = DateTime.UtcNow.ToLocalDate().Date;
            return (dateTime.Date - dtUtc).TotalDays;
        }

        [HttpGet]
        public async Task<dynamic> ReportAsync(Guid id)
        {
            var group = "";
            var hoSoCongTrinh = await _hoSoCongTrinhRepository.GetEntityByIdAsync(id);
            var danhMucCongTrinh = _congTrinhAppService.GetCongTrinhByIdAsync(hoSoCongTrinh.CongTrinhId).Result;
            if (danhMucCongTrinh.NhomCongTrinhId != null)
            {
                Guid nhomCongTrinhId = danhMucCongTrinh.NhomCongTrinhId ?? new Guid();
                var nhomCongTrinh = _nhomCongTrinhAppService.GetAsync(nhomCongTrinhId).Result;
                group = nhomCongTrinh.TenNhomCongTrinh;
            }

            var chuDauTu = "";
            if (hoSoCongTrinh.ChuDauTuId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                chuDauTu = _chuDauTuAppService.GetAsync(hoSoCongTrinh.ChuDauTuId).Result.Ten;
            }

            var hoSoCongTrinhChiTiet = hoSoCongTrinh.HoSoCongTrinhChiTiets;
            string coSoPhapLy = "";
            foreach (var item in hoSoCongTrinhChiTiet[0].HoSoCongTrinhChiTietCoSoPhapLys)
            {
                if (item.ThuVienVanBanId != null)
                {
                    var thuVienVanBanId = item.ThuVienVanBanId ?? new Guid();
                    coSoPhapLy += "- Căn cứ nghị định" + _thuVienVanBanAppService.GetAsync(thuVienVanBanId).Result.SoKyHieu + "\r\n";
                }
            }

            string thanhPhanHoSo = "";
            foreach (var item in hoSoCongTrinhChiTiet[0].HoSoCongTrinhChiTietThanhPhanHoSos)
            {
                thanhPhanHoSo += "- Thành phần hồ sơ" + _thanhPhanHoSoAppService.GetAsync(item.ThanhPhanHoSoId).Result.TenThanhPhanHoSo + "\r\n";
            }

            string diaDiem = "";
            foreach (var item in danhMucCongTrinh.DiaDiemXayDungs)
            {
                diaDiem += _donViHanhChinhAppService.GetAsync(item.DonViHanhChinhId).Result + ",";
            }
            string namThucHien = "";
            if (danhMucCongTrinh.ThoiGianThucHienDenNgay != null && danhMucCongTrinh.ThoiGianThucHienTuNgay != null)
            {
                var tuNgay = danhMucCongTrinh.ThoiGianThucHienTuNgay ?? new DateTime();
                var denNgay = danhMucCongTrinh.ThoiGianThucHienDenNgay ?? new DateTime();
                namThucHien = (denNgay.Year - tuNgay.Year).ToString() + " năm";
            }

            string url = "{'year':'" + DateTime.Now.Year.ToString() + "','project': {'group':'" + group + "', 'name':'" +
                danhMucCongTrinh.TenCongTrinh + "', 'chudautu':'" + chuDauTu + "','cosophaply':'" + coSoPhapLy + "','thanhphanhoso':'" +
                thanhPhanHoSo + "','diadiem':'" + diaDiem + "','tongmucdautu':'" + danhMucCongTrinh.TongMucDauTu + "','thoigianthuchien':'" + namThucHien + "'}}";
            return url;
        }

        [HttpGet]
        public bool IsHoSoCongTrinhByCongTrinhId(Guid Id)
        {
            var item = _hoSoCongTrinhRepository.IsHoSoCongTrinhByCongTrinhId(Id);
            return item;
        }
    }
}