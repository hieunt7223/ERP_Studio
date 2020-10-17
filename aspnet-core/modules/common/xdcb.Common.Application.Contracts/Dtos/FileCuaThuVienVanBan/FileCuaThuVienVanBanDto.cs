using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.FileCuaThuVienVanBanDtos
{
    public class FileCuaThuVienVanBanDto : AuditedEntityDto<Guid>
    {
        public Guid ThuVienVanBanId { get; set; }
        public Guid FileId { get; set; }

        #region file info

        public string TenFile { get; set; }

        public string LinkDownload { get; set; }

        public string KieuFile { get; set; }

        public decimal? KichThuoc { get; set; }

        public string FullName { get; set; }

        #endregion file info
    }
}