using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.LoaiHoSoCoSoPhapLyDtos
{
    public class LoaiHoSoCoSoPhapLyDto : AuditedEntityDto<Guid>
    {
        public Guid LoaiHoSoId { get; set; }

        public Guid ThuVienVanBanId { get; set; }
    }
}
