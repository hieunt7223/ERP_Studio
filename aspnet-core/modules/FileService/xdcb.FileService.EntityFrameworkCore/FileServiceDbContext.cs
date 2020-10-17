using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using xdcb.FileService.DocumentStores;

namespace xdcb.FileService
{
    [ConnectionStringName("Default")]
    public class FileServiceDbContext : AbpDbContext<FileServiceDbContext>
    {
        //public DbSet<Book> Books { get; set; }
        public DbSet<DocumentStore> DocumentStores { get; set; }

        public FileServiceDbContext(DbContextOptions<FileServiceDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            /* Configure your own tables/entities inside the Configurexdcb method */

            builder.ConfigureFileService();
        }
    }
}