using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhDto : FullAuditedEntityDto<Guid>
    {
        public Guid CongTrinhId { get; set; }

        public Guid LoaiHoSoId { get; set; }

        public Guid ChuDauTuId { get; set; }

        public int TrangThai { get; set; }

        public DateTime HanXuLy { get; set; }

        public int SoLanDieuChinh { get; set; }

        public List<HoSoCongTrinhChiTietDto> HoSoCongTrinhChiTietDtos { get; set; }
    }
}