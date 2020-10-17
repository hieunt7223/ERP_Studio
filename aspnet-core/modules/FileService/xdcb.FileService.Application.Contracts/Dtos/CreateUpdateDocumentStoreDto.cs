using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace xdcb.FileService.DocumentStoreDtos
{
    public class CreateUpdateDocumentStoreDto
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string TenFile { get; set; }
        [Required]
        [StringLength(255)]
        public string Url { get; set; }
        [Required]
        [StringLength(255)]
        public string KieuFile { get; set; }
        public decimal? KichThuoc { get; set; }
        [StringLength(255)]
        public string FullName { get; set; }
        public decimal? TotalPage { get; set; }
        [StringLength(255)]
        public string Cached { get; set; }
    }
}
