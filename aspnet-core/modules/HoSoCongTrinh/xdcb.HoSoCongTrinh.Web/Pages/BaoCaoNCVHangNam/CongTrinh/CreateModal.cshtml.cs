using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using Volo.Abp.Users;
using xdcb.Common.DanhMuc;
using xdcb.Common.DanhMuc.ChucVuDtos;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using xdcb.Common.DanhMuc.ChuDauTus;
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGiaDtos;
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGias;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using xdcb.Common.DanhMuc.CongTrinhs;
using xdcb.Common.DanhMuc.LoaiCongTrinhDtos;
using xdcb.Common.DanhMuc.LoaiCongTrinhs;
using xdcb.Common.DanhMuc.LoaiKhoanDtos;
using xdcb.Common.DanhMuc.LoaiKhoans;
using xdcb.Common.DanhMuc.NhomCongTrinhDtos;
using xdcb.Common.DanhMuc.NhomCongTrinhs;
using xdcb.Common.Permissions;
using xdcb.HoSoCongTrinh.Dtos;

namespace xdcb.BaoCaoNCVHangNam.CongTrinh
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUpdateCongTrinhDto CongTrinh { get; set; }

        public List<SelectListItem> SelectChuDauTuList { get; set; }

        public List<SelectListItem> SelectNhomCongTrinhList { get; set; }

        public List<SelectListItem> SelectMaLoaiKhoanList { get; set; }
        public List<SelectListItem> SelectChuongTrinhMucTieuQuocGia { get; set; }
        public List<SelectListItem> SelectLoaiCongTrinh { get; set; }
        [BindProperty]
        public List<DiaDiemThucHienDto> DiaDiemThucHiens { get; set; }

        [BindProperty]
        public string diaDiemXayDungStr { get; set; }

        [BindProperty]
        public Guid? ChuDauTuId { get; set; }
        public Guid? UserId { get; set; }
        private readonly ICurrentUser _currentUser;

        private List<ChuDauTuDto> chuDauTuDtos;
        private List<NhomCongTrinhDto> nhomCongTrinhDtos;
        private List<LoaiKhoanDto> loaiKhoanDtos;
        private List<ChuongTrinhMucTieuQuocGiaDto> chuongTrinhMucTieuQuocGiaDtos;
        private List<LoaiCongTrinhDto> loaiCongTrinhDtos;

        private readonly ICongTrinhAppService _congTrinhAppService;
        private readonly IAuthorizationService _authorization;
        private readonly IChuDauTuAppService _chuDauTu;
        private readonly INhomCongTrinhAppService _nhomCongTrinh;
        private readonly ILoaiKhoanAppService _loaiKhoan;
        private readonly IChuongTrinhMucTieuQuocGiaAppService _chuongTrinhMucTieuQuocGia;
        private readonly ILoaiCongTrinhAppService _loaiCongTrinh;

        public CreateModalModel(ICongTrinhAppService congTrinhAppService,
            IAuthorizationService authorization, IChuDauTuAppService chuDauTu, INhomCongTrinhAppService nhomCongTrinh,
            ILoaiKhoanAppService loaiKhoan, IChuongTrinhMucTieuQuocGiaAppService chuongTrinhMucTieuQuocGia, ILoaiCongTrinhAppService loaiCongTrinh,
            ICurrentUser currentUser)
        {
            _congTrinhAppService = congTrinhAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
            _chuDauTu = chuDauTu;
            _nhomCongTrinh = nhomCongTrinh;
            _loaiKhoan = loaiKhoan;
            _chuongTrinhMucTieuQuocGia = chuongTrinhMucTieuQuocGia;
            _loaiCongTrinh = loaiCongTrinh;
            _currentUser = currentUser;
        }

        public async Task OnGetAsync()
        {
            UserId = _currentUser.Id;
            if (UserId != null)
            {
                ChuDauTuId = await _chuDauTu.CheckChuDauTuAsync((Guid)UserId);
            }
            // xử lý select chủ đầu tư
            chuDauTuDtos = (List<ChuDauTuDto>)(await _chuDauTu.GetChuDauTuListAsync() ?? new List<ChuDauTuDto>());
            SelectChuDauTuList = new List<SelectListItem>();
            SelectChuDauTuList.Add(new SelectListItem { Value = "", Text = ViewTextConsts.PlaceholderCongTrinh.ChuDauTu, Selected = true, Disabled = true });
            foreach (var item in chuDauTuDtos)
            {
                SelectChuDauTuList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Ten.ToString() });
            }
            // xử lý select nhóm công trình
            nhomCongTrinhDtos = (List<NhomCongTrinhDto>)(await _nhomCongTrinh.GetNhomCongTrinhsAsync() ?? new List<NhomCongTrinhDto>());
            SelectNhomCongTrinhList = new List<SelectListItem>();
            SelectNhomCongTrinhList.Add(new SelectListItem { Value = "", Text = ViewTextConsts.PlaceholderCongTrinh.NhomCongTrinh, Selected = true, Disabled = true });
            foreach (var item in nhomCongTrinhDtos)
            {
                SelectNhomCongTrinhList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.TenNhomCongTrinh.ToString() });
            }
            // xử lý select loại khoản
            loaiKhoanDtos = (List<LoaiKhoanDto>)(await _loaiKhoan.GetLoaiAsync() ?? new List<LoaiKhoanDto>());
            SelectMaLoaiKhoanList = new List<SelectListItem>();
            SelectMaLoaiKhoanList.Add(new SelectListItem { Value = "", Text = ViewTextConsts.PlaceholderCongTrinh.MaLoaiKhoan, Selected = true, Disabled = true });
            foreach (var item in loaiKhoanDtos)
            {
                SelectMaLoaiKhoanList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.TenLoaiKhoan.ToString() });
            }
            // xử lý select chương trình mục tiêu quốc gia
            chuongTrinhMucTieuQuocGiaDtos = (await _chuongTrinhMucTieuQuocGia.GetMaChuongTrinhQuocGia() ?? new List<ChuongTrinhMucTieuQuocGiaDto>());
            SelectChuongTrinhMucTieuQuocGia = new List<SelectListItem>();
            SelectChuongTrinhMucTieuQuocGia.Add(new SelectListItem { Value = "", Text = ViewTextConsts.PlaceholderCongTrinh.MaCTMTQG, Selected = true, Disabled = true });
            foreach (var item in chuongTrinhMucTieuQuocGiaDtos)
            {
                SelectChuongTrinhMucTieuQuocGia.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.TenChuongTrinhMucTieuQuocGia.ToString() });
            }
            // xử lý select loại công trình
            loaiCongTrinhDtos = (List<LoaiCongTrinhDto>)(await _loaiCongTrinh.GetLoaiCongTrinhsAsync() ?? new List<LoaiCongTrinhDto>());
            SelectLoaiCongTrinh = new List<SelectListItem>();
            SelectLoaiCongTrinh.Add(new SelectListItem { Value = "", Text = ViewTextConsts.PlaceholderCongTrinh.LoaiCongTrinh, Selected = true, Disabled = true });
            foreach (var item in loaiCongTrinhDtos)
            {
                SelectLoaiCongTrinh.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.TenLoaiCongTrinh.ToString() });
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {

            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.CongTrinhPermission.Create))
            {
                diaDiemXayDungStr=diaDiemXayDungStr ?? "";
                List<DiaDiemThucHienDto> diaDiemThucHien = JsonConvert.DeserializeObject<List<DiaDiemThucHienDto>>(diaDiemXayDungStr);
                if (ChuDauTuId != null)
                {
                    CongTrinh.ChuDauTuId = ChuDauTuId;
                }
                var newCongTrinh = await _congTrinhAppService.CreateAsync(CongTrinh);
                List<DiaDiemXayDungDto> newDiaDiemXayDungs = new List<DiaDiemXayDungDto>();
                if (diaDiemThucHien != null) {
                    foreach (var diaDiem in diaDiemThucHien)
                    {
                        if (diaDiem.DonViHanhChinhId == null)
                        {
                            newDiaDiemXayDungs.Add(new DiaDiemXayDungDto { CongTrinhId = newCongTrinh.Id, DonViHanhChinhId = (Guid)diaDiem.Id, GhiChu = diaDiem.GhiChu });
                        }
                        else
                        {
                            newDiaDiemXayDungs.Add(new DiaDiemXayDungDto { CongTrinhId = newCongTrinh.Id, DonViHanhChinhId = (Guid)diaDiem.DonViHanhChinhId, GhiChu = diaDiem.GhiChu });
                        }
                    }
                }
               
                CongTrinh.DiaDiemXayDungs = new List<DiaDiemXayDungDto>();
                CongTrinh.DiaDiemXayDungs = newDiaDiemXayDungs;

                var result = _congTrinhAppService.SaveDiaDiemXayDung(CongTrinh);

                return Content("create");

            }
            else
            {
                return Content("error_permission");
            }

        }

        
    }
}