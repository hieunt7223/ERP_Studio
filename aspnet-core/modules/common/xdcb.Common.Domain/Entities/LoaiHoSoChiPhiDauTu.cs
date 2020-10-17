using System;
using xdcb.Common.DanhMuc.ChiPhiDauTus;

namespace xdcb.Common.DanhMuc.LoaiHoSos
{
    public class LoaiHoSoChiPhiDauTu
    {
        public Guid LoaiHoSoId { get; set; }

        public Guid ChiPhiDauTuId { get; set; }

        public LoaiHoSo LoaiHoSo { get; set; }

        public ChiPhiDauTu ChiPhiDauTu { get; set; }
    }
}