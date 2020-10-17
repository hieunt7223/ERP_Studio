using System;
using xdcb.Common.DanhMuc.ThuVienVanBans;

namespace xdcb.Common.DanhMuc.LoaiHoSos
{
    public class LoaiHoSoCoSoPhapLy
    {
        public Guid LoaiHoSoId { get; set; }

        public Guid ThuVienVanBanId { get; set; }

        public LoaiHoSo LoaiHoSo { get; set; }

        public ThuVienVanBan ThuVienVanBan { get; set; }
    }
}