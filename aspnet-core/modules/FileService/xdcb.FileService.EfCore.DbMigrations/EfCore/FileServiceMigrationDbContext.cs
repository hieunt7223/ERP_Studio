using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.FileService.EntityFrameworkCore
{
    public class FileServiceMigrationDbContext : AbpDbContext<FileServiceMigrationDbContext>
    {
        public FileServiceMigrationDbContext(DbContextOptions<FileServiceMigrationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureFileService();

            base.OnModelCreating(builder);
        }
    }
}