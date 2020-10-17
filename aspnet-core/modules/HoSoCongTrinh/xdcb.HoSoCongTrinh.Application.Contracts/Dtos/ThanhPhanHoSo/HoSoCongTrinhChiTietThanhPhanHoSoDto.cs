using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhChiTietThanhPhanHoSoDto : FullAuditedEntityDto<Guid>
    {
        public Guid? HoSoCongTrinhChiTietId { get; set; }

        public Guid ThanhPhanHoSoId { get; set; }

        public List<HoSoCongTrinhChiTietThanhPhanHoSoFileDto> HoSoCongTrinhChiTietThanhPhanHoSoFileDtos { get; set; }
    }
}