using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CreateUpdateHoSoCongTrinhChiTietDiaDiemXayDungRequest
    {
        public Guid? Id { get; set; }

        public Guid? HoSoCongTrinhChiTietId { get; set; }

        public Guid DonViHanhChinhId { get; set; }

        public string GhiChu { get; set; }

        public bool IsDeleted { get; set; }
    }
}