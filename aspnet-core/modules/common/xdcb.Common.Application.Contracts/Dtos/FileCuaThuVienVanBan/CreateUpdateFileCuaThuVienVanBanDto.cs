using System;

namespace xdcb.Common.DanhMuc.FileCuaThuVienVanBanDtos
{
    public class CreateUpdateFileCuaThuVienVanBanDto
    {
        public Guid Id { get; set; }
        public Guid ThuVienVanBanId { get; set; }
        public Guid FileId { get; set; }
    }
}