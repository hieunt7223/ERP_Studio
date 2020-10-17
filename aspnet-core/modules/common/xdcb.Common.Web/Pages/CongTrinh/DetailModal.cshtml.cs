using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Users;
using xdcb.Common.DanhMuc.ChuDauTus;
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGias;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using xdcb.Common.DanhMuc.DonViHanhChinhs;
using xdcb.Common.DanhMuc.LoaiCongTrinhs;
using xdcb.Common.DanhMuc.LoaiKhoans;
using xdcb.Common.DanhMuc.NhomCongTrinhs;

namespace xdcb.Common.DanhMuc.CongTrinhs
{
    public class DetailModalModel : Web.Pages.CommonBaseAbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CongTrinhViewModel CongTrinh { get; set; }

        [BindProperty]
        public List<DiaDiemThucHienDto> diaDiemThucHienDtos { get; set; }

        [BindProperty]
        public string diaDiemXayDungStr { get; set; }

        public Guid? ChuDauTuId { get; set; }
        private readonly ICurrentUser _currentUser;

        private readonly ICongTrinhAppService _congTrinhAppService;
        private readonly IChuDauTuAppService _chuDauTu;
        private readonly IDonViHanhChinhAppService _donViHanhChinh;

        public DetailModalModel(ICongTrinhAppService congTrinhAppService,
            IAuthorizationService authorization, IChuDauTuAppService chuDauTu, INhomCongTrinhAppService nhomCongTrinh,
            ILoaiKhoanAppService loaiKhoan, IChuongTrinhMucTieuQuocGiaAppService chuongTrinhMucTieuQuocGia, ILoaiCongTrinhAppService loaiCongTrinh,
            ICurrentUser currentUser, IDonViHanhChinhAppService donViHanhChinh)
        {
            _congTrinhAppService = congTrinhAppService;
            _chuDauTu = chuDauTu;
            _currentUser = currentUser;
            _donViHanhChinh = donViHanhChinh;
        }

        public async Task OnGetAsync(Guid congTrinhId)
        {
            this.Id = congTrinhId;
            var congTrinhDto = await _congTrinhAppService.GetCongTrinhDetailAsync(Id);
            CongTrinh = ObjectMapper.Map<CongTrinhDto, CongTrinhViewModel>(congTrinhDto);

            Guid? userId = _currentUser.Id;
            if (userId != null)
            {
                ChuDauTuId = await _chuDauTu.CheckChuDauTuAsync((Guid)userId);
            }
            diaDiemThucHienDtos = new List<DiaDiemThucHienDto>();
            var diaDiemXayDungs = await _donViHanhChinh.GetListByIdsAsync(congTrinhDto.DiaDiemXayDungs.Select(s => s.DonViHanhChinhId).Distinct().ToList());
            var thanhPhoHuyenThiXa = diaDiemXayDungs.Where(s => s.CapDonViHanhChinh == CapDonVi.ThanhPho ||
                                                                s.CapDonViHanhChinh == CapDonVi.Huyen ||
                                                                s.CapDonViHanhChinh == CapDonVi.ThiXa).ToList();
            foreach (var item in congTrinhDto.DiaDiemXayDungs)
            {
                var donViHanhChinhChaDto = thanhPhoHuyenThiXa.FirstOrDefault(s => s.Id == item.DonViHanhChinhId);
                if (donViHanhChinhChaDto != null)
                {
                    diaDiemThucHienDtos.Add(new DiaDiemThucHienDto { DonViHanhChinhChaId = donViHanhChinhChaDto.Id, ThanhPho = donViHanhChinhChaDto.TenDonViHanhChinh, GhiChu = item.GhiChu });
                }
                else
                {
                    var donViHanhChinhConDto = diaDiemXayDungs.FirstOrDefault(s => s.Id == item.DonViHanhChinhId);
                    if (donViHanhChinhConDto == null) continue;
                    diaDiemThucHienDtos.Add(new DiaDiemThucHienDto
                    {
                        DonViHanhChinhChaId = (Guid)donViHanhChinhConDto.ParentId,
                        DonViHanhChinhId = donViHanhChinhConDto.Id,
                        ThanhPho = thanhPhoHuyenThiXa.FirstOrDefault(s => s.Id == donViHanhChinhConDto.ParentId) != null ?
                                   thanhPhoHuyenThiXa.FirstOrDefault(s => s.Id == donViHanhChinhConDto.ParentId).TenDonViHanhChinh : string.Empty,
                        Phuong = donViHanhChinhConDto.TenDonViHanhChinh,
                        GhiChu = item.GhiChu
                    });
                }
            }
        }

        public class CongTrinhViewModel
        {
            public Guid? ChuDauTuId { get; set; }
            public string MaCongTrinh { get; set; }
            public string TenChuDauTu { get; set; }
            public string TenCongTrinh { get; set; }
            public Guid? NhomCongTrinhId { get; set; }
            public string MaSoDuAn { get; set; }
            public string TenNhomCongTrinh { get; set; }
            public string MaLoaiKhoan { get; set; }
            public string MaCTMTQG { get; set; }
            public string TenLoaiCongTrinh { get; set; }
            public Guid? LoaiKhoanId { get; set; }
            public Guid? CTMTQuocGiaId { get; set; }
            public Guid? LoaiCongTrinhId { get; set; }
            public double? DienTich { get; set; }
            public DateTime? ThoiGianThucHienTuNgay { get; set; }
            public DateTime? ThoiGianThucHienDenNgay { get; set; }
            public string SoQuyetDinhDauTu { get; set; }
            public DateTime? NgayQuyetDinhDauTu { get; set; }
            public decimal? TongMucDauTu { get; set; }
            public decimal? NST { get; set; }
            public decimal? NSTW { get; set; }
            public decimal? ODA { get; set; }
            public List<DiaDiemXayDungDto> DiaDiemXayDungs { get; set; }
        }
    }
}