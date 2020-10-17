using System.ComponentModel.DataAnnotations;

namespace xdcb.FormServices.ConfigColumns.Dtos
{
    public class CreateUpdateConfigColumnDto
    {
        [Required]
        [StringLength(200)]
        public string ConfigColumnName { get; set; }

        [Required]
        [StringLength(200)]
        public string ConfigColumnCaption { get; set; }

        [StringLength(200)]
        public string ConfigColumnTableName { get; set; }

        public string Status { get; set; }

        public int? ConfigColumnVisibleIndex { get; set; }

        public string ConfigColumnDataType { get; set; }

        public int? ConfigColumnLength { get; set; }

        public bool? ConfigColumnAllowEdit { get; set; }

        public bool? ConfigColumnIsVisible { get; set; }

        public string ConfigColumnDisplayFormat { get; set; }

        public string ConfigColumnFunctionCode { get; set; }

        public string ConfigColumnDataSource { get; set; }

        public string ConfigColumnDisplayMember { get; set; }

        public string ConfigColumnValueMember { get; set; }

        public string ConfigColumnFilter { get; set; }

        public int? ConfigColumnWidth { get; set; }
    }
}