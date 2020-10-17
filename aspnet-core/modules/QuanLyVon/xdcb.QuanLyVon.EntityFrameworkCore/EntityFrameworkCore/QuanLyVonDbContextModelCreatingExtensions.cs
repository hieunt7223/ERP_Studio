using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using xdcb.QuanLyVon.GiaiNganChiTiets;
using xdcb.QuanLyVon.GiaiNgans;
using xdcb.QuanLyVon.KeHoachTongNguonChiTiets;
using xdcb.QuanLyVon.KeHoachTongNguons;
using xdcb.QuanLyVon.KeHoachVonNQChiTiets;
using xdcb.QuanLyVon.KeHoachVonNQs;
using xdcb.QuanLyVon.KeHoachVonNSTChiTiets;
using xdcb.QuanLyVon.KeHoachVonNSTs;
using xdcb.QuanLyVon.KeHoachVonNSTWChiTiets;
using xdcb.QuanLyVon.KeHoachVonNSTWs;
using xdcb.QuanLyVon.NhuCauKeHoachVonChiTiets;
using xdcb.QuanLyVon.NhuCauKeHoachVons;
using xdcb.QuanLyVon.vKeHoachVons;

namespace xdcb.QuanLyVon.EntityFrameworkCore
{
    public static class QuanLyVonDbContextModelCreatingExtensions
    {
        public static void ConfigureQuanLyVon(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<KeHoachTongNguon>(b =>
            {
                b.ToTable(QuanLyVonDBConsts.DbTablePrefix + "KeHoachTongNguons", QuanLyVonDBConsts.DbSchema);

                b.Property(s => s.Nam).IsRequired();

                b.Property(s => s.SoQuyetDinhDauNam).HasMaxLength(255);

                b.Property(s => s.SoQuyetDinhDieuChinh).HasMaxLength(255);

                b.Property(s => s.KeHoachDauNam).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachDauNamDuocDuyet).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachSauBoSung).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachSauBoSungDuocDuyet).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.TrangThaiDauNam).IsRequired().HasMaxLength(255).HasDefaultValue("");

                b.Property(s => s.TrangThaiDieuChinh).IsRequired().HasMaxLength(255).HasDefaultValue("");

                b.Property(s => s.DinhKemFileDauNam).HasMaxLength(500);

                b.Property(s => s.DinhKemFileDieuChinh).HasMaxLength(500);

                b.Property(s => s.GhiChuDauNam);

                b.Property(s => s.GhiChuDieuChinh);

                b.Property(s => s.IsDeleted).HasDefaultValue(false);

                b.ConfigureByConvention();
            });

            builder.Entity<KeHoachTongNguonChiTiet>(b =>
            {
                b.ToTable(QuanLyVonDBConsts.DbTablePrefix + "KeHoachTongNguonChiTiets", QuanLyVonDBConsts.DbSchema);

                b.Property(s => s.KeHoachTongNguonId).IsRequired();

                b.Property(s => s.NguonVonId).IsRequired();

                b.Property(s => s.NguonVonChaId).IsRequired();

                b.Property(s => s.TenNguonVon).HasMaxLength(255);

                b.Property(s => s.KeHoachDauNamTruoc).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachBoSungNamTruoc).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachDauNam).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachDauNamDuocDuyet).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.DieuChinhTang).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.DieuChinhGiam).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachBoSung).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachBoSungDuocDuyet).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.IsSelectDieuChinh).HasDefaultValue(false);

                b.Property(s => s.IsDeleteDieuChinh).HasDefaultValue(false);

                b.Property(s => s.IsDeleted).HasDefaultValue(false);
                b.ConfigureByConvention();
            });

            builder.Entity<NhuCauKeHoachVon>(b =>
            {
                b.ToTable(QuanLyVonDBConsts.DbTablePrefix + "NhuCauKeHoachVons", QuanLyVonDBConsts.DbSchema);

                b.Property(s => s.TuNam).IsRequired();

                b.Property(s => s.DenNam).IsRequired();

                b.Property(s => s.GiaiDoanNam).IsRequired();

                b.Property(s => s.ChuDauTuID).IsRequired();

                b.Property(s => s.TenKeHoach).HasMaxLength(255).HasDefaultValue("");

                b.Property(s => s.TrangThaiDauNam).HasMaxLength(255).HasDefaultValue("");

                b.Property(s => s.TrangThaiDieuChinh).HasMaxLength(255).HasDefaultValue("");

                b.Property(s => s.TongNhuCauVonDauNam).HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.TongNhuCauVonDieuChinh).HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.OrderIndex).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();

                b.Property(s => s.IsDeleted).HasDefaultValue(false);

                b.ConfigureByConvention();
            });

            builder.Entity<NhuCauKeHoachVonChiTiet>(b =>
            {
                b.ToTable(QuanLyVonDBConsts.DbTablePrefix + "NhuCauKeHoachVonChiTiets", QuanLyVonDBConsts.DbSchema);

                b.Property(s => s.NhuCauKeHoachVonID).IsRequired();

                b.Property(s => s.CongTrinhID).IsRequired();

                b.Property(s => s.LuyKeKhoiLuongNamTruocNST).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.LuyKeVonNamTruocNST).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.NhuCauVonDauNamNST).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.DieuChinhGiamNST).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.DieuChinhTangNST).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.NhuCauVonDieuChinhNST).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.IsSelectNST).HasDefaultValue(false);

                b.Property(s => s.LuyKeKhoiLuongNamTruocNSTW).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.LuyKeVonNamTruocNSTW).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.NhuCauVonDauNamNSTW).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.DieuChinhGiamNSTW).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.DieuChinhTangNSTW).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.NhuCauVonDieuChinhNSTW).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.IsSelectNSTW).HasDefaultValue(false);

                b.Property(s => s.LuyKeKhoiLuongNamTruocODA).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.LuyKeVonNamTruocODA).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.NhuCauVonDauNamODA).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.DieuChinhGiamODA).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.DieuChinhTangODA).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.NhuCauVonDieuChinhODA).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.IsSelectODA).HasDefaultValue(false);

                b.Property(s => s.IsSelectDieuChinh).HasDefaultValue(false);

                b.Property(s => s.IsDeleteDieuChinh).HasDefaultValue(false);

                b.Property(s => s.IsSelect).HasDefaultValue(false);

                b.Property(s => s.OrderIndex).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();

                b.Property(s => s.IsDeleted).HasDefaultValue(false);

                b.ConfigureByConvention();
            });

            builder.Entity<KeHoachVonNQ>(b =>
            {
                b.ToTable(QuanLyVonDBConsts.DbTablePrefix + "KeHoachVonNQs", QuanLyVonDBConsts.DbSchema);

                b.Property(s => s.Nam).IsRequired();

                b.Property(s => s.SoQuyetDinhDauNam).HasMaxLength(255);

                b.Property(s => s.SoQuyetDinhDieuChinh).HasMaxLength(255);

                b.Property(s => s.KeHoachVonDauNam).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDauNamDuocDuyet).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDieuChinh).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDieuChinhDuocDuyet).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.TrangThaiDauNam).IsRequired().HasMaxLength(255).HasDefaultValue("");

                b.Property(s => s.TrangThaiDieuChinh).IsRequired().HasMaxLength(255).HasDefaultValue("");

                b.Property(s => s.DinhKemFileDauNam).HasMaxLength(500);

                b.Property(s => s.DinhKemFileDieuChinh).HasMaxLength(500);

                b.Property(s => s.OrderIndex).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();

                b.Property(s => s.IsDeleted).HasDefaultValue(false);

                b.ConfigureByConvention();
            });

            builder.Entity<KeHoachVonNQChiTiet>(b =>
            {
                b.ToTable(QuanLyVonDBConsts.DbTablePrefix + "KeHoachVonNQChiTiets", QuanLyVonDBConsts.DbSchema);

                b.Property(s => s.KeHoachVonNQId).IsRequired();

                b.Property(s => s.CongTrinhId).IsRequired();

                b.Property(s => s.LuyKeVonTongCong).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.LuyKeVonNamTruoc).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDauNam).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDauNamDuocDuyet).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.DieuChinhTang).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.DieuChinhGiam).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDieuChinh).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDieuChinhDuocDuyet).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.IsSelectDieuChinh).HasDefaultValue(false);

                b.Property(s => s.IsDeleteDieuChinh).HasDefaultValue(false);

                b.Property(s => s.OrderIndex).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();

                b.Property(s => s.IsDeleted).HasDefaultValue(false);
                b.ConfigureByConvention();
            });

            builder.Entity<KeHoachVonNST>(b =>
            {
                b.ToTable(QuanLyVonDBConsts.DbTablePrefix + "KeHoachVonNSTs", QuanLyVonDBConsts.DbSchema);

                b.Property(s => s.Nam).IsRequired();

                b.Property(s => s.SoQuyetDinhDauNam).HasMaxLength(255);

                b.Property(s => s.SoQuyetDinhDieuChinh).HasMaxLength(255);

                b.Property(s => s.KeHoachVonDauNam).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDauNamDuocDuyet).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDieuChinh).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDieuChinhDuocDuyet).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.TrangThaiDauNam).IsRequired().HasMaxLength(255).HasDefaultValue("");

                b.Property(s => s.TrangThaiDieuChinh).IsRequired().HasMaxLength(255).HasDefaultValue("");

                b.Property(s => s.DinhKemFileDauNam).HasMaxLength(500);

                b.Property(s => s.DinhKemFileDieuChinh).HasMaxLength(500);

                b.Property(s => s.OrderIndex).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();

                b.Property(s => s.IsDeleted).HasDefaultValue(false);

                b.ConfigureByConvention();
            });

            builder.Entity<KeHoachVonNSTChiTiet>(b =>
            {
                b.ToTable(QuanLyVonDBConsts.DbTablePrefix + "KeHoachVonNSTChiTiets", QuanLyVonDBConsts.DbSchema);

                b.Property(s => s.KeHoachVonNSTId).IsRequired();

                b.Property(s => s.LuyKeVonTongCong).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.LuyKeVonNamTruoc).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDauNam).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDauNamDuocDuyet).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.DieuChinhTang).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.DieuChinhGiam).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDieuChinh).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDieuChinhDuocDuyet).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.NhuCauKeHoachVonDauNam).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.NhuCauKeHoachVonDieuChinh).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.IsSelectDieuChinh).HasDefaultValue(false);

                b.Property(s => s.IsDeleteDieuChinh).HasDefaultValue(false);

                b.Property(s => s.OrderIndex).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();

                b.Property(s => s.IsDeleted).HasDefaultValue(false);
                b.ConfigureByConvention();
            });

            builder.Entity<KeHoachVonNSTW>(b =>
            {
                b.ToTable(QuanLyVonDBConsts.DbTablePrefix + "KeHoachVonNSTWs", QuanLyVonDBConsts.DbSchema);

                b.Property(s => s.Nam).IsRequired();

                b.Property(s => s.SoQuyetDinhDauNam).HasMaxLength(255);

                b.Property(s => s.SoQuyetDinhDieuChinh).HasMaxLength(255);

                b.Property(s => s.KeHoachVonDauNam).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDauNamDuocDuyet).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDieuChinh).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDieuChinhDuocDuyet).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.TrangThaiDauNam).IsRequired().HasMaxLength(255).HasDefaultValue("");

                b.Property(s => s.TrangThaiDieuChinh).IsRequired().HasMaxLength(255).HasDefaultValue("");

                b.Property(s => s.DinhKemFileDauNam).HasMaxLength(500);

                b.Property(s => s.DinhKemFileDieuChinh).HasMaxLength(500);

                b.Property(s => s.OrderIndex).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();

                b.Property(s => s.IsDeleted).HasDefaultValue(false);

                b.ConfigureByConvention();
            });

            builder.Entity<KeHoachVonNSTWChiTiet>(b =>
            {
                b.ToTable(QuanLyVonDBConsts.DbTablePrefix + "KeHoachVonNSTWChiTiets", QuanLyVonDBConsts.DbSchema);

                b.Property(s => s.KeHoachVonNSTWId).IsRequired();

                b.Property(s => s.CongTrinhId).IsRequired();

                b.Property(s => s.LuyKeVonTongCong).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.LuyKeVonNamTruoc).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.NhuCauKeHoachVonDauNam).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.NhuCauKeHoachVonDieuChinh).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDauNam).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDauNamDuocDuyet).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.DieuChinhTang).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.DieuChinhGiam).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDieuChinh).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonDieuChinhDuocDuyet).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.IsSelectDieuChinh).HasDefaultValue(false);

                b.Property(s => s.IsDeleteDieuChinh).HasDefaultValue(false);

                b.Property(s => s.OrderIndex).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();

                b.Property(s => s.IsDeleted).HasDefaultValue(false);
                b.ConfigureByConvention();
            });

            builder.Entity<GiaiNgan>(b =>
            {
                b.ToTable(QuanLyVonDBConsts.DbTablePrefix + "GiaiNgans", QuanLyVonDBConsts.DbSchema);

                b.Property(s => s.Nam).IsRequired();

                b.Property(s => s.ChuDauTuId).IsRequired();

                b.Property(s => s.IsKeHoachKeoDai).HasDefaultValue(false);

                b.Property(s => s.TenKeHoach).HasMaxLength(255).HasDefaultValue("");

                b.Property(s => s.TrangThai).HasMaxLength(255).HasDefaultValue("");

                b.Property(s => s.TongGiaiNgan).HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.OrderIndex).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();

                b.Property(s => s.IsDeleted).HasDefaultValue(false);

                b.ConfigureByConvention();
            });

            builder.Entity<GiaiNganChiTiet>(b =>
            {
                b.ToTable(QuanLyVonDBConsts.DbTablePrefix + "GiaiNganChiTiets", QuanLyVonDBConsts.DbSchema);

                b.Property(s => s.GiaiNganId).IsRequired();

                b.Property(s => s.CongTrinhId).IsRequired();

                b.Property(s => s.LuyKeVonNamNayNST).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.LuyKeGiaiNganNamNayNST).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonNamTruocKeoDaiNST).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonNamNayNST).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KhoiLuongThucHienNamNayNST).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.GiaiNganNamNayNST).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.GiaiNganNamTruocKeoDaiNST).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.IsSelectNST).HasDefaultValue(false);

                b.Property(s => s.LuyKeVonNamNayNSTW).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.LuyKeGiaiNganNamNayNSTW).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonNamTruocKeoDaiNSTW).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonNamNayNSTW).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KhoiLuongThucHienNamNayNSTW).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.GiaiNganNamNayNSTW).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.GiaiNganNamTruocKeoDaiNSTW).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.IsSelectNSTW).HasDefaultValue(false);

                b.Property(s => s.LuyKeVonNamNayODA).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.LuyKeGiaiNganNamNayODA).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonNamTruocKeoDaiODA).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KeHoachVonNamNayODA).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.KhoiLuongThucHienNamNayODA).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.GiaiNganNamNayODA).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.GiaiNganNamTruocKeoDaiODA).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,6)");

                b.Property(s => s.IsSelectODA).HasDefaultValue(false);

                b.Property(s => s.IsSelectDieuChinh).HasDefaultValue(false);

                b.Property(s => s.IsDeleteDieuChinh).HasDefaultValue(false);

                b.Property(s => s.OrderIndex).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();

                b.Property(s => s.IsDeleted).HasDefaultValue(false);

                b.ConfigureByConvention();
            });

            builder.Entity<vKeHoachVon>(b =>
            {
                b.HasNoKey();
                b.ToView("vKeHoachVons", QuanLyVonDBConsts.DbSchema);
            });
        }
    }
}