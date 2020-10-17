using System;
using System.Collections.Generic;
using System.ComponentModel;
using xdcb.HoSoCongTrinh.Constants;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class ThanhPhanHoSoViewModel
    {
        [DisplayName(ViewTextConsts.ThanhPhanHoSoViewModel.Stt)]
        public int Stt { get; set; }

        /// <summary>
        /// Id Thanh phan ho so
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id Hồ sơ công trình chi tiết
        /// </summary>
        public Guid? HoSoCongTrinhChiTietId { get; set; }

        /// <summary>
        /// Id Loại văn bản
        /// </summary>
        public Guid LoaiVanBanId { get; set; }

        [DisplayName(ViewTextConsts.ThanhPhanHoSoViewModel.ThongTinThanhPhanHoSo)]
        public string ThongTinThanhPhanHoSo { get; set; }

        /// <summary>
        /// Id Thành phần hồ sơ
        /// </summary>
        [DisplayName(ViewTextConsts.ThanhPhanHoSoViewModel.ThongTinThanhPhanHoSo)]
        public Guid ThanhPhanHoSoId { get; set; }

        [DisplayName(ViewTextConsts.ThanhPhanHoSoViewModel.Files)]
        public List<HoSoFile> Files { get; set; }

        [DisplayName(ViewTextConsts.ThanhPhanHoSoViewModel.BatBuoc)]
        public bool BatBuoc { get; set; } = false;

        public ActionViewModel Action { get; set; }

        /// <summary>
        /// Số quyết định
        /// </summary>
        [DisplayName(ViewTextConsts.ThanhPhanHoSoViewModel.SoQuyetDinh)]
        public string SoQuyetDinh { get; set; }

        /// <summary>
        /// Ngày ban hành
        /// </summary>
        [DisplayName(ViewTextConsts.ThanhPhanHoSoViewModel.NgayBanHanh)]
        public DateTime? NgayBanHanh { get; set; }

        /// <summary>
        /// Ngày ban hành format
        /// </summary>
        [DisplayName(ViewTextConsts.ThanhPhanHoSoViewModel.NgayBanHanh)]
        public string NgayBanHanhFormat { get; set; }

        /// <summary>
        /// Id đơn vị ban hành get từ danh mục chủ đầu tư
        /// </summary>
        [DisplayName(ViewTextConsts.ThanhPhanHoSoViewModel.DonViBanHanh)]
        public Guid? DonViBanHanhId { get; set; }

        /// <summary>
        /// Tên đơn vị ban hành
        /// </summary>
        [DisplayName(ViewTextConsts.ThanhPhanHoSoViewModel.DonViBanHanh)]
        public string TenDonViBanHanh { get; set; }

        /// <summary>
        /// trích yếu
        /// </summary>
        public string TrichYeu { get; set; }
    }
}