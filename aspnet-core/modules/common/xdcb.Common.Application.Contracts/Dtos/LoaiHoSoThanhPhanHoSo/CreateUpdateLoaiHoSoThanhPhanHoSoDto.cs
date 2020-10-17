using System;

namespace xdcb.Common.DanhMuc.LoaiHoSoThanhPhanHoSoDtos
{
    public class CreateUpdateLoaiHoSoThanhPhanHoSoDto
    {
        public Guid ThanhPhanHoSoId { get; set; }
        public bool BatBuoc { get; set; }
    }
}