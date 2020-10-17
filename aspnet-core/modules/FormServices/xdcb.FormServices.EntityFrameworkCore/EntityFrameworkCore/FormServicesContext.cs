using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using xdcb.FormServices.ConfigColumns;

namespace xdcb.FormServices.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See FormServicesMigrationsDbContext for migrations.
     */

    [ConnectionStringName("Default")]
    public class FormServicesDbContext : AbpDbContext<FormServicesDbContext>
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside FormServicesDbContextModelCreatingExtensions.ConfigureFormServices
         */
        public FormServicesDbContext(DbContextOptions<FormServicesDbContext> options)
            : base(options)
        {
        }

        public DbSet<ConfigColumn> ConfigColumns { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /* Configure your own tables/entities inside the ConfigureFormServices method */
            builder.ConfigureFormServices();
        }
    }
}