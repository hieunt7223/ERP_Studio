using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.ChuDauTuDtos
{
    public class ChuDauTuDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string MaSoChuong { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string GhiChu { get; set; }
        public string NguoiDaiDien { get; set; }
        public string SDTNguoiDaiDien { get; set; }
        public string NguoiDung { get; set; }

        #endregion Base properties
    }
}