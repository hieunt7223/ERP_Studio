using System.Collections.Generic;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhViewModel
    {
        /// <summary>
        /// Số thứ tự hiển thị trên view
        /// </summary>
        public int Stt { get; set; }

        public CongTrinhViewModel CongTrinh { get; set; }

        public ChuDauTuViewModel ChuDauTu { get; set; }

        public ActionViewModel Action { get; set; }

        public List<HoSoViewModel> HoSos { get; set; } = new List<HoSoViewModel>();
    }
}