using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.FormServices.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See FormServicesDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */

    public class FormServicesMigrationsDbContext : AbpDbContext<FormServicesMigrationsDbContext>
    {
        public FormServicesMigrationsDbContext(DbContextOptions<FormServicesMigrationsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /* Configure your own tables/entities inside the ConfigureFormServices method */

            builder.ConfigureFormServices();
        }
    }
}