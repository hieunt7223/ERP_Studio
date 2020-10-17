using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using xdcb.HoSoCongTrinh.Constants;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class KetQuaThamDinhPhapLyDto
    {
        /// <summary>
        /// Id Thư viện văn bản
        /// </summary>
        [DisplayName(ViewTextConsts.CongViec.NoiDungKiemTra)]
        public Guid NoiDungKiemTraId { get; set; }

        /// <summary>
        /// Tên thư viện văn bản
        /// </summary>
        [DisplayName(ViewTextConsts.CongViec.NoiDungKiemTra)]
        [Required(ErrorMessage = HoSoConstants.Messages.MSG_Requied)]
        public string TenNoiDungKiemTra { get; set; }

        /// <summary>
        /// Kết quả thẩm đinh
        /// </summary>
        [DisplayName(ViewTextConsts.CongViec.KetQuaThamDinh)]
        [Required(ErrorMessage = HoSoConstants.Messages.MSG_Requied)]
        public bool IsKetQuaThamDinh { get; set; }
    }
}