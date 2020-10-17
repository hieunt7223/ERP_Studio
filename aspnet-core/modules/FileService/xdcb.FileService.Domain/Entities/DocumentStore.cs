using System;
using System.Collections.Generic;
using System.Text;

namespace xdcb.FileService.DocumentStores
{
    public class DocumentStore : BaseEntity
    {
        #region Base properties

        public string TenFile { get; set; }
        public string Url { get; set; }
        public string KieuFile { get; set; }
        public decimal? KichThuoc { get; set; }
        public string FullName { get; set; }
        public decimal? TotalPage { get; set; }
        public string Cached { get; set; }


        #endregion Base properties
    }
}
