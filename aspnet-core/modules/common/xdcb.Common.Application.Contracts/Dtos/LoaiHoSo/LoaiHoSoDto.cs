using System;
using System.Collections.Generic;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;
using xdcb.Common.DanhMuc.LoaiHoSoChiPhiDauTuDtos;
using xdcb.Common.DanhMuc.LoaiHoSoCoSoPhapLyDtos;
using xdcb.Common.DanhMuc.LoaiHoSoThanhPhanHoSoDtos;

namespace xdcb.Common.DanhMuc.LoaiHoSoDtos
{
    public class LoaiHoSoDto : AuditedEntityDto<Guid>
    {
        public string TenLoaiHoSo { get; set; }

        public bool IsDieuChinh { get; set; }

        public bool IsTrangThai { get; set; }

        public string BieuMau { get; set; }

        public string TenViewLoaiHoSo { get; set; }

        public int? ThoiGianXuLyQuyDinhNhomA { get; set; }

        public int? ThoiGianXuLyQuyDinhNhomB { get; set; }

        public int? ThoiGianXuLyQuyDinhNhomC { get; set; }

        public List<LoaiHoSoChiPhiDauTuDto> LoaiHoSoChiPhiDauTus { get; set; }

        public List<LoaiHoSoThanhPhanHoSoDto> LoaiHoSoThanhPhanHoSos { get; set; }

        public List<LoaiHoSoCoSoPhapLyDto> LoaiHoSoCoSoPhapLys { get; set; }
    }
    public class LoaiHoSoReport
    {
        [Description(ViewTextConsts.LoaiHoSo.TenHoSo)]
        public string TenLoaiHoSo { get; set; }

        [Description(ViewTextConsts.LoaiHoSo.TrangThai)]
        public string TrangThai { get; set; }
    }
}