using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using xdcb.Common.DanhMuc.NhomCongTrinhDtos;
using xdcb.Common.DanhMuc.LoaiKhoanDtos;
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGiaDtos;
using xdcb.Common.DanhMuc.LoaiCongTrinhDtos;
using xdcb.Common.DanhMuc.ChuDauTus;
using xdcb.Common.DanhMuc.NhomCongTrinhs;
using xdcb.Common.DanhMuc.LoaiKhoans;
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGias;
using xdcb.Common.DanhMuc.LoaiCongTrinhs;
using Newtonsoft.Json;
using xdcb.Common.Permissions;
using Volo.Abp.Users;

namespace xdcb.Common.DanhMuc.CongTrinhs
{
    public class CreateModalModel : Web.Pages.CommonBaseAbpPageModel
    {
        [BindProperty]
        public CongTrinhViewModel CongTrinh { get; set; }

        public List<SelectListItem> SelectChuDauTuList { get; set; }

        public List<SelectListItem> SelectNhomCongTrinhList { get; set; }

        public List<SelectListItem> SelectMaLoaiKhoanList { get; set; }
        public List<SelectListItem> SelectChuongTrinhMucTieuQuocGia { get; set; }
        public List<SelectListItem> SelectLoaiCongTrinh { get; set; }
        public List<SelectListItem> SelectNam { get; set; }
        [BindProperty]
        public List<DiaDiemThucHienDto> DiaDiemThucHiens { get; set; }

        [BindProperty]
        public string diaDiemXayDungStr { get; set; }

        [BindProperty]
        public Guid? ChuDauTuId { get; set; }

        [BindProperty]
        [DisplayName(ViewTextConsts.CongTrinh.TuNam)]
        public string TuNam { get; set; }

        [BindProperty]
        [DisplayName(ViewTextConsts.CongTrinh.DenNam)]
        public string DenNam { get; set; }
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
            ICurrentUser currentUser
            )
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

            var yearNow = DateTime.Now.Year;
            SelectNam = new List<SelectListItem>();
            for (int i= yearNow - 5; i < yearNow + 6; i++)
            {
                SelectNam.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }
            TuNam = yearNow.ToString();
            DenNam = yearNow.ToString();
        }

        public async Task<IActionResult> OnPostAsync()
        {
           
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.CongTrinhPermission.Create))
            {

                List<DiaDiemThucHienDto> diaDiemThucHien = JsonConvert.DeserializeObject<List<DiaDiemThucHienDto>>(diaDiemXayDungStr);
                var congTrinhDto = ObjectMapper.Map<CongTrinhViewModel, CreateUpdateCongTrinhDto>(CongTrinh);
                if (ChuDauTuId != null)
                {
                    congTrinhDto.ChuDauTuId = ChuDauTuId;
                }
                congTrinhDto.NST = congTrinhDto.NST ?? 0;
                congTrinhDto.NSTW = congTrinhDto.NSTW ?? 0;
                congTrinhDto.ODA = congTrinhDto.ODA ?? 0;
                congTrinhDto.TongMucDauTu = congTrinhDto.NST + congTrinhDto.NSTW + congTrinhDto.ODA;
                congTrinhDto.ThoiGianThucHienTuNgay = Convert.ToDateTime("1/1/" + TuNam);
                congTrinhDto.ThoiGianThucHienDenNgay = Convert.ToDateTime("1/1/" + DenNam);
                var newCongTrinh = await _congTrinhAppService.CreateAsync(congTrinhDto);
                List<DiaDiemXayDungDto> newDiaDiemXayDungs = new List<DiaDiemXayDungDto>();
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
                congTrinhDto.DiaDiemXayDungs = new List<DiaDiemXayDungDto>();
                congTrinhDto.DiaDiemXayDungs = newDiaDiemXayDungs;

                var result = _congTrinhAppService.SaveDiaDiemXayDung(congTrinhDto);

                return Content("create");

            }
            else
            {
                return Content("error_permission");
            }

        }

        public class CongTrinhViewModel
        {
           
            [DisplayName(ViewTextConsts.CongTrinh.ChuDauTu)]
            [Placeholder(ViewTextConsts.PlaceholderCongTrinh.ChuDauTu)]
            [SelectItems(nameof(SelectChuDauTuList))]
            public Guid? ChuDauTuId { get; set; }

            [StringLength(10)]
            [DisplayName(ViewTextConsts.CongTrinh.MaCongTrinh)]
            [Placeholder(ViewTextConsts.PlaceholderCongTrinh.MaCongTrinh)]
            public string MaCongTrinh { get; set; }

            [Required(ErrorMessage = Messages.MSG_Requied)]
            [StringLength(500)]
            [DisplayName(ViewTextConsts.CongTrinh.TenCongTrinh)]
            [Placeholder(ViewTextConsts.PlaceholderCongTrinh.TenCongTrinh)]
            public string TenCongTrinh { get; set; }
            [DisplayName(ViewTextConsts.CongTrinh.NhomCongTrinh)]
            [Placeholder(ViewTextConsts.PlaceholderCongTrinh.NhomCongTrinh)]
            [SelectItems(nameof(SelectNhomCongTrinhList))]
            public Guid? NhomCongTrinhId { get; set; }
            [DisplayName(ViewTextConsts.CongTrinh.MaSoDuAn)]
            [Placeholder(ViewTextConsts.PlaceholderCongTrinh.MaSoDuAn)]
            public string MaSoDuAn { get; set; }
            [DisplayName(ViewTextConsts.CongTrinh.MaLoaiKhoan)]
            [Placeholder(ViewTextConsts.PlaceholderCongTrinh.MaLoaiKhoan)]
            [SelectItems(nameof(SelectMaLoaiKhoanList))]
            public Guid? LoaiKhoanId { get; set; }
            [DisplayName(ViewTextConsts.CongTrinh.MaCTMTQG)]
            [Placeholder(ViewTextConsts.PlaceholderCongTrinh.MaCTMTQG)]
            [SelectItems(nameof(SelectChuongTrinhMucTieuQuocGia))]
            public Guid? CTMTQuocGiaId { get; set; }
            [DisplayName(ViewTextConsts.CongTrinh.LoaiCongTrinh)]
            [Placeholder(ViewTextConsts.PlaceholderCongTrinh.LoaiCongTrinh)]
            [SelectItems(nameof(SelectLoaiCongTrinh))]
            public Guid? LoaiCongTrinhId { get; set; }
            [DisplayName(ViewTextConsts.CongTrinh.DienTich)]
            [Placeholder(ViewTextConsts.PlaceholderCongTrinh.DienTich)]
            public double? DienTich { get; set; }

            [DisplayName(ViewTextConsts.CongTrinh.TuNam)]
            public int? ThoiGianThucHienTuNgay { get; set; }

            [DisplayName(ViewTextConsts.CongTrinh.DenNam)]
            public int? ThoiGianThucHienDenNgay { get; set; }

            [StringLength(500)]
            [DisplayName(ViewTextConsts.CongTrinh.SoQDDT)]
            [Placeholder(ViewTextConsts.PlaceholderCongTrinh.SoQDDT)]
            public string SoQuyetDinhDauTu { get; set; }
            [DisplayName(ViewTextConsts.CongTrinh.NgayQuyetDinh)]
            public DateTime? NgayQuyetDinhDauTu { get; set; }
            [DisplayName(ViewTextConsts.CongTrinh.TongMucDauTu)]
            [DisplayFormat(DataFormatString = "{0:#.#}", ApplyFormatInEditMode = true)]
            public decimal? TongMucDauTu { get; set; }

            [System.ComponentModel.DisplayName(ViewTextConsts.CongTrinh.NST)]
            [Display(Prompt = ViewTextConsts.PlaceholderCongTrinh.NST)]
            [DisplayFormat(DataFormatString = "{0:#.#}", ApplyFormatInEditMode = true)]
            public decimal? NST { get; set; }

            [System.ComponentModel.DisplayName(ViewTextConsts.CongTrinh.NSTW)]
            [Display(Prompt = ViewTextConsts.PlaceholderCongTrinh.NSTW)]
            [DisplayFormat(DataFormatString = "{0:#.#}", ApplyFormatInEditMode = true)]
            public decimal? NSTW { get; set; }

            [System.ComponentModel.DisplayName(ViewTextConsts.CongTrinh.ODA)]
            [Display(Prompt = ViewTextConsts.PlaceholderCongTrinh.ODA)]
            [DisplayFormat(DataFormatString = "{0:#.#}", ApplyFormatInEditMode = true)]
            public decimal? ODA { get; set; }

        }
    }
}