using System;
using System.Collections.Generic;
using xdcb.HoSoCongTrinh.Enums;

namespace xdcb.HoSoCongTrinh.Dtos.HoSoCongTrinh
{
    public class CreateHoSoCongTrinhRequest
    {
        public Guid CongTrinhId { get; set; }

        public Guid LoaiHoSoId { get; set; }

        public Guid ChuDauTuId { get; set; }

        public TrangThaiEnums TrangThai { get; set; }

        public int SoLanDieuChinh { get; set; }

        public DateTime HanXuLy { get; set; }

        public CreateUpdateHoSoCongTrinhChiTietRequest HoSoCongTrinhChiTiets { get; set; }
    }
}
