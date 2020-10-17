using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace xdcb.FileService.EfCore.DbMigrations
{
    public static class ModelExtensions
    {
        public static void ConfigureFileService(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            //builder.Entity<Book>(b =>
            //{
            //    b.ToTable(FileServiceConsts.DbTablePrefix + "Books", FileServiceConsts.DbSchema);
            //});
        }
    }
}