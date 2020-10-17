using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.BookStore.EntityFrameworkCore
{
    public class BookStoreMigrationDbContext : AbpDbContext<BookStoreMigrationDbContext>
    {
        public BookStoreMigrationDbContext(DbContextOptions<BookStoreMigrationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureBookStore();

            base.OnModelCreating(builder);
        }
    }
}