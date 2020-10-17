using System;
using System.Collections.Generic;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CreateUpdateThanhPhanHoSoDto
    {
        public Guid? HoSoCongTrinhChiTietId { get; set; }

        public Guid ThanhPhanHoSoId { get; set; }

        public string SoKyHieu { get; set; }

        public DateTime? NgayBanHanh { get; set; }

        /// <summary>
        /// Id Đơn vị ban hành get từ danh mục chủ đầu tư 
        /// </summary>
        public Guid? DonViBanHanhId { get; set; }

        public string TrichYeu { get; set; }

        public bool BatBuoc { get; set; }

        public List<CreateUpdateThanhPhanHoSoFileDto> HoSoCongTrinhChiTietThanhPhanHoSoFileDtos { get; set; }
    }
}