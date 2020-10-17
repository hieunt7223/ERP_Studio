using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.CongTrinhDtos;


namespace xdcb.Common.DanhMuc.CongTrinhs
{
    public class CongTrinhAppService : CrudAppService<CongTrinh,
            CongTrinhDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateCongTrinhDto, CreateUpdateCongTrinhDto>,
        ICongTrinhAppService
    {
        private readonly ICongTrinhRepository _congTrinhRepository;



        public CongTrinhAppService(
            ICongTrinhRepository congTrinhRepository) : base(congTrinhRepository)
        {
            _congTrinhRepository = congTrinhRepository;
        }

        public async Task<int> CountAsync()
        {
            return await _congTrinhRepository.CountAsync();
        }

        public async Task<CongTrinhDto> GetCongTrinhByIdAsync(Guid id)
        {
            var item = await _congTrinhRepository.GetCongTrinhByIdAsync(id);
            return ObjectMapper.Map<CongTrinh, CongTrinhDto>(item);
        }

        public async Task<CongTrinhDto> CreateData(CreateUpdateCongTrinhDto input)
        {
            if (input.DiaDiemXayDungs != null && input.DiaDiemXayDungs.Count > 0)
                input.DiaDiemXayDungs.Clear();
            var item = ObjectMapper.Map<CreateUpdateCongTrinhDto, CongTrinh>(input);
            var data = await _congTrinhRepository.InsertAsync(item, true);
            return ObjectMapper.Map<CongTrinh, CongTrinhDto>(data);
        }

        public async Task<CongTrinhDto> UpdateData(Guid id, CreateUpdateCongTrinhDto input)
        {
            var item = await _congTrinhRepository.GetAsync(id);
            if (item != null && item.IsDeleted == false)
            {
                item.ChuDauTuId = input.ChuDauTuId;
                item.MaCongTrinh = input.MaCongTrinh;
                item.TenCongTrinh = input.TenCongTrinh;
                item.NhomCongTrinhId = input.NhomCongTrinhId;
                item.MaSoDuAn = input.MaSoDuAn;
                item.LoaiKhoanId = input.LoaiKhoanId;
                item.CTMTQuocGiaId = input.CTMTQuocGiaId;
                item.LoaiCongTrinhId = input.LoaiCongTrinhId;
                item.DienTich = input.DienTich;
                item.ThoiGianThucHienTuNgay = input.ThoiGianThucHienTuNgay;
                item.ThoiGianThucHienDenNgay = input.ThoiGianThucHienDenNgay;
                item.SoQuyetDinhDauTu = input.SoQuyetDinhDauTu;
                item.NgayQuyetDinhDauTu = input.NgayQuyetDinhDauTu;
                item.TongMucDauTu = input.TongMucDauTu;
                item.NSTW = input.NSTW;
                item.NST = input.NST;
                item.ODA = input.ODA;
                var data = await _congTrinhRepository.UpdateAsync(item, true);
                return ObjectMapper.Map<CongTrinh, CongTrinhDto>(data);
            }
            return ObjectMapper.Map<CongTrinh, CongTrinhDto>(item);
        }

        public async Task<CongTrinhDto> SaveDiaDiemXayDung(CreateUpdateCongTrinhDto input)
        {
            CongTrinh item = new CongTrinh();
            List<DiaDiemXayDung> listDiaDiemXayDung = new List<DiaDiemXayDung>();
            input.DiaDiemXayDungs.ForEach(o =>
            {
                DiaDiemXayDung obj = new DiaDiemXayDung();
                obj.CongTrinhId = o.CongTrinhId;
                obj.DonViHanhChinhId = o.DonViHanhChinhId;
                obj.GhiChu = o.GhiChu;
                listDiaDiemXayDung.Add(obj);
            });
            item.DiaDiemXayDungs = listDiaDiemXayDung;
            var data = await _congTrinhRepository.SaveDiaDiemXayDung(item);
            return ObjectMapper.Map<CongTrinh, CongTrinhDto>(data);
        }

        public async Task DeleleDiaDiemXayDungByCongTrinhId(Guid id)
        {
            await _congTrinhRepository.DeleleDiaDiemXayDungByCongTrinhId(id);
            return;
        }

        public async Task<List<CongTrinhDto>> GetListByChuDauTuIdAsync(Guid ChuDauTuId)
        {
            var items = await _congTrinhRepository.GetListAsync();
            if (items != null && items.Count > 0)
            {
                items = items.Where(x => x.IsDeleted == false && x.ChuDauTuId == ChuDauTuId).ToList();
            }
            return new List<CongTrinhDto>(ObjectMapper.Map<List<CongTrinh>, List<CongTrinhDto>>(items));
        }

        #region Property
        public async Task<List<CongTrinhDto>> GetListNotPageAsync()
        {
            var items = await _congTrinhRepository.GetListAsync();
            List<CongTrinhDto> data = new List<CongTrinhDto>();
            if (items != null && items.Count > 0)
            {
                data = (List<CongTrinhDto>)ObjectMapper.Map<List<CongTrinh>, List<CongTrinhDto>>(items.ToList().Where(x => x.IsDeleted == false).ToList());
                return data;
            }
            return data;
        }

        public async Task<CongTrinhDto> UpdateTongMucDauTu(Guid id, CreateUpdateCongTrinhDto input)
        {
            var item = await _congTrinhRepository.GetAsync(id);
            if (item != null && item.IsDeleted == false)
            {
                item.TongMucDauTu = input.TongMucDauTu;
                var data = await _congTrinhRepository.UpdateAsync(item, true);
                return ObjectMapper.Map<CongTrinh, CongTrinhDto>(data);
            }
            return ObjectMapper.Map<CongTrinh, CongTrinhDto>(item);
        }

        [HttpGet]
        [Route("/api​/app​/congTrinh​/searchData​")]
        public async Task<List<CongTrinhDto>> GetSearchData(string tencongtrinh, Guid chuDauTuId,int nam)
        {
            List<CongTrinhDto> list = new List<CongTrinhDto>();

            if (string.IsNullOrWhiteSpace(tencongtrinh))
            {
                tencongtrinh = "";
            }

            var item = _congTrinhRepository.GetListAsync().GetAwaiter().GetResult().ToList();
            if (item != null && item.Count > 0)
            {
                var data = item.Where(x => (x.IsDeleted == false)
                              && (tencongtrinh == "" || x.TenCongTrinh.ToString().ToLower().Contains(tencongtrinh.ToString().ToLower()))
                              && (chuDauTuId == Guid.Empty || x.ChuDauTuId == chuDauTuId)
                              && (nam == 0 || (Convert.ToDateTime(x.ThoiGianThucHienTuNgay).Year<= nam 
                                            && Convert.ToDateTime(x.ThoiGianThucHienDenNgay).Year >= nam))
                ).ToList();
                return ObjectMapper.Map<List<CongTrinh>, List<CongTrinhDto>>(data);
            }
            return list;
        }

        [HttpGet]
        public async Task<PagedResultDto<CongTrinhDto>> SearchAsync(CongTrinhConditionSearch condition)
        {
            var hoSoCongTrinhDtoList = new List<CongTrinhDto>();
            condition.keyword = Common.ConvertToUnSign(condition.keyword);
            var hoSoCongTrinhList = await _congTrinhRepository.SearchAsync(condition);
            foreach (var item in hoSoCongTrinhList.Items)
            {

                hoSoCongTrinhDtoList.Add(new CongTrinhDto
                {
                    TenChuDauTu = item.ChuDauTu != null ? item.ChuDauTu.Ten : "",
                    ChuDauTuId = item.ChuDauTu != null ? item.ChuDauTuId : null,
                    MaChuong = item.ChuDauTu != null ? item.ChuDauTu.MaSoChuong : "",
                    MaCongTrinh = item.MaCongTrinh ?? "",
                    TenCongTrinh = item.TenCongTrinh ?? "",
                    NhomCongTrinhId = item.NhomCongTrinh != null ? item.NhomCongTrinhId : null,
                    TenNhomCongTrinh = item.NhomCongTrinh != null ? item.NhomCongTrinh.TenNhomCongTrinh : "",
                    MaSoDuAn = item.MaSoDuAn ?? "",
                    LoaiKhoanId = item.LoaiKhoan != null ? item.LoaiKhoanId : null,
                    MaLoaiKhoan = item.LoaiKhoan != null ? item.LoaiKhoan.MaSo : "",
                    CTMTQuocGiaId = item.ChuongTrinhMucTieuQuocGia != null ? item.CTMTQuocGiaId : null,
                    LoaiCongTrinhId = item.LoaiCongTrinh != null ? item.LoaiCongTrinhId : null,
                    DienTich = item.DienTich,
                    ThoiGianThucHienTuNgay = item.ThoiGianThucHienTuNgay,
                    ThoiGianThucHienDenNgay = item.ThoiGianThucHienDenNgay,
                    SoQuyetDinhDauTu = item.SoQuyetDinhDauTu,
                    NgayQuyetDinhDauTu = item.NgayQuyetDinhDauTu,
                    TongMucDauTu = item.TongMucDauTu,
                    DiaDiemXayDungs = ObjectMapper.Map<List<DiaDiemXayDung>, List<DiaDiemXayDungDto>>(item.DiaDiemXayDungs),
                    Id = item.Id,
                    CreatorId = item.CreatorId,
                });
            }
            return new PagedResultDto<CongTrinhDto>
            {
                Items = hoSoCongTrinhDtoList,
                TotalCount = hoSoCongTrinhList.TotalCount
            };
        }

        public async Task<CongTrinhDto> GetCongTrinhDetailAsync(Guid id)
        {
            var congTrinh = await _congTrinhRepository.GetCongTrinhByIdAsync(id);

            var congTrinhDto = new CongTrinhDto
            {
                TenChuDauTu = congTrinh.ChuDauTu != null ? congTrinh.ChuDauTu.Ten : "",
                ChuDauTuId = congTrinh.ChuDauTu != null ? congTrinh.ChuDauTuId : null,
                MaChuong = congTrinh.ChuDauTu != null ? congTrinh.ChuDauTu.MaSoChuong : "",
                MaCongTrinh = congTrinh.MaCongTrinh ?? "",
                TenCongTrinh = congTrinh.TenCongTrinh ?? "",
                NhomCongTrinhId = congTrinh.NhomCongTrinh != null ? congTrinh.NhomCongTrinhId : null,
                TenNhomCongTrinh = congTrinh.NhomCongTrinh != null ? congTrinh.NhomCongTrinh.TenNhomCongTrinh : "",
                MaSoDuAn = congTrinh.MaSoDuAn ?? "",
                LoaiKhoanId = congTrinh.LoaiKhoan != null ? congTrinh.LoaiKhoanId : null,
                MaLoaiKhoan = congTrinh.LoaiKhoan != null ? congTrinh.LoaiKhoan.MaSo : "",
                TenLoaiKhoan = congTrinh.LoaiKhoan != null ? congTrinh.LoaiKhoan.TenLoaiKhoan : "",
                CTMTQuocGiaId = congTrinh.ChuongTrinhMucTieuQuocGia != null ? congTrinh.CTMTQuocGiaId : null,
                LoaiCongTrinhId = congTrinh.LoaiCongTrinh != null ? congTrinh.LoaiCongTrinhId : null,
                DienTich = congTrinh.DienTich,
                ThoiGianThucHienTuNgay = congTrinh.ThoiGianThucHienTuNgay,
                ThoiGianThucHienDenNgay = congTrinh.ThoiGianThucHienDenNgay,
                SoQuyetDinhDauTu = congTrinh.SoQuyetDinhDauTu,
                NgayQuyetDinhDauTu = congTrinh.NgayQuyetDinhDauTu,
                TongMucDauTu = congTrinh.TongMucDauTu,
                DiaDiemXayDungs = ObjectMapper.Map<List<DiaDiemXayDung>, List<DiaDiemXayDungDto>>(congTrinh.DiaDiemXayDungs),
                Id = congTrinh.Id,
                MaCTMTQG = congTrinh.ChuongTrinhMucTieuQuocGia != null ? congTrinh.ChuongTrinhMucTieuQuocGia.MaChuongTrinhMucTieuQuocGia : "",
                TenLoaiCongTrinh = congTrinh.LoaiCongTrinh != null ? congTrinh.LoaiCongTrinh.TenLoaiCongTrinh : "",
                NST = congTrinh.NST,
                NSTW = congTrinh.NSTW,
                ODA = congTrinh.ODA
            };

            return congTrinhDto;
        }
        [HttpGet]
        public bool IsMaExist(string ma, Guid id)
        {
            if (ma == null)
            {
                ma = "";
            }
            return _congTrinhRepository.IsMaExist(ma, id);
        }
        [HttpGet]
        public bool IsNameExist(string name, Guid id)
        {
            if (name == null)
            {
                name = "";
            }
            return _congTrinhRepository.IsNameExist(name, id);
        }
        #endregion
    }
}