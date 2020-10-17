using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
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
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See QuanLyVonMigrationsDbContext for migrations.
     */

    [ConnectionStringName("Default")]
    public class QuanLyVonDbContext : AbpDbContext<QuanLyVonDbContext>
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside QuanLyVonDbContextModelCreatingExtensions.ConfigureQuanLyVon
         */
        public QuanLyVonDbContext(DbContextOptions<QuanLyVonDbContext> options)
            : base(options)
        {
        }

        public DbSet<KeHoachTongNguon> KeHoachTongNguon { get; set; }
        public DbSet<KeHoachTongNguonChiTiet> KeHoachTongNguonChiTiet { get; set; }

        public DbSet<NhuCauKeHoachVon> NhuCauKeHoachVon { get; set; }
        public DbSet<NhuCauKeHoachVonChiTiet> NhuCauKeHoachVonChiTiet { get; set; }

        public DbSet<KeHoachVonNQ> KeHoachVonNQ { get; set; }
        public DbSet<KeHoachVonNQChiTiet> KeHoachVonNQChiTiet { get; set; }

        public DbSet<KeHoachVonNST> KeHoachVonNST { get; set; }
        public DbSet<KeHoachVonNSTChiTiet> KeHoachVonNSTChiTiet { get; set; }

        public DbSet<KeHoachVonNSTW> KeHoachVonNSTW { get; set; }
        public DbSet<KeHoachVonNSTWChiTiet> KeHoachVonNSTWChiTiet { get; set; }

        public DbSet<GiaiNgan> GiaiNgan { get; set; }
        public DbSet<GiaiNganChiTiet> GiaiNganChiTiet { get; set; }

        public DbSet<vKeHoachVon> vKeHoachVon { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /* Configure your own tables/entities inside the ConfigureQuanLyVon method */
            builder.ConfigureQuanLyVon();
        }
    }
}