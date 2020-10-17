using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using xdcb.Common.DanhMuc.ChiPhiDauTus;
using xdcb.Common.DanhMuc.ChucVus;
using xdcb.Common.DanhMuc.ChuDauTus;
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGias;
using xdcb.Common.DanhMuc.CongTrinhs;
using xdcb.Common.DanhMuc.CongViecGoiThaus;
using xdcb.Common.DanhMuc.DonViBanHanhs;
using xdcb.Common.DanhMuc.DonViHanhChinhs;
using xdcb.Common.DanhMuc.DoUuTiens;
using xdcb.Common.DanhMuc.FileCuaThuVienVanBans;
using xdcb.Common.DanhMuc.GoiThaus;
using xdcb.Common.DanhMuc.HangMucCongTrinhs;
using xdcb.Common.DanhMuc.HinhThucChonNhaThaus;
using xdcb.Common.DanhMuc.HinhThucHopDongs;
using xdcb.Common.DanhMuc.HinhThucLuaChonNhaThaus;
using xdcb.Common.DanhMuc.KhoanChis;
using xdcb.Common.DanhMuc.LinhVucVanBans;
using xdcb.Common.DanhMuc.LoaiCongTrinhs;
using xdcb.Common.DanhMuc.LoaiGoiThaus;
using xdcb.Common.DanhMuc.LoaiHoSos;
using xdcb.Common.DanhMuc.LoaiKhoans;
using xdcb.Common.DanhMuc.LoaiVanBans;
using xdcb.Common.DanhMuc.NganhLinhVucSuDungs;
using xdcb.Common.DanhMuc.NghiQuyets;
using xdcb.Common.DanhMuc.NguonVons;
using xdcb.Common.DanhMuc.NhomCongTrinhs;
using xdcb.Common.DanhMuc.PhongBans;
using xdcb.Common.DanhMuc.PhuongThucDauThaus;
using xdcb.Common.DanhMuc.PhuongThucLuaChonNhaThaus;
using xdcb.Common.DanhMuc.ThanhPhanHoSos;
using xdcb.Common.DanhMuc.ThuVienVanBans;

namespace xdcb.Common
{
    [ConnectionStringName("Default")]
    public class CommonDbContext : AbpDbContext<CommonDbContext>
    {
        public DbSet<DonViHanhChinh> DonViHanhChinhs { get; set; }
        public DbSet<HangMucCongTrinh> HangMucCongTrinhs { get; set; }
        public DbSet<HinhThucChonNhaThau> HinhThucChonNhaThaus { get; set; }
        public DbSet<LinhVucVanBan> LinhVucVanBans { get; set; }
        public DbSet<LoaiCongTrinh> LoaiCongTrinhs { get; set; }
        public DbSet<NhomCongTrinh> NhomCongTrinhs { get; set; }
        public DbSet<DoUuTien> DoUuTiens { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<LoaiKhoan> Loai_Khoans { get; set; }
        public DbSet<HinhThucHopDong> HinhThucHopDongs { get; set; }
        public DbSet<ChuDauTu> ChuDauTus { get; set; }
        public DbSet<LoaiVanBan> LoaiVanBans { get; set; }
        public DbSet<NghiQuyet> NghiQuyets { get; set; }
        public DbSet<NghiQuyetCongTrinh> NghiQuyetCongTrinhs { get; set; }
        public DbSet<PhuongThucDauThau> PhuongThucDauThaus { get; set; }
        public DbSet<ChuongTrinhMucTieuQuocGia> ChuongTrinhMucTieuQuocGias { get; set; }
        public DbSet<NguonVon> NguonVons { get; set; }
        public DbSet<KhoanChi> KhoanChis { get; set; }
        public DbSet<ThanhPhanHoSo> ThanhPhanHoSos { get; set; }
        public DbSet<ChiPhiDauTu> ChiPhiDauTus { get; set; }
        public DbSet<ThuVienVanBan> ThuVienVanBans { get; set; }
        public DbSet<FileCuaThuVienVanBan> FileCuaThuVienVanBans { get; set; }
        public DbSet<PhongBan> PhongBans { get; set; }

        public DbSet<CongTrinh> CongTrinhs { get; set; }

        public DbSet<LoaiHoSo> LoaiHoSos { get; set; }

        public DbSet<DiaDiemXayDung> DiaDiemXayDungs { get; set; }

        public DbSet<NganhLinhVucSuDung> NganhLinhVucSuDungs { get; set; }

        public DbSet<DonViBanHanh> DonViBanHanhs { get; set; }

        public DbSet<HinhThucLuaChonNhaThau> HinhThucLuaChonNhaThaus { get; set; }

        public DbSet<PhuongThucLuaChonNhaThau> PhuongThucLuaChonNhaThaus { get; set; }

        public DbSet<GoiThau> GoiThaus { get; set; }

        public DbSet<LoaiGoiThau> LoaiGoiThaus { get; set; }

        public DbSet<CongViecGoiThau> CongViecGoiThaus { get; set; }


        public CommonDbContext(DbContextOptions<CommonDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            /* Configure your own tables/entities inside the Configurexdcb method */

            builder.ConfigureCommon();
        }
    }
}