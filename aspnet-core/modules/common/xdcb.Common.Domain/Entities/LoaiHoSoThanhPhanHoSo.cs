using System;
using xdcb.Common.DanhMuc.ThanhPhanHoSos;

namespace xdcb.Common.DanhMuc.LoaiHoSos
{
    public class LoaiHoSoThanhPhanHoSo
    {
        public Guid LoaiHoSoId { get; set; }

        public LoaiHoSo LoaiHoSo { get; set; }

        public Guid ThanhPhanHoSoId { get; set; }

        public ThanhPhanHoSo ThanhPhanHoSo { get; set; }

        public bool BatBuoc { get; set; }
    }
}