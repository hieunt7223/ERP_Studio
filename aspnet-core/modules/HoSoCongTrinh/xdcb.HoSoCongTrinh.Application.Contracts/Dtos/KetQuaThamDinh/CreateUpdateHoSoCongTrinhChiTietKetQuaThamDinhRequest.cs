using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CreateUpdateHoSoCongTrinhChiTietKetQuaThamDinhRequest
    {
        public Guid? Id { get; set; }

        public Guid? HoSoCongTrinhChiTietId { get; set; }

        public Guid? FileId { get; set; }

        public bool IsDeleted { get; set; }
    }
}