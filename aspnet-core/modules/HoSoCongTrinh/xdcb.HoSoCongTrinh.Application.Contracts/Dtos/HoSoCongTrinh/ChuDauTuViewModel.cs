using System;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class ChuDauTuViewModel
    {
        /// <summary>
        /// Id chủ đầu tư
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Tên chủ đầu tư
        /// </summary>
        public string Ten { get; set; }
    }
}