using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using xdcb.HoSoCongTrinh.Entities;

namespace xdcb.HoSoCongTrinh.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class HoSoCongTrinhDbContext : AbpDbContext<HoSoCongTrinhDbContext>
    {
        public DbSet<Entities.HoSoCongTrinh> HoSoCongTrinhs { get; set; }

        public DbSet<HoSoCongTrinhChiTiet> HoSoCongTrinhChiTiets { get; set; }

        public DbSet<HoSoCongTrinhChiTietDiaDiem> HoSoCongTrinhChiTietDiaDiems { get; set; }

        public DbSet<HoSoCongTrinhChiTietMucDauTu> HoSoCongTrinhChiTietMucDauTus { get; set; }

        public DbSet<HoSoCongTrinhChiTietCoSoPhapLy> HoSoCongTrinhChiTietCoSoPhapLys { get; set; }

        public DbSet<HoSoCongTrinhChiTietThanhPhanHoSo> HoSoCongTrinhChiTietThanhPhanHoSos { get; set; }

        public DbSet<HoSoCongTrinhChiTietThanhPhanHoSoFile> HoSoCongTrinhChiTietThanhPhanHoSoFiles { get; set; }

        public DbSet<HoSoCongTrinhChiTietNoiDungYeuCau> HoSoCongTrinhChiTietNoiDungYeuCaus { get; set; }

        public DbSet<HoSoCongTrinhChiTietGoiThau> HoSoCongTrinhChiTietGoiThaus { get; set; }

        public DbSet<HoSoCongTrinhChiTietKetQuaThamDinh> HoSoCongTrinhChiTietKetQuaThamDinhs { get; set; }

        public DbSet<HoSoCongTrinhChiTietNguonVon> HoSoCongTrinhChiTietNguonVons { get; set; }

        public DbSet<HoSoCongTrinhChiTietCongViec> HoSoCongTrinhChiTietCongViecs { get; set; }

        public DbSet<vHoSoCongTrinh> vHoSoCongTrinhs { get; set; }

        public DbSet<vHoSoCongTrinhChiTiet> vHoSoCongTrinhChiTiets { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside HoSoCongTrinhDbContextModelCreatingExtensions.ConfigureHoSoCongTrinh
         */

        public HoSoCongTrinhDbContext(DbContextOptions<HoSoCongTrinhDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /* Configure your own tables/entities inside the ConfigureHoSoCongTrinh method */
            builder.ConfigureHoSoCongTrinh();
        }
    }
}