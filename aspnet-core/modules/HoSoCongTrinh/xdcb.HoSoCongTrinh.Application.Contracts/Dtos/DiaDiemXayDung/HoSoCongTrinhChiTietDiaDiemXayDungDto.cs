using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhChiTietDiaDiemXayDungDto : FullAuditedEntityDto<Guid>
    {
        public Guid HoSoCongTrinhChiTietId { get; set; }

        public Guid DonViHanhChinhId { get; set; }

        public string GhiChu { get; set; }
    }
}