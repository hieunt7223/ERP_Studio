using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using xdcb.HoSoCongTrinh.Entities;

namespace xdcb.HoSoCongTrinh.EntityFrameworkCore
{
    public static class HoSoCongTrinhDbContextModelCreatingExtensions
    {
        public static void ConfigureHoSoCongTrinh(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */
            builder.Entity<Entities.HoSoCongTrinh>(b =>
            {
                b.ToTable(HoSoCongTrinhConsts.DbTablePrefix + "HoSoCongTrinhs", HoSoCongTrinhConsts.DbSchema);
                b.Property(p => p.ConcurrencyStamp).IsConcurrencyToken();
                b.Property(p => p.TrangThai).HasMaxLength(255).IsRequired(true);
                b.Property(p => p.SoLanDieuChinh).HasDefaultValue(0);
                b.ConfigureByConvention();
            });

            builder.Entity<HoSoCongTrinhChiTiet>(b =>
            {
                b.ToTable(HoSoCongTrinhConsts.DbTablePrefix + "HoSoCongTrinhChiTiets", HoSoCongTrinhConsts.DbSchema);
                b.Property(p => p.TrangThai).HasMaxLength(255).IsRequired(true);
                b.Property(p => p.SoLanDieuChinh).HasDefaultValue(0);
                b.HasOne(pt => pt.HoSoCongTrinh).WithMany(p => p.HoSoCongTrinhChiTiets).HasForeignKey(pt => pt.HoSoCongTrinhId);
                b.ConfigureByConvention();
            });

            builder.Entity<HoSoCongTrinhChiTietDiaDiem>(b =>
            {
                b.ToTable(HoSoCongTrinhConsts.DbTablePrefix + "HoSoCongTrinhChiTietDiaDiems", HoSoCongTrinhConsts.DbSchema);
                b.HasOne(pt => pt.HoSoCongTrinhChiTiet).WithMany(p => p.HoSoCongTrinhChiTietDiaDiems).HasForeignKey(pt => pt.HoSoCongTrinhChiTietId);
                b.ConfigureByConvention();
            });

            builder.Entity<HoSoCongTrinhChiTietMucDauTu>(b =>
            {
                b.ToTable(HoSoCongTrinhConsts.DbTablePrefix + "HoSoCongTrinhChiTietMucDauTus", HoSoCongTrinhConsts.DbSchema);
                b.HasOne(pt => pt.HoSoCongTrinhChiTiet).WithMany(p => p.HoSoCongTrinhChiTietMucDauTus).HasForeignKey(pt => pt.HoSoCongTrinhChiTietId);
                b.ConfigureByConvention();
            });

            builder.Entity<HoSoCongTrinhChiTietCoSoPhapLy>(b =>
            {
                b.ToTable(HoSoCongTrinhConsts.DbTablePrefix + "HoSoCongTrinhChiTietCoSoPhapLys", HoSoCongTrinhConsts.DbSchema);
                b.HasOne(pt => pt.HoSoCongTrinhChiTiet).WithMany(p => p.HoSoCongTrinhChiTietCoSoPhapLys).HasForeignKey(pt => pt.HoSoCongTrinhChiTietId);
                b.ConfigureByConvention();
            });

            builder.Entity<HoSoCongTrinhChiTietNguonVon>(b =>
            {
                b.ToTable(HoSoCongTrinhConsts.DbTablePrefix + "HoSoCongTrinhChiTietNguonVons", HoSoCongTrinhConsts.DbSchema);
                b.HasOne(pt => pt.HoSoCongTrinhChiTiet).WithMany(p => p.HoSoCongTrinhChiTietNguonVons).HasForeignKey(pt => pt.HoSoCongTrinhChiTietId);
                b.ConfigureByConvention();
            });

            builder.Entity<HoSoCongTrinhChiTietGoiThau>(b =>
            {
                b.ToTable(HoSoCongTrinhConsts.DbTablePrefix + "HoSoCongTrinhChiTietGoiThaus", HoSoCongTrinhConsts.DbSchema);
                b.HasOne(pt => pt.HoSoCongTrinhChiTiet).WithMany(p => p.HoSoCongTrinhChiTietGoiThaus).HasForeignKey(pt => pt.HoSoCongTrinhChiTietId);
                b.ConfigureByConvention();
            });

            builder.Entity<HoSoCongTrinhChiTietKetQuaThamDinh>(b =>
            {
                b.ToTable(HoSoCongTrinhConsts.DbTablePrefix + "HoSoCongTrinhChiTietKetQuaThamDinhs", HoSoCongTrinhConsts.DbSchema);
                b.HasOne(pt => pt.HoSoCongTrinhChiTiet).WithMany(p => p.HoSoCongTrinhChiTietKetQuaThamDinhs).HasForeignKey(pt => pt.HoSoCongTrinhChiTietId);
                b.ConfigureByConvention();
            });

            builder.Entity<HoSoCongTrinhChiTietNoiDungYeuCau>(b =>
            {
                b.ToTable(HoSoCongTrinhConsts.DbTablePrefix + "HoSoCongTrinhChiTietNoiDungYeuCaus", HoSoCongTrinhConsts.DbSchema);
                b.HasOne(pt => pt.HoSoCongTrinhChiTiet).WithMany(p => p.HoSoCongTrinhChiTietNoiDungYeuCaus).HasForeignKey(pt => pt.HoSoCongTrinhChiTietId);
                b.Property(p => p.NoiDung).IsRequired(true);
                b.ConfigureByConvention();
            });

            builder.Entity<HoSoCongTrinhChiTietThanhPhanHoSo>(b =>
            {
                b.ToTable(HoSoCongTrinhConsts.DbTablePrefix + "HoSoCongTrinhChiTietThanhPhanHoSos", HoSoCongTrinhConsts.DbSchema);
                b.HasOne(pt => pt.HoSoCongTrinhChiTiet).WithMany(p => p.HoSoCongTrinhChiTietThanhPhanHoSos).HasForeignKey(pt => pt.HoSoCongTrinhChiTietId);
                b.ConfigureByConvention();
            });

            builder.Entity<HoSoCongTrinhChiTietThanhPhanHoSoFile>(b =>
            {
                b.ToTable(HoSoCongTrinhConsts.DbTablePrefix + "HoSoCongTrinhChiTietThanhPhanHoSoFiles", HoSoCongTrinhConsts.DbSchema);
                b.HasOne(pt => pt.HoSoCongTrinhChiTietThanhPhanHoSo).WithMany(p => p.HoSoCongTrinhChiTietThanhPhanHoSoFiles).HasForeignKey(pt => pt.HoSoCongTrinhChiTietThanhPhanHoSoId);
                b.ConfigureByConvention();
            });

            builder.Entity<HoSoCongTrinhChiTietCongViec>(b =>
            {
                b.ToTable(HoSoCongTrinhConsts.DbTablePrefix + "HoSoCongTrinhChiTietCongViecs", HoSoCongTrinhConsts.DbSchema);
                b.HasOne(pt => pt.HoSoCongTrinhChiTiet).WithMany(p => p.HoSoCongTrinhChiTietCongViecs).HasForeignKey(pt => pt.HoSoCongTrinhChiTietId);
                b.ConfigureByConvention();
            });

            // view
            builder.Entity<vHoSoCongTrinh>(b =>
            {
                b.HasNoKey();
                b.ToView("vHoSoCongTrinhs", HoSoCongTrinhConsts.DbSchema);
            });

            builder.Entity<vHoSoCongTrinhChiTiet>(b =>
            {
                b.HasNoKey();
                b.ToView("vHoSoCongTrinhChiTiets", HoSoCongTrinhConsts.DbSchema);
            });
        }
    }
}