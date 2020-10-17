using System;

namespace xdcb.Common.DanhMuc.LoaiHoSos
{
    public class BieuMauDto
    {
        public string TenBieuMau { get; set; }

        public Guid FileId { get; set; }

        public string TenFile { get; set; }

        public string LinkDownload { get; set; }

        public string FileHtml { get; set; }
    }
}