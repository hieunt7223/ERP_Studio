using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhChiTietNoiDungYeuCauDto : FullAuditedEntityDto<Guid>
    {
        public Guid HoSoCongTrinhChiTietId { get; set; }

        public string NoiDung { get; set; }
    }
}