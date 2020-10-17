using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using xdcb.HoSoCongTrinh.Enums;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhChiTietDto : FullAuditedEntityDto<Guid>
    {
        public Guid HoSoCongTrinhId { get; set; }

        public int SoLanDieuChinh { get; set; }

        public string SuCanThietDauTu { get; set; }

        public string QuyMoDauTu { get; set; }

        public string NguonVonDauTu { get; set; }

        public TrangThaiEnums TrangThai { get; set; }

        public DateTime HanXuLy { get; set; }

        public int OrderIndex { get; set; }

        public Guid TenantId { get; set; }

        /// <summary>
        /// Địa điểm xây dựng 
        /// </summary>
        public List<HoSoCongTrinhChiTietDiaDiemXayDungDto> DiaDiemXayDungs { get; set; }

        /// <summary>
        /// mức đầu tư
        /// </summary>
        public List<HoSoCongTrinhChiTietMucDauTuDto> MucDauTus { get; set; }

        ///// <summary>
        ///// Cơ sở pháp lý hồ sơ công trình
        ///// </summary>
        public List<HoSoCongTrinhChiTietCoSoPhapLyDto> CoSoPhapLys { get; set; }

        ///// <summary>
        ///// Thành phần hồ
        ///// </summary>
        public List<HoSoCongTrinhChiTietThanhPhanHoSoDto> ThanhPhanHoSos { get; set; }

        ///// <summary>
        ///// Gói thầu hồ sơ công trình
        ///// </summary>
        public List<HoSoCongTrinhChiTietGoiThauDto> GoiThaus { get; set; }

        ///// <summary>
        ///// Kết quả thẩm định
        ///// </summary>
        public List<HoSoCongTrinhChiTietKetQuaThamDinhDto> KetQuaThamDinhs { get; set; }
    }
}