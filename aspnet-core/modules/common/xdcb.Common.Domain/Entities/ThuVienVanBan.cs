using System;
using System.Collections.Generic;
using xdcb.Common.DanhMuc.FileCuaThuVienVanBans;
using xdcb.Common.DanhMuc.LinhVucVanBans;
using xdcb.Common.DanhMuc.LoaiHoSos;
using xdcb.Common.DanhMuc.LoaiVanBans;

namespace xdcb.Common.DanhMuc.ThuVienVanBans
{
    public class ThuVienVanBan : BaseEntity
    {
        #region Base properties

        public ThuVienVanBan()
        {
            FileCuaThuVienVanBans = new HashSet<FileCuaThuVienVanBan>();
        }
        public string SoKyHieu { get; set; }
        public Guid? LinhVucVanBanId { get; set; }
        public Guid LoaiVanBanId { get; set; }
        public string TrichYeu { get; set; }
        public int CapBanHanh { get; set; }
        public Guid DonViBanHanhId { get; set; }
        public DateTime NgayBanHanh { get; set; }
        public virtual LinhVucVanBan LinhVucVanBan { get; set; }
        public virtual LoaiVanBan LoaiVanBan { get; set; }

        public virtual ICollection<FileCuaThuVienVanBan> FileCuaThuVienVanBans { get; set; }

        public List<LoaiHoSoCoSoPhapLy> LoaiHoSoCoSoPhapLys { get; set; }

        #endregion Base properties
    }
}