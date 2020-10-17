using System;
using System.Collections.Generic;
using System.Text;
using xdcb.HoSoCongTrinh.Enums;

namespace xdcb.HoSoCongTrinh.Dtos.HoSoCongTrinh
{
    public class CreateUpdateHoSoCongTrinhChiTietRequest
    {
        public Guid? Id { get; set; }

        public string SuCanThietDauTu { get; set; }

        public string QuyMoDauTu { get; set; }

        public string NguonVonDauTu { get; set; }

        public Guid? HoSoCongTrinhId { get; set; }

        /// <summary>
        /// Địa điểm xây dựng 
        /// </summary>
        public List<CreateUpdateHoSoCongTrinhChiTietDiaDiemXayDungRequest> HoSoCongTrinhChiTietDiaDiems { get; set; }

        /// <summary>
        /// mức đầu tư
        /// </summary>
        public List<CreateUpdateHoSoCongTrinhChiTietMucDauTuRequest> HoSoCongTrinhChiTietMucDauTus { get; set; }

        /// <summary>
        /// Thành phần hồ
        /// </summary>
        public List<CreateUpdateHoSoCongTrinhChiTietThanhPhanHoSoRequest> HoSoCongTrinhChiTietThanhPhanHoSos { get; set; }

        /// <summary>
        /// Gói thầu hồ sơ công trình
        /// </summary>
        //public List<HoSoCongTrinhChiTietGoiThauRequest> GoiThaus { get; set; }

        /// <summary>
        /// Cơ sở pháp lý hồ sơ công trình
        /// </summary>
        public List<CreateUpdateHoSoCongTrinhChiTietCoSoPhapLyRequest> HoSoCongTrinhChiTietCoSoPhapLys { get; set; }

        /// <summary>
        /// Kết quả thẩm định
        /// </summary>
        public List<CreateUpdateHoSoCongTrinhChiTietKetQuaThamDinhRequest> HoSoCongTrinhChiTietKetQuaThamDinhs { get; set; }
    }
}
