using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static xdcb.Common.DanhMuc.ViewTextConsts;

namespace xdcb.Common.DanhMuc.NghiQuyetDtos
{
    public class CreateUpdateNghiQuyetCongTrinhDto
    {
      
        public string SoVanBan { get; set; }
       
        public DateTime NgayBanHanh { get; set; }
      
        public string TrichYeu { get; set; }

     
        public bool IsTheoDoi { get; set; }

        public List<NghiQuyetCongTrinhDto> NghiQuyetCongTrinhs { get; set; }
    }
}
