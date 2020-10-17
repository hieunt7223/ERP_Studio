using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.LoaiHoSoThanhPhanHoSoDtos
{
    public class LoaiHoSoThanhPhanHoSoDto : AuditedEntityDto<Guid>
    {
        public Guid LoaiHoSoId { get; set; }
        public Guid ThanhPhanHoSoId { get; set; }
        public bool BatBuoc { get; set; }
    }
}
