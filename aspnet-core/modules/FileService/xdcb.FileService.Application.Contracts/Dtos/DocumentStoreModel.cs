using System;
using System.Collections.Generic;
using System.Text;

namespace xdcb.FileService.DocumentStoreDtos
{
    public class DocumentStoreModel
    {
        public Guid Id { get; set; }
        public string TenFile { get; set; }
        public string Url { get; set; }
        public string KieuFile { get; set; }
        public decimal? KichThuoc { get; set; }
        public string FullName { get; set; }
        public decimal? TotalPage { get; set; }
        public string Cached { get; set; }
    }
}
