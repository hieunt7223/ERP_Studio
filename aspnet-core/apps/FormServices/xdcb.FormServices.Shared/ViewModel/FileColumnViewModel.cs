using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xdcb.FormServices.Shared
{
    public class FileColumnViewModel
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }

        public string path { get; set; }

        public string url { get; set; }

        public string TypeFile { get; set; }

        public decimal Length { get; set; }

        public string ContentType { get; set; }

        public string Name { get; set; }
    }
}
