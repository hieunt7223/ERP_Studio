using System;
using System.Collections.Generic;
using System.ComponentModel;
using xdcb.HoSoCongTrinh.Constants;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CoSoPhapLyViewModel
    {
        [DisplayName(ViewTextConsts.CoSoPhapLyViewModel.Stt)]
        public int Stt { get; set; }

        /// <summary>
        /// Id ho so cong trinh chi tiet co so phap ly
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id Hồ sơ công trình chi tiết
        /// </summary>
        public Guid? HoSoCongTrinhChiTietId { get; set; }

        /// <summary>
        /// Id Thư viện văn bản
        /// </summary>
        public Guid? ThuVienVanBanId { get; set; }

        [DisplayName(ViewTextConsts.CoSoPhapLyViewModel.NoiDung)]
        public string NoiDung { get; set; }

        public CoSoPhapLyJsonViewModel CoSoPhapLyJsonViewModel { get; set; }

        [DisplayName(ViewTextConsts.CoSoPhapLyViewModel.File)]
        public List<HoSoFile> Files { get; set; }
    }
}