using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CreateUpdateHoSoCongTrinhChiTietCoSoPhapLyRequest
    {
        public Guid? Id { get; set; }

        public Guid? HoSoCongTrinhChiTietId { get; set; }

        public Guid? ThuVienVanBanId { get; set; }

        /// <summary>
        /// Thư viện văn bản # null được lưu từ danh mục thư viện văn bản
        /// nếu = null thì được lưu theo hồ sơ công trình
        /// </summary>
        public string NoiDungJson { get; set; }

        public bool IsDeleted { get; set; }
    }
}