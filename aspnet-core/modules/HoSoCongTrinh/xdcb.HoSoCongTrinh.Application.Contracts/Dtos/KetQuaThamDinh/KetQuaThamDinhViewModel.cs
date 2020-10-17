using System;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class KetQuaThamDinhViewModel
    {
        public int Stt { get; set; }

        /// <summary>
        /// Id ket qua tham dinh
        /// </summary>
        public Guid Id { get; set; }

        public Guid? HoSoCongTrinhChiTietId { get; set; }

        public HoSoFile File { get; set; }
    }
}