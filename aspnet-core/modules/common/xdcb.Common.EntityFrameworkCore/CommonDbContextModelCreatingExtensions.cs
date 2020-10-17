using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using xdcb.Common.DanhMuc;
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
    public static class CommonDbContextModelCreatingExtensions
    {
        public static void ConfigureCommon(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<DonViHanhChinh>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "DonViHanhChinhs", DanhMucDBConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.MaDonViHanhChinh).HasColumnType("nvarchar(10)").IsRequired(true);
                b.Property(x => x.TenDonViHanhChinh).HasMaxLength(255).IsRequired(true);
                b.HasIndex(e => e.MaDonViHanhChinh).IsUnique();
            });

            builder.Entity<HangMucCongTrinh>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "HangMucCongTrinhs", DanhMucDBConsts.DbSchema);
                b.Property(s => s.MaHangMuc).HasColumnType("nvarchar(10)");
                b.Property(s => s.TenHangMuc).HasMaxLength(255).IsRequired(true);
                b.Property(s => s.MoTa).HasMaxLength(500);
                b.ConfigureByConvention();
            });

            builder.Entity<LoaiCongTrinh>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "LoaiCongTrinhs", DanhMucDBConsts.DbSchema);
                b.Property(s => s.MaLoaiCongTrinh).HasColumnType("nvarchar(10)");
                b.Property(s => s.TenLoaiCongTrinh).HasMaxLength(255).IsRequired(true);
                b.Property(s => s.MoTa).HasMaxLength(500);
                
                b.ConfigureByConvention();
            });
            builder.Entity<NhomCongTrinh>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "NhomCongTrinhs", DanhMucDBConsts.DbSchema);
                b.Property(s => s.MaNhomCongTrinh).HasColumnType("nvarchar(10)");
                b.Property(s => s.TenNhomCongTrinh).HasMaxLength(255).IsRequired(true);
                b.Property(s => s.MoTa).HasMaxLength(500);
                b.ConfigureByConvention();
            });

            builder.Entity<HinhThucHopDong>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "HinhThucHopDongs", DanhMucDBConsts.DbSchema);
                b.Property(s => s.TenHinhThucHopDong).HasMaxLength(255).IsRequired(true);
                b.HasIndex(s => s.TenHinhThucHopDong).IsUnique();
                b.ConfigureByConvention();
            });

            builder.Entity<LinhVucVanBan>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "LinhVucVanBans", DanhMucDBConsts.DbSchema);
                b.Property(s => s.MaLinhVuc).HasMaxLength(10);
                b.Property(s => s.TenLinhVuc).HasMaxLength(256).IsRequired(true);
                b.Property(s => s.MoTa).HasMaxLength(500);
                b.ConfigureByConvention();
            });
            builder.Entity<DoUuTien>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "DoUuTiens", DanhMucDBConsts.DbSchema);
                b.Property(s => s.TenDoUuTien).HasMaxLength(255).IsRequired(true);
                b.Property(s => s.MoTa).HasMaxLength(500);
                b.ConfigureByConvention();
            });
            builder.Entity<ChucVu>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "ChucVus", DanhMucDBConsts.DbSchema);
                b.Property(s => s.MaChucVu).HasColumnType("nvarchar(10)");
                b.Property(s => s.TenChucVu).HasMaxLength(255).IsRequired(true);
                b.ConfigureByConvention();
            });

            builder.Entity<HinhThucChonNhaThau>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "HinhThucChonNhaThaus", DanhMucDBConsts.DbSchema);
                b.Property(s => s.TenHinhThucChonNhaThau).HasMaxLength(255).IsRequired(true);
                b.ConfigureByConvention();
            });
            builder.Entity<LoaiKhoan>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "Loai_Khoans", DanhMucDBConsts.DbSchema);
                b.Property(s => s.TenLoaiKhoan).HasMaxLength(255).IsRequired(true);
                b.Property(s => s.GhiChu).HasMaxLength(500);
                b.Property(s => s.MaSo).HasMaxLength(255);
                b.ConfigureByConvention();
            });
            builder.Entity<ChuDauTu>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "ChuDauTus", DanhMucDBConsts.DbSchema);
                b.Property(s => s.MaSoChuong).HasMaxLength(10);
                b.Property(s => s.Ten).HasMaxLength(255).IsRequired(true);
                b.Property(s => s.DiaChi).HasMaxLength(255);
                b.Property(s => s.SoDienThoai).HasMaxLength(15);
                b.Property(s => s.Email).HasMaxLength(100);
                b.Property(s => s.GhiChu).HasMaxLength(500);
                b.Property(s => s.NguoiDaiDien).HasMaxLength(150);
                b.Property(s => s.SDTNguoiDaiDien).HasMaxLength(15);
                b.HasMany(s => s.PhongBans).WithOne();
                b.ConfigureByConvention();
            });

            builder.Entity<LoaiVanBan>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "LoaiVanBans", DanhMucDBConsts.DbSchema);
                b.Property(s => s.MaLoaiVanBan).HasMaxLength(10);
                b.Property(s => s.TenLoaiVanBan).HasMaxLength(255).IsRequired(true);
                b.Property(s => s.MoTa).HasMaxLength(500);
                b.HasMany(l => l.ThanhPhanHoSos).WithOne();
                b.ConfigureByConvention();
            });

            builder.Entity<ThanhPhanHoSo>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "ThanhPhanHoSos", DanhMucDBConsts.DbSchema);
                b.Property(s => s.TenThanhPhanHoSo).HasMaxLength(256).IsRequired(true);
                b.HasOne(t => t.LoaiVanBan).WithMany(l => l.ThanhPhanHoSos).HasForeignKey(t => t.LoaiVanBanId);
                b.ConfigureByConvention();
            });
            builder.Entity<NghiQuyet>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "NghiQuyets", DanhMucDBConsts.DbSchema);
                b.Property(s => s.SoVanBan).HasMaxLength(255).IsRequired(true);
                b.Property(s => s.TrichYeu).HasMaxLength(196).IsRequired(true);
                b.Property(s => s.IsTheoDoi).HasDefaultValue(1);
                b.ConfigureByConvention();
            });

            builder.Entity<ChuongTrinhMucTieuQuocGia>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "ChuongTrinhMucTieuQuocGias", DanhMucDBConsts.DbSchema);
                b.Property(s => s.MaChuongTrinhMucTieuQuocGia).HasMaxLength(10);
                b.Property(s => s.TenChuongTrinhMucTieuQuocGia).HasMaxLength(255).IsRequired(true);
                b.ConfigureByConvention();
            });

            builder.Entity<PhuongThucDauThau>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "PhuongThucDauThaus", DanhMucDBConsts.DbSchema);
                b.Property(s => s.TenPhuongThucDauThau).HasMaxLength(255).IsRequired(true);
                b.ConfigureByConvention();
            });

            builder.Entity<NguonVon>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "NguonVons", DanhMucDBConsts.DbSchema);
                b.Property(s => s.MaNguonVon).HasMaxLength(10);
                b.Property(s => s.TenNguonVon).HasMaxLength(255).IsRequired(true);
                b.Property(s => s.ThuTuHienThi).HasMaxLength(20);
                b.Property(s => s.OrderIndex).HasDefaultValue(-1);
                
                b.ConfigureByConvention();
            });

            builder.Entity<KhoanChi>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "KhoanChis", DanhMucDBConsts.DbSchema);
                b.Property(s => s.MaKhoanChi).HasMaxLength(10);
                b.Property(s => s.TenKhoanChi).HasMaxLength(255).IsRequired(true);
                b.Property(s => s.GhiChu).HasMaxLength(500);
                b.ConfigureByConvention();
            });

            builder.Entity<ChiPhiDauTu>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "ChiPhiDauTus", DanhMucDBConsts.DbSchema);
                b.Property(s => s.TenChiPhi).HasMaxLength(255).IsRequired(true);
                b.Property(s => s.LoaiChiPhi).HasMaxLength(255).IsRequired(true);
                b.ConfigureByConvention();
            });

            builder.Entity<ThuVienVanBan>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "ThuVienVanBans", DanhMucDBConsts.DbSchema);
                b.Property(s => s.SoKyHieu).HasMaxLength(50).IsRequired(true);
                b.Property(s => s.TrichYeu).HasMaxLength(500);
                b.HasOne(t => t.LoaiVanBan).WithMany(l => l.ThuVienVanBans).HasForeignKey(t => t.LoaiVanBanId);
                b.HasOne(t => t.LinhVucVanBan).WithMany(l => l.ThuVienVanBans).HasForeignKey(t => t.LinhVucVanBanId);
                b.ConfigureByConvention();
            });

            builder.Entity<FileCuaThuVienVanBan>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "FileCuaThuVienVanBans", DanhMucDBConsts.DbSchema);
                b.HasOne(t => t.ThuVienVanBan).WithMany(l => l.FileCuaThuVienVanBans).HasForeignKey(t => t.ThuVienVanBanId);
                b.ConfigureByConvention();
            });

            builder.Entity<PhongBan>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "PhongBans", DanhMucDBConsts.DbSchema);
                b.Property(p => p.MaPhongBan).HasMaxLength(10).IsRequired(true);
                b.Property(p => p.TenPhongBan).HasMaxLength(100).IsRequired(true);
                b.Property(p => p.ChucNangNhiemVu).HasMaxLength(255);
                b.Property(p => p.SoDienThoai).HasMaxLength(24);
                b.HasOne(p => p.ChuDauTu).WithMany(c => c.PhongBans).HasForeignKey(p => p.ChuDauTuId);
                b.ConfigureByConvention();
            });

            builder.Entity<CongTrinh>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "CongTrinhs", DanhMucDBConsts.DbSchema);
                b.Property(p => p.MaCongTrinh).HasMaxLength(10);
                b.Property(p => p.TenCongTrinh).HasMaxLength(500).IsRequired(true);
                b.Property(p => p.SoQuyetDinhDauTu).HasMaxLength(50);
                b.HasIndex(e => e.TenCongTrinh).IsUnique();
                b.ConfigureByConvention();
            });

            builder.Entity<DiaDiemXayDung>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "DiaDiemXayDungs", DanhMucDBConsts.DbSchema);
                b.HasKey(p => new { p.CongTrinhId, p.DonViHanhChinhId });
                b.Property(p => p.GhiChu).HasMaxLength(500);
                b.HasOne(pt => pt.CongTrinh).WithMany(p => p.DiaDiemXayDungs).HasForeignKey(pt => pt.CongTrinhId);
                b.HasOne(pt => pt.DonViHanhChinh).WithMany(p => p.DiaDiemXayDungs).HasForeignKey(pt => pt.DonViHanhChinhId);
            });

            builder.Entity<NghiQuyetCongTrinh>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "NghiQuyetCongTrinhs", DanhMucDBConsts.DbSchema);
                b.HasKey(p => new { p.CongTrinhId, p.NghiQuyetId });
                b.HasOne(pt => pt.CongTrinh).WithMany(p => p.NghiQuyetCongTrinhs).HasForeignKey(pt => pt.CongTrinhId);
                b.HasOne(pt => pt.NghiQuyet).WithMany(p => p.NghiQuyetCongTrinhs).HasForeignKey(pt => pt.NghiQuyetId);
            });

            builder.Entity<LoaiHoSo>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "LoaiHoSos", DanhMucDBConsts.DbSchema);
                b.Property(p => p.TenLoaiHoSo).HasMaxLength(500).IsRequired(true);
                b.ConfigureByConvention();
            });

            builder.Entity<LoaiHoSoChiPhiDauTu>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "LoaiHoSoChiPhiDauTus", DanhMucDBConsts.DbSchema);
                b.HasKey(p => new { p.LoaiHoSoId, p.ChiPhiDauTuId });
                b.HasOne(pt => pt.LoaiHoSo).WithMany(p => p.LoaiHoSoChiPhiDauTus).HasForeignKey(pt => pt.LoaiHoSoId);
                b.HasOne(pt => pt.ChiPhiDauTu).WithMany(p => p.LoaiHoSoChiPhiDauTus).HasForeignKey(pt => pt.ChiPhiDauTuId);
            });

            builder.Entity<LoaiHoSoCoSoPhapLy>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "LoaiHoSoCoSoPhapLys", DanhMucDBConsts.DbSchema);
                b.HasKey(p => new { p.LoaiHoSoId, p.ThuVienVanBanId });
                b.HasOne(pt => pt.LoaiHoSo).WithMany(p => p.LoaiHoSoCoSoPhapLys).HasForeignKey(pt => pt.LoaiHoSoId);
                b.HasOne(pt => pt.ThuVienVanBan).WithMany(p => p.LoaiHoSoCoSoPhapLys).HasForeignKey(pt => pt.ThuVienVanBanId);
            });

            builder.Entity<LoaiHoSoThanhPhanHoSo>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "LoaiHoSoThanhPhanHoSos", DanhMucDBConsts.DbSchema);
                b.HasKey(p => new { p.LoaiHoSoId, p.ThanhPhanHoSoId });
                b.HasOne(pt => pt.LoaiHoSo).WithMany(p => p.LoaiHoSoThanhPhanHoSos).HasForeignKey(pt => pt.LoaiHoSoId);
                b.HasOne(pt => pt.ThanhPhanHoSo).WithMany(p => p.LoaiHoSoThanhPhanHoSos).HasForeignKey(pt => pt.ThanhPhanHoSoId);
            });

            builder.Entity<NganhLinhVucSuDung>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "NganhLinhVucSuDungs", DanhMucDBConsts.DbSchema);
                b.ConfigureByConvention();
            });

            builder.Entity<DonViBanHanh>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "DonViBanHanhs", DanhMucDBConsts.DbSchema);
                b.Property(p => p.Ten).HasMaxLength(500).IsRequired(true);
                b.ConfigureByConvention();
            });

            builder.Entity<HinhThucLuaChonNhaThau>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "HinhThucLuaChonNhaThaus", DanhMucDBConsts.DbSchema);
                b.Property(p => p.TenHinhThuc).HasMaxLength(500).IsRequired(true);
                b.ConfigureByConvention();
            });

            builder.Entity<PhuongThucLuaChonNhaThau>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "PhuongThucLuaChonNhaThaus", DanhMucDBConsts.DbSchema);
                b.Property(p => p.TenPhuongThuc).HasMaxLength(500).IsRequired(true);
                b.ConfigureByConvention();
            });

            builder.Entity<GoiThau>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "GoiThaus", DanhMucDBConsts.DbSchema);
                b.Property(p => p.TenGoiThau).HasMaxLength(500).IsRequired(true);
                b.ConfigureByConvention();
            });

            builder.Entity<LoaiGoiThau>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "LoaiGoiThaus", DanhMucDBConsts.DbSchema);
                b.Property(p => p.TenLoaiGoiThau).HasMaxLength(500).IsRequired(true);
                b.ConfigureByConvention();
            });

            builder.Entity<CongViecGoiThau>(b =>
            {
                b.ToTable(DanhMucDBConsts.DbTablePrefix + "CongViecGoiThaus", DanhMucDBConsts.DbSchema);
                b.Property(p => p.TenCongViec).HasMaxLength(500).IsRequired(true);
                b.ConfigureByConvention();
            });
        }
    }
}