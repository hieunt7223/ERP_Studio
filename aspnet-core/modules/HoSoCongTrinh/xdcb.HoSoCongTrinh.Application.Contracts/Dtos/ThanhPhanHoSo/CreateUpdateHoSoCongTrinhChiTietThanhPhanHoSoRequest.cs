using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CreateUpdateHoSoCongTrinhChiTietThanhPhanHoSoRequest
    {
        public Guid? Id { get; set; }

        public Guid? HoSoCongTrinhChiTietId { get; set; }

        public Guid ThanhPhanHoSoId { get; set; }

        public List<HoSoCongTrinhChiTietThanhPhanHoSoFileRequest> HoSoCongTrinhChiTietThanhPhanHoSoFiles { get; set; }

        public bool IsDeleted { get; set; }
    }
}