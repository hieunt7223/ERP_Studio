using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhChiTietThanhPhanHoSoFileRequest
    {
        public Guid HoSoCongTrinhChiTietThanhPhanHoSoId { get; set; }

        public Guid? FileId { get; set; }
    }
}